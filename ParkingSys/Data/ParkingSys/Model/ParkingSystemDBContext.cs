namespace Data.ParkingSys.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ParkingSystemDBContext : DbContext
    {
        public ParkingSystemDBContext()
            : base("name=ParkingSystemDBContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Comanda> Comanda { get; set; }
        public virtual DbSet<ComandaStatus> ComandaStatus { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Pacote> Pacote { get; set; }
        public virtual DbSet<PacoteServico> PacoteServico { get; set; }
        public virtual DbSet<Servico> Servico { get; set; }
        public virtual DbSet<Vaga> Vaga { get; set; }
        public virtual DbSet<VagaTipo> VagaTipo { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<VeiculoTipo> VeiculoTipo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
