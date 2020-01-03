using FakeItEasy;
using System;
using System.Runtime.CompilerServices;
using UnitTest.TestBuilder.Core.Abstracts;

[assembly: InternalsVisibleTo("UnitTest.TestBuilder.FakeItEasy.Test")]

namespace UnitTest.TestBuilder.FakeItEasy
{
    internal class ObjectBuilder : IObjectBuilder
    {
        public bool CanCreate(Type type)
        {
            return type.IsInterface 
                || (type.IsClass && !type.IsGenericType && type != typeof(string))
                || (type.IsGenericType && type.Name != "Fake`1");
        }

        public object Create(Type type)
        {
            if (!CanCreate(type)) return null;

            var fake = typeof(Fake<>);

            return Activator.CreateInstance(fake.MakeGenericType(type));
        }
    }
}
