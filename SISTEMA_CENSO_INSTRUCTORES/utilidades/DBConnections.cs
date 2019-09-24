using Newtonsoft.Json.Linq;
using SISTEMA_CENSO_INSTRUCTORES.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SISTEMA_CENSO_INSTRUCTORES.utilidades
{
    public class DBConnections
    {
        public string getCedFromUser(string usuario)
        {
            try
            {
                using (var ctx = new Contexto())
                {
                    var admin = ctx.T_ADMINISTRADORES2020.Where(a => a.USUARIO == (usuario.ToUpper()) && a.ROL == "ADMIN").FirstOrDefault();
                    if (admin != null)
                    {
                        return "ADMIN";
                    }
                    var u = ctx.T_DATOS_PARA_CENSO2020.Where(d => d.USUARIO_REGISTRO == (usuario.ToUpper())).FirstOrDefault();
                    if (u == null)
                    {
                        return "";
                    }
                    return u.CED;
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
                    if (u == null)
                    {
                        return null;
                    }
                    return u;
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
                    T_DATOS_PARA_CENSO2020 censo = ctx.T_DATOS_PARA_CENSO2020.Where(c => c.CED == CED).FirstOrDefault();
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
                            var oldExp = ctx.T_EXPERIENCIA_INSTRUCTORES.Where(e => e.CED == exp.CED && e.INDICE == exp.INDICE).FirstOrDefault();
                            if (oldExp != null) {
                                oldExp.TIPO_ACTIVIDAD = exp.TIPO_ACTIVIDAD;
                                oldExp.TIPO_ACTIVIDAD_ESP = exp.TIPO_ACTIVIDAD_ESP;
                                oldExp.TEMA = exp.TEMA;
                                oldExp.DESCRIPCION = exp.DESCRIPCION;
                                oldExp.YEAR = exp.YEAR;
                                oldExp.UPDATE_POR = usuario;
                            }
                        }
                    }else
                    {

                        ctx.T_EXPERIENCIA_INSTRUCTORES.RemoveRange(deletes);
                        foreach (var exp in experiencias)
                        {
                            exp.CED = ceds["CED"].ToString();
                            exp.CEDPROINI = ceds["prov"].ToString();
                            exp.CEDTOM = ceds["tom"].ToString();
                            exp.CEDASI = ceds["asi"].ToString();
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
            jo["tom"] = ced.Substring(ced.IndexOf("-")+1, ced.LastIndexOf("-"));
            jo["ini"] = ced.Substring(ced.LastIndexOf("-")+1,ced.Length);
            return jo;
        }
    }
}