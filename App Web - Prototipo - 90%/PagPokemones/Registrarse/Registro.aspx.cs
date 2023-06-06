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
    public partial class Formulario_web19 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee user = new Trainee();
                MailService service = new MailService();
                TraineeNegocio negocio = new TraineeNegocio();

                user.Mail = txtMail.Text;
                user.Pass = txtPass.Text;

                user.Id = negocio.insertarNuevo(user);
                Session.Add("trainee", user);

                //service.armarMail(user.Mail, "Bienvenido gordito", "Pingo");
                //service.enviarMail();

                Response.Redirect("../Default.aspx", false);


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString() );
            }
        }
    }
}