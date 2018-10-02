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

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe o nome do tipo de ve�culo.")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe quantas rodas tem o ve�culo.")]
        public int Rodas { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe quantos eixos tem o ve�culo.")]
        public int Eixos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Veiculo> Veiculo { get; set; }
    }
}
