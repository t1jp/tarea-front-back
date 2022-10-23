using System.ComponentModel.DataAnnotations;

namespace web_api_empleados.Models{
public class Empleados{
        [Key]
        public int idempleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string dpi { get; set; }
        public string fechanacimiento { get; set; }
        public string fechaingresoregistro { get; set; }
        
        
}

}