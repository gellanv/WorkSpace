using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.Repositories
{
    public interface IRepositoryPage
    {
        IEnumerable<Page> GetList(); // получение всех объектов
        Page Get(int id); // получение одного объекта по id
        void Create(Page item); // создание объекта
        void Update(Page item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
