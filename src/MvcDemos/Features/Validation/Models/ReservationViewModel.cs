using System;
using System.ComponentModel.DataAnnotations;

namespace MvcDemos.Validation.Models
{
    public class ReservationViewModel
    {
        public DateTime Date { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}