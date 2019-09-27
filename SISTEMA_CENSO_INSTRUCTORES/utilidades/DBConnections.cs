using Newtonsoft.Json.Linq;
using SISTEMA_CENSO_INSTRUCTORES.Models;
using SISTEMA_CENSO_INSTRUCTORES.sigrhuProd;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                                oldExp.TIENE_EXPERIENCIA = exp.TIENE_EXPERIENCIA;
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