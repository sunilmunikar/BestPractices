using FluentAssertions;
using My.Framework.Helper;
using System;
using Xunit;

namespace UnitTests.Framework.Helper
{
    public class Foo
    {
        public Bar Bar { get; set; }
    }

    public class Bar { }

    public class FooBar
    {
        public Foo Foo { get; set; }
    }

    public class NotNullTests
    {
        [Fact]
        public void GivenNullInChainOfProperties_WhenAccessingProperty_ShouldReturnNull()
        {
            var foo = new Foo();
            Assert.Null(foo.Bar);
        }

        [Fact]
        public void GivenNullInChainOfPerperties_WhenAccesingLastProerty_ShouldThrowException()
        {
            var foobar = new FooBar();

            Bar result;

            Action act = () => result = foobar.Foo.Bar;

            act.ShouldThrow<NullReferenceException>();
        }

        [Fact]
        public void GivenNullInChainOfPerperties_WhenAccesingLastProerty_ShouldNotThrowException()
        {
            var foobar = new FooBar();

            Bar result;

            Action act = () => result = foobar.Get(f => f.Foo.Bar);

            act.ShouldNotThrow();
        }
    }
}