namespace Data.ParkingSys.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Servico")]
    public partial class Servico : Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servico()
        {
            Comanda = new HashSet<Comanda>();
            PacoteServico = new HashSet<PacoteServico>();
        }

        [Key]
        public int ServicoID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o nome do serviço.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o código do serviço.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe se o serviço está ativo ou não.")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o valor do serviço.")]
        public double Valor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comanda> Comanda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PacoteServico> PacoteServico { get; set; }
    }
}
