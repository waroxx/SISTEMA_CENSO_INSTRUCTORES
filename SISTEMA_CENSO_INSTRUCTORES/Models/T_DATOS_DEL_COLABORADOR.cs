namespace SISTEMA_CENSO_INSTRUCTORES.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DATOS_DEL_COLABORADOR
    {
        [StringLength(50)]
        public string CED { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string CEDPROINI { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string CEDTOM { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string CEDASI { get; set; }

        [StringLength(50)]
        public string NOMPRI { get; set; }

        [StringLength(50)]
        public string NOMSEG { get; set; }

        [StringLength(50)]
        public string APEPAT { get; set; }

        [StringLength(50)]
        public string APEMAT { get; set; }

        [StringLength(50)]
        public string APECAS { get; set; }

        [StringLength(50)]
        public string SEXO { get; set; }

        [StringLength(50)]
        public string FECNAC { get; set; }

        [StringLength(50)]
        public string TELRES { get; set; }

        [StringLength(50)]
        public string TELTRA { get; set; }

        [StringLength(50)]
        public string TELEXT { get; set; }

        [StringLength(254)]
        public string NOMDIR { get; set; }

        [StringLength(100)]
        public string NOMDEP { get; set; }

        [StringLength(50)]
        public string NOMSEC { get; set; }

        [StringLength(100)]
        public string TITCAR { get; set; }

        [StringLength(50)]
        public string ESTATUSLABORAL { get; set; }

        [StringLength(50)]
        public string ASERVICIOS { get; set; }
    }
}
