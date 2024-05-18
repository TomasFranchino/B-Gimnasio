
using B_Gimnasio.ServiceReference1;
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

namespace Vista
{
    public partial class MenuClases : Form
    {
        public MenuClases()
        {
            InitializeComponent();
        }
      

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        WebService1SoapClient aCli = new WebService1SoapClient();

        private void btnAtras_Click(object sender, EventArgs e)
        {
            MenuPrincipal logeo = new MenuPrincipal();
            logeo.Show();
            this.Hide();
        }



        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btDarAltaProfesores_Click(object sender, EventArgs e)
        {
            AltaClases logeo = new AltaClases();
            logeo.Show();
            this.Hide();
        }

        private void btnBajaProfesores_Click(object sender, EventArgs e)
        {
            int idClase = Convert.ToInt32(gridClases[0, gridClases.CurrentRow.Index].Value);
            aCli.DeleteClase(idClase);
            gridClases.Refresh();
            MessageBox.Show("Clase eliminada correctamente.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void MenuProfesores_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        public void cargarDatos()
        {
            var datos = aCli.GetClases();
            gridClases.DataSource = datos;
            

        }

        private void gridProfesores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificarProfesores_Click(object sender, EventArgs e)
        {
            Clases clases = new Clases();
            int posicion = gridClases.CurrentRow.Index;
            clases.id = Convert.ToInt32(gridClases[0, posicion].Value);
            clases.tema = gridClases[1, posicion].Value.ToString();
            clases.cantAlumnos = Convert.ToInt32(gridClases[2, posicion].Value);
            clases.fechaInicio = gridClases[3, posicion].Value.ToString();
            clases.idProfesor = Convert.ToInt32(gridClases[4, posicion].Value);
            aCli.PutClases(clases);
            MessageBox.Show("Clase modificada correctamente.");

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void MenuProfesores_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void InicialiceComponent()
        {
            this.SuspendLayout();
            
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MenuClases";
            this.Load += new System.EventHandler(this.MenuClases_Load);
            this.ResumeLayout(false);

        }

        private void MenuClases_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
