namespace SISTEMA_CENSO_INSTRUCTORES.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
        }

        public virtual DbSet<T_ADMINISTRADORES2020> T_ADMINISTRADORES2020 { get; set; }
        public virtual DbSet<T_DATOS_DEL_COLABORADOR> T_DATOS_DEL_COLABORADOR { get; set; }
        public virtual DbSet<T_DATOS_PARA_CENSO2020> T_DATOS_PARA_CENSO2020 { get; set; }
        public virtual DbSet<T_EXPERIENCIA_INSTRUCTORES> T_EXPERIENCIA_INSTRUCTORES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_ADMINISTRADORES2020>()
                .Property(e => e.USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<T_ADMINISTRADORES2020>()
                .Property(e => e.ROL)
                .IsUnicode(false);

            modelBuilder.Entity<T_ADMINISTRADORES2020>()
                .Property(e => e.AdminCenso)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.CED)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.CEDPROINI)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.CEDTOM)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.CEDASI)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.NOMPRI)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.NOMSEG)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.APEPAT)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.APEMAT)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.APECAS)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.SEXO)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.FECNAC)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.TELRES)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.TELTRA)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.TELEXT)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.NOMDIR)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.NOMDEP)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.NOMSEC)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.TITCAR)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.ESTATUSLABORAL)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_DEL_COLABORADOR>()
                .Property(e => e.ASERVICIOS)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.CED)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.CEDPROINI)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.CEDTOM)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.CEDASI)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.NOMBRES)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.APELLIDOS)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.DEPARTAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.PROV_ID)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.DIST_ID)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.CORR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.L_POBLADO)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.BARRIO)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.CALLE)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.EDIFICIO)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.APARTAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.CARGO_DE_INTERES)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.OTRO_CARGO_INTERES)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.USUARIO_REGISTRO)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.FECHA_REGISTRO)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.USUARIO_MODIFICACION)
                .IsUnicode(false);

            modelBuilder.Entity<T_DATOS_PARA_CENSO2020>()
                .Property(e => e.FECHA_MODIFICACION)
                .IsUnicode(false);

            modelBuilder.Entity<T_EXPERIENCIA_INSTRUCTORES>()
                .Property(e => e.CED)
                .IsUnicode(false);

            modelBuilder.Entity<T_EXPERIENCIA_INSTRUCTORES>()
                .Property(e => e.CEDPROINI)
                .IsUnicode(false);

            modelBuilder.Entity<T_EXPERIENCIA_INSTRUCTORES>()
                .Property(e => e.CEDTOM)
                .IsUnicode(false);

            modelBuilder.Entity<T_EXPERIENCIA_INSTRUCTORES>()
                .Property(e => e.CEDASI)
                .IsUnicode(false);

            modelBuilder.Entity<T_EXPERIENCIA_INSTRUCTORES>()
                .Property(e => e.TIPO_ACTIVIDAD)
                .IsUnicode(false);

            modelBuilder.Entity<T_EXPERIENCIA_INSTRUCTORES>()
                .Property(e => e.TIPO_ACTIVIDAD_ESP)
                .IsUnicode(false);

            modelBuilder.Entity<T_EXPERIENCIA_INSTRUCTORES>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<T_EXPERIENCIA_INSTRUCTORES>()
                .Property(e => e.TEMA)
                .IsUnicode(false);

            modelBuilder.Entity<T_EXPERIENCIA_INSTRUCTORES>()
                .Property(e => e.YEAR)
                .IsUnicode(false);

            modelBuilder.Entity<T_EXPERIENCIA_INSTRUCTORES>()
                .Property(e => e.REGISTRADO_POR)
                .IsUnicode(false);

            modelBuilder.Entity<T_EXPERIENCIA_INSTRUCTORES>()
                .Property(e => e.UPDATE_POR)
                .IsUnicode(false);
        }
    }
}
