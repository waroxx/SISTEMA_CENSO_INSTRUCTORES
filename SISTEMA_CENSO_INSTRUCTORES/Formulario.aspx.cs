using Newtonsoft.Json.Linq;
using SISTEMA_CENSO_INSTRUCTORES.Models;
using SISTEMA_CENSO_INSTRUCTORES.sigrhuProd;
using SISTEMA_CENSO_INSTRUCTORES.utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        public static string BuscarDatosGenerales(string cedula)
        {
            WebForm2 f = new WebForm2();

            if (f.session_user() == null)
            {
                return "ERROR";
            }
            string res = "";
            if (f.session_rol()!="ADMIN"&&
                f.session_rol()!="CENSO"&&
                f.session_rol()!=cedula)
            {
                return "su cedula es " + f.session_rol();
            }
            DBConnections dbc = new DBConnections();
            var datos = dbc.getDatosGeneralesCenso(cedula); //TODO buscar de sigrhu
            if (datos == null)
            {
                return "ERROR";
            }
            res = HtmlPaterns.MOSTRAR_DATOS;
                res = res.Replace("{{ cedula }}", datos.CED);
                res = res.Replace("{{ nombres }}", datos.NOMBRES);
                res = res.Replace("{{ apellidos }}", datos.APELLIDOS);      
            return res;
        }

        [WebMethod]
        public static string getCedula()
        {
            WebForm2 f = new WebForm2();

            if (f.session_user() == null)
            {
                return "ERROR";
            }
            string res = "";
            DBConnections dbc = new DBConnections();
            JObject rol = dbc.getCedFromUser(f.session_user());
            if (rol == null)
            {
                f.rol_session("CENSO");
                return "";
            }
            else if (rol["SRC"].ToString() == "ADMIN")
            {
                f.rol_session(rol["SRC"].ToString());
                res = rol["CED"].ToString();
            }
            else if (rol["SRC"].ToString() == "DB")
            {
                f.rol_session(rol["CED"].ToString());
                res = rol["CED"].ToString();
            }
            else if (rol["SRC"].ToString() == "CENSO")
            {
                f.rol_session(rol["SRC"].ToString());
                res = rol["CED"].ToString();
            }
            return res;
        }

        [WebMethod]
        public static string getExperiencias(string cedula)
        {
            WebForm2 f = new WebForm2();
            if (f.session_user() == null)
            {
                return "ERROR";
            }
            var fs = f.session_rol();
            if (fs=="CENSO")
            {
                return "WARNING: aún no ha guardado datos";
            }
            if (fs == cedula || fs == "ADMIN")
            {
                try {
                    DBConnections dbc = new DBConnections();
                    var Exp = dbc.getExpIntructores(cedula);
                    JObject response = new JObject();
                    response["TieneExperienciaInec"] = Exp.First().TIENE_EXPERIENCIA_INEC;
                    response["TieneExperienciaDoc"] = Exp.First().TIENE_EXPERIENCIA_DOCENTE;
                    response["Exp"] = JArray.FromObject(Exp);
                    return response.ToString();
                    //JObject jo = JObject.FromObject(Exp);
                    //return jo.ToString();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return "WARNING: aún no ha guardado datos";
                } 
            }
            if (fs != cedula)
            {
                return "Solo puede guardar en su propia cédula " + f.session_rol();
            }
            else
            {
                return "ERROR";
            }
        }

        [WebMethod]
        public static string getDesc(string id)
        {
                try
                {
                    DBConnections dbc = new DBConnections();
                    var desc = dbc.getDescripciones(id);
                    return desc;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return "[]";
                }           
        }

        [WebMethod]
        public static string getActividad()
        {
            try
            {
                DBConnections dbc = new DBConnections();
                var act = dbc.getActividad();
                return act;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "[]";
            }
        }

        [WebMethod]
        public static string getDescFull()
        {
            try
            {
                DBConnections dbc = new DBConnections();
                var act = dbc.getDescripcion_full();
                return act;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "[]";
            }
        }

        [WebMethod]
        public static string getTema()
        {
            try
            {
                DBConnections dbc = new DBConnections();
                var temas = dbc.getTemas();
                return temas;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "[]";
            }
        }

        [WebMethod]
        public static string postExperiencias(string experiencias, string cedula)
        {
            WebForm2 f = new WebForm2();

            if (f.session_user() == null)
            {
                return "ERROR";
            }
            if (f.session_rol()!="ADMIN" && f.session_rol() != "CENSO" && f.session_rol()!=cedula )
            {
                return "Solo puede guardar en su propia cédula " + f.session_rol();
            }
            var e = JArray.Parse(experiencias);
            var Exp = JArray.Parse(experiencias).ToObject<List<T_EXPERIENCIA_INSTRUCTORES>>();
            DBConnections dbc = new DBConnections();
            var r = dbc.postExpInstructores(Exp, cedula, f.session_user());
            return r.ToString();
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
            Session["ROL"] = null;
            Session.Abandon();
            ret = true;
            return ret;
        }

        protected bool rol_session(string rol)
        {
            bool ret = false;
            Session["ROL"] = rol;
            ret = true;
            return ret;
        }


        private string session_user()
        {
            return (string)Session["USUARIO"];
        }

        private string session_rol()
        {
            return (string)Session["ROL"];
        }

        public static string ExpFormatter(List<T_EXPERIENCIA_INSTRUCTORES> exList)
        {

            string acts = "";
            string output = "";
            foreach (var item in exList)
            {
                acts = "";
                var campos = HtmlPaterns.campos;
                campos = campos.Replace("{{tp}}value='" + item.TIPO_ACTIVIDAD + "'", "value='" + item.TIPO_ACTIVIDAD + "' selected");
                
                if (item.TIPO_ACTIVIDAD_ESP!="" && item.TIPO_ACTIVIDAD_ESP != null)
                {
                    campos = campos.Replace("{{DISPLAY}}", "display:block");
                    campos = campos.Replace("{{OTIPO}}", item.TIPO_ACTIVIDAD_ESP);
                    acts = HtmlPaterns.descInput.Replace("{{DESC}}", item.DESCRIPCION); 
                }
                else
                {
                    campos = campos.Replace("{{DISPLAY}}", "display:none");
                    campos = campos.Replace("{{OTIPO}}", item.TIPO_ACTIVIDAD_ESP);
                    DBConnections db = new DBConnections();
                    var ja = JArray.Parse(db.getDescripciones("0" + item.TIPO_ACTIVIDAD));
                    foreach (var i in ja)
                    {
                        acts += "<option value='"+i["ID"]+"'>"+i["DESCRIPCION"]+"</option>";
                    }
                    acts = acts.Replace("value='"+item.DESCRIPCION+"'", "selected='selected' value='" + item.DESCRIPCION + "'");
                    acts = HtmlPaterns.descSelect.Replace("{{campos}}", acts);
                }

                campos = campos.Replace("{{tm}}value='" + item.TEMA + "'", "value='" + item.TEMA + "' selected");
                campos = campos.Replace("{{DESC}}", acts);
                campos = campos.Replace("{{YEAR}}", item.YEAR);
                campos = campos.Replace("{{tm}}", "");
                campos = campos.Replace("{{tp}}", "");
                output += campos;
            }
            return output;
        }
    }
}