using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
namespace tarea_umg
{
    public class ConexionBD
    {
        private string cadena = "server=localhost; database=cn_empresa; user=usr_empleado; password=Emple@123";
        public MySqlConnection conectar = new MySqlConnection();
        

        public void AbrirConexion(){
            try {
                conectar.ConnectionString = cadena;
                conectar.Open();
               // System.Diagnostics.Debug.WriteLine("Conexion Exitosa");
               
            } 
            catch(Exception ex){
                System.Diagnostics.Debug.WriteLine(ex.Message);
               // Console.WriteLine(ex.StackTrace);
                
            }

        }
        public void CerarConexion(){
            
                if (conectar.State == ConnectionState.Open){
                conectar.Close();            }

        }
    }
}