using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace EKLEXIA.ViewModels
{
    public class EditMemberVM
    {
        public string Surname { get; set; }
        public string Othername { get; set; }






        public SelectList Genders { get; set; }
        public string GenderId { get; set; }

        public DateTime DoB { get; set; }
        public string Hometown { get; set; }


        public string RegionId { get; set; }


        public SelectList Regions { get; set; }



        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
