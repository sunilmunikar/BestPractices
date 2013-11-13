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
    }
}