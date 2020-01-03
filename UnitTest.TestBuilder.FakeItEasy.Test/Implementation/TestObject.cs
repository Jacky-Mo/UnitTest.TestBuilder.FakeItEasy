using System;

namespace UnitTest.TestBuilder.FakeItEasy.Test.Implementation
{
    public class TestObject
    {
        public ITestService TestService { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }

        public TestObject(ITestService testService, DateTime date, int number)
        {
            TestService = testService;
            Date = date;
            Number = number;
        }
    }
}
