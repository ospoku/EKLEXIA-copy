using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKLEXIA.Models
{
    public class Tithe: TableAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TitheId { get; set; }
        public string MemberId { get; set; }
        public Member Member { get; set; }
        public string MonthId { get; set; }
        [ForeignKey("MonthId")]
        public Month Month { get; set; }
        public DateTime TitheDate { get; set; }
   
        public double Amount { get; set; }

        public string Description { get; set; }
     
    }
}
