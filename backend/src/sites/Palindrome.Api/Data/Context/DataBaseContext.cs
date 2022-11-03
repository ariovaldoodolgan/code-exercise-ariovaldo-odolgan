using Microsoft.EntityFrameworkCore;
using Palindrome.Api.Models;

namespace Palindrome.Api.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<PalindromeResult> Palindromes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PalindromeResult>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}