using System.Collections;
namespace ProgramingPractice;

public static class ProductOfArrayExceptSelf
{
  public static List<ulong> solution(int[] arr)
  {
    List<ulong> ans = new List<ulong>();
    if (arr.Length == 0) return ans;

    int[] left = new int[arr.Length];
    int[] right = new int[arr.Length];

    for (int i = 0; i < arr.Length; i++)
    {
      if (i == 0)
      {
        left[i] = 1;
      }
      else
      {
        left[i] = left[i - 1] * arr[i - 1];
      }
    }

    for (int i = arr.Length - 1; i > -1; i--)
    {
      if (i == arr.Length - 1)
      {
        right[i] = 1;
      }
      else
      {
        right[i] = right[i + 1] * arr[i + 1];
      }
    }

    for (int i = 0; i < arr.Length; i++)
    {
      ans.Add(Convert.ToUInt64(left[i] * right[i]));
    }

    return ans;
  }
}