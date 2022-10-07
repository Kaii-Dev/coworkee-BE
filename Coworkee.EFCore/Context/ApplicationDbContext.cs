using Coworkee.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Coworkee.Data
{
    public class ApplicationDbContext :DbContext
    {
        private readonly string _connectionString;
        private readonly bool _usingMemoryDb = false;
        public virtual DbSet<Music> NewMusic { get; set; }
        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ApplicationDbContext(string connectionString, bool usingMemoryDb)
        {
           _connectionString=connectionString;
            _usingMemoryDb = usingMemoryDb;
        }
        
        public ApplicationDbContext()
        {

        }
          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString != null)
            {
                if (!_usingMemoryDb)
                {
                    optionsBuilder.UseNpgsql(_connectionString, buidler =>
                    {
                        buidler.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    });
                }
                else
                {
                    optionsBuilder.UseInMemoryDatabase("TestingDbContextDatabase");
                }
            }
        }


    }
}
