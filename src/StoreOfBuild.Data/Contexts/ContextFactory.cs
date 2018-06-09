using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace StoreOfBuild.Data.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StoreOfBuildDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ApplicationDbContext(builder.Options);
        }
    }
}
