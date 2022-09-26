using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.AttachmentServices
{
    public interface IAttachmentService
    {
        List<Attachment> GetAttachments();

        Attachment UpdateAttachment(Guid id , Attachment attachment);

        Attachment GetAttachmentDetails(Guid id);

        /*    JsonResult AddAttachment(HttpRequest httpRequest,string id, string entity);*/
        JsonResult AddAttachment(List<IFormFile> formFile, string id, string entity);
        /*        JsonResult AddAttachment(IFormFile formFile, string id, string entity);*/
/*        JsonResult AddAttachment(List<IFormFile> files);*/

        void DeleteAttachment(Guid guid);
        List<Attachment> GetItemAttachments(Guid id);

    }
}
