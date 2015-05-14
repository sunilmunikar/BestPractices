using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebApiDemos.Controllers
{
    public class User
    {
        public int Age { get; set; }

        public DateTime Birthdate { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime ConvertedUsingAttribute { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string IgnoreProperty { get; set; }

        public int Salary { get; set; }

        public string Username { get; set; }

        public Uri Website { get; set; }
    }
}
