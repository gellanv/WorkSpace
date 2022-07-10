using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.DTO;
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

    }
}
