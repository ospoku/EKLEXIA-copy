using System;
using EKLEXIA.Models;

namespace EKLEXIA.ViewModels
{
    public class ViewCardListVM
    {
        public string Fullname { get; set; }



        public string ClinicNumber { get; set; }
        public string Insurance { get; set; }

        public int Age { get; set; }
        public string Address { get; set; }

        public DateTime DateofBirth { get; set; }
        public string GenderId { get; set; }
        public Gender Gender { get; set; }
        public string Telephone { get; set; }



        public string MemberId { get; set; }

    }
}
