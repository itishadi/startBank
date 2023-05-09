using AutoMapper;
using startBank.BankAppDatas;
using startBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerModel, Customer>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Givenname, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Streetaddress, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Zipcode, opt => opt.MapFrom(src => src.Zipcode))
                .ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.CountryCode))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.NationalId, opt => opt.MapFrom(src => src.NationalID))
                .ForMember(dest => dest.Telephonenumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Emailaddress, opt => opt.MapFrom(src => src.Email))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Givenname))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Streetaddress))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.CountryCode))
                .ForMember(dest => dest.Zipcode, opt => opt.MapFrom(src => src.Zipcode))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.NationalID, opt => opt.MapFrom(src => src.NationalId))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Telephonenumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Emailaddress));
        }
    }

}
