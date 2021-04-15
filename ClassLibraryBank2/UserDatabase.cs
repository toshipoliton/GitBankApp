using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ClassLibraryBank2
{
    public class UsersDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=SensiSeeds");
        }
    }
}