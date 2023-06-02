using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKLEXIA.ViewModels
{
    public class AddMeetingVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        

    }
}
