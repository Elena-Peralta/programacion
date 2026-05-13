using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ControlInventario.Models;

namespace ControlInventario.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=ControlInventarioDB;Integrated Security=true;";

        public void Registrar(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Inventario (Producto, Categoria, Cantidad, PrecioCompra) VALUES (@Producto, @Categoria, @Cantidad, @PrecioCompra)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Producto", producto.NombreProducto);
                    cmd.Parameters.AddWithValue("@Categoria", producto.Categoria);
                    cmd.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Producto> ObtenerTodos()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Producto, Categoria, Cantidad, PrecioCompra FROM Inventario";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                NombreProducto = reader["Producto"].ToString(),
                                Categoria = reader["Categoria"].ToString(),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public List<Producto> ObtenerStockMenorA(int limite)
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Producto, Categoria, Cantidad, PrecioCompra FROM Inventario WHERE Cantidad < @Limite";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Limite", limite);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                NombreProducto = reader["Producto"].ToString(),
                                Categoria = reader["Categoria"].ToString(),
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                PrecioCompra = Convert.ToDecimal(reader["PrecioCompra"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public decimal ObtenerValorTotalInventario()
        {
            decimal total = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(SUM(Cantidad * PrecioCompra), 0) FROM Inventario";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    total = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            return total;
        }
    }
}