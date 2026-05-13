using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_8
{
    public class PacienteRepository
    {

        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=SistemaMedicoDB;Integrated Security=true;";

        // Registrar paciente
        public void Registrar(Paciente paciente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Pacientes (Nombre, Edad, Diagnostico) VALUES (@Nombre, @Edad, @Diagnostico)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@Edad", paciente.Edad);
                cmd.Parameters.AddWithValue("@Diagnostico", paciente.Diagnostico);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Paciente> BuscarPorNombre(string nombre)
        {
            List<Paciente> lista = new List<Paciente>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Pacientes WHERE Nombre LIKE @Nombre";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Paciente
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Edad = Convert.ToInt32(reader["Edad"]),
                        Diagnostico = reader["Diagnostico"].ToString()
                    });
                }
            }

            return lista;
        }

        public List<Paciente> MayoresDe60()
        {
            List<Paciente> lista = new List<Paciente>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Pacientes WHERE Edad > 60";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Paciente
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Edad = Convert.ToInt32(reader["Edad"]),
                        Diagnostico = reader["Diagnostico"].ToString()
                    });
                }
            }

            return lista;
        }
    }

}
}
