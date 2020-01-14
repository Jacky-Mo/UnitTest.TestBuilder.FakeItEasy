using Xunit;
using FakeItEasy;
using System.Collections.Generic;
using UnitTest.TestBuilder.FakeItEasy.Test.Implementation;

namespace UnitTest.TestBuilder.FakeItEasy.Test
{
    public class ObjectBuilderTests
    {
        #region CanCreate

        [Fact]
        public void CanCreate_ReferenceType_ReturnFalse()
        {
            var builder = new ObjectBuilder();

            var result = builder.CanCreate(typeof(TestObject));

            Assert.False(result);
        }

        [Fact]
        public void CanCreate_ValueType_ReturnFalse()
        {
            var builder = new ObjectBuilder();

            var result = builder.CanCreate(typeof(int));

            Assert.False(result);
        }

        [Fact]
        public void CanCreate_StringType_ReturnFalse()
        {
            var builder = new ObjectBuilder();

            var result = builder.CanCreate(typeof(string));

            Assert.False(result);
        }

        [Fact]
        public void CanCreate_Interface_ReturnTrue()
        {
            var builder = new ObjectBuilder();

            var result = builder.CanCreate(typeof(ITestService));

            Assert.True(result);
        }

        [Fact]
        public void CanCreate_RandomGenericType_ReturnFalse()
        {
            var builder = new ObjectBuilder();

            var result = builder.CanCreate(typeof(List<ITestService>));

            Assert.False(result);
        }

        [Fact]
        public void CanCreate_GenericTypeOfFake_ReturnTrue()
        {
            var builder = new ObjectBuilder();

            var result = builder.CanCreate(typeof(Fake<ITestService>));

            Assert.True(result);
        }

        #endregion


        #region Create
        [Fact]
        public void Create_ReferenceType_ReturnNull()
        {
            var builder = new ObjectBuilder();

            var result = builder.Create(typeof(TestObject));

            Assert.Null(result);
        }

        [Fact]
        public void Create_ValueType_ReturnNull()
        {
            var builder = new ObjectBuilder();

            var result = builder.Create(typeof(int));

            Assert.Null(result);
        }

        [Fact]
        public void Create_StringType_ReturnNull()
        {
            var builder = new ObjectBuilder();

            var result = builder.Create(typeof(string));

            Assert.Null(result);
        }

        [Fact]
        public void Create_Interface_ReturnObject()
        {
            var builder = new ObjectBuilder();

            var result = builder.Create(typeof(ITestService));

            Assert.NotNull(result);
            Assert.IsAssignableFrom<ITestService>(result);
        }

        [Fact]
        public void Create_RandomGenericType_ReturnNull()
        {
            var builder = new ObjectBuilder();

            var result = builder.Create(typeof(List<ITestService>));

            Assert.Null(result);
        }

        [Fact]
        public void Create_GenericTypeOfFake_ReturnObject()
        {
            var builder = new ObjectBuilder();

            var result = builder.Create(typeof(Fake<ITestService>));

            Assert.NotNull(result);
            Assert.IsAssignableFrom<Fake<ITestService>>(result);
        }
        #endregion
    }
}
