namespace Data.ParkingSys.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vaga")]
    public partial class Vaga : Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vaga()
        {
            Comanda = new HashSet<Comanda>();
        }

        [Key]
        public int VagaID { get; set; }

        [Required(ErrorMessage ="Este campo � obrigat�rio! Favor inserir um c�digo.")]
        [MaxLength(3,ErrorMessage ="O valor m�ximo para c�digo � 999")]
        public string Codigo { get; set; }

        public string Andar { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe se a vaga est� ocupada ou n�o.")]
        public bool Ocupada { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe se a vaga est� ativa ou n�o.")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe o tipo da vaga.")]
        [Display(Name = "Tipo de vaga")]
        public int VagaTipoID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comanda> Comanda { get; set; }

        public virtual VagaTipo _VagaTipo { get; set; }
    }
}
