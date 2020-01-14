namespace UnitTest.TestBuilder.FakeItEasy.Test.Examples
{
    public interface IRateService
    {
        double GetRate();
    }

    public class RateCalculator
    {
        private readonly IRateService _rateService;
        public DefaultSetting DefaultSetting { get; }
        public RateCalculator(IRateService rateService, DefaultSetting setting)
        {
            _rateService = rateService;
            DefaultSetting = setting;
        }

        public double GetTodayRate()
        {
            return DefaultSetting.DefaultTodayRateFactor * _rateService.GetRate();
        }

        public double GetTomorrowRate()
        {
            return DefaultSetting.DefaultTomorrowRateFactor * _rateService.GetRate();
        }
    }
}
