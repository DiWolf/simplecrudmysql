using Microsoft.EntityFrameworkCore;
using mysqltest.Entities;

namespace mysqltest.Infraestructura
{
    public class MySqlContexto: DbContext 
    {
        public MySqlContexto(DbContextOptions<MySqlContexto> options )
        :base (options){}

        //Databaseset 
        public DbSet<Persona> Personas {get;set;}
    }
}