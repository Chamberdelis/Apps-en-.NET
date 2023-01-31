using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppyConexionaBD
{
    public partial class AppDisco : Form
    {
        public AppDisco()
        {
            InitializeComponent();
        }

        private List<Disco> listadisco;

        private void cargarImagen ( string imagen)
        {
            try
            {
                pbxDiscos.Load(imagen);
   
            }
            catch (Exception ex)
            {

                pbxDiscos.Load("https://store-images.s-microsoft.com/image/apps.38282.13733306562729316.049f2fd1-b066-4cb5-b5ef-317d282a0b02.ca5b4cd1-6cda-4b13-80af-d7d8e5ba2256?mode=scale&q=90&h=300&w=300");
            }
        }

        private void AppDisco_Load(object sender, EventArgs e)
        {
            DiscosConexion disco = new DiscosConexion();
            listadisco = disco.Listadiscos();
            dgvDiscos.DataSource = listadisco;
            dgvDiscos.Columns[3].Visible = false;
            cargarImagen(listadisco[0].Imagen);
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.Imagen);
        }
    }
}
