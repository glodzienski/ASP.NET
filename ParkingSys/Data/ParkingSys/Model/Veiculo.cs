namespace Data.ParkingSys.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Veiculo")]
    public partial class Veiculo : Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Veiculo()
        {
            Comanda = new HashSet<Comanda>();
        }

        public int VeiculoID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe a placa do veículo.")]
        public string Placa { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o tipo de veículo.")]
        [Display(Name = "Tipo de veículo")]
        public int VeiculoTipoID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe a marca do veículo")]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        public virtual Cliente _Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comanda> Comanda { get; set; }

        public virtual VeiculoTipo _VeiculoTipo { get; set; }
    }
}
