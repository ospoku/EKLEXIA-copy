using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKLEXIA.Models
{
    public class Tithe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TitheId { get; set; }
        public string MemberId { get; set; }
        public string Month { get; set; }
        public DateTime TitheDate { get; set; }
        public bool IsDeleted { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
