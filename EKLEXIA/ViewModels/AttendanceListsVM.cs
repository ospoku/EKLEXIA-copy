using System;
using EKLEXIA.Models;

namespace EKLEXIA.ViewModels
{
    public class AttendanceListsVM
    {
        public string Fullname { get; set; }
        public string Meeting { get; set; }
        public DateTime Date { get; set; }
        public bool IsSelected { get; set; }
       public string AttendanceId { get; set; }
        public string Comment { get; set; }
     

    }
}
