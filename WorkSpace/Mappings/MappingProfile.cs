using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;
using WorkSpace.DTO;
using WorkSpace.ViewModels.Response;


namespace WorkSpace.Mappings
{
    public class MappingProfile : Profile
    {
        //Изменения для записи
        public MappingProfile()
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<Models.WorkSpace, WorkSpaceDTO>().ReverseMap();
            CreateMap<GetAllWorkSpaceResponse, WorkSpaceDTO>().ReverseMap();
        }
    } 
}
