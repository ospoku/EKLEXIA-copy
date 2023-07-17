using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{
    public class Member : TableAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MemberId { get; set; }
        [DataType(DataType.Text)]
        public string Surname { get; set; } = string.Empty;
        [DataType(DataType.Text)]
        public string Othername { get; set; } = string.Empty;
        public string Fullname { get { return Surname + "  " + Othername; } }
        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; } = new Branch();
      
        public string BranchId { get; set; } = string.Empty;

        public byte[] Photo { get; set; } = Array.Empty<byte>();
        
        public Career Career { get; set; } 
        public string CareerId { get; set; } = string.Empty;
        [ForeignKey(nameof(GenderId))]
        public Gender Gender { get; set; }
        
        public string GenderId { get; set; } = string.Empty;
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



        public string IDNumber { get; set; } = string.Empty;

        public string Hometown { get; set; } = string.Empty;



        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }= string.Empty;

        public string Address { get; set; } = string.Empty;
    
        public Region Region { get; set; } 
        [DataType(DataType.Text)]
        public string RegionId { get; set; }=string.Empty;
     
 
    }
}
