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
                config.CreateMap<PessoaVO, Pessoa>();
                config.CreateMap<Pessoa, PessoaVO>();
            });
            return mappingconfig;
        }
    }
}
