using System;
using System.Windows.Forms;

namespace ControlInventario
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Aquí le decimos que arranque abriendo tu formulario FrmInventario
            Application.Run(new FrmInventario());
        }
    }
}