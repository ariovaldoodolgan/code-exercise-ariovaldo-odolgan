using System.ComponentModel.DataAnnotations;

namespace Palindrome.Api.Models
{
    public class PalindromeInput
    {
        [Required]
        public string? Value { get; set; }
    }
}