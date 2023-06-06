using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PagPokemones
{
    public partial class Formulario_web110 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["trainee"]))
                    {
                        Trainee user = (Trainee)Session["trainee"];
                        txtMail.Text = user.Mail;
                        txtMail.ReadOnly= true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFecha.Text = user.FechaNacimieto.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(user.Imagen))
                        {
                            imgImagenMiPerfil.ImageUrl = "~/Images/" + user.Imagen;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Escribir.
                TraineeNegocio negocio = new TraineeNegocio();
                Trainee user = (Trainee)Session["trainee"];

                if (inpImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("~/Images/");

                    inpImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");

                    user.Imagen = "perfil-" + user.Id + ".jpg";
                }


                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimieto = DateTime.Parse(txtFecha.Text);

                // Leer

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + user.Imagen;

                negocio.actualizar(user);


            }
            catch (Exception ex)
            {

                Session.Add("error",ex.ToString());
            }
        }
    }
}