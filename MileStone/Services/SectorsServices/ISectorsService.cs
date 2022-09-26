using MileStone.Models;
using System;
using System.Collections.Generic;

namespace MileStone.Services.SectorsServices
{
    public interface ISectorsService
    {
        public List<Sector> GetSectors();
        public Sector GetSector(Guid Id);
        public Sector AddSector(Sector sector);

        public Sector UpdateSector (Guid Id,Sector sector);
        public void DeleteSector(Guid Id);
    }
}
