using System.Diagnostics;
using Core.Entities;
using Core.Services;
using FakeItEasy;
using FluentAssertions;
using MvcDemos.ApiControllers;
using Xunit;
using WebApiDemos.Controllers;
using WebApiDemos;
using System;

namespace UnitTests.MvcDemos.ApiControllers
{
    public class ValuesControllerTests
    {

        [Fact]
        public void Get_NonExistingItem_ReturnsNotFound()
        {
            var api = new ValuesController();


            Action action = () => api.Get(null);
            action();
            //action.ShouldThrow

            
        }

        [Fact]
        public void Post_NullTeamIsPassed_ReturnsValue()
        {
            var api = new ValuesController();

            api.Post(new Team());
        } 
    }
}