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
        public void CanCreate_ReferenceType_ReturnTrue()
        {
            var builder = new ObjectBuilder();

            var result = builder.CanCreate(typeof(TestObject));

            Assert.True(result);
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
        public void CanCreate_RandomGenericType_ReturnTrue()
        {
            var builder = new ObjectBuilder();

            var result = builder.CanCreate(typeof(List<ITestService>));

            Assert.True(result);
        }

        [Fact]
        public void CanCreate_GenericTypeOfFake_ReturnFalse()
        {
            var builder = new ObjectBuilder();

            var result = builder.CanCreate(typeof(Fake<ITestService>));

            Assert.False(result);
        }

        #endregion


        #region Create
        [Fact]
        public void Create_ReferenceType_ReturnObject()
        {
            var builder = new ObjectBuilder();

            var result = builder.Create(typeof(TestObject));

            Assert.NotNull(result);
            Assert.IsAssignableFrom<Fake<TestObject>>(result);
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
            Assert.IsAssignableFrom<Fake<ITestService>>(result);
        }

        [Fact]
        public void Create_RandomGenericType_ReturnObject()
        {
            var builder = new ObjectBuilder();

            var result = builder.Create(typeof(List<ITestService>));

            Assert.NotNull(result);
            Assert.IsAssignableFrom<Fake<List<ITestService>>>(result);
        }

        [Fact]
        public void Create_GenericTypeOfFake_ReturnNull()
        {
            var builder = new ObjectBuilder();

            var result = builder.Create(typeof(Fake<ITestService>));

            Assert.Null(result);
        }
        #endregion
    }
}
