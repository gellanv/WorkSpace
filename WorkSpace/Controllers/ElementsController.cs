using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.DTO;
using WorkSpace.Services.Interface;
using WorkSpace.ViewModels.Request;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Controllers
{
    [Route("api/elements")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        private readonly IElementService elementService;
        private readonly IMapper mapper;

        public ElementsController(IElementService _elementService, IMapper _mapper)
        {
            elementService = _elementService;
            mapper = _mapper;
        }

        /// <summary>
        /// Create new Element
        /// </summary>
        /// <response code="200">Success</response>
        // POST: api/elements     
        [HttpPost]
        public async Task<IActionResult> CreateElement(CreateElementRequest createElementRequest)
        {
            ElementDTO elementDTO = mapper.Map<ElementDTO>(createElementRequest);
            ElementDTO newElementDTO = await elementService.CreateElement(elementDTO);
            CreateElementResponse createElementResponse = mapper.Map<CreateElementResponse>(newElementDTO);

            return Ok(createElementResponse);
        }

        /// <summary>
        /// Upload Media
        /// </summary>
        /// <response code="200">Success</response>
        // POST: api/elements/media     
        [HttpPost("media")]
        public async Task<IActionResult> UnloadMedia(IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Guid nameFile = Guid.NewGuid();
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = nameFile + fileInfo.Extension;
            string fileNameWithPath = Path.Combine(path, fileName);


            using (var stream = System.IO.File.Create(fileNameWithPath))
            {
                await file.CopyToAsync(stream);
            }
            return Ok(fileNameWithPath);
        }


        /// <summary>
        /// Change Element by Id
        /// </summary>
        /// <response code="200">Success</response>
        // PUT: api/elements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeElementById(int id, ChangeElementRequest changeElementRequest)
        {
            ElementDTO elementDTO = mapper.Map<ElementDTO>(changeElementRequest);
            elementDTO.Id = id;
            ElementDTO changeElementDTO = await elementService.ChangeElement(elementDTO);
            ChangeElementResponse changeElementResponse = mapper.Map<ChangeElementResponse>(changeElementDTO);

            return Ok(changeElementResponse);
        }

        /// <summary>
        /// Delete Element by Id
        /// </summary>
        /// <response code="200">Success</response>
        // DELETE: api/elements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElementById(int id)
        {
            await elementService.DeleteElement(id);

            return Ok();
        }

        /// <summary>
        /// Change position for element
        /// </summary>
        /// <response code="200">Success</response>
        // POST: api/elements/position     
        [HttpPut("position")]
        public async Task<IActionResult> ChangePositionElement(int idElement, int newPosition)
        {            
            IEnumerable<ElementDTO> elementDTOs = await elementService.ChangeElementPosition(idElement, newPosition);
            IEnumerable<GetElementsResponse> changedPositionElementList = mapper.Map<IEnumerable<GetElementsResponse>>(elementDTOs);

            return Ok(changedPositionElementList);
        }
    }
}
