using System.Collections;
namespace ProgramingPractice;

public static class StockBuySellAtMostOne
{
  public static int[] solution(int[] arr)
  {
    int[] ans = [0, 0];
    if (arr == null || arr.Length == 0) return ans;

    int min = arr[0], max = arr[0], minDay = 1, maxDay = 1;

    if (arr.Length > 1)
    {
      for (int i = 1; i < arr.Length; i++)
      {
        if (min > arr[i])
        {
          min = arr[i];
          minDay = i + 1;
        }
        if (max < arr[i])
        {
          max = arr[i];
          maxDay = i + 1;
        }
      }
    }
    ans = [minDay, maxDay];
    return ans;
  }

}