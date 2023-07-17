using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{
    public class Attendance : TableAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } 

        public string MeetingId { get; set; } = string.Empty;
        [ForeignKey(nameof(MeetingId))]
        public Meeting Meeting { get; set; }= new Meeting();
        [ForeignKey(nameof(MemberId))]
        public string MemberId { get; set; } = string.Empty;

        public Member Member { get; set; }=new Member();
        public bool IsPresent { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
