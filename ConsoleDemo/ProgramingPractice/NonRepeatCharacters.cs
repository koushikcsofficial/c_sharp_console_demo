using System.Collections;
namespace ConsoleDemo.ProgramingPractice;

public static class NonRepeatChatacters
{
  public static char? solution(string inputString)
  {
    Dictionary<char, int> charCount = new Dictionary<char, int>();
    if (String.IsNullOrEmpty(inputString)) return null;
    foreach (var ch in inputString)
    {
      if (charCount.ContainsKey(ch))
      {
        charCount[ch]++;
      }
      else
      {
        charCount.Add(ch, 1);
      }
    }

    foreach (var ch in inputString)
    {
      if (charCount[ch] == 1) return ch;
    }

    return null;
  }
}