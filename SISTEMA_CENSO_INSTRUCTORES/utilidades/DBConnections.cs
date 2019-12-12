using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SISTEMA_CENSO_INSTRUCTORES.Models;
using SISTEMA_CENSO_INSTRUCTORES.sigrhuProd;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SISTEMA_CENSO_INSTRUCTORES.utilidades
{
    public class DBConnections
    {
        public JObject getCedFromUser(string usuario)
        {
            JObject jo = new JObject();
            try
            {
                using (var ctx = new Contexto())
                {
                    var admin = ctx.T_ADMINISTRADORES2020.Where(a => a.USUARIO == (usuario.ToUpper()) && a.ROL == "ADMIN").FirstOrDefault();
                    if (admin != null)
                    {
                        jo["CED"] = "ADMIN";
                        jo["SRC"] = "ADMIN";
                        return jo;
                    }
                    var eu = ctx.T_EXPERIENCIA_INSTRUCTORES.Where(d => d.REGISTRADO_POR == (usuario.ToUpper())).FirstOrDefault();
                    if (eu != null)
                    {
                        jo["CED"] = eu.CED;
                        jo["SRC"] = "DB";
                        return jo;
                    }
                    var u = ctx.T_DATOS_PARA_CENSO2020.Where(d => d.USUARIO_REGISTRO == (usuario.ToUpper())).FirstOrDefault();
                    if (u == null)
                    {
                        return null;
                    }
                    jo["CED"] = u.CED;
                    jo["SRC"] = "CENSO";
                    return jo;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }

        public T_DATOS_PARA_CENSO2020 getUserFromUsername(string usuario)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    var u = ctx.T_DATOS_PARA_CENSO2020.Where(d => d.USUARIO_REGISTRO == (usuario.ToUpper())).FirstOrDefault();
                    if (u != null)
                    {
                        return u;
                    }
                    var eu = ctx.T_EXPERIENCIA_INSTRUCTORES.Where(d=>d.REGISTRADO_POR== (usuario.ToUpper())).FirstOrDefault();
                    if (eu!=null)
                    {
                        return u;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }

        public T_DATOS_PARA_CENSO2020 getDatosGeneralesCenso(string CED)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    //T_DATOS_PARA_CENSO2020 censo = ctx.T_DATOS_PARA_CENSO2020.Where(c => c.CED == CED).FirstOrDefault();
                    DataTable dt = WS_SIGRHU(CED);
                    T_DATOS_PARA_CENSO2020 censo;
                    if (dt.Rows.Count != 0)
                    {
                        censo = new T_DATOS_PARA_CENSO2020
                        {
                            NOMBRES = dt.Rows[0]["PrimerNombre"] + " " + dt.Rows[0]["SegundoNombre"],
                            APELLIDOS = dt.Rows[0]["ApellidoPaterno"] + " " + dt.Rows[0]["ApellidoMaterno"],
                            CED = CED
                        };
                    }else
                    {
                        censo = null;
                    }
                    
                    if (censo == null)
                    {
                        return null;
                    }
                    return censo;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public DataTable WS_SIGRHU(string _ced)
        {
            JObject ced = parseCedula(_ced);
            string constring = ConfigurationManager.ConnectionStrings["sigrhu"].ToString(); ;
            string[] args = new string[] { (string)ced["prov"], (string)ced["tom"], (string)ced["asi"] };
            IsGenericoClient cliente = new IsGenericoClient();
            DataTable dt = cliente.ListarGenericoArgArregloCadena("PE_L_GeneralesServidorPublico_CENSO2020", args, constring);
            if (dt.Rows.Count <= 0)
            {
                return new DataTable();
            }
            System.Diagnostics.Debug.WriteLine(dt.Rows[0]["PrimerNombre"]);
            insertDatosSIGRHU(dt, (string)ced["prov"], (string)ced["tom"], (string)ced["asi"], _ced);
            return dt;
        }

        public List<T_EXPERIENCIA_INSTRUCTORES> getExpIntructores(string CED)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    List<T_EXPERIENCIA_INSTRUCTORES> experiencias = ctx.T_EXPERIENCIA_INSTRUCTORES.Where(e => e.CED == CED).ToList();
                    if (experiencias == null)
                    {
                        return null;
                    }
                    return experiencias;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public bool postExpInstructores(List<T_EXPERIENCIA_INSTRUCTORES> experiencias, string CED, string usuario)
        {
            try { 
            using (var ctx = new Contexto())
            {
                   // var Exp = ctx.T_EXPERIENCIA_INSTRUCTORES.Where(e => e.CED == experiencias.First().CED && e.INDICE == experiencias.First().INDICE).FirstOrDefault();
                    var deletes = ctx.T_EXPERIENCIA_INSTRUCTORES.Where(e => e.CED == CED);
                    JObject ceds = parseCedula(CED);
                    if(experiencias.Count == deletes.ToList().Count)
                    {
                        foreach (var exp in experiencias)
                        {
                            var oldExp = ctx.T_EXPERIENCIA_INSTRUCTORES.Where(e => e.CED == CED && e.INDICE == exp.INDICE).FirstOrDefault();
                            if (oldExp != null) {
                                oldExp.TIPO_ACTIVIDAD = exp.TIPO_ACTIVIDAD;
                                oldExp.TIPO_ACTIVIDAD_ESP = exp.TIPO_ACTIVIDAD_ESP;
                                oldExp.TEMA = exp.TEMA;
                                oldExp.DESCRIPCION = exp.DESCRIPCION;
                                oldExp.YEAR = exp.YEAR;
                                oldExp.TIENE_EXPERIENCIA_INEC = exp.TIENE_EXPERIENCIA_INEC;
                                oldExp.TIENE_EXPERIENCIA_DOCENTE = exp.TIENE_EXPERIENCIA_DOCENTE;
                                oldExp.UPDATE_POR = usuario;
                            }
                        }
                    }else
                    {

                        ctx.T_EXPERIENCIA_INSTRUCTORES.RemoveRange(deletes);
                        ctx.SaveChanges();
                        foreach (var exp in experiencias)
                        {
                            exp.CED = ceds["ced"].ToString();
                            exp.CEDPROINI = ceds["prov"].ToString();
                            exp.CEDTOM = ceds["tom"].ToString();
                            exp.CEDASI = ceds["asi"].ToString();
                            exp.REGISTRADO_POR = usuario;
                            ctx.T_EXPERIENCIA_INSTRUCTORES.Add(exp);
                        }

                    }
                    ctx.SaveChanges();
                }
        }catch(Exception e){
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public bool insertDatosSIGRHU(DataTable dt, string prov, string tom, string asi, string cedula)
        {
            var ConString = ConfigurationManager.ConnectionStrings["ConnectionStringCenso"].ToString();
            var con = new SqlConnection(ConString);
            SqlCommand cmd = new SqlCommand("CargarSIGRHU", con); //LLAMADA_SIGRHU

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ced", SqlDbType.VarChar, 12).Value = cedula;
            cmd.Parameters.Add("@cedproini", SqlDbType.VarChar, 4).Value = prov;
            cmd.Parameters.Add("@cedtom", SqlDbType.VarChar, 4).Value = tom;
            cmd.Parameters.Add("@cedasi", SqlDbType.VarChar, 5).Value = asi;
            cmd.Parameters.Add("@apecas", SqlDbType.VarChar, 20).Value = dt.Rows[0]["ApellidoCasada"];
            cmd.Parameters.Add("@apepat", SqlDbType.VarChar, 20).Value = dt.Rows[0]["ApellidoPaterno"];
            cmd.Parameters.Add("@apemat", SqlDbType.VarChar, 20).Value = dt.Rows[0]["ApellidoMaterno"];
            cmd.Parameters.Add("@nompri", SqlDbType.VarChar, 20).Value = dt.Rows[0]["PrimerNombre"];
            cmd.Parameters.Add("@nomseg", SqlDbType.VarChar, 20).Value = dt.Rows[0]["SegundoNombre"];
            cmd.Parameters.Add("@sexo", SqlDbType.VarChar, 1).Value = dt.Rows[0]["Sexo"]; ;
            cmd.Parameters.Add("@telres", SqlDbType.VarChar, 8).Value = dt.Rows[0]["Teléfono Residencia"]; ;
            cmd.Parameters.Add("@teltra", SqlDbType.VarChar, 8).Value = dt.Rows[0]["Teléfono Oficina"];
            cmd.Parameters.Add("@telext", SqlDbType.VarChar, 4).Value = dt.Rows[0]["Extension"];
            cmd.Parameters.Add("@fecnac", SqlDbType.VarChar, 10).Value = dt.Rows[0]["FechaNacimiento"];
            cmd.Parameters.Add("@nomdir", SqlDbType.VarChar, 254).Value = dt.Rows[0]["Direccion"];
            cmd.Parameters.Add("@nomdep", SqlDbType.VarChar, 100).Value = dt.Rows[0]["Departamento"];
            cmd.Parameters.Add("@nomsec", SqlDbType.VarChar, 50).Value = dt.Rows[0]["Seccion"];
            cmd.Parameters.Add("@titcar", SqlDbType.VarChar, 100).Value = dt.Rows[0]["Seccion"];
            cmd.Parameters.Add("@estatus", SqlDbType.VarChar, 254).Value = dt.Rows[0]["Estatus Laboral"];
            cmd.Parameters.Add("@aservicios", SqlDbType.VarChar, 254).Value = dt.Rows[0]["Años de Servicio"];
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {

                dt.Load(reader);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
                reader.Close();
            }
            return true;
        }

        public string getDescripciones(string id)
        {
            DataTable dt = new DataTable();
            var ConString = ConfigurationManager.ConnectionStrings["Contexto"].ToString();
            var con = new SqlConnection(ConString);
            SqlCommand cmd = new SqlCommand("SEL_ENCUESTA", con); //LLAMADA_SIGRHU

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ACT", SqlDbType.VarChar, 2).Value = id;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {

                dt.Load(reader);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                con.Close();
                reader.Close();
            }
            string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return json;
        }

        public string getActividad()
        {
            DataTable dt = new DataTable();
            var ConString = ConfigurationManager.ConnectionStrings["Contexto"].ToString();
            var con = new SqlConnection(ConString);
            SqlCommand cmd = new SqlCommand("SEL_ACTIVIDAD", con);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {

                dt.Load(reader);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                con.Close();
                reader.Close();
            }
            string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return json;
        }

        public string getDescripcion_full()
        {
            DataTable dt = new DataTable();
            var ConString = ConfigurationManager.ConnectionStrings["Contexto"].ToString();
            var con = new SqlConnection(ConString);
            SqlCommand cmd = new SqlCommand("SEL_ENCUESTA_FULL", con);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                con.Close();
                reader.Close();
            }
            string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return json;
        }

        public JObject parseCedula(string ced)
        {
            JObject jo = new JObject();
            jo["ced"] = ced;
            jo["prov"] = ced.Substring(0, ced.IndexOf("-"));
            var rest = ced.Substring(ced.IndexOf("-")+1);
            jo["tom"] = rest.Substring(0,rest.IndexOf("-"));
            jo["asi"] = rest.Substring(rest.IndexOf("-") + 1);
            return jo;
        }
    }
}