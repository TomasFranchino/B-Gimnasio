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
    public partial class AltaProfesores : Form
    {
        WebService1SoapClient aCli = new WebService1SoapClient();
        

        public AltaProfesores()
        {
            InitializeComponent();
        }
        


        //Profesores paraAltaProfesores=new Profesores();
        //Principal principal=new Principal();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btDarAltaSecretario_Click(object sender, EventArgs e)
        {
            
            B_Gimnasio.ServiceReference1.Calendario profe = new B_Gimnasio.ServiceReference1.Calendario();
            B_Gimnasio.ServiceReference1.Clases clases =  aCli.GetClase(Convert.ToInt32(txtIdClase.Text));
            profe.id = Convert.ToInt32(txtId.Text);
            profe.dniProfesor = Convert.ToInt32(txtDNI.Text);
            profe.nombre = txtNombre.Text;
            profe.titulo = txtTitulo.Text;
            profe.clases.Append(clases);
            
            aCli.PostProfesor(profe);
            MessageBox.Show("Dado de alta satifactoriamente.");
            limpiar();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            MenuProfesores logeo = new MenuProfesores();
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
            txtTitulo.ResetText();
            txtDNI.ResetText();
            txtIdClase.ResetText();
            txtId.ResetText();
            txtNombre.ResetText();
          
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
