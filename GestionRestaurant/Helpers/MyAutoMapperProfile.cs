using AutoMapper;
using GestionRestaurant.Models;
using GestionRestaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestaurant.Helpers
{
    public class MyAutoMapperProfile:Profile 
    {
        public MyAutoMapperProfile()
        {
            CreateMap<TableCmd, TableCmdViewModel>().ReverseMap();

            CreateMap<TableCmd, DetailsTableCmdViewModel>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Serveur.Name))
                .ForMember(dest => dest.Phone,
                    opt => opt.MapFrom(src => src.Serveur.Phone))
                .ForMember(dest => dest.NumberOfPlace,
                    opt => opt.DoNotUseDestinationValue());

        }
    }
}
