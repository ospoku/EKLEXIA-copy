using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{
    public class Attendance:TableAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ?Id { get;set; }
        public Meeting ?MeetingId { get; set; }
        public Member ?MemberId { get; set; }
        public Group? GroupId { get; set; }
        public bool? IsPresent { get; set; }
        public DateTime? Date { get; set; }
        public string ?Description { get; set; }
    }
}
