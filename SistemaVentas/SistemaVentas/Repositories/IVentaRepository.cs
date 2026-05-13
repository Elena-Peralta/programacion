using System.Collections.Generic;
using SistemaVentas.Models;

namespace SistemaVentas.Repositories
{
    public interface IVentaRepository
    {
        void Registrar(Venta venta);
        List<Venta> ObtenerTodas();
        decimal ObtenerTotalGeneralVendido();
        string ObtenerProductoMasVendido();
    }
}