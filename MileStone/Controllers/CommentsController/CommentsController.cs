using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using MileStone.Services.CommentServices;

namespace MileStone.Controllers.CommentsController
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly DBContext _context;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // GET: api/Comments
        [HttpGet]
        public ActionResult<IEnumerable<Comments>> GetComments()
        {
            return commentService.GetComments();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public ActionResult<Comments> GetComment(Guid id)
        {
            try
            {
                return commentService.GetComment(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public Comments PutComments(Guid id, Comments comments)
        {
            try
            {
                return commentService.UpdateComment(id , comments);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Comments> PostComments(Comments comments)
        {
            try
            {
                return commentService.AddComment(comments);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public void DeleteComments(Guid id)
        {
            try
            {
                 commentService.DeleteComment(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
