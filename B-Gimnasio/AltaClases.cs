using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasesGimnasio;
using B_Gimnasio.ServiceReference1;


namespace Vista
{
    public partial class AltaClases : Form
    {
        WebService1SoapClient aCli = new WebService1SoapClient();
        

        public AltaClases()
        {
            InitializeComponent();
        }
        

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btDarAltaSecretario_Click(object sender, EventArgs e)
        {
            B_Gimnasio.ServiceReference1.Clases clase = new B_Gimnasio.ServiceReference1.Clases();
            clase.id = Convert.ToInt32(txtID.Text);
            clase.tema = txtTema.Text.ToString();
            clase.cantAlumnos = Convert.ToInt32(txtCantAlumnos.Text);
            clase.fechaInicio = txtFecha.Text;
            clase.idProfesor = Convert.ToInt32(txtIdProfe.Text);

            aCli.PostClase(clase);
            MessageBox.Show("Dada de alta satifactoriamente.");
            limpiar();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            MenuClases logeo = new MenuClases();
            logeo.Show();
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AltaProfesores_Load(object sender, EventArgs e)
        {

        }

        private void AltaProfesores_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        

       
        public void limpiar()
        {
            txtID.ResetText();
            txtTema.ResetText();
            txtCantAlumnos.ResetText();
            txtFecha.ResetText();
            txtIdProfe.ResetText();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
