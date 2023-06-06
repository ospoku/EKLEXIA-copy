using EKLEXIA.Models;

namespace EKLEXIA.ViewModels
{
    public class MembersVM
    {
        public string Fullname { get; set; }


        public Region Region { get; set; }
        public string RegionId { get; set; }
        public string Hometown { get; set; }

        public int Age { get; set; }
        public string Address { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateofBirth { get; set; }
        public string GenderId { get; set; }
        public string CareerId { get; set; }
        public string Telephone { get; set; }

        public byte[] Photo { get; set; }

        public string MemberId { get; set; }

    }
}
