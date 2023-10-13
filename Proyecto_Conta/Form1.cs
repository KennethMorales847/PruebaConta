using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //Llamamos a la función CDominosPizza y operamos según proceda la condición.
            string usuario = Convert.ToString(txtUsuario.Text);
            string clave = Convert.ToString(txtContrasenya.Text);
            string respuesta = CMenuPrincipal.iniciarSesion(usuario, clave);

            //Condición para determinar a si se accede al form del admin o empleados.
            if (respuesta == "admin")
            {
                //Envaindo al form del administrador.
                FormMenuAdministrador formMenuAdministrador = new FormMenuAdministrador();
                formMenuAdministrador.ShowDialog();
            }
            else if (respuesta == "user")
            {
                //Enviando al form del empleado.
                FormMenuPrincipal formMenuPrincipal = new FormMenuPrincipal();
                formMenuPrincipal.ShowDialog();
            }
            else
            {
                //Mensaje de alerta.
                MessageBox.Show(respuesta);
            }

            //Restableciendo botones.
            txtUsuario.Text = "";
            txtContrasenya.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
