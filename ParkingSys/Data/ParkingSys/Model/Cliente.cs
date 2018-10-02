namespace Data.ParkingSys.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente : Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Comanda = new HashSet<Comanda>();
            Veiculo = new HashSet<Veiculo>();
        }

        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o sobrenome.")]
        public string Sobrenome { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe se o cliente está ativo ou não.")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o CPF.")]
        [RegularExpression(@"\d\d\d.\d\d\d.\d\d\d-\d\d", ErrorMessage = "CEP deve estar no formato 999.999.999-99")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o CEP.")]
        public int Cep { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public int Numero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comanda> Comanda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Veiculo> Veiculo { get; set; }
    }
}
