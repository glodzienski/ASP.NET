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

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe o total.")]
        public double Total { get; set; }

        [Display(Name = "Status")]
        public int ComandaStatusID { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe o servi�o da comanda.")]
        [Display(Name = "Servi�o")]
        public int ServicoID { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe a vaga.")]
        [Display(Name = "Vaga")]
        public int VagaID { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe o cliente.")]
        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe o funcion�rio.")]
        [Display(Name = "Funcion�rio respons�vel")]
        public int FuncionarioID { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio! Favor informe o ve�culo.")]
        [Display(Name = "Ve�culo")]
        public int VeiculoID { get; set; }

        public virtual Cliente _Cliente { get; set; }

        public virtual ComandaStatus _ComandaStatus { get; set; }

        public virtual Funcionario _Funcionario { get; set; }

        public virtual Servico _Servico { get; set; }

        public virtual Vaga _Vaga { get; set; }

        public virtual Veiculo _Veiculo { get; set; }
    }
}
