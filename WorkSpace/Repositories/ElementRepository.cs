using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;

namespace WorkSpace.Repositories
{
    public class ElementRepository : IRepositoryElement
    {
        private readonly WorkSpaceContext context;

        public ElementRepository(WorkSpaceContext _context)
        {
            this.context = _context;
        }

        public async Task<Element> Create(Element element)
        {
            int count = context.Elements.Where(x => x.BlockId == element.BlockId).Count();
            element.Position = ++count;
            await context.Elements.AddAsync(element);

            return element;
        }

        public async Task<Element> GetElementById(int elementId)
        {
            return await context.Elements.Where(x => x.Id == elementId).FirstOrDefaultAsync();
        }

        public void Update(Element element)
        {
            context.Entry(element).State = EntityState.Modified;
        }

        public void Delete(Element element)
        {
            int elementPosition = element.Position;
            List<Element> elementsBlock = context.Elements.Where(x => x.BlockId == element.BlockId).ToList();

            if (elementsBlock.Count() > elementPosition)
            {
                for(int i= elementPosition+1;i<= elementsBlock.Count(); i++)
                {
                    Element elementTemp = context.Elements.Where(x => x.Position == i).FirstOrDefault();
                    elementTemp.Position--;
                    context.Elements.Update(elementTemp);
                }
            }
            context.Elements.Remove(element);
        }
    }
}
