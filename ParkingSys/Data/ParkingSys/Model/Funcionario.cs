namespace Data.ParkingSys.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Funcionario")]
    public partial class Funcionario : Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionario()
        {
            Comanda = new HashSet<Comanda>();
        }

        public int FuncionarioID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o sobrenome.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o email, o mesmo é usado para efetuar login na plataforma.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe a senha, a mesmo é usado para efetuar login na plataforma.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe se o funcionário está ativo ou não.")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o CPF.")]
        [RegularExpression(@"\d\d\d.\d\d\d.\d\d\d-\d\d", ErrorMessage = "CEP deve estar no formato 999.999.999-99")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe se o funcionário é administrador ou não.")]
        public bool Administrador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comanda> Comanda { get; set; }
    }
}
