using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{
    public class MemberGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MemberGroupId { get; set; }
        public Group Group {get;set;}
        public string GroupId { get; set; }
    public string MemberId { get; set; }
    }
}
