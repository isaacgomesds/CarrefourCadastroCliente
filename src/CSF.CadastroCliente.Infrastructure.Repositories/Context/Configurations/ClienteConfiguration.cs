using CSF.CadastroCliente.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSF.CadastroCliente.Infrastructure.Repositories.Context.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_CLIENTE");

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();

            builder.Property(e => e.DataNascimento).HasColumnName("DATA_NASCIMENTO");
            builder.Property(e => e.CodEmpresa).HasColumnName("COD_EMPRESA");
        }
    }
}
