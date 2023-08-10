using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SellPoint.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPoint.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Entidades> Entidades { get; set; }
        public virtual DbSet<User> User { get; set; }
        IConfigurationRoot configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfigurationRoot configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public ApplicationDbContext()
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(m => m.UserNameEntidad).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)

        => options.UseSqlServer(@"Server=(local)\SQLEXPRESS;Database=SellPoint;Trusted_Connection=True;",
            b => b.MigrationsAssembly("SellPoint.Presentation.API"));
    }
}
