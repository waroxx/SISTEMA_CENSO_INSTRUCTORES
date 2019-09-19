namespace SISTEMA_CENSO_INSTRUCTORES.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ADMINISTRADORES2020
    {
        public int id { get; set; }

        [StringLength(50)]
        public string USUARIO { get; set; }

        [StringLength(50)]
        public string ROL { get; set; }

        [StringLength(50)]
        public string AdminCenso { get; set; }
    }
}
