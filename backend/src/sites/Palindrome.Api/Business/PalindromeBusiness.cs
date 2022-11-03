using System;
using Palindrome.Api.Services;
using Palindrome.Api.Models;
using Palindrome.Api.Data.Repositories;

namespace Palindrome.Api.Business
{
    public class PalindromeBusiness : IPalindromeBusiness
    {
        private readonly IPalindromeService _palindromeService;
        private readonly IPalindromeRepository _palindromeRepository;

        public PalindromeBusiness(IPalindromeService palindromeService,
            IPalindromeRepository palindromeRepository)
        {
            _palindromeService = palindromeService;
            _palindromeRepository = palindromeRepository;
        }

        public PalindromeResult Validate(PalindromeInput input)
        {
            try
            {
                var result = _palindromeService.IsPalindrome(input.Value);

                var palindromeResult = new PalindromeResult
                {
                    Input = input.Value,
                    IsPalindrome = result,
                    CreateAt = DateTime.UtcNow.ToString("mm/dd/yyyy HH:mm:ss")
                };

                _palindromeRepository.AddPalindrome(palindromeResult);

                return palindromeResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}