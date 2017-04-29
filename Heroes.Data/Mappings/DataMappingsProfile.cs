using AutoMapper;
using Heroes.Data.Models;
using Heroes.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Data.Mappings
{
    public class DataMappingsProfile : Profile
    {
        public DataMappingsProfile()
        {
            CreateMap<Country, CountryDTO>(MemberList.None)
                .ReverseMap()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(y => y.CreatedAt ?? DateTime.Now));
            CreateMap<Power, PowerDTO>(MemberList.None)
                .ReverseMap()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(y => y.CreatedAt ?? DateTime.Now));
            CreateMap<Hero, HeroDTO>(MemberList.None)
                .ReverseMap()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(y => y.CreatedAt ?? DateTime.Now));
        }
    }
}
