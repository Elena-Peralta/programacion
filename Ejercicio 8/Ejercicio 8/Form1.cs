namespace Ejercicio_8
{
    public partial class Form1 : Form
    {
        PacienteRepository repo = new PacienteRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Paciente p = new Paciente();

            p.Nombre = txtNombre.Text;
            p.Edad = int.Parse(txtEdad.Text);
            p.Diagnostico = txtDiagnostico.Text;

            repo.Registrar(p);

            MessageBox.Show("Paciente registrado");

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var lista = repo.BuscarPorNombre(txtNombre.Text);
            dgvPacientes.DataSource = lista;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var lista = repo.MayoresDe60();
            dgvPacientes.DataSource = lista;

        }
    }
}
