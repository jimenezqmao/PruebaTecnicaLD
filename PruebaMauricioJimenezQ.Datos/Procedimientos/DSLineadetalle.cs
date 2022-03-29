using PruebaMauricioJimenezQ.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PruebaMauricioJimenezQ.Datos
{
    public class DSLineadetalle
    {
        public void RegistrarLineadetalle(string FacturaId, string ArticuloId, decimal PrecioUnitario, int Cantidad, decimal TotalLinea)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_LineaDetalleRegistrar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FacturaId", SqlDbType.NVarChar).Value = FacturaId;
                    cmd.Parameters.Add("@ArticuloId", SqlDbType.NVarChar).Value = ArticuloId;
                    cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Money).Value = PrecioUnitario;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
                    cmd.Parameters.Add("@TotalLinea", SqlDbType.Money).Value = TotalLinea;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public void ActualizarLineadetalle(string LineaDetalleId, string FacturaId, string ArticuloId, decimal PrecioUnitario, int Cantidad, decimal TotalLinea)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_LineaDetalleActualizar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LineaDetalleId", SqlDbType.NVarChar).Value = LineaDetalleId;
                    cmd.Parameters.Add("@FacturaId", SqlDbType.NVarChar).Value = FacturaId;
                    cmd.Parameters.Add("@ArticuloId", SqlDbType.NVarChar).Value = ArticuloId;
                    cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Money).Value = PrecioUnitario;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
                    cmd.Parameters.Add("@TotalLinea", SqlDbType.Money).Value = TotalLinea;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public void EliminarLineadetalle(string LineaDetalleId)
        {
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_LineaDetalleEliminar", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LineaDetalleId", SqlDbType.NVarChar).Value = LineaDetalleId;
                    cmd.ExecuteReader();
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
        }

        public List<ETLineadetalle> ObtenerLineadetalles(string FacturaId)
        {
            List<ETLineadetalle> EntidadLineadetalle = new List<ETLineadetalle>();
            try
            {
                SqlConnection StringConexion = new SqlConnection((ConfigurationManager.ConnectionStrings["ConexionMauricioBD"].ToString()));
                StringConexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_LineadetalleObtener", StringConexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FacturaId", SqlDbType.NVarChar).Value = FacturaId;
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            EntidadLineadetalle.Add(new ETLineadetalle()
                            {
                                LineadetalleId  = (Guid)r["LineadetalleId"],
                                FacturaId       = (Guid)r["FacturaId"],
                                ArticuloId      = (Guid)r["ArticuloId"],
                                NombreArticulo  = (string)r["NombreArticulo"],
                                PrecioUnitario  = (decimal)r["PrecioUnitario"],
                                Cantidad        = (int)r["Cantidad"],
                                TotalLinea      = (decimal)r["TotalLinea"]
                            });
                        }
                    }
                }
                StringConexion.Close();
            }
            catch (Exception)
            { }
            return EntidadLineadetalle;
        }
    }
}
