﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WorkSpace.Behaviors.Interface;
using WorkSpace.DTO;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;
using WorkSpace.Services.Interface;

namespace WorkSpace.Services
{
    public class PageService : IPageService
    {
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;
        readonly IValidation validation;
        public PageService(IUnitOfWork _unitOfWork, IMapper _mapper, IValidation _validation)
        {
            this.unitOfWork = _unitOfWork;
            this.mapper = _mapper;
            this.validation = _validation;
        }

        public async Task<PageDTO> DuplicatePage(string UserId, int pageId)
        {
            validation.CheckId(pageId);
            Page page = await unitOfWork.RepositoryPage.GetPageById(pageId);
            validation.CheckObjectForNull(page);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(page.WorkSpaceId);
            validation.CheckObjectForNull(workSpace);

            if (workSpace != null && workSpace.UserId == UserId)
            {
                Page newPage = new Page() { Name = page.Name + "-copy", DateCreate = DateTime.Now, Favourite = false, Deleted = false, WorkSpaceId = page.WorkSpaceId };
                newPage = unitOfWork.RepositoryPage.Create(newPage).Result;
                await unitOfWork.SaveAsync();

                for (int i = 0; i < page.Blocks.Count; i++)
                {
                    Block newBlock = new Block() { PageId = newPage.Id,
                                                   X = page.Blocks[i].X,
                                                   Y = page.Blocks[i].Y,
                                                   Height = page.Blocks[i].Height,
                                                   Width = page.Blocks[i].Width,
                                                   Style = page.Blocks[i].Style, 
                                                   Title = page.Blocks[i].Title };
                    newBlock = unitOfWork.RepositoryBlock.Create(newBlock).Result;
                    await unitOfWork.SaveAsync();
                    for (int j = 0; j < page.Blocks[i].Elements.Count; j++)
                    {
                        Element newElement = new Element { BlockId = newBlock.Id, ContentHtml = page.Blocks[i].Elements[j].ContentHtml };
                        await unitOfWork.RepositoryElement.Create(newElement);
                        await unitOfWork.SaveAsync();
                    }
                }
                PageDTO newPageDTO = await unitOfWork.RepositoryPage.GetPageDTOById(newPage.Id);
                return newPageDTO;
            }
            else
            {
                throw new Exception("No access");
            }
        }

        public async Task DeletePageById(string UserId, int pageId)
        {
            validation.CheckId(pageId);
            Page page = await unitOfWork.RepositoryPage.GetPageById(pageId);
            validation.CheckObjectForNull(page);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(page.WorkSpaceId);
            validation.CheckObjectForNull(workSpace);

            if (workSpace != null && workSpace.UserId == UserId)
            {
                unitOfWork.RepositoryPage.Delete(page);
                await unitOfWork.SaveAsync();
            }
            else
            {
                throw new Exception("No access");
            }
        }
        public async Task ClearTrash(string UserId)
        {
            IEnumerable<Page> pages = await unitOfWork.RepositoryPage.GetListPagesDeleted(UserId);

            unitOfWork.RepositoryPage.DeleteRange(pages);
            await unitOfWork.SaveAsync();
        }

        public async Task<PageDTO> GetPageById(string UserId, int pageId)
        {
            validation.CheckId(pageId);
            PageDTO pageDTO = await unitOfWork.RepositoryPage.GetPageDTOById(pageId);
            validation.CheckObjectForNull(pageDTO);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(pageDTO.WorkSpaceId);
            validation.CheckObjectForNull(workSpace);

            if (workSpace != null && workSpace.UserId == UserId)
            {
                return pageDTO;
            }
            else
            {
                throw new Exception("No access");
            }
        }

        public async Task<ChangePageNameDTO> ChangePageNameById(string UserId, ChangePageNameDTO changePageNameDTO)
        {
            validation.CheckId(changePageNameDTO.Id);
            validation.CheckObjectForValid(changePageNameDTO);

            Page modelPage = await unitOfWork.RepositoryPage.GetPageById(changePageNameDTO.Id);
            validation.CheckObjectForNull(modelPage);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(modelPage.WorkSpaceId);
            if (workSpace != null && workSpace.UserId == UserId)
            {
                modelPage.Name = changePageNameDTO.Name;
                unitOfWork.RepositoryPage.Update(modelPage);
                await unitOfWork.SaveAsync();

                ChangePageNameDTO changePageNameDto = mapper.Map<ChangePageNameDTO>(modelPage);

                return changePageNameDto;
            }
            else
            {
                throw new Exception("No access");
            }
        }

        public async Task AddRemoveFavouritesById(string UserId, int id)
        {
            validation.CheckId(id);
            Page modelPage = await unitOfWork.RepositoryPage.GetPageById(id);
            validation.CheckObjectForNull(modelPage);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(modelPage.WorkSpaceId);
            if (workSpace != null && workSpace.UserId == UserId)
            {
                modelPage.Favourite = modelPage.Favourite == true ? false : true;
                unitOfWork.RepositoryPage.Update(modelPage);
                await unitOfWork.SaveAsync();
            }
            else
            {
                throw new Exception("No access");
            }
        }

        public async Task PushPullPageToTrashById(string UserId, int id)
        {
            validation.CheckId(id);
            Page modelPage = await unitOfWork.RepositoryPage.GetPageById(id);
            validation.CheckObjectForNull(modelPage);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(modelPage.WorkSpaceId);
            if (workSpace != null && workSpace.UserId == UserId)
            {
                modelPage.Deleted = modelPage.Deleted == true ? false : true;
                unitOfWork.RepositoryPage.Update(modelPage);
                await unitOfWork.SaveAsync();
            }
            else
            {
                throw new Exception("No access");
            }
        }

        public async Task<PageDTO> CreatePage(string UserId, PageDTO pageDTO)
        {
            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(pageDTO.WorkSpaceId);
            validation.CheckObjectForNull(workSpace);

            if (workSpace.UserId == UserId)
            {
                Page pageModel = mapper.Map<Page>(pageDTO);
                pageModel.DateCreate = DateTime.Now;
                Page newPage = unitOfWork.RepositoryPage.Create(pageModel).Result;
                await unitOfWork.SaveAsync();
                PageDTO newPageDTO = mapper.Map<PageDTO>(newPage);

                return newPageDTO;
            }
            else
            {
                throw new Exception("No access");
            }
        }
        public async Task<IEnumerable<PageDTO>> GetListDeletedPages(string userId)
        {
            IEnumerable<Page> pages = await unitOfWork.RepositoryPage.GetListPagesDeleted(userId);
            IEnumerable<PageDTO> pageDtos = mapper.Map<IEnumerable<PageDTO>>(pages);
            return pageDtos;
        }

        public async Task<IEnumerable<PageDTO>> GetListFavoritePages(string userId)
        {
            IEnumerable<Page> pages = await unitOfWork.RepositoryPage.GetListFavoritePages(userId);
            IEnumerable<PageDTO> pageDtos = mapper.Map<IEnumerable<PageDTO>>(pages);
            return pageDtos;
        }
    }
}
