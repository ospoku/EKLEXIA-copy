using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKKLESIA.Models
{
    public class Welfare
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string WelfareId { get; set; }
        public string MemberId { get; set; }
        public string Month { get; set; }
        public DateTime WelfareDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
