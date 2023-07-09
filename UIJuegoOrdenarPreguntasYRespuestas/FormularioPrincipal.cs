using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using EQuienQuiereSerIngeniero;
using BLQuienQuiereSerIngeniero;
using System.Media;
using UIJuegoOrdenarPreguntasYRespuestas.Properties;

namespace GUIQuienQuiereSerIngeniero
{
    public partial class FormularioPrincipal : Form
    {
        public BLPartida PartidaNegocio { get; set; } = new BLPartida();
        public Partida PartidaNueva { get; set; } = new Partida();
        public Jugador Usuario { get; set; } = new Jugador();

        public FormularioPrincipal()
        {
            InitializeComponent();
            personalizarDiseno();
            OcultarBarraTareas();
        }

        #region Movimiento del panel horizontal
        //Movilidad del formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        #region Movimiento del menu desplegable
        private void personalizarDiseno()
        {
            pnlTemas.Visible = false;
        }

        private void ocultarSubmenu()
        {
            if (pnlTemas.Visible == true)
            {
                pnlTemas.Visible = false;
            }
        }

        private void mostrarSubmenu(Panel subMenu)
        {
            if (pnlTemas.Visible == false)
            {

                pnlTemas.Visible = true;
            }
            else
                subMenu.Visible = false;

        }
        #endregion

