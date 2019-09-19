using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Web.Services;

namespace SISTEMA_CENSO_INSTRUCTORES
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["cliente"] = Request.LogonUserIdentity.Name;
            string nombre = (string)Session["USUARIO"];
            if (nombre != null)
            {
                Response.Redirect("Formulario.aspx");
            }
        }

        [WebMethod]
        public static bool login(string user, string password)
        {
            Default l = new Default();

            return l.sessionStart(user, password);

        }

        protected bool autentica_Windows(string _pass,
        string _usuario)
        {
            bool autenticacion = false;
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://CGR",
                    _usuario, _pass);
                object nativeObject = entry.NativeObject;
                Session["USUARIO"] = "CGR\\" + _usuario;
                autenticacion = true;
            }
            catch (DirectoryServicesCOMException EX)
            {
                System.Diagnostics.Debug.WriteLine(EX.Message);
                //lblConectando.Visible = false;
                // MessageBox.Show(EX.ToString());
            }
            //Thread.Sleep(3000);

            return autenticacion;
        }

        public bool sessionStart(string user, string password)
        {
            bool ret = autentica_Windows(password, user);
            return ret;
        }
    }
}