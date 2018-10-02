namespace Data.ParkingSys.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comanda")]
    public partial class Comanda : Model
    {
        [Key]
        public int ComandaID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o total.")]
        public double Total { get; set; }

        [Display(Name = "Status")]
        public int ComandaStatusID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o serviço da comanda.")]
        [Display(Name = "Serviço")]
        public int ServicoID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe a vaga.")]
        [Display(Name = "Vaga")]
        public int VagaID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o cliente.")]
        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o funcionário.")]
        [Display(Name = "Funcionário responsável")]
        public int FuncionarioID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Favor informe o veículo.")]
        [Display(Name = "Veículo")]
        public int VeiculoID { get; set; }

        public virtual Cliente _Cliente { get; set; }

        public virtual ComandaStatus _ComandaStatus { get; set; }

        public virtual Funcionario _Funcionario { get; set; }

        public virtual Servico _Servico { get; set; }

        public virtual Vaga _Vaga { get; set; }

        public virtual Veiculo _Veiculo { get; set; }
    }
}
