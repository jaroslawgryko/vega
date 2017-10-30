using AutoMapper;
using Vega.Controllers.Resources;
using Vega.Models;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Marka, MarkaResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Atrybut, AtrybutResource>();
        }
    }
}