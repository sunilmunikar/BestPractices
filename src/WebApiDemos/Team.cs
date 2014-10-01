using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiDemos
{
    public class Team
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(6)]
        public string League { get; set; }
    }
}