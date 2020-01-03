namespace UnitTest.TestBuilder.FakeItEasy.Test.Examples
{
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
}
