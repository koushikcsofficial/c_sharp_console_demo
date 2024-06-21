using System.Collections;
namespace ConsoleDemo.ProgramingPractice;

public static class NonRepeatChatacters
{
  public static char Solution(string inputString)
  {
    Dictionary<char, int> charCount = new Dictionary<char, int>();
    if (String.IsNullOrEmpty(inputString)) return '\0';
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

    return '\0';
  }
}