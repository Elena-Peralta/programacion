using SistemaVentas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Repositories
{
    public class VentaRepository : IVentaRepository
    {
      
        private readonly string connectionString = "Server=DESKTOP-MMKGDGT\\SQLEXPRESS;Database=SistemaVentasDB;Integrated Security=true;";

        public void Registrar(Venta venta)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Ventas (Cliente, Producto, Cantidad, Precio) VALUES (@Cliente, @Producto, @Cantidad, @Precio)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Cliente", venta.Cliente);
                    cmd.Parameters.AddWithValue("@Producto", venta.Producto);
                    cmd.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", venta.Precio);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Venta> ObtenerTodas()
        {
            List<Venta> lista = new List<Venta>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Cliente, Producto, Cantidad, Precio FROM Ventas";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Venta
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Cliente = reader["Cliente"].ToString(),
                                Producto = reader["Producto"].ToString(),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                Precio = Convert.ToDecimal(reader["Precio"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public decimal ObtenerTotalGeneralVendido()
        {
            decimal total = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(SUM(Cantidad * Precio), 0) FROM Ventas";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    total = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return total;
        }

             public string ObtenerProductoMasVendido()
        {
            string producto = "Sin ventas";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
               
                string query = "SELECT TOP 1 Producto FROM Ventas GROUP BY Producto ORDER BY SUM(Cantidad) DESC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        producto = result.ToString();
                    }
                }
            }
            return producto;
        }
    }
}
