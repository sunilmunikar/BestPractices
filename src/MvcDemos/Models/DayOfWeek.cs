using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MvcDemos.Helpers;
using MvcDemos.Resources;

namespace MvcDemos.Models
{
	[LocalizationEnum(typeof(Translations))]
	public enum WeekDay
	{
		Sunday,
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday
	}


	#region without [LocalizationEnum]

	//public enum WeekDay
	//{
	//    Sunday,
	//    Monday,
	//    Tuesday,
	//    Wednesday,
	//    Thursday,
	//    Friday,
	//    Saturday
	//}

	#endregion

	#region No localization, using [Description] attribute

	//public enum WeekDay
	//{
	//    [Description("Domingo")]
	//    Sunday,

	//    [Description("Segunda")]
	//    Monday,

	//    [Description("Terça")]
	//    Tuesday,

	//    [Description("Quarta")]
	//    Wednesday,

	//    [Description("Quinta")]
	//    Thursday,

	//    [Description("Sexta")]
	//    Friday,

	//    [Description("Sábado")]
	//    Saturday
	//}

	#endregion
}