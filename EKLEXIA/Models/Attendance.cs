using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{
    public class Attendance : TableAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AttendanceId { get; set; } 

        public string MeetingId { get; set; }
        [ForeignKey(nameof(MeetingId))]
        public Meeting Meeting { get; set; }
       
        public string MemberId { get; set; } 
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }
        public bool IsPresent { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
