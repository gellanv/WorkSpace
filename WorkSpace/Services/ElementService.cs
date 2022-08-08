using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WorkSpace.Behaviors.Interface;
using WorkSpace.DTO;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;
using WorkSpace.Services.Interface;

namespace WorkSpace.Services
{
    public class ElementService : IElementService
    {
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;
        readonly IValidation validation;
        public ElementService(IUnitOfWork _unitOfWork, IMapper _mapper, IValidation _validation)
        {
            this.unitOfWork = _unitOfWork;
            this.mapper = _mapper;
            this.validation = _validation;
        }
        public async Task<ElementDTO> CreateElement(ElementDTO createElementDTO)
        {
            validation.CheckObjectForValid(createElementDTO);
            Element element = mapper.Map<Element>(createElementDTO);

            Element newElement = await unitOfWork.RepositoryElement.Create(element);
            await unitOfWork.SaveAsync();
            ElementDTO elementDTO = mapper.Map<ElementDTO>(newElement);

            return elementDTO;
        }

        public async Task<ElementDTO> ChangeElement(ElementDTO changeElementDTO)
        {
            validation.CheckObjectForValid(changeElementDTO);
            validation.CheckId(changeElementDTO.Id);

            Element element = await unitOfWork.RepositoryElement.GetElementById(changeElementDTO.Id);
            validation.CheckObjectForNull(element);

            element.ContentHtml = changeElementDTO.ContentHtml;
            element.BlockId = changeElementDTO.BlockId;
            unitOfWork.RepositoryElement.Update(element);
            await unitOfWork.SaveAsync();
            ElementDTO elementDTO = mapper.Map<ElementDTO>(element);

            return elementDTO;
        }

        public async Task DeleteElement(int elementId)
        {
            validation.CheckId(elementId);

            Element element = await unitOfWork.RepositoryElement.GetElementById(elementId);
            validation.CheckObjectForNull(element);

            unitOfWork.RepositoryElement.Delete(element);
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ElementDTO>> ChangeElementPosition(int idElement, int newPosition)
        {
            validation.CheckId(idElement);
            validation.CheckId(newPosition);

            IEnumerable<Element> elements = await unitOfWork.RepositoryElement.ChangeElementPosition(idElement, newPosition);
            await unitOfWork.SaveAsync();
            IEnumerable<ElementDTO> elementDTO = mapper.Map< IEnumerable<ElementDTO>>(elements);

            return elementDTO;
        }
    }
}