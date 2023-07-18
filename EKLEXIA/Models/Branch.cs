using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{
    public class Branch : TableAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BranchId { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; }=string.Empty;
    }
}