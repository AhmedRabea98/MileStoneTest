using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileStone.Models
{
    public class ProjectCashFlow
    {
        [Key]
        public Guid ProjectCashFlowId { get; set; }
        public int Year { get; set; }
        public decimal Value { get; set; }
        public Guid? BusinessCaseId { get; set; }

        [ForeignKey("BusinessCaseId")]
        public virtual BusinessCase BusinessCase { get; set; }
    }
}
