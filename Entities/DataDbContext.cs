using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _23crbcyr.Entities
{
    public class DataDbContext : DbContext
    {
        //Constructor sin parametros
        public DataDbContext()
        {
        }

        //Constructor con parametros para la configuracion
        public DataDbContext(DbContextOptions options)
        : base(options)
        {
        }

        //Sobreescribimos el metodo OnConfiguring para hacer los ajustes que queramos en caso de
        //llamar al constructor sin parametros
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var mysqlServer = Environment.GetEnvironmentVariable("MYSQLSERVER") ?? "";
            var mysqlDb = Environment.GetEnvironmentVariable("MYSQLDB") ?? "";
            var mysqlUser = Environment.GetEnvironmentVariable("MYSQLUSER") ?? "";
            var mysqlPass = Environment.GetEnvironmentVariable("MYSQLPASS") ?? "";
            var mysqlProtocol = Environment.GetEnvironmentVariable("MYSQLPROTOCOL") ?? "";

            optionsBuilder.UseMySql("Protocol="+ mysqlProtocol + ";Server=" + mysqlServer + ";Database=" + mysqlDb + ";User ID=" + mysqlUser + ";Password=" + mysqlPass + ";");
        }

        //Tablas de datos
        public virtual DbSet<Person> Person { get; set; }
    }
}
