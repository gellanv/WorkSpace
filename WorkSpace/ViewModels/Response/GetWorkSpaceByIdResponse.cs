using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.DTO;
using WorkSpace.Models;

namespace WorkSpace.ViewModels.Response
{
    public class GetWorkSpaceByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<WorkSpaceWithListPagesDTO.PagesDTO> Pages { get; set; }
    }
}
