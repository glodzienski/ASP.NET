namespace Data.ParkingSys.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VagaTipo")]
    public partial class VagaTipo : Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VagaTipo()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int VagaTipoID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe a descrição do tipo de vaga.")]
        public string Descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
