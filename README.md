# UnitTest.TestBuilder.FakeItEasy

### Introduction

This is a concrete implementation of a test builder for [FakeItEasy](https://fakeiteasy.github.io) based on [UnitTest.TestBuilder.Core](https://github.com/Jacky-Mo/UnitTest.TestBuilder.Core)

Please visit the repository to see implementations for other test frameworks.

#### Description
This is a test library that helps to write unit tests faster by abstractin out the boilerplate codes and let the developers focus on the actual logics of the unit tests instead.

#### How to use
1. Create a Builder class that inherits from ***FakeItEasyBuilder*** abstract classes
   

```C#
public class TestClass
{
  private class Builder : FakeItEasyBuilder<TestObject>
  {
  }
}
```

2. Define class properties in the ***Builder*** class. 
> All reference type properties including string will be dynamically created and assigned by ***FakeItEasyBuilder***.
>
> The ***TestObject*** is created using its public constructor that has the most parameters. If the parameter is the same type as any of the properties defined
> in the ***Builder***, the property of the ***Builder*** will be passed in as the parameter to the constructor. Hence, the ***TestObject*** will have reference
> to the properties defined in the ***Builder***.

```C#
public class TestClass
{
  private class Builder : FakeItEasyBuilder<TestObject>
  {
       Fake<IServiceA> ServiceA {get; private set;}
  }
}
```

3. You can optionally override the creation of the property objects in the constructor of the ***Builder*** class

```C#
  private class Builder : FakeItEasyBuilder<TestObject>
  {
      public IServiceA ServiceA {get; private set;}
      
      public Builder(IContainer container)
      {
         // override the creation of ServiceA
         ServiceA = new ServiceA();
      }
  }
```

4. You can optionally use dependency injection for the creation of the properties. You can define a custom DI container using your favorite DI library that implements the IContainer interface.


5. You can optionally override the creation of the ***TestObject*** by overriding the *CreateObject* method.

```C#
  private class Builder : FakeItEasyBuilder<TestObject>
  {
      public IServiceA ServiceA {get; private set;}
      
      /// You can pass in additional parameters to create your custom TestObject
      /// through the *args* paramater
      protected override TestObject CreateObject(params object[] args)
      {
        return new TestObject();
      }
  }
```

#### Examples

> Check out the Examples in Unit Tests project for more details

```C#
    public interface IRateService
    {
        double GetRate();
    }

    public class RateCalculator
    {
        private readonly IRateService _rateService;

        public RateCalculator(IRateService rateService)
        {
            _rateService = rateService;
        }

        public double GetTodayRate()
        {
            return 2 * _rateService.GetRate();
        }

        public double GetTomorrowRate()
        {
            return 3 * _rateService.GetRate();
        }
    }

    [TestClass]
    public class ExampleTests
    {
        private class Builder : FakeItEasyBuilder<RateCalculator>
        {
            // This property will be auto-populated by the base builder
            public Fake<IRateService> RateService { get; private set; }

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

            //verify RateService.GetRate() was called
            builder.RateService.CallsTo(a => a.GetRate()).MustHaveHappened();
        }
    }
```

<br>
<br>
Last Updated: Jan-13-2020 (Jacky-Mo)