using AutoMapper;
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
            CreateMap<Page, WorkSpaceWithListPagesDTO.PagesDTO>().ReverseMap();

            CreateMap<GetAllWorkSpaceResponse, WorkSpaceDTO>().ReverseMap();

            CreateMap<Page, WorkSpaceGetPagesDTO>().ReverseMap();
            CreateMap<WorkSpaceGetPagesDTO, GetWorkSpaceByIdResponse>().ReverseMap();
            CreateMap<WorkSpaceWithListPagesDTO, GetWorkSpaceByIdResponse>().ReverseMap();

            CreateMap<ChangeWorkSpaceNameRequest, WorkSpaceDTO>().ReverseMap();
            CreateMap<ChangeNameWorkSpaceResponse, WorkSpaceDTO>().ReverseMap();

            CreateMap<Block, BlockDTO>().ReverseMap();

            CreateMap<Element, ElementDTO>().ReverseMap();
            CreateMap<Page, PageDTO>().ReverseMap();
            CreateMap<Block, PageDTO.BlockDTO>().ReverseMap();
            CreateMap<Element, PageDTO.BlockDTO.ElementDTO>().ReverseMap();

            CreateMap<PageDTO, GetPageByIdResponse>().ReverseMap();


            CreateMap<PageRequest, ChangePageNameDTO>().ReverseMap();
            CreateMap<PageRequest, PageDTO>().ReverseMap();
            CreateMap<ChangePageNameDTO, Page>().ReverseMap();
            CreateMap<ChangePageNameDTO, ChangePageNameResponse>().ReverseMap();

            CreateMap<CreatePageRequest, PageDTO>().ReverseMap();
            CreateMap<PageDTO, Page>().ReverseMap();
            CreateMap<PageDTO, CreatePageResponse>().ReverseMap();


            CreateMap<CreatePageResponse, PageDTO>().ReverseMap();
            CreateMap<CreatePageResponse.BlockResponse, PageDTO.BlockDTO>().ReverseMap();
            CreateMap<CreatePageResponse.BlockResponse.ElementResponse, PageDTO.BlockDTO.ElementDTO>().ReverseMap();


        }
    } 
}
