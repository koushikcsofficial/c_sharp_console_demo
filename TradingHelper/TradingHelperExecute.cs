using System.Numerics;

namespace TradingHelper;

public static class TradingHelperExecution
{
  public static void Execute()
  {
    int tradeCountDaily = 0;
    DateTime softwareStartingTime = DateTime.Now;
    int expectedTradeAsPerLevel = 0;
    string[] genericYesNoOptions = ["Y", "y", "N", "n"];
    bool invalidTradingLevel = true;
    do
    {
      if (DateTime.Now.Date > softwareStartingTime)
      {
        Console.WriteLine("Please close the application and reoprn it.");
        Environment.Exit(0);
      }
      Console.WriteLine("Select trading level (B/I/A) [Default B/Biginner]:");
      string tradingLevel = Console.ReadLine() ?? string.Empty;
      tradingLevel = string.IsNullOrEmpty(tradingLevel) ? "B" : tradingLevel;
      string[] validTradingLevels = ["B", "b", "I", "i", "A", "a"];
      if (!validTradingLevels.Contains(tradingLevel))
      {
        Console.WriteLine("Please enter a valid trading level.");
      }
      else
      {
        if (tradingLevel == "B" || tradingLevel == "b")
          expectedTradeAsPerLevel = 3;
        if (tradingLevel == "I" || tradingLevel == "i")
          expectedTradeAsPerLevel = 5;
        if (tradingLevel == "A" || tradingLevel == "a")
          expectedTradeAsPerLevel = 7;
        invalidTradingLevel = false;
      }
    } while (invalidTradingLevel);

    invalidTradingLevel = true;

    do
    {
      string? providedTradeType = string.Empty;
      decimal strikePrice;
      int ATR_value;

      bool invalidTradeType = true;
      do
      {
        Console.WriteLine("Please enter C/P (default is C/Call buy): ");
        providedTradeType = Console.ReadLine();
        string[] validTradeTypes = ["C", "c", "P", "p"];
        if (string.IsNullOrEmpty(providedTradeType))
        {
          providedTradeType = "c";
          invalidTradeType = false;
          break;
        }

        if (!validTradeTypes.Contains(providedTradeType))
        {
          Console.WriteLine("Please enter a valid trade type.");
          continue;
        }
        else
        {
          invalidTradeType = false;
        }
      } while (invalidTradeType);

      invalidTradeType = true;

      bool invalidStrikePrice = true;
      do
      {
        Console.WriteLine("Please enter current strike price: ");
        strikePrice = Convert.ToDecimal(ConvertStringToDecimal(Console.ReadLine()));
        if (strikePrice <= 0) Console.WriteLine("Please provide a valid value for Strike price");
        else
        {
          invalidStrikePrice = false;
        }

      } while (invalidStrikePrice);

      invalidStrikePrice = true;

      bool invalidATR = true;
      do
      {
        Console.WriteLine("Provide mentioned ATR: ");
        ATR_value = Convert.ToInt32(ConvertStringToInt(Console.ReadLine()));
        if (ATR_value <= 0)
        {
          Console.WriteLine("Please enter a valid ATR value.");
        }
        else if (ATR_value <= 10)
        {
          Console.WriteLine("WARNING: Please trade carefully.");
          invalidATR = false;
        }
        else
        {
          invalidATR = false;
        }
      } while (invalidATR);

      invalidATR = true;

      Console.WriteLine("Target count (default value is 1/One): ");
      int targetCount = ConvertStringToInt(Console.ReadLine());
      targetCount = (targetCount == 0) ? 1 : targetCount;

      decimal stoplossForTheTrade = TradingStoplossTarget.GetStopLoss(strikePrice, ATR_value);
      string targets = TradingStoplossTarget.GetTargets(strikePrice, ATR_value, targetCount);

      Console.WriteLine($"Stoploss: {stoplossForTheTrade}\n\n");
      Console.WriteLine(targets);

      Console.WriteLine("\n\n\n");
      bool invalidTradeSelectionResponse = true;
      do
      {
        Console.WriteLine("Did you took the trade (Y/N):");
        string tradeTakenByUserInput = Console.ReadLine() ?? string.Empty;
        tradeTakenByUserInput = string.IsNullOrEmpty(tradeTakenByUserInput) ? "N" : tradeTakenByUserInput;
        if (tradeTakenByUserInput == "Y" || tradeTakenByUserInput == "y")
        {
          DateTime tradeInitializationTime = DateTime.Now.ToLocalTime();
          DateTime tradeExitTime = DateTime.Now.ToLocalTime();
          if (softwareStartingTime.Date == DateTime.Now.Date)
            tradeCountDaily = tradeCountDaily + 1;
          Console.WriteLine("To stop the trade press enter key: ");
          if (Console.ReadKey().Key == ConsoleKey.Enter)
          {
            tradeExitTime = DateTime.Now.ToLocalTime();
          }
          //TODO: Update the csv file to track the success rate
          Console.WriteLine("Would you like to update further details related to your recent trade [Y/N](Default is N)? ");
          string updateFurther = Console.ReadLine() ?? string.Empty;
          updateFurther = string.IsNullOrEmpty(updateFurther) ? "N" : updateFurther;
          if (updateFurther == "Y" || updateFurther == "y")
          {
            DateTime tradeEndTime;
            bool invalidSuccessResponse = true;
            do
            {
              Console.WriteLine("Is your trade got success [Y/N](default is N)? ");
              string tradeResult = Console.ReadLine() ?? string.Empty;
              tradeResult = string.IsNullOrEmpty(tradeResult) ? "N" : tradeResult;

              if (!genericYesNoOptions.Contains(tradeResult))
              {
                Console.WriteLine("Please provide a valid response.");
              }
              else
              {
                // if(tradeResult == "Y" || tradeResult == "y")
                // {

                // }
                Console.WriteLine("Please enter your displayed P/L in the application: ");
                decimal profitAndLoss = ConvertStringToDecimal(Console.ReadLine());

                Console.WriteLine("Please enter traded lot size: ");
                int lotSize = ConvertStringToInt(Console.ReadLine());

                Console.WriteLine("Please enter the approx round figure brokerage (default rs 100): ");
                decimal brokerage = ConvertStringToDecimal(Console.ReadLine()) == 0 ? 100 : ConvertStringToDecimal(Console.ReadLine());

                decimal actualProfitOrLoss = profitAndLoss - brokerage;

                int totalQuantity = 15 * lotSize;
                decimal ProfitOrLossForOneQty = actualProfitOrLoss / totalQuantity;

                bool isSuccess = false;
                if (tradeResult == "Y" || tradeResult == "y") isSuccess = true;

                WriteToTradeValidationCsv(DateTime.Now.Date.ToString(), tradeInitializationTime.ToString(), tradeExitTime.ToString(), strikePrice, stoplossForTheTrade, lotSize, targets, isSuccess, profitAndLoss, ProfitOrLossForOneQty, brokerage);
              }
            } while (invalidSuccessResponse);
          }
          updateFurther = string.Empty;

        }
        if (!genericYesNoOptions.Contains(tradeTakenByUserInput))
        {
          Console.WriteLine("Please provide a valid input. It is important to track your trading record.");
        }
        else
        {
          invalidTradeSelectionResponse = false;
        }
      } while (invalidTradeSelectionResponse);

      invalidTradeSelectionResponse = true;

    } while (expectedTradeAsPerLevel >= tradeCountDaily);

    if (tradeCountDaily > expectedTradeAsPerLevel)
    {
      Console.WriteLine("Do not overtade. Overtrading may cause your capital loss.");
      Environment.Exit(0);
    }
  }

