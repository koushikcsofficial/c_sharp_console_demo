namespace TradingHelper;

static class TradingStoplossTarget
{
    static TradingStoplossTarget()
    {

    }

    public static decimal GetStopLoss(decimal priceChartValue, int ATR_value)
    {
        return priceChartValue - ATR_value;
    }
    public static string GetTargets(decimal priceChartValue, decimal ATR_value, int targetCount)
    {
        string result = string.Empty;
        for (int i = 0; i < targetCount; i++)
        {
            decimal targetPrice = priceChartValue + (ATR_value * (i + 1));
            result = result + $"Target{i + 1}: {targetPrice}, ";
        }
        return result;
    }

}