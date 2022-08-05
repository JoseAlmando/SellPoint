using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<GrupoEntidad> GrupoEntidad { get; set; }
        public virtual DbSet<TipoEntidad> TipoEntidad { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("workstation id=SellPoint.mssql.somee.com;packet size=4096;user id=JoseAlmando_SQLLogin_1;pwd=z2k7m9iucm;data source=SellPoint.mssql.somee.com;persist security info=False;initial catalog=SellPoint",
            b => b.MigrationsAssembly("SellPoint.Presentation.API"));
    }
}
