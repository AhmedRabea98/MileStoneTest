using Microsoft.EntityFrameworkCore;
using MileStone.Context;
using MileStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MileStone.Services.SectorsServices
{
    public class SectorsService : ISectorsService
    {
        private readonly DBContext context;
        public SectorsService(DBContext context)
        {
            this.context = context; 
        }
        public Sector AddSector(Sector sector)
        {
            if (sector == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Sectors.Add(sector);
                context.SaveChanges();
            }
            return sector;
        }

        public void DeleteSector(Guid Id)
        {
            Sector sector = context.Sectors.FirstOrDefault(e => e.SectorId == Id);
            if (sector == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Sectors.Remove(sector);
                context.SaveChanges();
            }
        }

        public Sector GetSector(Guid Id)
        {
            Sector sector = context.Sectors.Include(e=>e.BusinessCases).Include(e=>e.ProjectCharter).Include(e=>e.ProjectManagementPlan).FirstOrDefault(s=>s.SectorId == Id);
            if (sector == null)
            {
                throw new NotImplementedException();

            }
            else
            {
                return sector;
            }
        }

        public List<Sector> GetSectors()
        {
            List<Sector> sectors = new List<Sector>();
            sectors = context.Sectors.Include(e=>e.BusinessCases).Include(e=>e.ProjectCharter).Include(e=>e.ProjectManagementPlan).ToList();
            return sectors;
        }

        public Sector UpdateSector(Guid Id, Sector sector)
        {
            if (Id != sector.SectorId)
            {
                throw new NotImplementedException();

            }
            else
            {
                context.Entry(sector).State = EntityState.Modified;
                context.SaveChanges();
                return sector;
            }
        }
    }
}
