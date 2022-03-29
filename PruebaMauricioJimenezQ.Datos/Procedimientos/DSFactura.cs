using PruebaMauricioJimenezQ.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PruebaMauricioJimenezQ.Datos
{
    public class DSFactura
    {
        public void RegistrarFactura(string ClienteId, decimal TotalFactura, bool Pago)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_FacturaRegistrar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClienteId", SqlDbType.NVarChar).Value = ClienteId;
                    cmd.Parameters.Add("@TotalFactura", SqlDbType.Money).Value = TotalFactura;
                    cmd.Parameters.Add("@Pago", SqlDbType.Bit).Value = Pago;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public void ActualizarFactura(string FacturaId, string ClienteId, decimal TotalFactura, bool Pago)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_FacturaActualizar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FacturaId", SqlDbType.NVarChar).Value = FacturaId;
                    cmd.Parameters.Add("@ClienteId", SqlDbType.NVarChar).Value = ClienteId;
                    cmd.Parameters.Add("@TotalFactura", SqlDbType.Money).Value = TotalFactura;
                    cmd.Parameters.Add("@Pago", SqlDbType.Bit).Value = Pago;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public void EliminarFactura(string FacturaId)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_FacturaEliminar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FacturaId", SqlDbType.NVarChar).Value = FacturaId;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public List<ETFactura> ObtenerFacturas(string FacturaId, string ClienteId)
        {
            List<ETFactura> EntidadFactura = new List<ETFactura>();
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_FacturaObtener", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FacturaId", SqlDbType.NVarChar).Value = FacturaId;
                    cmd.Parameters.Add("@ClienteID", SqlDbType.NVarChar).Value = ClienteId;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            EntidadFactura.Add(new ETFactura()
                            {
                                FacturaId       = (Guid)r["FacturaId"],
                                ClienteId       = (Guid)r["ClienteId"],
                                NombreCliente   = (string)r["NombreCliente"],
                                Consecutivo     = (int)r["Consecutivo"],
                                TotalFactura    = (decimal)r["TotalFactura"],
                                Pago            = (bool)r["Pago"]
                            });
                        }
                    }
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
            return EntidadFactura;
        }
    }
}
