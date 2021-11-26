using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Model
{
    class AplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //crear la conexion a la base de datos
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PuntoVenta;" +
                "Integrated Security= True").EnableSensitiveDataLogging(true);

            
        }
        //propiedad la cual le indica a EFC que vamos a tener una tabla Empleados
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Producto> Producto { get; set; }
    }
}
