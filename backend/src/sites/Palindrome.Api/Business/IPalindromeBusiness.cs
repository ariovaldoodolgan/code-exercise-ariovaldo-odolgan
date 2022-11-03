using Palindrome.Api.Models;

namespace Palindrome.Api.Business
{
    public interface IPalindromeBusiness
    {
        PalindromeResult Validate(PalindromeInput input);
    }
}