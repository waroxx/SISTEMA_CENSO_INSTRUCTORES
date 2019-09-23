using Newtonsoft.Json.Linq;
using SISTEMA_CENSO_INSTRUCTORES.Models;
using SISTEMA_CENSO_INSTRUCTORES.utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SISTEMA_CENSO_INSTRUCTORES
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public string SessionUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombre = (string)Session["USUARIO"];
            if (nombre == null)
            {
                Response.Redirect("Default.aspx");
            }
            SessionUser = nombre;
        }

        [WebMethod]
        public static string datosBuscarDatosGenerales()
        {
            WebForm2 f = new WebForm2();

            if (f.session_user() == null)
            {
                return "ERROR";
            }
            string res = "";
            DBConnections dbc = new DBConnections();
            string rol = dbc.getCedFromUser(f.session_user());
            if (rol == "ADMIN")
            {
                res = HtmlPaterns.BUSCADOR_CEDULA;
            }
            else if (rol == "")
            {
                res = "";
            }
            else if (rol == null)
            {
                res = "ERROR";
            }
            else
            {
                var datos = dbc.getDatosGeneralesCenso(rol);
                res = HtmlPaterns.MOSTRAR_DATOS;
                res = res.Replace("{{ cedula }}", datos.CED);
                res = res.Replace("{{ nombres }}", datos.NOMBRES);
                res = res.Replace("{{ apellidos }}", datos.APELLIDOS);
            }
            return res;
        }

        [WebMethod]
        public static string getExperiencias()
        {
            WebForm2 f = new WebForm2();

            if (f.session_user() == null)
            {
                return "ERROR";
            }
            DBConnections dbc = new DBConnections();
            var Exp = dbc.getExpIntructores(dbc.getCedFromUser(f.session_user()));
            JObject jo = JObject.FromObject(Exp);
            return jo.ToString();
        }

        [WebMethod]
        public static string postExperiencias(string experiencias)
        {
            WebForm2 f = new WebForm2();

            if (f.session_user() == null)
            {
                return "ERROR";
            }
            var Exp = JObject.Parse(experiencias).ToObject<List<T_EXPERIENCIA_INSTRUCTORES>>();
            DBConnections dbc = new DBConnections();
            dbc.postExpInstructores(Exp, dbc.getCedFromUser(f.session_user()), f.session_user());
            return "true";
        }

        [WebMethod]
        public static bool cerrarSession()
        {
            WebForm2 f = new WebForm2();
            return f.sessionEnd();
        }

        public bool sessionEnd()
        {
            return cerrar_session();
        }

        protected bool cerrar_session()
        {
            var nom = Session["USUARIO"];
            bool ret = false;
            Session["USUARIO"] = null;
            ret = true;
            return ret;
        }

        private string session_user()
        {
            return (string)Session["USUARIO"];
        }
    }
}