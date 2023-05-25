using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKLEXIA.ViewModels
{
    public class AddTitheVM
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string MemberId { get; set; }
        public string MonthId { get; set; }
        public string TitheId { get; set; }
        public SelectList Months { get; set; }
        public SelectList Members { get; set; }
        public decimal Amount { get; set; }


    }
}
