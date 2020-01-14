using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnitTest.TestBuilder.Core.Abstracts;

[assembly: InternalsVisibleTo("UnitTest.TestBuilder.FakeItEasy.Test")]

namespace UnitTest.TestBuilder.FakeItEasy
{
    internal class ObjectBuilder : IObjectBuilder
    {
        private readonly Dictionary<Type, object> _mockTypeDictionary = new Dictionary<Type, object>();

        public bool CanCreate(Type type)
        {
            return type.IsInterface || (type.IsGenericType && type.Name == "Fake`1");
        }

        public object Create(Type type)
        {
            if (!CanCreate(type)) return null;

            if (_mockTypeDictionary.ContainsKey(type))
            {
                return GetMockObjectProperty(_mockTypeDictionary[type], type);
            }

            //it is Mock<T>, create it and save it
            if (type.IsGenericType && type.Name == "Fake`1")
            {
                var genericType = type.GenericTypeArguments[0];

                if (!_mockTypeDictionary.ContainsKey(genericType))
                {
                    _mockTypeDictionary.Add(genericType, Activator.CreateInstance(type));
                }

                return _mockTypeDictionary[genericType];
            }

            //it is interface, wrap it w/ Fake and return the Object property
            var fake = typeof(Fake<>);
            var fakeObj = Activator.CreateInstance(fake.MakeGenericType(type));

            return GetMockObjectProperty(fakeObj, type);
        }

        /// <summary>
        /// Get Fake's FakeObject property
        /// </summary>
        /// <param name="fakeObject">an object of Fake type></param>
        /// <param name="type">the type of the return type</param>
        /// <returns>object of type or null if the property does not exists</returns>
        private object GetMockObjectProperty(object fakeObject, Type type)
        {
            var objectProperty = fakeObject.GetType().GetProperty("FakedObject");
            return objectProperty != null ? objectProperty.GetValue(fakeObject) : null;
        }
    }
}
