﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;
using WorkSpace.DTO;

namespace WorkSpace.Mappings
{
    public class MappingProfile : Profile
    {
        //Изменения для записи
        public MappingProfile()
        {
            CreateMap<User,UserDTO>().ReverseMap();
        }
    } 
}
