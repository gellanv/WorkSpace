using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.DTO;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;
using WorkSpace.Services.Interface;

namespace WorkSpace.Services
{
    public class PageService: IPageService
    {
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;
        public PageService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            this.unitOfWork = _unitOfWork;
            this.mapper = _mapper;
        }

        public async Task<PageDTO> DuplicatePage(int pageId)
        {
            if (pageId > 0)
            {
                var page = await unitOfWork.RepositoryPage.GetPageById(pageId);
                if (page != null)
                {
                    page.Name += " - copy";
                    page.Id = 0;
                    var copyPage = unitOfWork.RepositoryPage.Create(page);
                    await unitOfWork.SaveAsync();
                    var newPageDTO = mapper.Map<PageDTO>(copyPage.Result);
                    return newPageDTO;
                }
                else throw new Exception("такой pageId не найден");
            }
            else throw new Exception("такого pageId не существует");
        }
        public async Task DeletePageById(int pageId)
        {
            if (pageId > 0)
            {
                var page = await unitOfWork.RepositoryPage.GetPageById(pageId);
                if (page != null)
                {
                    unitOfWork.RepositoryPage.Delete(page);
                    await unitOfWork.SaveAsync();
                }
                else throw new Exception("такой pageId не найден");
            }
            else throw new Exception("такого pageId не существует");
        }

        public async Task<PageDTO> GetPageById(int pageId)
        {
            var PageDTO = await unitOfWork.RepositoryPage.GetPageDTOById(pageId);

            return PageDTO;
        }

        public async Task<ChangePageNameDTO> ChangePageNameById(ChangePageNameDTO changePageNameDTO)
        {
            var modelPage = await unitOfWork.RepositoryPage.GetPageById(changePageNameDTO.Id);
            modelPage.Name = changePageNameDTO.Name;

            unitOfWork.RepositoryPage.Update(modelPage);
            await unitOfWork.SaveAsync();

            var DTO = mapper.Map<ChangePageNameDTO>(modelPage);

            return DTO;
        }
        public async Task<PageDTO> AddRemoveFavouritesById(PageDTO addToFavouritesByIdDTO)
        {
            var modelPage = await unitOfWork.RepositoryPage.GetPageById(addToFavouritesByIdDTO.Id);

            modelPage.Favourite = addToFavouritesByIdDTO.Favourite; 

            unitOfWork.RepositoryPage.Update(modelPage);
            await unitOfWork.SaveAsync();

            var DTO = mapper.Map<PageDTO>(modelPage);

            return DTO;
        }
        public async Task<PageDTO> PushPullPageToTrashById(PageDTO trashPageDTO)
        {
            var modelPage = await unitOfWork.RepositoryPage.GetPageById(trashPageDTO.Id);

            modelPage.Deleted = trashPageDTO.Deleted;

            unitOfWork.RepositoryPage.Update(modelPage);
            await unitOfWork.SaveAsync();

            var DTO = mapper.Map<PageDTO>(modelPage);

            return DTO;
        }
        public async Task<PageDTO> CreatePage(PageDTO pageDTO)
        {
            var pageModel = mapper.Map<Page>(pageDTO);
            pageModel.DateCreate = DateTime.Now;
            var newPage = unitOfWork.RepositoryPage.Create(pageModel);
            await unitOfWork.SaveAsync();
            var newPageDTO = mapper.Map<PageDTO>(newPage.Result);

            return newPageDTO;
        }

        public async Task<IEnumerable<WorkSpaceDTO>> GetListDeletedPages(string userId)
        {
            var workSpaces = await unitOfWork.RepositoryPage.GetListPagesDeleted(userId);
            var workSpacesDTO = mapper.Map<IEnumerable<WorkSpaceDTO>>(workSpaces);

            return workSpacesDTO;
        }
        public async Task<IEnumerable<WorkSpaceDTO>> GetListFavoritePages(string userId)
        {
            var workSpaces = await unitOfWork.RepositoryPage.GetListPagesDeleted(userId);
            var workSpacesDTO = mapper.Map<IEnumerable<WorkSpaceDTO>>(workSpaces);

            return workSpacesDTO;
        }
    }
}
