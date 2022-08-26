using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.DTO;
using WorkSpace.Models;

namespace WorkSpace.Repositories
{
    public interface IRepositoryPage
    {
        public IEnumerable<Page> GetList(); // получение всех объектов
        public Task<PageDTO> GetPageDTOById(int id); // получение одного объекта по id
        public Task<Page> GetPageById(int id); // получение одного объекта по id
        public Task<Page> Create(Page page); // создание объекта
        public void Update(Page page); // обновление объекта
        public void Delete(Page page); // удаление объекта по id
        public void DeleteRange(IEnumerable<Page> pages);
        public Task<IEnumerable<Page>> GetListPagesNotDeleted(int workSpaceId);
        public Task<IEnumerable<Page>> GetListPagesDeleted(string userId);
        public Task<IEnumerable<Page>> GetListFavoritePages(string userId);

    }
}
