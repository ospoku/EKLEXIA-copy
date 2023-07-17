﻿using System;

namespace EKLEXIA.Models
{
    public class TableAudit
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
