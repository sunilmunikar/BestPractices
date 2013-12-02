using System;
using FluentValidation.Attributes;
using MvcDemos.Validators;
using System.ComponentModel.DataAnnotations;

namespace MvcDemos.ViewModels
{
    [Validator(typeof(GenreValidator))]
    public class GenreEditModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Property1 { get; set; }
        public string MustNotBeEqualsToProperty1 { get; set; }

        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateToCompareAgainst { get; set; }

        public bool UseCustomSlug { get; set; }

        [RequiredIfTrue(BooleanPropertyName = "UseCustomSlug", ErrorMessage = "Please provide a custom slug if you opt for one.")]
        public string CustomSlug { get; set; }
    }
}