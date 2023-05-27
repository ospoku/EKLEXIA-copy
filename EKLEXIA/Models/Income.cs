using System;

namespace EKLEXIA.Models
{
    public class Income
    {
        public static object DoB { get;  set; }
        public object Address { get;  set; }
        public object Description { get; set; }
        public object Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public object Amount { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IncomeId { get; internal set; }
    }
}
