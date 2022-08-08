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

            CreateMap<Block, PageDTO.BlockDTO>().ReverseMap();

            CreateMap<Element, PageDTO.BlockDTO.ElementDTO>().ReverseMap();
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
            CreateMap<PageDTO, GetListPagesResponse>().ReverseMap();

            CreateMap<CreatePageResponse, PageDTO>().ReverseMap();
            CreateMap<CreatePageResponse.BlockResponse, PageDTO.BlockDTO>().ReverseMap();
            CreateMap<CreatePageResponse.BlockResponse.ElementResponse, PageDTO.BlockDTO.ElementDTO>().ReverseMap();

            CreateMap<CreateElementRequest, DTO.ElementDTO>().ReverseMap();
            CreateMap<CreateElementResponse, DTO.ElementDTO>().ReverseMap();
            CreateMap<ChangeElementRequest, DTO.ElementDTO>().ReverseMap();
            CreateMap<ChangeElementResponse, DTO.ElementDTO>().ReverseMap();
            CreateMap<DTO.ElementDTO, Element>().ReverseMap();
            CreateMap<Page, PageTemplateDTO>().ReverseMap();
            CreateMap<Block, PageTemplateDTO.BlockTemplateDTO>().ReverseMap();
            CreateMap<Element, PageTemplateDTO.BlockTemplateDTO.ElementTemplateDTO>().ReverseMap();

            CreateMap<AddListBlocksTemplateResponse, PageTemplateDTO>().ReverseMap();
            CreateMap<AddListBlocksTemplateResponse.BlockTemplateResponse, PageTemplateDTO.BlockTemplateDTO>().ReverseMap();
            CreateMap<AddListBlocksTemplateResponse.BlockTemplateResponse.ElementTemplateResponse, PageTemplateDTO.BlockTemplateDTO.ElementTemplateDTO>().ReverseMap();

            CreateMap<CreateBlockRequest, DTO.BlockDTO>().ReverseMap();
            CreateMap<Block, DTO.BlockDTO>().ReverseMap();

            CreateMap<UpdateBlockRequest, UpdateBlockDTO>().ReverseMap();
            CreateMap<Block, UpdateBlockDTO>().ReverseMap();

            CreateMap<ChangeBlockTitleRequest, ChangeBlockTitleDTO>().ReverseMap();
            CreateMap<Block, ChangeBlockTitleDTO>().ReverseMap();

            CreateMap<Block, BlockDuplicateDTO>().ReverseMap();

        }
    } 
}
