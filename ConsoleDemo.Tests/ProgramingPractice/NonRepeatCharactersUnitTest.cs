using ConsoleDemo.ProgramingPractice;
using FluentAssertions;

namespace ConsoleDemo.Tests.ProgramingPractice;

public class NonRepeatCharactersUnitTest
{
  [Fact]
  public void Solution_should_return_null_when_input_is_null()
  {
    //Arrange
    string input = "";
    //Act
    var result = NonRepeatChatacters.Solution(input);
    //Assert
    result.Should().NotBeNull();
  }

  [Fact]
  public void Solution_should_return_correct_character()
  {
    //Arrange
    string input = "Koushik";
    char expectecdChar = 'o';
    //Act
    var result = NonRepeatChatacters.Solution(input);
    //Assert
    result.Equals(expectecdChar);
  }
}