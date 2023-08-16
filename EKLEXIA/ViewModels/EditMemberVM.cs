using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace EKLEXIA.ViewModels
{
    public class EditMemberVM
    {
        public string Surname { get; set; }
        public string Othername { get; set; }



        public SelectList Careers { get; set; }
        public string CareerId { get; set; }

        public SelectList Branches { get; set; }
        public string BranchId { get; set; }
        public SelectList Genders { get; set; }
        public string GenderId { get; set; }

        public DateTime DoB { get; set; }
        public string Residence { get; set; }


        public string RegionId { get; set; }


        public SelectList Regions { get; set; }

        public SelectList MaritalStatuses { get; set; }
        public string MaritalStatusId { get; set; }

        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
