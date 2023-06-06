using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlTypes;
using System.Configuration;


namespace Proyecto
{
    public partial class AltaArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        public AltaArticulo()
        {
            InitializeComponent();
        }

        public AltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();

            try
            {
                if (articulo == null)
                {
                    articulo = new Articulo();
                }


                if (validarAlta())
                {
                    return;
                }

                articulo.Codigo = txtCodigo.Text.ToUpper();
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Imagen = txtImagen.Text;
                articulo.Precio = decimal.Parse((txtPrecio.Text));

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado con exito");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado con exito");
                }



                Close();


            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (archivo != null && !(txtImagen.Text.ToUpper().Contains("HTTP")))
            {
                if (txtImagen.Text != "")
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                }
            }
        }

        private bool validarAlta()
        {
            if (txtCodigo.Text.Length != 3)
            {
                MessageBox.Show("Solo se permite un codigo alfanumerico igual a 3 caracteres.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe completar el campo Nombre para continuar.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;

            }

            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Debe completar el campo Precio para continuar.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            if (validaralfanum(txtCodigo.Text))
            {
                MessageBox.Show("Debe incluir al menos un numero y una letra en el campo codigo.","¡Atencion!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return true;
            }

            return false;
            
        }

        private bool validaralfanum(string cadena)
        {
            bool bannumero = false;
            bool banletra = false;
            foreach (char caracter in cadena)
            {
                if (char.IsNumber(caracter))
                {
                    bannumero = true;
                }

                if (char.IsLetter(caracter))
                {
                    banletra = true;
                }
               
            }

            if (bannumero == true && banletra == true)
            {
                bannumero= false;
                banletra= false;
                return false;
            }
            else
            {
                bannumero = false;
                banletra = false;
                return true;
            }


        }

        private void AltaArticulo_Load(object sender, EventArgs e)
        {
            marcaNegocio marcaNegocio = new marcaNegocio();
            categoriaNegocio categoriaNegocio= new categoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                string imagen = "https://yt3.googleusercontent.com/ytc/AL5GRJXD8hrrI7BajP7-BaY36p2dpEcomBo736hTk1y7=s900-c-k-c0x00ffffff-no-rj";
                cargarImagen(imagen);


                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text= articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                    txtImagen.Text = articulo.Imagen;
                    txtPrecio.Text = articulo.Precio.ToString("0.00");


                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxAltaImagen.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxAltaImagen.Load("https://store-images.s-microsoft.com/image/apps.38282.13733306562729316.049f2fd1-b066-4cb5-b5ef-317d282a0b02.ca5b4cd1-6cda-4b13-80af-d7d8e5ba2256?mode=scale&q=90&h=300&w=300");
            }
        }

        private void txtImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagen.Text);
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();

            archivo.Filter = "jpg|*.jpg; | png|*.png";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
