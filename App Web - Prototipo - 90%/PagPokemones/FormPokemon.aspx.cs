using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace PagPokemones
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
       
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled= false;
            ConfirmaEliminacion= false;

            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    List<Elemento> lista = negocio.listar();

                    ddTipo.DataSource = lista;
                    ddTipo.DataValueField = "Id";
                    ddTipo.DataTextField = "Descripcion";
                    ddTipo.DataBind();

                    ddDebilidad.DataSource = lista;
                    ddDebilidad.DataValueField = "Id";
                    ddDebilidad.DataTextField = "Descripcion";
                    ddDebilidad.DataBind();

                    // Para modificar datos de un registro.

                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                    if (id != "" && !(IsPostBack))
                    {
                        PokemonNegocio negocioP = new PokemonNegocio();
                        Pokemon selecciona = (negocioP.listar(id))[0];

                        Session.Add("pokeSeleccionado", selecciona);

                        txtId.Text = id;
                        txtNombre.Text = selecciona.Nombre;
                        txtNumero.Text = selecciona.Numero.ToString();
                        txtDescripcion.Text = selecciona.Descripcion;
                        txtImagen.Text = selecciona.UrlImagen;

                        ddTipo.SelectedValue = selecciona.Tipo.Id.ToString();
                        ddDebilidad.SelectedValue = selecciona.Debilidad.Id.ToString();
                        txtImagen_TextChanged(sender, e);

                        if (!selecciona.Activo)
                        {
                            btnInactivar.Text = "Activar";
                        }

                    }

                    

                    if (id == "")
                    {
                        btnEliminar.Visible = false;
                        btnInactivar.Visible = false;
                    }





                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtImagen.Text;
                
                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddTipo.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddDebilidad.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text); 
                    negocio.modificarConSp(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);
                }

                Response.Redirect("Lista.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            pbxImagen.ImageUrl= txtImagen.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));

                    Response.Redirect("Lista.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];
                negocio.eliminarLogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("Lista.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}