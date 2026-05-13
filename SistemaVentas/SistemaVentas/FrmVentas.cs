using SistemaVentas.Models;
using SistemaVentas.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentas
{
    public partial class FrmVentas: Form
    {
        private readonly IVentaRepository _repository;
        public FrmVentas()
        {
            InitializeComponent();
            _repository = new VentaRepository();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Venta nuevaVenta = new Venta
                {
                    Cliente = txtCliente.Text,
                    Producto = txtProducto.Text,
                    Cantidad = int.Parse(txtCantidad.Text),
                    Precio = decimal.Parse(txtPrecio.Text)
                };

                _repository.Registrar(nuevaVenta);
                MessageBox.Show("Venta registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                txtCliente.Clear(); txtProducto.Clear(); txtCantidad.Clear(); txtPrecio.Clear();
                txtCliente.Focus();

             
                ActualizarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void ActualizarDatos()
        {
            try
            {
              
                dgvVentas.DataSource = _repository.ObtenerTodas();

             
                decimal totalGeneral = _repository.ObtenerTotalGeneralVendido();
                lblTotalGeneral.Text = $"Total General: {totalGeneral:C2}";

                
                string productoEstrella = _repository.ObtenerProductoMasVendido();
                lblProductoMasVendido.Text = $"Producto más vendido: {productoEstrella}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron cargar los datos de la BD: {ex.Message}");
            }
        }

    }
    }
