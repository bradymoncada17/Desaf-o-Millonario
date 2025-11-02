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
    public partial class frmFormularioJuego : Form
    {
        private int usuarioId;
        private string nombreUsuario;
        private IRepositorioPreguntas _repoPreg;
        private IRepositorioPartidas _repoPart;
        private IRepositorioUsuarios _repoUsr;
        private List<PreguntaOpcionMultiple> _preguntas;
        private int _indiceActual = 0;
        private int _dinero = 0;
        private int _correctas = 0;
        private int _partidaId = 0;
        private bool _uso5050 = false, _usoPublico = false;
       

        public frmFormularioJuego(int usuarioId, string nombreUsuario, IRepositorioPreguntas repoP, IRepositorioPartidas repoPa, IRepositorioUsuarios repoU)
        {

            
            _repoPreg = repoP;
            _repoPart = repoPa;
            _repoUsr = repoU;
            CargarPreguntas();
            MostrarPregunta();
        }
        private void CargarPreguntas()
        {
            var todas = _repoPreg.ObtenerTodas();
            _preguntas = todas.OrderBy(x => Guid.NewGuid()).Take(Math.Min(15, todas.Count)).ToList();
        }

        private void btnRespuestaA_Click(object sender, EventArgs e)
        {
            var boton = (Button)sender;
            int seleccionado = Convert.ToInt32(boton.Tag);
            var p = _preguntas[_indiceActual];
            bool esCorrecto = seleccionado == p.IndiceCorrecto;
            if (esCorrecto)
            {
                _correctas++;
                _dinero += p.Premio;
                lblDinero.Text = "Dinero: " + _dinero;
                // guardar respuesta provisional al final o guardar ahora en memoria para luego persistir
                _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, true); // si la partida ya está creada
                _indiceActual++;
                MostrarPregunta();
            }
            else
            {
                MessageBox.Show("Respuesta incorrecta. Fin del juego.");
                _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, false);
                FinalizarPartida();
            }
        }

        private void btnRespuestaD_Click(object sender, EventArgs e)
        {
            var boton = (Button)sender;
            int seleccionado = Convert.ToInt32(boton.Tag);
            var p = _preguntas[_indiceActual];
            bool esCorrecto = seleccionado == p.IndiceCorrecto;
            if (esCorrecto)
            {
                _correctas++;
                _dinero += p.Premio;
                lblDinero.Text = "Dinero: " + _dinero;
                // guardar respuesta provisional al final o guardar ahora en memoria para luego persistir
                _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, true); // si la partida ya está creada
                _indiceActual++;
                MostrarPregunta();
            }
            else
            {
                MessageBox.Show("Respuesta incorrecta. Fin del juego.");
                _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, false);
                FinalizarPartida();
            }
        }

        private void btnRespuestaB_Click(object sender, EventArgs e)
        {
            var boton = (Button)sender;
            int seleccionado = Convert.ToInt32(boton.Tag);
            var p = _preguntas[_indiceActual];
            bool esCorrecto = seleccionado == p.IndiceCorrecto;
            if (esCorrecto)
            {
                _correctas++;
                _dinero += p.Premio;
                lblDinero.Text = "Dinero: " + _dinero;
                // guardar respuesta provisional al final o guardar ahora en memoria para luego persistir
                _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, true); // si la partida ya está creada
                _indiceActual++;
                MostrarPregunta();
            }
            else
            {
                MessageBox.Show("Respuesta incorrecta. Fin del juego.");
                _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, false);
                FinalizarPartida();
            }
        }

        private void btnRespuestaC_Click(object sender, EventArgs e)
        {
            var boton = (Button)sender;
            int seleccionado = Convert.ToInt32(boton.Tag);
            var p = _preguntas[_indiceActual];
            bool esCorrecto = seleccionado == p.IndiceCorrecto;
            if (esCorrecto)
            {
                _correctas++;
                _dinero += p.Premio;
                lblDinero.Text = "Dinero: " + _dinero;
                // guardar respuesta provisional al final o guardar ahora en memoria para luego persistir
                _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, true); // si la partida ya está creada
                _indiceActual++;
                MostrarPregunta();
            }
            else
            {
                MessageBox.Show("Respuesta incorrecta. Fin del juego.");
                _repoPart.GuardarRespuestaPartida(_partidaId, p.Id, null, false);
                FinalizarPartida();
            }
        }

        private void MostrarPregunta()
        {
            if (_indiceActual >= _preguntas.Count)
            {
                MessageBox.Show("¡Completaste el juego!");
                FinalizarPartida();
                return;
            }
            var p = _preguntas[_indiceActual];
            lblPregunta.Text = $"[{_indiceActual + 1}] {p.Texto}";
            btnRespuestaA.Text = "A) " + p.Opciones[0];
            btnRespuestaB.Text = "B) " + p.Opciones[1];
            btnRespuestaC.Text = "C) " + p.Opciones[2];
            btnRespuestaD.Text = "D) " + p.Opciones[3];
            btnRespuestaA.Enabled = btnRespuestaB.Enabled = btnRespuestaC.Enabled = btnRespuestaD.Enabled = true;
        }

        private void btnCincuentaCincuenta_Click(object sender, EventArgs e)
        {
            if (_uso5050) { MessageBox.Show("Ya usaste 50:50"); return; }
            var p = _preguntas[_indiceActual];
            var incorrectas = Enumerable.Range(0, 4).Where(i => i != p.IndiceCorrecto).OrderBy(x => Guid.NewGuid()).Take(2).ToList();
            foreach (var idx in incorrectas)
            {
                if (idx == 0) btnRespuestaA.Enabled = false;
                if (idx == 1) btnRespuestaB.Enabled = false;
                if (idx == 2) btnRespuestaC.Enabled = false;
                if (idx == 3) btnRespuestaD.Enabled = false;
            }
            _uso5050 = true;
        }

        public frmFormularioJuego(IRepositorioPreguntas repoPreg, IRepositorioPartidas repoPart, IRepositorioUsuarios repoUsr)
        {
            InitializeComponent();
        }

        public frmFormularioJuego(int usuarioId, string nombreUsuario)
        {
            this.usuarioId = usuarioId;
            this.nombreUsuario = nombreUsuario;
        }

        private void FinalizarPartida()
        {
            // Evitar más interacciones en la UI
            btnRespuestaA.Enabled = btnRespuestaB.Enabled = btnRespuestaC.Enabled = btnRespuestaD.Enabled = false;

            // Guardar la partida si existe el repositorio
            if (_repoPart != null)
            {
                // Si no hay partida creada, crearla y obtener el id devuelto
                if (_partidaId == 0)
                {
                    int? uid = usuarioId > 0 ? (int?)usuarioId : null;
                    _partidaId = _repoPart.GuardarPartida(uid, _dinero, _correctas);
                }
            }

            // Mensaje final al usuario
            MessageBox.Show($"Partida finalizada. Respuestas correctas: {_correctas}, Dinero ganado: {_dinero}");

            // Cerrar el formulario de juego
            this.Close();
        }
    }
}
