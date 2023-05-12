using CSF.CadastroCliente.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSF.CadastroCliente.Infrastructure.Repositories.Context.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("TB_ENDERECO");

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();

            builder.Property(e => e.TipoEndereco).HasColumnName("TIPO_ENDERECO");
            builder.Property(e => e.CidadeId).HasColumnName("TB_CIDADE_ID");

            builder.HasOne(e => e.ClienteEndereco)
                .WithOne(e => e.Endereco);
        }
    }
}
