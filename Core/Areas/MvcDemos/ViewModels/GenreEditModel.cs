using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using MvcDemos.Validators;

namespace MvcDemos.ViewModels
{
    [Validator(typeof(GenreValidator))]
    public class GenreEditModel
    {
        [ScaffoldColumn(false)]
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}