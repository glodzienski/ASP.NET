namespace Data.ParkingSys.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PacoteServico")]
    public partial class PacoteServico : Model
    {
        public int PacoteServicoID { get; set; }

        public int ServicoID { get; set; }

        public virtual Servico Servico { get; set; }
    }
}
