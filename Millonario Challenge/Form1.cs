using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Millonario_Challenge
{
    public partial class FormularioPrincipal : Form
    {
        private readonly IRepositorioPreguntas _repoPreg;
        private readonly IRepositorioPartidas _repoPart;
        private readonly IRepositorioUsuarios _repoUsr;
        private int _usuarioId;
        private string _nombreUsuario;
        public FormularioPrincipal(int usuarioId, string nombreUsuario)
        {
            InitializeComponent();
            _repoPreg = new RepositorioPreguntasSql();
            _repoPart = new RepositorioPartidasSql() as IRepositorioPartidas;
            _repoUsr = new RepositorioUsuariosSql();
            lblBienvenida.Text = $"¡Bienvenido, {_nombreUsuario}!";
        }

        public FormularioPrincipal()
        {
        }

        private void btnIniciarJuego_Click(object sender, EventArgs e)
        {
            var frm = new FormularioJuego(_usuarioId, _nombreUsuario);
            frm.ShowDialog();
        }

        private void btnAdministrarPreguntas_Click(object sender, EventArgs e)
        {
            var frm = new FormularioAdmin(_repoPreg);
            frm.ShowDialog();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            var frm = new FormularioRanking();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
