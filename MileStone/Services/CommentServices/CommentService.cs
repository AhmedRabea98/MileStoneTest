using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly DBContext context;
        public CommentService(DBContext context)
        {
            this.context = context;
        }
        public Comments AddComment(Comments comment)
        {
            if(comment == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Comments.Add(comment);
                context.SaveChanges();
                return comment; 
            }
        }

        public void DeleteComment(Guid Id)
        {
            var comment= context.Comments.FirstOrDefault(e => e.CommentsId == Id);
            if (comment == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Comments.Remove(comment);
                context.SaveChanges();
            }
        }

        public Comments GetComment(Guid Id)
        {
            var comment = context.Comments.FirstOrDefault(e => e.CommentsId == Id);
            if (comment == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return comment;
            }
        }

        public List<Comments> GetComments()
        {
           return context.Comments.ToList();
        }

        public Comments UpdateComment(Guid Id, Comments comment)
        {
            if (Id != comment.CommentsId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(comment).State = EntityState.Modified;
                context.SaveChanges();
                return comment;
            }
        }
    }
}