  //Helper methods
  private static int ConvertStringToInt(string? input)
  {
    if (string.IsNullOrEmpty(input)) return 0;
    int result;

    // Try to parse the string, if successful, return the result
    if (int.TryParse(input, out result))
    {
      return result;
    }
    else
    {
      // If parsing fails, return 0
      return 0;
    }
  }

  private static decimal ConvertStringToDecimal(string? input)
  {
    if (string.IsNullOrEmpty(input)) return 0;
    decimal result;

    // Try to parse the string, if successful, return the result
    if (decimal.TryParse(input, out result))
    {
      return result;
    }
    else
    {
      // If parsing fails, return 0
      return 0;
    }
  }

  private static void WriteToTradeValidationCsv(string tradeDate, string tradeStartTime, string tradeEndTime, decimal strikePrice, decimal stopLoss, int lotsize, string targets, bool isSuccess, decimal totalProfitLoss, decimal profitLossPerQty, decimal brokerage)
  {
    string csvFilePath = "tradeValidation.csv";

    // Check if the file exists
    bool fileExists = File.Exists(csvFilePath);

    // If the file doesn't exist, create it with headers
    if (!fileExists)
    {
      string headers = "TradeDate,TradeStartTime,TradeEndTime,StrikePrice,StopLoss,Lotsize,Targets,IsSuccess,Total_P&L,P&L_Per_Qty,Brokerage";
      File.WriteAllText(csvFilePath, headers + Environment.NewLine);
    }

    // Append a new row with trade details
    string newRow = $"{tradeDate},{tradeStartTime},{tradeEndTime},{strikePrice},{stopLoss},{lotsize},{targets},{isSuccess},{totalProfitLoss},{profitLossPerQty},{brokerage}";
    File.AppendAllText(csvFilePath, newRow + Environment.NewLine);
  }
}