using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EQuienQuiereSerIngeniero;
using BLQuienQuiereSerIngeniero;
using System.Runtime.InteropServices;

namespace GUIQuienQuiereSerIngeniero
{
    public partial class FormularioJuego : Form
    {
        public BLPartida PartidaNegocio { get; set; } = new BLPartida();
        public Partida PartidaNueva { get; set; } = new Partida();
        public List<Pregunta> PreguntasAleatorias { get; set; } = new List<Pregunta>();
        public List<Respuesta> RespuestasAleatorias { get; set; } = new List<Respuesta>();
        private int segundosRestantes;
        private int minutosRestantes;
        
        public FormularioJuego()
        {
            InitializeComponent();
        }

        private void FormularioJuego_Load_1(object sender, EventArgs e)
        {
            //Inicialización del tiempo
            CargarTiempo();
            tbxSegundos.Text = segundosRestantes.ToString();
            tbxMinutos.Text = $"0{minutosRestantes.ToString()}";
            tmrSegundos.Start();
            tmrMinutos.Start();
            //Cargar el usuario
            tbxUsuario.Text = PartidaNueva.Jugador.Nombre;

            //Generar preguntas y respuestas aleatorias
            PreguntasAleatorias = PartidaNegocio.ReordenarPreguntas(PartidaNueva.Preguntas);
            RespuestasAleatorias = PartidaNegocio.ReordenarRespuestas(PartidaNueva.Respuestas);

            //Cargo las preguntas
            btnPregunta1.Text = PreguntasAleatorias[0].Texto;
            btnPregunta2.Text = PreguntasAleatorias[1].Texto;
            btnPregunta3.Text = PreguntasAleatorias[2].Texto;
            btnPregunta4.Text = PreguntasAleatorias[3].Texto;
            btnPregunta5.Text = PreguntasAleatorias[4].Texto;
            btnPregunta6.Text = PreguntasAleatorias[5].Texto;
            btnPregunta7.Text = PreguntasAleatorias[6].Texto;
            btnPregunta8.Text = PreguntasAleatorias[7].Texto;

            //Cargo las respuestas
            btnRespuesta1.Text = RespuestasAleatorias[0].Texto;
            btnRespuesta2.Text = RespuestasAleatorias[1].Texto;
            btnRespuesta3.Text = RespuestasAleatorias[2].Texto;
            btnRespuesta4.Text = RespuestasAleatorias[3].Texto;
            btnRespuesta5.Text = RespuestasAleatorias[4].Texto;
            btnRespuesta6.Text = RespuestasAleatorias[5].Texto;
            btnRespuesta7.Text = RespuestasAleatorias[6].Texto;
            btnRespuesta8.Text = RespuestasAleatorias[7].Texto;
        }
       
        private void CargarTiempo()
        {
            if (PartidaNueva.Dificultad == "facil")
            {
                minutosRestantes = 4;
                segundosRestantes = 59;
            }
            if (PartidaNueva.Dificultad == "intermedia")
            {
                minutosRestantes = 3;
                segundosRestantes = 59;
            }
            if (PartidaNueva.Dificultad == "dificil")
            {
                minutosRestantes = 0;
                segundosRestantes = 59;
            }
        }
      
        #region Mostrar y ocultar barra de tareas de Windows
        private const int SWP_HIDEWINDOW = 0x0080;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int HWND_BOTTOM = 1;
        private const int HWND_NOTOPMOST = -2;
        private const int HWND_TOP = 0;
        private const int HWND_TOPMOST = -1;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        private void OcultarBarraTareas()
        {
            IntPtr taskBarHandle = FindWindow("Shell_TrayWnd", null);
            SetWindowPos(taskBarHandle, HWND_BOTTOM, 0, 0, 0, 0, SWP_HIDEWINDOW);
        }
        private void MostrarBarraTareas()
        {
            IntPtr taskBarHandle = FindWindow("Shell_TrayWnd", null);
            SetWindowPos(taskBarHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_SHOWWINDOW);

        }
        #endregion

