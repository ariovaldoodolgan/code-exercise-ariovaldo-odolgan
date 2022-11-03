using Palindrome.Api.Models;

namespace Palindrome.Api.Data.Repositories
{
    public interface IPalindromeRepository
    {
         void AddPalindrome(PalindromeResult result);

         List<PalindromeResult> GetPalindromeList();
    }
}