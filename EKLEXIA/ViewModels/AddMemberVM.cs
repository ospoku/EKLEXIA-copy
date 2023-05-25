using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKLEXIA.ViewModels
{
    public class AddMemberVM
    {
        public string Surname { get; set; }
        public string Othername { get; set; }


        public string GroupId { get; set; }
        public SelectList Groups { get; set; }
        public SelectList Genders { get; set; }

        [DataType(DataType.Text)]


        public string Fullname { get { return Surname + "  " + Othername; } }

        public string BranchId { get; set; }
        public SelectList Branches { get; set; }
        public string GenderId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }
        public string CareerId { get; set; }
        public SelectList Careers { get; set; }
        public string MaritalStatusId { get; set; }
        public SelectList MaritalStatuses { get; set; }
        public SelectList Regions { get; set; }
        [FileExtensions(Extensions = "jpg,jpeg,png")]
        public IFormFile UploadPhoto { get; set; }
        public string Hometown { get; set; }
        public string Residence { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        public string Address { get; set; }
        [DataType(DataType.Text)]
        public string RegionId { get; set; }

        [DataType(DataType.Date)]
        public DateTime PrintedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}
