using AutoMapper;
using CSF.CadastroCliente.API.Model;
using CSF.CadastroCliente.Domain.Model;

namespace CSF.CadastroCliente.API.AutoMapper
{
    public class NovoClienteEnderecoTypeConverter : ITypeConverter<NovoEnderecoModel, ClienteEndereco>
    {
        public ClienteEndereco Convert(NovoEnderecoModel source, ClienteEndereco destination, ResolutionContext context)
        {
            if (destination == null) destination = new ClienteEndereco();

            destination.Endereco = context.Mapper.Map<Endereco>(source);

            return destination;
        }
    }
}
