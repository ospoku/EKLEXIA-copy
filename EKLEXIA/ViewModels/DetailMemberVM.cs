
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKKLESIA.Models;

namespace EKLEXIA.ViewModels
{
    public class DetailMemberVM
    {
        public string Surname { get; set; }
        public string Othername { get; set; }



        public string GenderId { get; set; }


        public Gender Gender { get; set; }


        public DateTime DoB { get; set; }







        public string Telephone1 { get; set; }

        public string Insurance { get; set; }


        public string Address { get; set; }






        public string ClinicNumber { get; set; }
        public string Telephone { get; internal set; }
    }
}
