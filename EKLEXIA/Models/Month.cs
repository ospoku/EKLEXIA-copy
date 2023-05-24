using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKKLESIA.Models
{
    public class Month
    {
        [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MonthId { get; set; }
        public string Name { get; set; }
    }
}
