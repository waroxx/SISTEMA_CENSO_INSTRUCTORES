using SISTEMA_CENSO_INSTRUCTORES.Models;
using System;
using System.Collections.Generic;
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
                using (var ctx = new dbcontext())
                {
                    var admin = ctx.T_ADMINISTRADORES2020.Where(a => a.USUARIO == ("CGR\\" + usuario.ToUpper()) && a.ROL == "ADMIN").FirstOrDefault();
                    if (admin != null)
                    {
                        return "ADMIN";
                    }
                    //retornar ced o admin
                    var u = ctx.T_DATOS_PARA_CENSO2020.Where(d => d.USUARIO_REGISTRO == ("CGR\\" + usuario.ToUpper())).FirstOrDefault();
                    if (u == null)
                    {
                        return "";
                    }
                    return u.CED;
                }
            }
            catch (Exception e)
            {
                //write
                return null;
            }

        }

        public T_DATOS_PARA_CENSO2020 getDatosGeneralesCenso(string CED)
        {
            try
            {
                using (var ctx = new dbcontext())
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
                //write
                return null;
            }
        }

        public List<T_EXPERIENCIA_INSTRUCTORES> getExpIntructores(string CED)
        {
            try
            {
                using (var ctx = new dbcontext())
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
                //write
                return null;
            }
        }

        public bool postExpInstructores(List<T_EXPERIENCIA_INSTRUCTORES> experiencias, string usuario,string CEDULA)
        {
            try { 
            using (var ctx = new dbcontext())
            {
                foreach (var exp in experiencias)
                {
                    var oldExp = ctx.T_EXPERIENCIA_INSTRUCTORES.Where(e => e.CED == exp.CED && e.INDICE == exp.INDICE).FirstOrDefault();
                    if (oldExp == null)
                    {
                        oldExp.TIPO_ACTIVIDAD = exp.TIPO_ACTIVIDAD;
                        oldExp.TIPO_ACTIVIDAD_ESP = exp.TIPO_ACTIVIDAD_ESP;
                        oldExp.TEMA = exp.TEMA;
                        oldExp.DESCRIPCION = exp.DESCRIPCION;
                        oldExp.YEAR = exp.YEAR;
                        oldExp.REGISTRADO_POR = usuario;
                            // trigger para la fecha
                    } else
                    {
                        ctx.T_EXPERIENCIA_INSTRUCTORES.Add(exp);
                    }
                }                   
                    //remove a los que no estan en el indice
                    ctx.SaveChanges();
                }
        }catch(Exception e){
                //write
                return false;
            }
            return true;
        }
    }
}