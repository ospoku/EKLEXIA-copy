﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKLEXIA.Models
{
    public class Gender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  string Id { get; set; } 
        public string Name { get; set; }= string.Empty;
    }
}
