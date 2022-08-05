using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkSpace.Behaviors.Interface;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;

namespace WorkSpace.Repositories
{
    public class ElementRepository : IRepositoryElement
    {
        private readonly WorkSpaceContext context;
        readonly IValidation validation;
        public ElementRepository(WorkSpaceContext _context, IValidation validation)
        {
            this.context = _context;
            this.validation = validation;
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
        public async Task<List<Element>> GetElementByBlockId(int blockId)
        {
            return await context.Elements.Where(x => x.BlockId == blockId).OrderBy(x=>x.Position).ToListAsync();
        }

        public async Task<IEnumerable<Element>> ChangeElementPosition(int idElement, int newPosition)
        {
            Element elemment = GetElementById(idElement).Result;
            validation.CheckObjectForNull(elemment);
            List<Element> elements = await GetElementByBlockId(elemment.BlockId);
            elements.Remove(elemment);
            elements.Insert(newPosition-1, elemment);

            for (int i=0; i<elements.Count; i++)
            {
                elements[i].Position = i + 1;
                context.Elements.Update(elements[i]);
            }
            
            return elements;
        }
    }
}
