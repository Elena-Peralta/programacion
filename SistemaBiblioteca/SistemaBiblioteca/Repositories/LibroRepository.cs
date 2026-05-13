using SistemaBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaBiblioteca.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly string connectionString = "Server=DESKTOP-MMKGDGT\\SQLEXPRESS;Database=BibliotecaDB;Integrated Security=true;";

        public void Registrar(Libro libro)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Corrección: INSERT INTO Libro
                string query = "INSERT INTO Libro (Titulo, Autor, AñoPublicacion, Disponible) VALUES (@Titulo, @Autor, @Anio, @Disponible)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                    cmd.Parameters.AddWithValue("@Anio", libro.AñoPublicacion);
                    cmd.Parameters.AddWithValue("@Disponible", libro.Disponible);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarDisponibilidad(int id, bool estaDisponible)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Corrección: UPDATE Libro
                string query = "UPDATE Libro SET Disponible = @Disponible WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Disponible", estaDisponible);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Libro> ObtenerTodos()
        {
            // Corrección: SELECT * FROM Libro
            return EjecutarConsulta("SELECT * FROM Libro");
        }

        public List<Libro> MostrarSoloDisponibles()
        {
            // Corrección: SELECT * FROM Libro
            return EjecutarConsulta("SELECT * FROM Libro WHERE Disponible = 1");
        }

        public List<Libro> BuscarPorAutor(string autor)
        {
            // Corrección: SELECT * FROM Libro
            return EjecutarConsulta($"SELECT * FROM Libro WHERE Autor LIKE '%{autor}%'");
        }

        // Método auxiliar para no repetir código de lectura (No requiere cambios en el query, solo lo ejecuta)
        private List<Libro> EjecutarConsulta(string query)
        {
            List<Libro> lista = new List<Libro>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Libro
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Titulo = reader["Titulo"].ToString(),
                                Autor = reader["Autor"].ToString(),
                                AñoPublicacion = Convert.ToInt32(reader["AñoPublicacion"]),
                                Disponible = Convert.ToBoolean(reader["Disponible"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}