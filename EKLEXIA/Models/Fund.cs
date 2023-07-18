using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{
    public class Fund : TableAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string FundId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
