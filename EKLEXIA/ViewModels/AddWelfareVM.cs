using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace EKLEXIA.ViewModels
{
    public class AddWelfareVM
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string MonthId { get; set; }
        public SelectList Months { get; set; }
        public string IncomeId { get; set; }
        public decimal Amount { get; set; }
        public string MemberId { get; set; }
        public SelectList Members { get; set; }


    }
}
