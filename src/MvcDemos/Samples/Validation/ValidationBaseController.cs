using System;
using System.Collections.Generic;
using AutoMapper;
using Core.Entities;
using Core.Services;
using MvcDemos.ViewModels;
using System.Web.Mvc;
using FluentValidation;
using MvcDemos.Samples.Validation;

namespace MvcDemos.Samples
{
    public abstract class ValidationBaseController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            return new FluentValidationExceptionHandlingActionInvoker();
        }
    }
}
