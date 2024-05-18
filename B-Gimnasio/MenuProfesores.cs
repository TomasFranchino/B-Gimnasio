
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
    public partial class MenuProfesores : Form
    {
        public MenuProfesores()
        {
            InitializeComponent();
        }
        //Profesores profe = new Profesores();
        //Principal principal = new Principal();

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
            AltaProfesores logeo;
            logeo = new AltaProfesores();
            logeo.Show();
            this.Hide();
        }

        private void btnBajaProfesores_Click(object sender, EventArgs e)
        {
            int idProfe = Convert.ToInt32(gridProfesores[0, gridProfesores.CurrentRow.Index].Value);
            aCli.DeleteProfesor(idProfe);
            gridProfesores.Refresh();
            MessageBox.Show("Profesor eliminado correctamente.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //string parabuscardni = "select * from profesores where dni like " + "'%" + txtBuscar.Text.ToString() + "%'";
            //string parabuscarnombre = "select * from profesores where nombre like " + "'%" + txtBuscar.Text.ToString() + "%'";
            //string parabuscarapellido = "select * from profesores where apellido like " + "'%" + txtBuscar.Text.ToString() + "%'";
            //if (true == ConexionASql.hacerConsultas(parabuscardni))
            //{ 
            //    gridProfesores.DataSource = ConexionASql.hacerConsulta(parabuscardni);
            //    gridProfesores.Refresh();
            //}else if (true == ConexionASql.hacerConsultas(parabuscarnombre))
            //{
            //    gridProfesores.DataSource = ConexionASql.hacerConsulta(parabuscarnombre);
            //    gridProfesores.Refresh();
            //}else if (true == ConexionASql.hacerConsultas(parabuscarapellido))
            //{
            //    gridProfesores.DataSource = ConexionASql.hacerConsulta(parabuscarapellido);
            //    gridProfesores.Refresh();
            //}
            //else if (txtBuscar.Text.ToString() == null || txtBuscar.Text.ToString() == "" || txtBuscar.Text.ToString() == "Buscar")
            //{
            //    var sql = "select * from profesores";
            //    gridProfesores.DataSource = ConexionASql.hacerConsulta(sql);
            //    gridProfesores.Refresh();
            //}
            //else
            //{
            //    MessageBox.Show("El Profesor no esta registrado.");
            //}
            //txtBuscar.Enabled = false;
            //txtBuscar.Enabled = true;
        }

        private void MenuProfesores_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        public void cargarDatos()
        {
            var datos = aCli.GetProfesores();
            gridProfesores.DataSource = datos;
            

        }

        private void gridProfesores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificarProfesores_Click(object sender, EventArgs e)
        {
            Calendario profe = new Calendario();
            int posicion = gridProfesores.CurrentRow.Index;
            profe.id = Convert.ToInt32(gridProfesores[0, posicion].Value);
            profe.dniProfesor = Convert.ToInt32(gridProfesores[1, posicion].Value);
            profe.titulo = gridProfesores[2, posicion].Value.ToString();
            profe.nombre = gridProfesores[3, posicion].Value.ToString();
            aCli.PutProfesor(profe);
            MessageBox.Show("Profesor modificado correctamente.");
            
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
            int idProfe = gridProfesores.CurrentRow.Index;
            
            var sueldo = aCli.CalcularSueldoProfe(idProfe);
            MessageBox.Show($"El sueldo del profesor {idProfe} es: $"+sueldo.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idProfe = gridProfesores.CurrentRow.Index;
            var clase = aCli.ClasesSinAlumnos(idProfe);
            string respuesta = "";
            if (clase == false)
            {
                respuesta = $"El profesor {idProfe} no tiene clases sin alumnos";
            }
            else { respuesta = $"El profesor {idProfe} tiene clases sin alumnos"; }
            MessageBox.Show(respuesta);
        }
    }
}
