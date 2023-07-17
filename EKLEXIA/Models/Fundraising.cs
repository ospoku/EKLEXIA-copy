using System.ComponentModel.DataAnnotations;

namespace EKLEXIA.Models
{
    public class Fundraising
    {
        public Fundraising()
        
        { 
        
        }
        [Key]
        public string Id { get; set; }
        public string FundraisingId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
    }
}
