using Microsoft.EntityFrameworkCore;
namespace web_api_empleados.Models{
    class Conexion : DbContext{
        public Conexion (DbContextOptions<Conexion> options) : base(options){}
        public DbSet<Empleados> Empleados {get;set;}      
    }
 class Conectar{
           private const string cadenaConexion = "server=localhost;port=3306;database=dbEmpleado;userid=usr_empleado;pwd=Empleado1234;";
            public static Conexion Create(){
                var constructor = new DbContextOptionsBuilder<Conexion>();
                constructor.UseMySQL(cadenaConexion);
                var cn = new Conexion (constructor.Options);
                return cn;

            }
        }

}