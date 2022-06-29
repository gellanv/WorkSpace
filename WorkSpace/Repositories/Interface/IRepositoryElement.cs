using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.Repositories.Interface
{
    public interface IRepositoryElement
    {
        IEnumerable<Element> GetList();
        Element Get(int id);
        void Create(Element element);
        void Update(Element element);
        void Delete(int id);
        void Save();
    }
}
