using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiPrimeraAplicacion
{
    public partial class DatosPersonales : Form
    {
        public DatosPersonales()
        {
            InitializeComponent();
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( (e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bandera = false;

            if(txtApellido.Text == "")
            {
                lblcorreccion1.Visible= true;
                bandera= true;
            }
            else
            {
                lblcorreccion1.Visible = false;
                txtApellido.BackColor = System.Drawing.SystemColors.Window;
            }

            if (txtNombre.Text == "")
            {
                lblcorrecion2.Visible= true;
                bandera= true;
            }
            else
            {
                txtNombre.BackColor = System.Drawing.SystemColors.Window;
                lblcorrecion2.Visible = false;
            }
            if (txtEdad.Text == "")
            {
                lblcorreccion3.Visible= true;
                bandera = true;
            }
            else
            {
                txtEdad.BackColor = System.Drawing.SystemColors.Window;
                lblcorreccion3.Visible = false;
            }
            if (txtDireccion.Text == "")
            {
                lblcorrecion4.Visible= true;
                bandera = true;
            }
            else
            {
                txtDireccion.BackColor = System.Drawing.SystemColors.Window;
                lblcorrecion4.Visible = false;
            }

            if (bandera)
            {
                MessageBox.Show("Complete todos los campos.");
            }

            string apellido = txtApellido.Text;
            string nombre   = txtNombre.Text;
            string edad = txtEdad.Text;
            string direccion = txtDireccion.Text;

            if (txtApellido.Text != "" && txtNombre.Text != "" && txtEdad.Text != "" && txtDireccion.Text != "")
            {
                txtResultado.Text = apellido + " " + nombre + Environment.NewLine + edad + Environment.NewLine + direccion;
                
            }
            
            
        }
    }
}
