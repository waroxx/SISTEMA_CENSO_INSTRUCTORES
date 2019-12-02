namespace SISTEMA_CENSO_INSTRUCTORES.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_EXPERIENCIA_INSTRUCTORES
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string CED { get; set; }

        [Required]
        [StringLength(4)]
        public string CEDPROINI { get; set; }

        [Required]
        [StringLength(4)]
        public string CEDTOM { get; set; }

        [Required]
        [StringLength(5)]
        public string CEDASI { get; set; }

        public bool? TIENE_EXPERIENCIA_INEC { get; set; }

        public bool? TIENE_EXPERIENCIA_DOCENTE { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int INDICE { get; set; }

        [StringLength(40)]
        public string TIPO_ACTIVIDAD { get; set; }

        [StringLength(40)]
        public string TIPO_ACTIVIDAD_ESP { get; set; }

        [StringLength(40)]
        public string DESCRIPCION { get; set; }

        [StringLength(40)]
        public string TEMA { get; set; }

        [StringLength(5)]
        public string YEAR { get; set; }

        public DateTime? FECHA_REGISTRO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string REGISTRADO_POR { get; set; }

        public DateTime? FECHA_UPDATE { get; set; }

        [StringLength(40)]
        public string UPDATE_POR { get; set; }
    }
}
