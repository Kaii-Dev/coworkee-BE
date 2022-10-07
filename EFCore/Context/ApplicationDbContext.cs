using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;
using EFCore.Model;

namespace EFCore.Context
{
    public class ApplicationDbContext : DbContext
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
            _connectionString = connectionString;
            _usingMemoryDb = usingMemoryDb;
        }

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        //    #region uppercase -> lowercase column name
        //    foreach (var entity in modelBuilder.Model.GetEntityTypes())
        //    {
        //        // Replace column names
        //        foreach (var property in entity.GetProperties())
        //        {
        //            property.SetColumnName(EFCommon.ToSnakeCase(property.GetColumnName()));
        //        }

        //        foreach (var key in entity.GetKeys())
        //        {
        //            key.SetName(EFCommon.ToSnakeCase(key.GetName()));
        //        }

        //        foreach (var key in entity.GetForeignKeys())
        //        {
        //            key.SetConstraintName(EFCommon.ToSnakeCase(key.GetConstraintName()));
        //        }

        //        foreach (var index in entity.GetIndexes())
        //        {
        //            index.SetName(EFCommon.ToSnakeCase(index.GetName()));
        //        }
        //    }
            
        }
    }

