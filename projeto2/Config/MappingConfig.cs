using AutoMapper;
using projeto2.API.Data.ValueObjects;
using projeto2.API.Model;

namespace projeto2.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingconfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PessoaVO, Pessoa>().ReverseMap();
                config.CreateMap<PessoaUpdateVO, Pessoa>().ReverseMap();
                config.CreateMap<PessoaViewVO, Pessoa>().ReverseMap();
                config.CreateMap<EmpresaVO, Empresa>().ReverseMap();
                config.CreateMap<EmpresaUpdateVO, Empresa>().ReverseMap();
                config.CreateMap<EmpresaViewVO, Empresa>().ReverseMap();
                config.CreateMap<EnderecoVO, Endereco>().ReverseMap();
            });
            return mappingconfig;
        }
    }
}
