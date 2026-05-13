using ControlInventario.Models;
using ControlInventario.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventario
{
    public partial class FrmInventario: Form
    {
        private readonly IInventarioRepository _repository;
        public FrmInventario()
        {
            InitializeComponent();
            _repository = new InventarioRepository();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
            ActualizarValorTotal();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación básica
                if (string.IsNullOrWhiteSpace(txtProducto.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioCompra.Text))
                {
                    MessageBox.Show("Por favor, complete los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Producto nuevoProducto = new Producto
                {
                    NombreProducto = txtProducto.Text,
                    Categoria = txtCategoria.Text,
                    Cantidad = int.Parse(txtCantidad.Text),
                    PrecioCompra = decimal.Parse(txtPrecioCompra.Text)
                };

                _repository.Registrar(nuevoProducto);

                MessageBox.Show("Producto registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                ActualizarGrilla();
                ActualizarValorTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnBajoStock_Click(object sender, EventArgs e)
        {
            try
            {
                dgvInventario.DataSource = _repository.ObtenerStockMenorA(5);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metodos

        private void ActualizarGrilla()
        {
            try
            {
                dgvInventario.DataSource = _repository.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Aún no hay conexión a la BD. Error: {ex.Message}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void ActualizarValorTotal()
        {
            try
            {
                decimal total = _repository.ObtenerValorTotalInventario();
                lblValorTotal.Text = $"Valor Total: {total:C2}";
            }
            catch
            {
                lblValorTotal.Text = "Valor Total: $0.00";
            }
        }

        private void LimpiarCampos()
        {
            txtProducto.Clear();
            txtCategoria.Clear();
            txtCantidad.Clear();
            txtPrecioCompra.Clear();
            txtProducto.Focus();
        }
    }
}