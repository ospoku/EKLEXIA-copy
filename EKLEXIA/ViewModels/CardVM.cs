
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKLEXIA.Models;

namespace EKLEXIA.ViewModels
{
    public class CardVM
    {
        public string MemberId { get; set; }
        public string Fullname { get; set; }

        public string GenderId { get; set; }
        public Gender Gender { get; set; }
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public byte Photo { get; set; }

        public DateTime PrintDate { get; set; }





    }
}
