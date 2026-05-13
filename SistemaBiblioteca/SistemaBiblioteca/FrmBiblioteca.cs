using SistemaBiblioteca.Models;
using SistemaBiblioteca.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBiblioteca
{
    public partial class FrmBiblioteca: Form
    {
        private readonly ILibroRepository _repository;
        public FrmBiblioteca()
        {
            InitializeComponent();
            _repository = new LibroRepository();
        }

        private void FrmBiblioteca_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Libro nuevoLibro = new Libro
                {
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    AñoPublicacion = int.Parse(txtAnio.Text),
                    Disponible = chkDisponible.Checked
                };

                _repository.Registrar(nuevoLibro);
                MessageBox.Show("Libro registrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTitulo.Clear(); txtAutor.Clear(); txtAnio.Clear(); chkDisponible.Checked = false;
                ActualizarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar: {ex.Message}");
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnMostrarDisponibles_Click(object sender, EventArgs e)
        {
            dgvLibros.DataSource = _repository.MostrarSoloDisponibles();
        }

        private void btnBuscarAutor_Click(object sender, EventArgs e)
        {
            string autor = txtBuscarAutor.Text.Trim();
            dgvLibros.DataSource = _repository.BuscarPorAutor(autor);
        }

        private void btnCambiarDisponibilidad_Click(object sender, EventArgs e)
        {
            if (dgvLibros.CurrentRow != null)
            {
               
                int id = Convert.ToInt32(dgvLibros.CurrentRow.Cells["Id"].Value);
                bool estadoActual = Convert.ToBoolean(dgvLibros.CurrentRow.Cells["Disponible"].Value);

                _repository.ActualizarDisponibilidad(id, !estadoActual);

                MessageBox.Show("Disponibilidad actualizada.");
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un libro de la tabla primero.");
            }
        }

        private void ActualizarGrilla()
        {
            dgvLibros.DataSource = _repository.ObtenerTodos();
        }

    }
}
