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
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio negocio = new TraineeNegocio();

            try
            {
                if (Validacion.validarTextoVacio(txtUsuario) || Validacion.validarTextoVacio(txtPass))
                {
                    Session.Add("error", "Debe completar los campos requeridos.");
                    Response.Redirect("Error.aspx");
                }
                trainee.Mail = txtUsuario.Text;
                trainee.Pass = txtPass.Text;

 
                if (negocio.Loguear(trainee))
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("Perfil/MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario y/o contraseña invalido");
                    Response.Redirect("Error.aspx",false);
                }

                
            }
            catch (System.Threading.ThreadAbortException ex)
            {

            }
            catch (Exception ex)
            {

                
            }
            
            
        }
    }
}