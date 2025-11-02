using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Millonario_Challenge
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            // Estas dos líneas deben ir primero siempre
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Aquí probamos si la conexión a la base de datos funciona
            try
            {
                var conexion = ConexionBD.Instancia.ObtenerConexion();
                MessageBox.Show("Conexión correcta a la base de datos");
                ConexionBD.Instancia.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                return; // Si falla, se detiene el programa
            }

            // Ahora se muestra el formulario donde el jugador pone su nombre
            FormularioRegistroUsuario registro = new FormularioRegistroUsuario();

            // Si el usuario presiona "Registrar y continuar"
            if (registro.ShowDialog() == DialogResult.OK)
            {
                // Abrimos el menú principal con los datos del jugador
                FormularioPrincipal menu = new FormularioPrincipal(registro.UsuarioId, registro.NombreUsuario);
                Application.Run(menu);
            }
            else
            {
                // Si cierra o cancela, se termina el programa
                Application.Exit();
            }
        }
    }
}
