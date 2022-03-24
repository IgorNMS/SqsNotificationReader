using Microsoft.EntityFrameworkCore;
using SqsNotificationReader.Models;

namespace SqsNotificationReader.Data
{
    internal class FileContext : DbContext
    {
        public DbSet<SqsFile>? SqsFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("");
        }
    }
}
