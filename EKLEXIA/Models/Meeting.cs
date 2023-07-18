using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{
    public class Meeting : TableAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MeetingId { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }=string.Empty;
        public Attendance Attendance { get; set; }

        public string  AttendanceId { get; set;}=string.Empty;
    }
}
