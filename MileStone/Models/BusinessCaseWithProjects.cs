using System;

namespace MileStone.Models
{
    public class BusinessCaseWithProjects
    {
        public Guid ProjectID { get; set; }
        public Project Project { get; set; }
        public Guid BusienssCaseID { get; set; }
        public BusinessCase BusinessCase { get; set; }
    }
}