        #region Mostrar y ocultar barra de tareas
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            pnlMenuVertical.Width = 50; //comienza el menu sin desplegar
            CenterPictureBox(); // comienzan centrados el pbxMillonario y el btnJugar
            //SoundPlayer introduccion = new SoundPlayer(Resources.Intro);
            //introduccion.Play();

        }
        private void CargarUsuario()
        { 
            Usuario.Id = 0;
            Usuario.Nombre = txtNombre.Text;
            Usuario.Password = txtPassword.Text;
        }
        private void CargarDificultad()
        {
            if (rbnFacil.Checked)
            {
                PartidaNueva.Dificultad = "facil";
            }
            if (rbnIntermedia.Checked)
            {
                PartidaNueva.Dificultad = "intermedia";
            }
            if (rbnDificil.Checked)
            {
                PartidaNueva.Dificultad = "dificil";
            }
        }

        
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (pnlMenuVertical.Width == 250)
            {
                pnlMenuVertical.Width = 50;
                CenterPictureBox(); // vuelven a centrarse cuando se contrae el menu
                pnlCentral.Left += -50;
                pnlJugar.Left += 100;
            }
            else
            {
                pnlMenuVertical.Width = 250;
                CenterPictureBox(); // vuelven a centrarse cuando se expande el menu
                pbxMillonario.Left += 50; // desplazamiento extra de pbxMillonario a la izquierda cuando se despliegue el menu
                btnJugar.Left += 50; // desplazamiento extra de btnJugar a la izquierda cuando se despliegue el menu
                lblTitulo.Left += 50;
                pnlCentral.Left += 50;
                pnlJugar.Left += 20;

                /*FALTA ARREGLAR CUANDO SE MAXIMIZA Y MINIMIZA*/
            }
        }

        private void CenterPictureBox()
        {
            pbxMillonario.Left = (this.ClientSize.Width - pbxMillonario.Width) / 2;
            pbxMillonario.Top = (this.ClientSize.Height - pbxMillonario.Height) / 3; // ajustar este valor para la posicion vertical a gusto

            btnJugar.Left = ((this.ClientSize.Width - btnJugar.Width) / 2) + 100;
            btnJugar.Top = this.ClientSize.Height - btnJugar.Height - 150; // ajustar el valor a gusto

            lblTitulo.Left = ((this.ClientSize.Width - lblTitulo.Width) / 2) + 100;
            lblTitulo.Top = this.ClientSize.Height - lblTitulo.Height - 600;

            pnlCentral.Left = ((this.ClientSize.Width - pnlCentral.Width) / 2) +100;

            pnlJugar.Left = ((this.ClientSize.Width - pnlJugar.Width) / 2) -120;


        }

        #region Botones del panel horizontal
        private void pnlMenuHorizontal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            MostrarBarraTareas();
            Application.Exit(); 
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnNormal.Visible = true;
            CenterPictureBox();

        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMax.Visible = true;
            btnNormal.Visible = false;
            CenterPictureBox();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region  Metodos para mostrar los temas
        private void MostrarPanelesCentrales()
        {
            pnlCentral.Visible = true;
            pnlCentralArriba.Visible = true;
            pnlCentralAbajo.Visible = true;
            //pnlCentralIzquierda.Visible = true;
            //pnlCentralDerecha.Visible = true;

        }
        private void MostrarAnalisisRequerimientos()
        {

            pbxMillonario.Visible = false;
            lblTitulo.Visible = true;
            lblTitulo.Text = "Análisis De Requerimientos:";
            lblTitulo.Left = 550;
            btnJugar.Visible = true;
            MostrarPanelesCentrales();
            CenterPictureBox();
        }

        private void MostrarDiseño()
        {

            pbxMillonario.Visible = false;
            lblTitulo.Visible = true;
            lblTitulo.Text = "Diseño:";
            lblTitulo.Left = 700;
            btnJugar.Visible = true;
            MostrarPanelesCentrales();
            CenterPictureBox();
        }

        private void MostrarCodificacion()
        {

            pbxMillonario.Visible = false;
            lblTitulo.Visible = true;
            lblTitulo.Text = "Codificación:";
            lblTitulo.Left = 680;
            btnJugar.Visible = true;
            MostrarPanelesCentrales();
            CenterPictureBox();
        }

        private void MostrarPruebas()
        {

            pbxMillonario.Visible = false;
            lblTitulo.Visible = true;
            lblTitulo.Text = "Pruebas:";
            lblTitulo.Left = 700;
            btnJugar.Visible = true;
            MostrarPanelesCentrales();
            CenterPictureBox();
        }

        private void MostrarMantenimiento()
        {

            pbxMillonario.Visible = false;
            lblTitulo.Visible = true;
            lblTitulo.Text = "Mantenimiento:";
            lblTitulo.Left = 660;
            btnJugar.Visible = true;
            MostrarPanelesCentrales();
            CenterPictureBox();
        }

        private void MostrarHimno()
        {

            pbxMillonario.Visible = false;
            lblTitulo.Visible = true;
            lblTitulo.Text = "Himno A La Escuela Politécnica Nacional:";
            lblTitulo.Left = 460;
            btnJugar.Visible = true;
            MostrarPanelesCentrales();
            CenterPictureBox();
        }
        #endregion

        #region Bontones Temas de la materia


        private void btnNuevaPartida_Click(object sender, EventArgs e)
        {
            mostrarSubmenu(pnlTemas);
        }
        private void btnAnalisisRequerimientos_Click(object sender, EventArgs e)
        {
            ocultarSubmenu();
            MostrarAnalisisRequerimientos();
            // Cargo la partida
            PartidaNueva = PartidaNegocio.CrearPartida("Analisis De Requerimientos","Facil",Usuario);
        }

        private void btnDiseno_Click(object sender, EventArgs e)
        {
            ocultarSubmenu();
            MostrarDiseño();
            // Cargo la partida
            PartidaNueva = PartidaNegocio.CrearPartida("Diseño", "Facil", Usuario);
        }

        private void btnProgramacion_Click(object sender, EventArgs e)
        {
            ocultarSubmenu();
            MostrarCodificacion();
            // Cargo la partida
            PartidaNueva = PartidaNegocio.CrearPartida("Codificacion", "Facil", Usuario);
        }

        private void btnPruebas_Click(object sender, EventArgs e)
        {
            ocultarSubmenu();
            MostrarPruebas();
            // Cargo la partida
            PartidaNueva = PartidaNegocio.CrearPartida("Pruebas", "Facil", Usuario);
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            ocultarSubmenu();
            MostrarMantenimiento();
            // Cargo la partida
            PartidaNueva = PartidaNegocio.CrearPartida("Mantenimiento", "Facil", Usuario);
        }

        private void btnEPN_Click(object sender, EventArgs e)
        {
            ocultarSubmenu();
            MostrarHimno();
            // Cargo la partida
            PartidaNueva = PartidaNegocio.CrearPartida("EPN", "Facil", Usuario);
        }
        #endregion
        private void btnJugar_Click(object sender, EventArgs e)
        {
            FormularioJuego formPartida = new FormularioJuego();
           
          
            if(txtNombre.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Por favor llene todos los campos","Login",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                CargarUsuario();
                CargarDificultad();
                formPartida.PartidaNueva = PartidaNueva;
                formPartida.Show();
            }
        }

       
    }
}
