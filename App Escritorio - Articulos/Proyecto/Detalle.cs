using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Detalle : Form
    {
        private Articulo articulo = null;
        public Detalle(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;

            txtCodigo1.Text = articulo.Codigo;
            txtNombre1.Text = articulo.Nombre;
            txtDescripcion1.Text = articulo.Descripcion;
            cboMarca1.Items.Add(articulo.Marca.Descripcion);
            cboMarca1.SelectedIndex= 0;
            cboCategoria1.Items.Add(articulo.Categoria.Descripcion);
            cboCategoria1.SelectedIndex= 0;
            cargarImagen(articulo.Imagen);
            txtPrecio1.Text = articulo.Precio.ToString("0.00");

        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxDetalle.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxDetalle.Load("https://store-images.s-microsoft.com/image/apps.38282.13733306562729316.049f2fd1-b066-4cb5-b5ef-317d282a0b02.ca5b4cd1-6cda-4b13-80af-d7d8e5ba2256?mode=scale&q=90&h=300&w=300");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
