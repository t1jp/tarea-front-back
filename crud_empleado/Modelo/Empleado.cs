using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace tarea_umg
{
    public class Empleado
    {
        ConexionBD conectar;
        private DataTable drop_puesto(){
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select idpuesto as id,puesto from puestos;");
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void drop_puesto(DropDownList drop){
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Agregar Puesto >>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_puesto();
            drop.DataTextField = "puesto";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        private DataTable grid_empleados() {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            String consulta = string.Format("select e.idEmpleado as id,e.nombre,e.apellido,e.direccion,e.telefono,e.telefono,e.dpi,e.fechanacimiento,e.fechaingresoregistro,p.idpuesto from empleados as e inner join puestos as p on e.idpuesto = p.idpuesto;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void grid_empleados(GridView grid){
            grid.DataSource = grid_empleados();
            grid.DataBind();

        }
        public int agregar(string nombre,string apellido,string direccion,string telefono, string dpi, string fechanacimiento, string fechaingresoregistro,int idpuesto){
            int noIngreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("insert into empleados(nombre,apellido,direccion,telefono,dpi,fechanacimiento,fechaingresoregistro,idpuesto) values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8});", nombre,apellido,direccion,telefono,dpi,fechanacimiento,fechaingresoregistro,idpuesto);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);
            
            insertar.Connection = conectar.conectar;
            noIngreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return noIngreso;

        }
        public int modificar(string nombre, string apellido, string direccion, string telefono, string dpi, string fechanacimiento, string fechaingresoregistro, int idpuesto)
        {
            int noIngreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("update empleados set nombre = '{0}',apellido = '{1}',direccion='{2}',telefono='{3}',dpi='{4}',fechanacimiento='{5}',fechaingresoregistro='{6}',id_puesto = {7} where id_empleado = {7};", nombre, apellido, direccion, telefono, dpi, fechanacimiento, fechaingresoregistro, idpuesto);
            MySqlCommand modificar = new MySqlCommand(strConsulta, conectar.conectar);

            modificar.Connection = conectar.conectar;
            noIngreso = modificar.ExecuteNonQuery();
            conectar.CerarConexion();
            return noIngreso;
        }
        public int eliminar(int id){
            int noIngreso = 0;
        conectar = new ConexionBD();
        conectar.AbrirConexion();
            string strConsulta = string.Format("delete from empleados  where idempleado = {0};", id);
        MySqlCommand eliminar = new MySqlCommand(strConsulta, conectar.conectar);

            eliminar.Connection = conectar.conectar;
            noIngreso = eliminar.ExecuteNonQuery();
            conectar.CerarConexion();
            return noIngreso;
        }

}
}