using EKLEXIA.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EKLEXIA.Models
{
    public class Member:TableAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MemberId { get; set; }
        [DataType(DataType.Text)]
        public  string Surname { get; set; }
        [DataType(DataType.Text)]
        public  string Othername { get; set; }
        public string Fullname { get { return Surname + "  " + Othername; } }
        [ForeignKey("BranchId")]
        public  Branch Branch { get; set; }
      
        public  string BranchId { get; set; }
       
        public  byte[] Photo { get; set; }
        public  Career Career { get; set; }
        public  string CareerId { get; set; }
        public  Gender Gender { get; set; }
        
        public  string GenderId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        public int Age
        {
            get
            {
                return (DateTime.Today.Date - DoB).Days
                    / 365;
            }
        }



        public string IDNumber { get; set; }




        public string Hometown { get; set; }



        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        public string Address { get; set; }
        public Region Region { get; set; }
        [DataType(DataType.Text)]
        public string RegionId { get; set; }

   
    }
}
