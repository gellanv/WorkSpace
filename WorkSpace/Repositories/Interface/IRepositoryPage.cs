using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.Repositories
{
    public interface IRepositoryPage
    {
        public IEnumerable<Page> GetList(); // получение всех объектов
        public Task<IEnumerable<Block>> GetPageById(int id); // получение одного объекта по id
        public Task<Page> Create(Page page); // создание объекта
        public void Update(Page page); // обновление объекта
        public void Delete(int id); // удаление объекта по id
    }
}
