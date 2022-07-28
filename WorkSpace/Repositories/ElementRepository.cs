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
            context.Elements.Remove(element);
        }
    }
}
