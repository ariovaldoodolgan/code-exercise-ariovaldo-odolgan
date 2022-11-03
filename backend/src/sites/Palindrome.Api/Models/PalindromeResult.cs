namespace Palindrome.Api.Models
{
    public class PalindromeResult
    {
        public int Id { get; set; }

        public string Input { get; set; }

        public bool IsPalindrome { get; set; }

        public string CreateAt { get; set; }
    }
}