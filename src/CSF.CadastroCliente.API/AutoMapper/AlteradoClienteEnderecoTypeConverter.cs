using AutoMapper;
using CSF.CadastroCliente.API.Model;
using CSF.CadastroCliente.Domain.Model;

namespace CSF.CadastroCliente.API.AutoMapper
{
    public class AlteradoClienteEnderecoTypeConverter : ITypeConverter<AlteradoEnderecoModel, ClienteEndereco>
    {
        public ClienteEndereco Convert(AlteradoEnderecoModel source, ClienteEndereco destination, ResolutionContext context)
        {
            if (destination == null) destination = new ClienteEndereco();

            destination.EnderecoId = source.Id;
            destination.Endereco = context.Mapper.Map<Endereco>(source);

            return destination;
        }
    }
}
