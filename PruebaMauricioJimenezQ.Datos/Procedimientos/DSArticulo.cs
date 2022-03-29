using PruebaMauricioJimenezQ.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PruebaMauricioJimenezQ.Datos
{
    public class DSArticulo
    {
        public void RegistrarArticulo(int Codigo, string Nombre, decimal Precio)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_ArticuloRegistrar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
                    cmd.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public void ActualizarArticulo(string ArticuloID, int Codigo, string Nombre, decimal Precio)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_ArticuloActualizar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ArticuloID", SqlDbType.NVarChar).Value = ArticuloID;
                    cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = Nombre;
                    cmd.Parameters.Add("@Precio", SqlDbType.Money).Value = Precio;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public void EliminarArticulo(string ArticuloID)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_ArticuloEliminar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ArticuloID", SqlDbType.NVarChar).Value = ArticuloID;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public List<ETArticulo> ObtenerArticulos(string ArticuloID)
        {
            List<ETArticulo> EntidadArticulo = new List<ETArticulo>();
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_ArticuloObtener", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ArticuloId", SqlDbType.NVarChar).Value = ArticuloID;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            EntidadArticulo.Add(new ETArticulo()
                            {
                                ArticuloId  = (Guid)r["ArticuloId"],
                                Codigo      = (int)r["Codigo"],
                                Nombre      = (string)r["Nombre"],
                                Precio      = (decimal)r["Precio"]
                            });
                        }
                    }
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
            return EntidadArticulo;
        }
    }
}
