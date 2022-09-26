using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.CommentServices
{
    public interface ICommentService
    {
        public List<Comments> GetComments();
        public Comments GetComment(Guid Id);
        public Comments AddComment(Comments comment);
        public Comments UpdateComment(Guid Id, Comments comment);
        public void DeleteComment(Guid Id);
    }
}
