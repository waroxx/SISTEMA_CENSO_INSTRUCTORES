namespace SISTEMA_CENSO_INSTRUCTORES.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DATOS_PARA_CENSO2020
    {
        [Required]
        [StringLength(20)]
        public string CED { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string CEDPROINI { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string CEDTOM { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string CEDASI { get; set; }

        [Required]
        [StringLength(80)]
        public string NOMBRES { get; set; }

        [Required]
        [StringLength(80)]
        public string APELLIDOS { get; set; }

        [StringLength(80)]
        public string DIRECCION { get; set; }

        [StringLength(80)]
        public string DEPARTAMENTO { get; set; }

        [StringLength(3)]
        public string PROV_ID { get; set; }

        [StringLength(3)]
        public string DIST_ID { get; set; }

        [StringLength(3)]
        public string CORR_ID { get; set; }

        [StringLength(80)]
        public string L_POBLADO { get; set; }

        [StringLength(250)]
        public string BARRIO { get; set; }

        [StringLength(80)]
        public string CALLE { get; set; }

        [StringLength(80)]
        public string EDIFICIO { get; set; }

        [StringLength(80)]
        public string APARTAMENTO { get; set; }

        [StringLength(30)]
        public string CARGO_DE_INTERES { get; set; }

        [StringLength(30)]
        public string OTRO_CARGO_INTERES { get; set; }

        public bool? TRABAJO_CERCA { get; set; }

        public bool? TRABAJO_LEJOS { get; set; }

        [StringLength(50)]
        public string USUARIO_REGISTRO { get; set; }

        [StringLength(10)]
        public string FECHA_REGISTRO { get; set; }

        [StringLength(50)]
        public string USUARIO_MODIFICACION { get; set; }

        [StringLength(10)]
        public string FECHA_MODIFICACION { get; set; }
    }
}
