namespace Data.ParkingSys.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pacote")]
    public partial class Pacote : Model
    {
        public int PacoteID { get; set; }

        public string Nome { get; set; }

        public string Codigo { get; set; }

        public bool Ativo { get; set; }
    }
}
