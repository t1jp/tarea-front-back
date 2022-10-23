using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using web_api_empleados.Models;
namespace web_api_empleados.Controllers{
[Route("api/[controller]")]
    public class EmpleadosController : Controller {
        private Conexion dbConexion;
        public EmpleadosController(){ dbConexion = Conectar.Create();        }
        // GET api
        [HttpGet]
        public ActionResult Get() {return Ok(dbConexion.Empleado.ToArray());}
        // GET api
        [HttpGet("{id}")]
         public async Task<ActionResult> Get(int id) {
             var Empleados = await dbConexion.Empleado.FindAsync(id);
            if (empleados != null) {
                return Ok(empleados);
            } else {
                return NotFound();
            }
        }
        
         [HttpPost]
        public async Task<ActionResult> Post([FromBody] empleados empleados){
            if (ModelState.IsValid){
             dbConexion.Empleado.Add(empleados);
             await dbConexion.SaveChangesAsync();
             return Ok();
             //return Ok(clientes); retorna el registro ingresado
             //return Created("api/clientes",clientes); retorna los registros
             }else{
                 return BadRequest();
             }
             
        }


    // editar

    public async Task<ActionResult> Put([FromBody] Empleados Empleados){
        var v_empleados = dbConexion.Empleados.SingleOrDefault(a => a.idempleado == empleados.idempleado);
        if (v_empleados != null && ModelState.IsValid) {
            dbConexion.Entry(v_empleados).CurrentValues.SetValues(empleados);
            await dbConexion.SaveChangesAsync();
            //return Created("api/clientes",clientes);
                return Ok();
            } else {
                return BadRequest();
            }
    }
//eliminar
[HttpDelete("{id}")]
public async Task<ActionResult> Delete(int id) {
    var empleados = dbConexion.empleados.SingleOrDefault(a => a.idempleado == id);
    if(empleados!= null) {
        dbConexion.Empleado.Remove(empleados);
        await dbConexion.SaveChangesAsync();
                return Ok();
        } 
        else {    return NotFound();
        }
}

}

}