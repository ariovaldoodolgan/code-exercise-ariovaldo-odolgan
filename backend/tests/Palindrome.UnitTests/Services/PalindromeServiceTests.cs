using Palindrome.Api.Services;
using Shouldly;
using Xunit;

namespace Palindrome.UnitTests.Services;

public class PalindromeServiceTests
{
    private IPalindromeService Sut => new PalindromeService();

    [Fact]
    public void Should_fail_null_values()
    {
        Sut.IsPalindrome(null).ShouldBeFalse();
    }

    [Theory]
    [InlineData("dood", true)]
    [InlineData("dude", false)]
    [InlineData("Eva, Can I Stab Bats In A Cave?", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void Should_detect_simple_palindromes(string input, bool expectedResult)
    {
        Sut.IsPalindrome(input).ShouldBe(expectedResult);
    }
}