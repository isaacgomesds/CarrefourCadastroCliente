using CSF.CadastroCliente.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSF.CadastroCliente.Infrastructure.Repositories.Context.Configurations
{
    public class ClienteEnderecoConfiguration : IEntityTypeConfiguration<ClienteEndereco>
    {
        public void Configure(EntityTypeBuilder<ClienteEndereco> builder)
        {
            builder.ToTable("TB_CLIENTE_ENDERECO");

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.ClienteId).HasColumnName("TB_CLIENTE_ID");
            builder.Property(e => e.EnderecoId).HasColumnName("TB_ENDERECO_ID");

            builder.HasOne(e => e.Cliente)
                .WithMany(e => e.Enderecos)
                .HasForeignKey(e => e.ClienteId);

            builder.HasOne(e => e.Endereco)
                .WithMany()
                .HasForeignKey(e => e.EnderecoId);
        }
    }
}
