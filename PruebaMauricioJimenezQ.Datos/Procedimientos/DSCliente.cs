using PruebaMauricioJimenezQ.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMauricioJimenezQ.Datos
{
    public class DSCliente
    {
        public void RegistrarCliente(int Codigo, int Identificacion, string Nombre)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_ClienteRegistrar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                    cmd.Parameters.Add("@Identificacion", SqlDbType.Int).Value = Identificacion;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public void ActualizarCliente(string ClienteID, int Codigo, int Identificacion, string Nombre)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_ClienteActualizar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClienteID", SqlDbType.NVarChar).Value = ClienteID;
                    cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                    cmd.Parameters.Add("@Identificacion", SqlDbType.Int).Value = Identificacion;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public void EliminarCliente(string ClienteID)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_ClienteEliminar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClienteID", SqlDbType.NVarChar).Value = ClienteID;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public List<ETCliente> ObtenerClientes(string ClienteID)
        {
            List<ETCliente> EntidadCliente = new List<ETCliente>();
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_ClienteObtener", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClienteId", SqlDbType.NVarChar).Value = ClienteID;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            EntidadCliente.Add(new ETCliente()
                            {
                                ClienteId       = (Guid)r["ClienteId"],
                                Codigo          = (int)r["Codigo"],
                                Identificacion  = (int)r["Identificacion"],
                                Nombre          = (string)r["Nombre"]
                            });
                        }
                    }
                }
                StringConexion.Close();
            }
            catch (Exception ex)
            { }
            return EntidadCliente;
        }
    }
}
