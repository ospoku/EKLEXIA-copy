using EKLEXIA.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace EKLEXIA.ViewModels
{
    public class AddAttendanceVM
    {
        public SelectList Meetings { get; set; } 

       public string MeetingId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPresent { get; set; }
        public DateTime Date { get; set; }
        public List<SelectListItem> Members { get; set; }=new List<SelectListItem>();
        public string MemberId { get; set; } = string.Empty;
    }

 
}
