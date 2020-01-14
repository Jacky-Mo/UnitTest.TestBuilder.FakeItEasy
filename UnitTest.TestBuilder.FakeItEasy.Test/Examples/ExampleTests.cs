using FakeItEasy;
using UnitTest.TestBuilder.Core.Abstracts;
using Xunit;

namespace UnitTest.TestBuilder.FakeItEasy.Test.Examples
{
    public class ExampleTests
    {
        private class Builder : FakeItEasyBuilder<RateCalculator>
        {
            public Fake<IRateService> RateService { get; private set; }
            public DefaultSetting DefaultSetting { get; private set; }

            public Builder() : this(null) { }

            public Builder(IContainer container) : base(container) { }
        }

        [Fact]
        public void GetTodayRate_WithRate_ReturnCorrectRate()
        {
            var builder = new Builder();

            //set up the getRate method to return 2
            builder.RateService.CallsTo(a => a.GetRate()).Returns(2);

            var calculator = builder.Build();

            //Act
            var result = calculator.GetTodayRate();

            //Assert
            Assert.Equal(4.0, result);
            Assert.Equal(builder.DefaultSetting, calculator.DefaultSetting);

            //verify RateService.GetRate() was called
            builder.RateService.CallsTo(a => a.GetRate()).MustHaveHappened();
        }

        [Fact]
        public void GetTomorrowRate_WithRate_ReturnCorrectRate()
        {
            var builder = new Builder();

            //set up the getRate method to return 2
            builder.RateService.CallsTo(a => a.GetRate()).Returns(2);

            var calculator = builder.Build();

            //Act
            var result = calculator.GetTomorrowRate();

            //Assert
            Assert.Equal(6.0, result);
            Assert.Equal(builder.DefaultSetting, calculator.DefaultSetting);

            //verify RateService.GetRate() was called
            builder.RateService.CallsTo(a => a.GetRate()).MustHaveHappened();
        }
    }
}
