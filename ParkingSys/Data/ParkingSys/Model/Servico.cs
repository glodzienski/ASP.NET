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

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe o nome do servi�o.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe o c�digo do servi�o.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe se o servi�o est� ativo ou n�o.")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe o valor do servi�o.")]
        public double Valor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comanda> Comanda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PacoteServico> PacoteServico { get; set; }
    }
}
