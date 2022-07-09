using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;
using WorkSpace.DTO;
using WorkSpace.ViewModels.Response;
using WorkSpace.ViewModels.Request;
using static WorkSpace.DTO.BlocksElementsDTO;

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

            CreateMap<Block, BlocksElementsDTO>().ReverseMap();
            
            CreateMap<Element, ElementDTO>().ReverseMap();
            CreateMap<Element, BlocksElementsDTO>().ReverseMap();

            CreateMap<BlocksElementsDTO.ElementDTO, BlocksElementsResponse.ElementDTO>().ReverseMap();
            CreateMap<BlocksElementsDTO, BlocksElementsResponse>().ReverseMap();
            
        }
    } 
}
