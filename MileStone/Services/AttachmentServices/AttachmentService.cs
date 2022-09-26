using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MileStone.Services.AttachmentServices
{
    public class AttachmentService : IAttachmentService
    {
        private readonly DBContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment env;

        public AttachmentService(DBContext context, IHttpContextAccessor httpContextAccessor , IWebHostEnvironment env)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.env = env;
        }
        /*public JsonResult AddAttachment(IFormFile formFile, string id, string entity)
        {
            *//*var req = httpRequest.Form;*/
            /*  var files = req.Files;*//*
            var files = formFile;
            if (files != null)
            {
              *//*  foreach (var file in files)
                {*//*
                    Attachment attachment = new Attachment();
                    var guid = Guid.NewGuid();
                    var physicalpath = env.ContentRootPath + "/Attachment/" + guid.ToString();
                    attachment.FileName = files.Name;
                    attachment.PhysicalPath = physicalpath;
          *//*          attachment.RelatedItemType = entity;
                    attachment.RelatedItemUID = Guid.Parse(id);*//*
                    Stream st = files.OpenReadStream();
                    BinaryReader br = new BinaryReader(st);
                    Byte[] bytes = br.ReadBytes((Int32)st.Length);
                    if(attachment.AttachmentUID == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    {
                        context.Attachment.Add(attachment);
                        context.SaveChanges();
                    }
                }
            //}
            return new JsonResult("Success");

        }*/




        public void DeleteAttachment(Guid guid)
        {
            var attachment = context.Attachment.FirstOrDefault(e => e.AttachmentUID == guid);
            if (attachment != null)
            {
                context.Attachment.Remove(attachment);
                context.SaveChanges();
            }
            else
            {
                throw new Exception();

            }
        }

        public Attachment GetAttachmentDetails(Guid id)
        {
            var attachment = context.Attachment.FirstOrDefault(e => e.AttachmentUID == id);
             if( attachment != null)
            {
                attachment.Document = null;
                attachment.PhysicalPath = "Not Allowed";
                return attachment;
            }
            else
            {
                throw new NotImplementedException();

            }
        }

        public List<Attachment> GetAttachments()
        {
            List<Attachment> attachments = context.Attachment.ToList();
            foreach(var attachment in attachments)
            {
                attachment.PhysicalPath = "Not Allowed";
                attachment.Document = null;
            }
            return context.Attachment.ToList();
        }

        public Attachment UpdateAttachment(Guid id, Attachment attachment)
        {
            if (id != attachment.AttachmentUID)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(attachment).State = EntityState.Modified;
                context.SaveChanges();
                return attachment;
            }
        }

        public List<Attachment> GetItemAttachments(Guid id)
        {

            var ath = context.Attachment.Where(t => t.RelatedItemUID == id);
            return ath.ToList();
        }

        public JsonResult AddAttachment(List<IFormFile> files, string id, string entity)
        {
            if (files != null)
            {
                foreach (var file in files)
                {

                    Attachment attachment = new Attachment();
                    var guid = Guid.NewGuid();
                    var physicalpath = env.ContentRootPath + "/Attachment/" + guid.ToString();
                    attachment.FileName = file.FileName;
                    attachment.PhysicalPath = physicalpath;
                    attachment.RelatedItemUID = Guid.Parse(id);
                    attachment.RelatedItemType = entity;
                    Stream fs = file.OpenReadStream();
                    BinaryReader br = new BinaryReader(fs);
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    attachment.Document = bytes;
                    if (attachment.AttachmentUID == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    {
                        context.Attachment.Add(attachment);
                        context.SaveChanges();
                    }
                }
                return new JsonResult("Added");
            }
            else
            {
                return new JsonResult("failed");
            }
            }
    }
}
