﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{
    public class SMSTask : TableAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public string  SMSTaskId { get; set; }
        public string MemberId { get; set; }
        public string Telephone { get; set; }
        public bool IsSent { get; set; }
    }
}
