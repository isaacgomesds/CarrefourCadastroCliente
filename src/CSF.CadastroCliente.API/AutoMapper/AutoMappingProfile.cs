using AutoMapper;
using CSF.CadastroCliente.API.Model;
using CSF.CadastroCliente.Domain.Model;

namespace CSF.CadastroCliente.API.AutoMapper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<NovoClienteModel, Cliente>()
                .ReverseMap();
            CreateMap<NovoEnderecoModel, Endereco>()
                .ReverseMap();

            CreateMap<NovoEnderecoModel, ClienteEndereco>()
                .ConvertUsing<NovoClienteEnderecoTypeConverter>();
            CreateMap<AlteradoEnderecoModel, ClienteEndereco>()
                .ConvertUsing<AlteradoClienteEnderecoTypeConverter>();

            CreateMap<AlteradoClienteModel, Cliente>()
                 .AfterMap((src, dest) =>
                 {
                     dest.Enderecos.ForEach(e => e.ClienteId = src.Id);
                 })
                .ReverseMap();
            CreateMap<AlteradoEnderecoModel, Endereco>()
                .ReverseMap();

            CreateMap<ClienteModel, Cliente>()
                .ReverseMap();
            CreateMap<EnderecoModel, Endereco>()
                .ReverseMap()
                .ForMember(m => m.Cidade, opt => opt.MapFrom(e => e.Cidade.Nome))
                .ForMember(m => m.Estado, opt => opt.MapFrom(e => e.Cidade.Estado));
            
            CreateMap<ClienteEndereco, EnderecoModel>()
                .ConvertUsing<EnderecoModelTypeConverter>();

        }
    }
}
