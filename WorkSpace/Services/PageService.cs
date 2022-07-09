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
        public async Task<IEnumerable<BlocksElementsDTO>> GetBlocksElementsOfPageById(int pageId)
        {
            var listBlocksElementsDTOs = await unitOfWork.RepositoryPage.GetPageById(pageId);

            return listBlocksElementsDTOs;
        }

    }
}
