using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PagPokemones
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para continuar.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagUser.aspx", false);
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagAdmin.aspx", false);
        }
    }
}