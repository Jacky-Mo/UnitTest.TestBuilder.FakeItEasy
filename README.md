# UnitTest.TestBuilder.FakeItEasy

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
> All reference type properties except string will be dynamically created and assigned by ***FakeItEasyBuilder***.
>
> The ***TestObject*** is created using its public constructor that has the most parameters. If the parameter is the same type as any of the properties defined
> in the ***Builder***, the property of the ***Builder*** will be passed in as the parameter to the constructor. Hence, the ***TestObject*** will have reference
> to the properties defined in the ***Builder***.

```C#
public class TestClass
{
  private class Builder : FakeItEasyBuilder<TestObject>
  {
       IServiceA ServiceA {get; private set;}
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

<br>
<br>
Last Updated: 01/03/2020