using System;
namespace UnitTests
{
    interface IPersonMapper
    {
        PersonDto Map<TFrom, TTo>(TFrom input)
            where TFrom : class
            where TTo : PersonDto;
    }
}
