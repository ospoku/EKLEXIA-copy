using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{
    public class Income:TableAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public string Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
      
        public double Amount { get; set; }
        public string IncomeId { get; internal set; } = string.Empty;
    }
}
