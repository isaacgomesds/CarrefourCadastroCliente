using AutoMapper;
using CSF.CadastroCliente.API.Model;
using CSF.CadastroCliente.Domain.Model;

namespace CSF.CadastroCliente.API.AutoMapper
{
    public class EnderecoModelTypeConverter : ITypeConverter<ClienteEndereco, EnderecoModel>
    {
        public EnderecoModel Convert(ClienteEndereco source, EnderecoModel destination, ResolutionContext context)
        {
            return context.Mapper.Map<EnderecoModel>(source.Endereco);
        }
    }
}
