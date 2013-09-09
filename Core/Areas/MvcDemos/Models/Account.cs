using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemos.Models
{
    public class Account
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Username { get; set; }

    }
}