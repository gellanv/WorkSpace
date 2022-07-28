using System.Collections.Generic;
using System.Threading.Tasks;
using WorkSpace.DTO;

namespace WorkSpace.Services.Interface
{
    public interface IElementService
    {       
        Task<ElementDTO> CreateElement(ElementDTO createElementDTO);
        Task<ElementDTO> ChangeElement(ElementDTO changeElementDTO);       
        Task DeleteElement(int elementId);
    }
}
