using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{

    public class AppSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string IDPrefix { get; set; }
        public string NameOfOrganization { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; } 
        public string Location { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }
        [DataType(DataType.Url)]
        public string SMSurl { get; set; }
       public string SMSfrom { get; set; }
       public  string SMSusername { get; set; }
        [DataType(DataType.Password)]
       public  string SMSpassword { get; set; }
        public  string SMSto { get; set; }
        public string SMSText { get; set; }
    }
}
