using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<Element> GetList()
        {
            return context.Elements.ToList();
        }
        public Element Get(int id)
        {
            return context.Elements.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Create(Element element)
        {
            context.Elements.Add(element);
        }
        public void Update(Element element)
        {
            context.Entry(element).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Element element = context.Elements.Find(id);
            if (element != null)
                context.Elements.Remove(element);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}
