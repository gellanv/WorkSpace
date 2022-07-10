﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;
using WorkSpace.DTO;
using WorkSpace.ViewModels.Response;
using WorkSpace.ViewModels.Request;
using static WorkSpace.DTO.PageDTO;
using static WorkSpace.DTO.PageDTO.BlockDTO;

namespace WorkSpace.Mappings
{
    public class MappingProfile : Profile
    {
        //Изменения для записи
        public MappingProfile()
        {
            CreateMap<User,UserDTO>().ReverseMap();

            CreateMap<Models.WorkSpace, WorkSpaceDTO>().ReverseMap();

            CreateMap<CreateWorkSpaceRequest, WorkSpaceDTO>().ReverseMap();
            CreateMap<WorkSpaceDTO, CreateWorkSpaceResponse>().ReverseMap();

            CreateMap<GetAllWorkSpaceResponse, WorkSpaceDTO>().ReverseMap();

            CreateMap<Page, WorkSpaceGetPagesDTO>().ReverseMap();
            CreateMap<WorkSpaceGetPagesDTO, GetWorkSpaceByIdResponse>().ReverseMap();

            CreateMap<ChangeWorkSpaceNameRequest, WorkSpaceDTO>().ReverseMap();
            CreateMap<ChangeNameWorkSpaceResponse, WorkSpaceDTO>().ReverseMap();

            CreateMap<Block, BlockDTO>().ReverseMap();

            CreateMap<IEnumerable<Element>, IEnumerable<ElementDTO>>().ReverseMap();
            CreateMap<IEnumerable<Block>, IEnumerable<BlockDTO>>().ReverseMap();
            CreateMap<Page, PageDTO>().ReverseMap();

           // CreateMap<BlockDTO.ElementDTO, GetPageByIdResponse.ElementDTO>().ReverseMap();
            CreateMap<BlockDTO, GetPageByIdResponse>().ReverseMap();


            CreateMap<ChangePageNameRequest, ChangePageNameDTO>().ReverseMap();
            CreateMap<ChangePageNameDTO, Page>().ReverseMap();
            CreateMap<ChangePageNameDTO, ChangePageNameResponse>().ReverseMap();

        }
    } 
}
