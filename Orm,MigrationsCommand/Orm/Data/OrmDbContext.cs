using Microsoft.EntityFrameworkCore;
using Orm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.Data
{
    //Databasenen connection qurmaq ucun bu klassdan istifade olunur,
    //Butun tableler bu classda saxlanmalidir.
    public class OrmDbContext:DbContext
    {
        //Burda Group ucun Orm.Entities olandan secirik
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Students> Students { get; set; }
        //Servernen elaqe qurmaq ucun
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database = PB502; User Id = sa; Password = Senan123@; TrustServerCertificate = true;");
        }
    }
}
