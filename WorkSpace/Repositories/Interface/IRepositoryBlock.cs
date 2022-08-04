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
        Task<Block> Create(Block block); // создание объекта
        void Update(Block block); // обновление объекта
        void Delete(Block block); // удаление объекта по id
        Task<Template> GetTemplateById(int id);
        Task<Block> GetBlockById(int id);
    }
}
