using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.Repositories.Interface
{
    public interface IRepositoryBlock
    {
        IEnumerable<Block> GetList(); // получение всех объектов
        Block Get(int id); // получение одного объекта по id
        void Create(Block block); // создание объекта
        void Update(Block block); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
