using AutoMapper;
using Kolokwium_30_06_2024_w66049.Data;
using Kolokwium_30_06_2024_w66049.Models.DruzynaPilkarska;
using Kolokwium_30_06_2024_w66049.Models.Mecz;

namespace Kolokwium_30_06_2024_w66049.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        // CreateMap<Entity, EntityDto>().ReverseMap();
        CreateMap<DruzynaPilkarska, DruzynaPilkarskaDto>().ReverseMap();
        CreateMap<Mecz, MeczDto>().ReverseMap();
    }
}