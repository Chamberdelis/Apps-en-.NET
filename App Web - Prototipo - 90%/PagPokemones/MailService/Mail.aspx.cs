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
    public partial class Formulario_web18 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            MailService service = new MailService();
            service.armarMail(txtmail.Text, txtAsunto.Text, txtMensaje.Text);
            try
            {
                service.enviarMail();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("../Error.aspx", false);
            }
        }
    }
}