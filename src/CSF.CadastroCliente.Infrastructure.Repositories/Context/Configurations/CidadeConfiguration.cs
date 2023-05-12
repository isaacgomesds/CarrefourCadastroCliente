using CSF.CadastroCliente.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSF.CadastroCliente.Infrastructure.Repositories.Context.Configurations
{
    internal class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("TB_CIDADE");

            builder.HasKey(t => t.Id);
        }
    }
}
