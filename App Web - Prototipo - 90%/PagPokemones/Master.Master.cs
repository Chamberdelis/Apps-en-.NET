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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            if (!( Page is Formulario_web14 || Page is Formulario_web1 || Page is Formulario_web19 || Page is Formulario_web17))
            {
                if (!Seguridad.sesionActiva(Session["trainee"]))
                    Response.Redirect("~/Login.aspx", false);
                else
                {
                    Trainee user = (Trainee)Session["trainee"];
                    lbbUserlogin.Text = user.Nombre;
                    if (!string.IsNullOrEmpty(user.Imagen))
                        imgAvatar.ImageUrl = "~/Images/" + user.Imagen;
                }
            }

           
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default.aspx", false);
        }
    }
}