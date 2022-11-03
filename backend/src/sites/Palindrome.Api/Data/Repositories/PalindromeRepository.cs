using Palindrome.Api.Data.Context;
using Palindrome.Api.Models;

namespace Palindrome.Api.Data.Repositories
{
    public class PalindromeRepository : IPalindromeRepository
    {
        private readonly DataBaseContext _dbContext;

        public PalindromeRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPalindrome(PalindromeResult result)
        {
            _dbContext.Palindromes.Add(result);
            _dbContext.SaveChanges();
        }

        public List<PalindromeResult> GetPalindromeList()
        {
            return _dbContext.Palindromes
                        .OrderByDescending(x => x.CreateAt)
                        .ToList();
        }
    }
}