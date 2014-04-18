using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemos.Models
{
    public enum MovieGenre
    {
        [Display(ResourceType = typeof(Resources.Translations), Name = "Action")]
        Action,

        [Display(Name = "Drama!")]
        Drama,

        Adventure,

        Fantasy,

        Boring
    }
}