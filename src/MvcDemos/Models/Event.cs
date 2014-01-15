using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MvcDemos.Models
{
	public class WeeklyEvent
	{
		public string Title { get; set; }
		public WeekDay Day { get; set; }
		public WeekDay? AnotherDay { get; set; }
	}
}