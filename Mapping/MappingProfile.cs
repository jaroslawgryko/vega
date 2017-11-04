using System.Linq;
using AutoMapper;
using Vega.Controllers.Resources;
using Vega.Models;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resources

            CreateMap<Marka, MarkaResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Atrybut, AtrybutResource>();

            //API Resources to Domain
            CreateMap<PojazdResource, Pojazd>()
            .ForMember(p => p.KontaktNazwa, opt => opt.MapFrom(pr => pr.Kontakt.Nazwa))
            .ForMember(p => p.KontaktEmail, opt => opt.MapFrom(pr => pr.Kontakt.Email))
            .ForMember(p => p.KontaktTelefon, opt => opt.MapFrom(pr => pr.Kontakt.Telefon))
            .ForMember(p => p.Atrybuty, opt => opt.MapFrom(pr => pr.Atrybuty.Select(id => new PojazdAtrybut { AtrybutId = id } )));
        }
    }
}