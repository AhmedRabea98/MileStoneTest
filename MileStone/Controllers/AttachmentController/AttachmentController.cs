using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using MileStone.Services.AttachmentServices;
using System;
using System.Collections.Generic;

namespace MileStone.Controllers.AttachmentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService attachmentService;

        public AttachmentController(IAttachmentService attachmentService)
        {
            this.attachmentService = attachmentService;
        }

        [HttpGet]
        public IEnumerable<Attachment> Get()
        {
            try
            {
                //throw new System.Exception("An error occurred");

                return attachmentService.GetAttachments();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

       /* [Route("GetAllAttachments/{id}")]
        [HttpGet]
        public IEnumerable<Attachment> GetItemAttachments([FromRoute] string id)
        {
            try
            {
                //throw new System.Exception("An error occurred");
                return attachmentService.GetItemAttachments(Guid.Parse(id));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }*/
        [Route("AddAttachment")]
        [HttpPost]
        public JsonResult AddAttachment(List<IFormFile> formFile , string id , string entity)
        {
            try
            {

                /*HttpRequest httpRequest = Request;*/
                return attachmentService.AddAttachment(formFile , id , entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public Attachment GetAttachmentDetails(string id)
        {
            try
            {
                return attachmentService.GetAttachmentDetails(new Guid(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public void DeleteAttachment([FromRoute] string id)
        {
            try
            {
                var data = attachmentService.GetAttachmentDetails(new Guid(id));

                if (data != null)
                {
                    attachmentService.DeleteAttachment(new Guid(id));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public Attachment PutAttachment(Guid id, Attachment attachment)
        {
            try
            {
                return attachmentService.UpdateAttachment(id, attachment);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
