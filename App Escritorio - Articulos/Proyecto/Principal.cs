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
using negocio;

namespace Proyecto
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private List<Articulo> listaarticulo;

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxArticulo.Load("https://store-images.s-microsoft.com/image/apps.38282.13733306562729316.049f2fd1-b066-4cb5-b5ef-317d282a0b02.ca5b4cd1-6cda-4b13-80af-d7d8e5ba2256?mode=scale&q=90&h=300&w=300");
            }
        }

       

        private void Principal_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Precio");
            cboFiltro.Items.Add("Marca");
            cboFiltro.Items.Add("Categoria");
            cboFiltro.Items.Add("Codigo");
        }

        private void dgvArticulo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulo.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.Imagen);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaArticulo alta = new AltaArticulo();
            alta.ShowDialog();
            cargar();
        }

        private void cargar()
        {
            articuloNegocio negocio = new articuloNegocio();

            try
            {
                listaarticulo = negocio.listaArticulo();
                dgvArticulo.DataSource = listaarticulo;
                ocultarcolumnas();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarcolumnas()
        {
            dgvArticulo.Columns[0].Visible= false;
            dgvArticulo.Columns[6].Visible= false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulo.CurrentRow != null)
            {
                Articulo seleccionado;
                seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                AltaArticulo modificar = new AltaArticulo(seleccionado);
                modificar.ShowDialog();
                cargar();
            }
            else
            {
                MessageBox.Show("No hay fila seleccionada", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            Articulo seleccionado;

            try
            {
                if (dgvArticulo.CurrentRow != null)
                {
                    DialogResult respuesta = MessageBox.Show("¿Esta seguro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                        negocio.eliminar(seleccionado.Id);
                        cargar();
                    }
                }
                else
                {
                    MessageBox.Show("No hay fila seleccionada.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listafiltrada;

            if (cboFiltro.SelectedIndex >= 0)
            {
                string filtro = txtFiltro.Text;
                string opcion = cboFiltro.SelectedItem.ToString();

                if (filtro.Length >= 1 && opcion == "Marca")
                {
                    listafiltrada = listaarticulo.FindAll(x => x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                }
                else if (filtro.Length >= 1 && opcion == "Categoria")
                {
                    listafiltrada = listaarticulo.FindAll(x => x.Categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                }
                else if (filtro.Length >= 1 && opcion == "Codigo")
                {
                    listafiltrada = listaarticulo.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()));
                }
                else
                {
                    listafiltrada = listaarticulo;
                }
                dgvArticulo.DataSource = null;
                dgvArticulo.DataSource = listafiltrada;
                ocultarcolumnas();
            }
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();

            if (opcion == "Nombre")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            
        }

        private void btnBuscarAvanzado_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();

            try
            {
                if (validarfiltro())
                {
                    return;
                }

                if (txtFiltroAvanzado.Text != "")
                {
                    string campo = cboCampo.SelectedItem.ToString();
                    string criterio = cboCriterio.SelectedItem.ToString();
                    string filtro = txtFiltroAvanzado.Text;

                    dgvArticulo.DataSource = negocio.filtroAvanzado(campo, criterio, filtro);
    

            }
                else
                {
                    MessageBox.Show("No se ha escrito ningun parametro a buscar.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool validarSoloNumeros ( string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                {
                    return false;
                }

            }

            return true;
        }

        private bool validarfiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir una opcion en Campo para continuar.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir una opcion en Criterio para continuar.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (!(validarSoloNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Solo se permiten numeros con este campo.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulo.CurrentRow != null)
                {
                    Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                    Detalle detalleArticulo = new Detalle(seleccionado);
                    detalleArticulo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay fila seleccionada.", "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
