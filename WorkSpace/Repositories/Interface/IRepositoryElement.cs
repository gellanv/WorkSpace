using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Models;

namespace WorkSpace.Repositories.Interface
{
    public interface IRepositoryElement
    {
        public Task<Element> Create(Element element);

        public Task<Element> GetElementById(int elementId);

        public Task<IEnumerable<Element>> ChangeElementPosition(int idElement, int newPosition);

        public Task<List<Element>> GetElementByBlockId(int blockId);

        void Update(Element element);

        void Delete(Element element);
    }
}
