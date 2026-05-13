using ControlInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlInventario.Repositories
{
    public interface IInventarioRepository
    {
        void Registrar(Producto producto);
        List<Producto> ObtenerTodos();
        List<Producto> ObtenerStockMenorA(int limite);
        decimal ObtenerValorTotalInventario();
    }
}
