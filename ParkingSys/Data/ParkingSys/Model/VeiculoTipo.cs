namespace Data.ParkingSys.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VeiculoTipo")]
    public partial class VeiculoTipo : Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VeiculoTipo()
        {
            Veiculo = new HashSet<Veiculo>();
        }

        public int VeiculoTipoID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o nome do tipo de veículo.")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe quantas rodas tem o veículo.")]
        public int Rodas { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe quantos eixos tem o veículo.")]
        public int Eixos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Veiculo> Veiculo { get; set; }
    }
}
