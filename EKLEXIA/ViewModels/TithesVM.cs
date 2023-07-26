using EKLEXIA.Models;
using System;

namespace EKLEXIA.ViewModels
{
    public class TithesVM
    {
        public string TitheId { get; set; }
        public Month Month { get;set; }
        public string MonthId { get; set; }
        public string MemberId { get; set; }
        public Member Member { get; set; }  

        public DateTime Date { get; set; }

        public double Amount { get; set; }
        public string Description { get; set; }




    }
}
