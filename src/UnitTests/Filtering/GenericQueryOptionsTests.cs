using System;
using System.Diagnostics;
using FluentAssertions;
using My.Framework.Filtering;
using Xunit;

namespace UnitTests.Filtering
{
    public class GenericQueryOptionsTests
    {
        [Fact]
        public void QueryOption()
        {
            var queryOption = new QueryOptions<FakeModel>();
            queryOption.QueryExpressions.Add(f => f.Property1 == "Property1");

            queryOption.QueryExpressions.Should().HaveCount(1);
        }

        [Fact]
        public void GivenQueryOptionForFakeModel_ShouldCastToAnotherFakeModel()
        {
            var queryOption = new QueryOptions<FakeModel>();
            queryOption.QueryExpressions.Add(f => f.Property1 == "Value of Property1");

            var output = queryOption.ToLogString();
            Trace.WriteLine(output);
        }
    }

    public class FakeModel
    {
        public string Property1 { get; set; }
    }

    public class AnotherFakeModel
    {
        public string Property1 { get; set; }
    }
}