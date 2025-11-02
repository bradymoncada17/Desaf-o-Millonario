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
    public partial class FormularioJuego : Form
    {
        public FormularioJuego(IRepositorioPreguntas repoPreg, IRepositorioPartidas repoPart, IRepositorioUsuarios repoUsr)
        {
            InitializeComponent();
        }
    }
}
