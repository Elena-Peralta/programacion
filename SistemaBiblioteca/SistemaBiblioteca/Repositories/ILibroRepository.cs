using SistemaBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Repositories
{
    public interface ILibroRepository
    {
            void Registrar(Libro libro);
            void ActualizarDisponibilidad(int id, bool estaDisponible);
            List<Libro> ObtenerTodos();
            List<Libro> MostrarSoloDisponibles();
            List<Libro> BuscarPorAutor(string autor);
        
    }
}