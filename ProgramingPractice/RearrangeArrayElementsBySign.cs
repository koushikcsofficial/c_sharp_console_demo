using System.Collections;
using System.Linq;
namespace ProgramingPractice;

public static class RearrangeArrayElementsBySign
{
  public static int[] Solution(int[] nums)
  {
    List<int> positiveSet = nums.AsQueryable().Where(x => x >= 0).ToList();
    List<int> negativeSet = nums.AsQueryable().Where(x => x < 0).ToList();
    //ToDo: combine these two sets and append the remaining elements at last

    return nums;
  }
}