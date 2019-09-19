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
                using (var ctx = new Dbcontext())
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

        public T_DATOS_PARA_CENSO2020 getDatosGeneralesCenso(string CED)
        {
            try
            {
                using (var ctx = new Dbcontext())
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
                using (var ctx = new Dbcontext())
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

        public bool postExpInstructores(List<T_EXPERIENCIA_INSTRUCTORES> experiencias, string CEDULA, string usuario)
        {
            try { 
            using (var ctx = new Dbcontext())
            {
                    var Exp = ctx.T_EXPERIENCIA_INSTRUCTORES.Where(e => e.CED == experiencias[0].CED && e.INDICE == experiencias[0].INDICE).FirstOrDefault();
                    var deletes = ctx.T_EXPERIENCIA_INSTRUCTORES.Where(e => e.CED == Exp.CED);
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
    }
}