        #region Botones Panel Horizontal Arriba

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            FormularioPrincipal formularioPrincipal = new FormularioPrincipal();
            DialogResult result = MessageBox.Show("¿Está seguro que desea salir del juego?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Hide();
                tmrMinutos.Stop();
                tmrSegundos.Stop();
                formularioPrincipal.ShowDialog();
                this.Close();
            }else if(result == DialogResult.Cancel)
            {
                this.Show();
            }
        }
        private void pbxClose_Click(object sender, EventArgs e)
        {
            MostrarBarraTareas();
            Application.Exit();
        }

        private void pbxNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pbxMax.Visible = true;
            pbxNormal.Visible = false;
            pnlPreguntas.Height = 330;
            pnlRespuestas.Height = 330;
            pbxFlecha1.Location = new Point(635, 110);
            pbxFlecha2.Location = new Point(635, 110);
        }

        private void pbxMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pbxMax.Visible = false;
            pbxNormal.Visible = true;
            pnlPreguntas.Height= 380;
            pnlRespuestas.Height= 380;
            pbxFlecha1.Location = new Point(720, 110) ;
            pbxFlecha2.Location = new Point(720, 160) ;
        }
        private void pbxMin_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }
        private void pbxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnNormal.Visible = false;
            
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnNormal.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Botones Preguntas y Respuestas
        private void SeñalarPregunta()
        {
            pnlPreguntas.BackColor = Color.Yellow;
            pnlRespuestas.BackColor = Color.White;
        }
        private void SeñalarRespuesta()
        {
            pnlRespuestas.BackColor = Color.Yellow;
            pnlPreguntas.BackColor = Color.White;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormularioPrincipal formPrincipal = new FormularioPrincipal();
            formPrincipal.ShowDialog();
            this.Close();
        }
        private void QuitarSeñal()
        {
            if (cbxRespuesta.Checked && cbxPregunta.Checked)
            {
                pnlRespuestas.BackColor = Color.White;
                pnlPreguntas.BackColor = Color.White;
            }
        }
        private void btnPregunta1_Click(object sender, EventArgs e)
        {
            SeleccionPreguntaNueva();
            lblPregunta.Text = btnPregunta1.Text;
            btnPregunta1.BackColor = Color.Yellow;
            btnPregunta1.ForeColor = Color.Black;
            // Verificar si se tiene una pregunta
            cbxPregunta.Checked = true;

            SeñalarRespuesta();
           
            SetVisualizacion();
        }

        private void btnPregunta2_Click(object sender, EventArgs e)
        {
            
            SeleccionPreguntaNueva();
            lblPregunta.Text = btnPregunta2.Text;
            btnPregunta2.BackColor = Color.Yellow;
            btnPregunta2.ForeColor = Color.Black;

            cbxPregunta.Checked = true;

            SeñalarRespuesta();
            SetVisualizacion();
        }
        private void btnPregunta3_Click(object sender, EventArgs e)
        {
            SeleccionPreguntaNueva();
            lblPregunta.Text = btnPregunta3.Text;
            btnPregunta3.BackColor = Color.Yellow;
            btnPregunta3.ForeColor = Color.Black;

            cbxPregunta.Checked = true;

            SeñalarRespuesta();
            SetVisualizacion();
        }

        private void btnPregunta4_Click(object sender, EventArgs e)
        {
            SeleccionPreguntaNueva();
            lblPregunta.Text = btnPregunta4.Text;
            btnPregunta4.BackColor = Color.Yellow;
            btnPregunta4.ForeColor = Color.Black;

            cbxPregunta.Checked = true;

            SeñalarRespuesta();
            SetVisualizacion();
        }

        private void btnPregunta5_Click(object sender, EventArgs e)
        {
            SeleccionPreguntaNueva();
            lblPregunta.Text = btnPregunta5.Text;
            btnPregunta5.BackColor = Color.Yellow;
            btnPregunta5.ForeColor = Color.Black;

            cbxPregunta.Checked = true;

            SeñalarRespuesta();
            SetVisualizacion();
        }

        private void btnPregunta6_Click(object sender, EventArgs e)
        {
            SeleccionPreguntaNueva();
            lblPregunta.Text = btnPregunta6.Text;
            btnPregunta6.BackColor = Color.Yellow;
            btnPregunta6.ForeColor = Color.Black;

            cbxPregunta.Checked = true;

            SeñalarRespuesta();
            SetVisualizacion();
        }

        private void btnPregunta7_Click(object sender, EventArgs e)
        {
            SeleccionPreguntaNueva();
            lblPregunta.Text = btnPregunta7.Text;
            btnPregunta7.BackColor = Color.Yellow;
            btnPregunta7.ForeColor = Color.Black;

            cbxPregunta.Checked = true;

            SeñalarRespuesta();
            SetVisualizacion();
        }

        private void btnPregunta8_Click(object sender, EventArgs e)
        {
            SeleccionPreguntaNueva();
            lblPregunta.Text = btnPregunta8.Text;
            btnPregunta8.BackColor = Color.Yellow;
            btnPregunta8.ForeColor = Color.Black;

            cbxPregunta.Checked = true;

            SeñalarRespuesta();

            SetVisualizacion();
        }


        private void btnRespuesta1_Click_1(object sender, EventArgs e)
        {
            SeleccionRespuestaNueva();
            lblRespuesta.Text = btnRespuesta1.Text;
            btnRespuesta1.BackColor = Color.Yellow;
            btnRespuesta1.ForeColor = Color.Black;
            //Verificar si tiene respuesta
            cbxRespuesta.Checked = true;
            SeñalarPregunta();
            
            SetVisualizacion();
        }

        private void btnRespuesta2_Click_1(object sender, EventArgs e)
        {
            SeleccionRespuestaNueva();
            lblRespuesta.Text = btnRespuesta2.Text;
            btnRespuesta2.BackColor = Color.Yellow;
            btnRespuesta2.ForeColor = Color.Black;
            cbxRespuesta.Checked = true;
            SeñalarPregunta();
            SetVisualizacion();
        }

        private void btnRespuesta3_Click_1(object sender, EventArgs e)
        {
            SeleccionRespuestaNueva();
            lblRespuesta.Text = btnRespuesta3.Text;
            btnRespuesta3.BackColor = Color.Yellow;
            btnRespuesta3.ForeColor = Color.Black;
            cbxRespuesta.Checked = true;
            SeñalarPregunta();
            SetVisualizacion();
        }

        private void btnRespuesta4_Click_1(object sender, EventArgs e)
        {
            SeleccionRespuestaNueva();
            lblRespuesta.Text = btnRespuesta4.Text;
            btnRespuesta4.BackColor = Color.Yellow;
            btnRespuesta4.ForeColor = Color.Black;
            cbxRespuesta.Checked = true;
            SeñalarPregunta();
            SetVisualizacion();
        }

        private void btnRespuesta5_Click_1(object sender, EventArgs e)
        {
            SeleccionRespuestaNueva();
            lblRespuesta.Text = btnRespuesta5.Text;
            btnRespuesta5.BackColor = Color.Yellow;
            btnRespuesta5.ForeColor = Color.Black;
            cbxRespuesta.Checked = true;
            SeñalarPregunta();
            SetVisualizacion();
        }

        private void btnRespuesta6_Click_1(object sender, EventArgs e)
        {
            SeleccionRespuestaNueva();
            lblRespuesta.Text = btnRespuesta6.Text;
            btnRespuesta6.BackColor = Color.Yellow;
            btnRespuesta6.ForeColor = Color.Black;
            cbxRespuesta.Checked = true;
            SeñalarPregunta();
            SetVisualizacion();
        }

        private void btnRespuesta7_Click_1(object sender, EventArgs e)
        {
            SeleccionRespuestaNueva();
            lblRespuesta.Text = btnRespuesta7.Text;
            btnRespuesta7.BackColor = Color.Yellow;
            btnRespuesta7.ForeColor = Color.Black;
            cbxRespuesta.Checked = true;
            SeñalarPregunta();
            SetVisualizacion();
        }

        private void btnRespuesta8_Click_1(object sender, EventArgs e)
        {
            SeleccionRespuestaNueva();
            lblRespuesta.Text = btnRespuesta8.Text;
            btnRespuesta8.BackColor = Color.Yellow;
            btnRespuesta8.ForeColor = Color.Black;
            cbxRespuesta.Checked = true;
            SeñalarPregunta();
            SetVisualizacion();
        }

        private void SeleccionRespuestaNueva()
        {
            if (cbxRespuesta.Checked)
            {
                EstadoNormalBotones();
            }
        }

        private void SeleccionPreguntaNueva()
        {
            if (cbxPregunta.Checked)
            {
                EstadoNormalBotones();
            }
        }



        #endregion

        #region Modalidad del juego

        private bool ValidacionPregunta()
        {
            if (lblPregunta.Text == PreguntasAleatorias[0].Texto ||
                lblPregunta.Text == PreguntasAleatorias[1].Texto ||
                lblPregunta.Text == PreguntasAleatorias[2].Texto ||
                lblPregunta.Text == PreguntasAleatorias[3].Texto ||
                lblPregunta.Text == PreguntasAleatorias[4].Texto ||
                lblPregunta.Text == PreguntasAleatorias[5].Texto ||
                lblPregunta.Text == PreguntasAleatorias[6].Texto ||
                lblPregunta.Text == PreguntasAleatorias[7].Texto
                )
                return true;
            return false;
        }
        private bool ValidacionRespuesta()
        {
            if (lblRespuesta.Text == RespuestasAleatorias[0].Texto ||
                lblRespuesta.Text == RespuestasAleatorias[1].Texto ||
                lblRespuesta.Text == RespuestasAleatorias[2].Texto ||
                lblRespuesta.Text == RespuestasAleatorias[3].Texto ||
                lblRespuesta.Text == RespuestasAleatorias[4].Texto ||
                lblRespuesta.Text == RespuestasAleatorias[5].Texto ||
                lblRespuesta.Text == RespuestasAleatorias[6].Texto ||
                lblRespuesta.Text == RespuestasAleatorias[7].Texto
                )
                return true;
            return false;
        }

        private void AumentarAciertos()
        {
            string aciertos = lblAciertos.Text;
            lblAciertos.Text = PartidaNegocio.AumentarAciertos(aciertos).ToString();
        }

        private void AumentarIntentos()
        {
            string intentos = lblIntentos.Text;
            lblIntentos.Text = PartidaNegocio.AumentarIntentos(intentos).ToString();
        }

        private void AumentarPuntos()
        {
            string puntos = lblPuntos.Text;
            lblPuntos.Text = PartidaNegocio.AumentarPuntos(puntos).ToString();
        }

        private void DeshabilitarBotones()
        {
            if(lblPregunta.Text == btnPregunta1.Text)
            {
                btnPregunta1.Enabled = false;
                btnPregunta1.BackColor = Color.FromArgb(152,152,152);
            }
            if (lblPregunta.Text == btnPregunta2.Text)
            {
                btnPregunta2.Enabled = false;
                btnPregunta2.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblPregunta.Text == btnPregunta3.Text)
            {
                btnPregunta3.Enabled = false;
                btnPregunta3.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblPregunta.Text == btnPregunta4.Text)
            {
                btnPregunta4.Enabled = false;
                btnPregunta4.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblPregunta.Text == btnPregunta5.Text)
            {
                btnPregunta5.Enabled = false;
                btnPregunta5.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblPregunta.Text == btnPregunta6.Text)
            {
                btnPregunta6.Enabled = false;
                btnPregunta6.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblPregunta.Text == btnPregunta7.Text)
            {
                btnPregunta7.Enabled = false;
                btnPregunta7.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblPregunta.Text == btnPregunta8.Text)
            {
                btnPregunta8.Enabled = false;
                btnPregunta8.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblRespuesta.Text == btnRespuesta1.Text)
            {
                btnRespuesta1.Enabled = false;
                btnRespuesta1.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblRespuesta.Text == btnRespuesta2.Text)
            {
                btnRespuesta2.Enabled = false;
                btnRespuesta2.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblRespuesta.Text == btnRespuesta3.Text)
            {
                btnRespuesta3.Enabled = false;
                btnRespuesta3.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblRespuesta.Text == btnRespuesta4.Text)
            {
                btnRespuesta4.Enabled = false;
                btnRespuesta4.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblRespuesta.Text == btnRespuesta5.Text)
            {
                btnRespuesta5.Enabled = false;
                btnRespuesta5.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblRespuesta.Text == btnRespuesta6.Text)
            {
                btnRespuesta6.Enabled = false;
                btnRespuesta6.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblRespuesta.Text == btnRespuesta7.Text)
            {
                btnRespuesta7.Enabled = false;
                btnRespuesta7.BackColor = Color.FromArgb(152, 152, 152);
            }
            if (lblRespuesta.Text == btnRespuesta8.Text)
            {
                btnRespuesta8.Enabled = false;
                btnRespuesta8.BackColor = Color.FromArgb(152, 152, 152);
            }
        }

        private void EstadoNormalBotones()
        {
            if (lblPregunta.Text == btnPregunta1.Text)
            {              
                btnPregunta1.BackColor = Color.FromArgb(33, 38, 78);
                btnPregunta1.ForeColor = Color.White;
            }
            if (lblPregunta.Text == btnPregunta2.Text)
            {
                btnPregunta2.BackColor = Color.FromArgb(33, 38, 78);
                btnPregunta2.ForeColor = Color.White;
            }
            if (lblPregunta.Text == btnPregunta3.Text)
            {
                btnPregunta3.BackColor = Color.FromArgb(33, 38, 78);
                btnPregunta3.ForeColor = Color.White;
            }
            if (lblPregunta.Text == btnPregunta4.Text)
            {
                btnPregunta4.BackColor = Color.FromArgb(33, 38, 78);
                btnPregunta4.ForeColor = Color.White;
            }
            if (lblPregunta.Text == btnPregunta5.Text)
            {
                btnPregunta5.BackColor = Color.FromArgb(33, 38, 78);
                btnPregunta5.ForeColor = Color.White;
            }
            if (lblPregunta.Text == btnPregunta6.Text)
            {
                btnPregunta6.BackColor = Color.FromArgb(33, 38, 78);
                btnPregunta6.ForeColor = Color.White;
            }
            if (lblPregunta.Text == btnPregunta7.Text)
            {
                btnPregunta7.BackColor = Color.FromArgb(33, 38, 78);
                btnPregunta7.ForeColor = Color.White;
            }
            if (lblPregunta.Text == btnPregunta8.Text)
            {
                btnPregunta8.BackColor = Color.FromArgb(33, 38, 78);
                btnPregunta8.ForeColor = Color.White;
            }
            if (lblRespuesta.Text == btnRespuesta1.Text)
            {
                btnRespuesta1.BackColor = Color.FromArgb(33, 38, 78);
                btnRespuesta1.ForeColor = Color.White;
            }
            if (lblRespuesta.Text == btnRespuesta2.Text)
            {
                btnRespuesta2.BackColor = Color.FromArgb(33, 38, 78);
                btnRespuesta2.ForeColor = Color.White;
            }
            if (lblRespuesta.Text == btnRespuesta3.Text)
            {
                btnRespuesta3.BackColor = Color.FromArgb(33, 38, 78);
                btnRespuesta3.ForeColor = Color.White;
            }
            if (lblRespuesta.Text == btnRespuesta4.Text)
            {
                btnRespuesta4.BackColor = Color.FromArgb(33, 38, 78);
                btnRespuesta4.ForeColor = Color.White;
            }
            if (lblRespuesta.Text == btnRespuesta5.Text)
            {
                btnRespuesta5.BackColor = Color.FromArgb(33, 38, 78);
                btnRespuesta5.ForeColor = Color.White;
            }
            if (lblRespuesta.Text == btnRespuesta6.Text)
            {
                btnRespuesta6.BackColor = Color.FromArgb(33, 38, 78);
                btnRespuesta6.ForeColor = Color.White;
            }
            if (lblRespuesta.Text == btnRespuesta7.Text)
            {
                btnRespuesta7.BackColor = Color.FromArgb(33, 38, 78);
                btnRespuesta7.ForeColor = Color.White;
            }
            if (lblRespuesta.Text == btnRespuesta8.Text)
            {
                btnRespuesta8.BackColor = Color.FromArgb(33, 38, 78);
                btnRespuesta8.ForeColor = Color.White;
            }
        }

        private void AumentarMrIncreible()
        {
            if (pbxUser.ImageIndex == -1)
            {
                pbxUser.ImageIndex = 0;
            }
            else
            {
                pbxUser.ImageIndex--;
            }
        }

        private void DismunirMrIncreible()
        {
            pbxUser.ImageIndex++;
        }
        private void MatchPreguntaRespuesta()
        {
            string pregunta = lblPregunta.Text;
            string respuesta = lblRespuesta.Text;

            // Verifico si la pregunta corresponde con la respuesta para hacer match
            if (PartidaNegocio.VerificarPreguntaRespuesta(pregunta, respuesta))
            {
                AumentarAciertos();
                AumentarIntentos();
                AumentarPuntos();
                //MessageBox.Show("Correcto");
                AumentarMrIncreible();
                DeshabilitarBotones();

                //Validacion para ganar la partida
                if (Convert.ToInt32(lblAciertos.Text)==8)
                {
                    tmrMinutos.Stop();
                    tmrSegundos.Stop();
                    this.Controls.Add(pnlGanar);
                    pnlGanar.BringToFront();
                    pnlGanar.Visible = true;
                    pbxGanar.Visible = true;
                    //MessageBox.Show("Has ganado");
                }


            }
            else if (!PartidaNegocio.VerificarPreguntaRespuesta(pregunta, respuesta))
            {
                AumentarIntentos();
                //MessageBox.Show("Error");
                DismunirMrIncreible();
                EstadoNormalBotones();
            }
        }
        
        private void SetVisualizacion()
        {
            if (cbxPregunta.Checked && cbxRespuesta.Checked)
            {
                QuitarSeñal();
                lblPregunta.Text = "Selecione una pregunta";
                lblRespuesta.Text = "Selecione una respuesta";
                cbxPregunta.Checked = false;
                cbxRespuesta.Checked = false;
            }
        }

     

        private void cbxPregunta_CheckedChanged(object sender, EventArgs e)
        {
            

            if (ValidacionPregunta() && ValidacionRespuesta() && cbxRespuesta.Checked && cbxPregunta.Checked)
            {
                // Verifico si la pregunta y la respuesta corresponden a partir de su ID
                MatchPreguntaRespuesta();
                
            }
        }

        private void cbxRespuesta_CheckedChanged(object sender, EventArgs e)
        {
            if (ValidacionPregunta() && ValidacionRespuesta() && cbxPregunta.Checked && cbxRespuesta.Checked)
            {
                // Verifico si la pregunta y la respuesta corresponden a partir de su ID
                MatchPreguntaRespuesta();
                
            }
        }


        #endregion

        #region Cronometro Bomba
        private void tmrSegundos_Tick(object sender, EventArgs e)
        {
            segundosRestantes--;
            if (segundosRestantes == -1)
            {
                segundosRestantes = 59;
            }
            if (segundosRestantes < 10)
            {
                tbxSegundos.Text = $"0{segundosRestantes.ToString()}";
            }
            else
            {
                tbxSegundos.Text = segundosRestantes.ToString();
            }       
            if (segundosRestantes == 0 && minutosRestantes == 0)
            {
                tmrSegundos.Stop();
                this.Controls.Add(pnlFinDelJuego);
                pnlFinDelJuego.BringToFront();
                pnlFinDelJuego.Visible = true;
                pbxPerder.Visible= true;
                //MessageBox.Show($"¡PERDISTE!\nDon Alfonso viendote decepcionado, porqué no sabe que futuro le espera contigo como ingeniero.","GAME OVER",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
          
           
        }

        private void tmrMinutos_Tick(object sender, EventArgs e)
        {
            minutosRestantes--;
            if (minutosRestantes < 10)
            {
                tbxMinutos.Text = $"0{minutosRestantes.ToString()}";
            }
            else
            {
                tbxMinutos.Text = minutosRestantes.ToString();
            }        
            if (minutosRestantes == 0)
            {
                tmrMinutos.Stop();
            }
        }


        #endregion

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
