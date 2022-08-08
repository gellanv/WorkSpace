using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSpace.Behaviors.Interface;
using WorkSpace.DTO;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;
using WorkSpace.Services.Interface;

namespace WorkSpace.Services
{
    public class BlockService: IBlockService
    {
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;
        readonly IValidation validation;

        public BlockService(IUnitOfWork _unitOfWork, IMapper _mapper, IValidation _validation)
        {
            this.unitOfWork = _unitOfWork;
            this.mapper = _mapper;
            this.validation = _validation;
        }
        public async Task DeleteBlockById(string UserId, int blockId)
        {
            validation.CheckId(blockId);
            Block block = await unitOfWork.RepositoryBlock.GetBlockById(blockId);
            validation.CheckObjectForNull(block);

            Page page = await unitOfWork.RepositoryPage.GetPageById(block.PageId);
            validation.CheckObjectForNull(page);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(page.WorkSpaceId);
            validation.CheckObjectForNull(workSpace);

            if (workSpace != null && workSpace.UserId == UserId)
            {
                unitOfWork.RepositoryBlock.Delete(block);
                await unitOfWork.SaveAsync();
            }
            else
            {
                throw new Exception("No access");
            }
        }
        public async Task<PageTemplateDTO> AddListTemplateBlocksById(string UserId, int pageId, int templateId)
        {
            validation.CheckId(pageId);
            Page page = await unitOfWork.RepositoryPage.GetPageById(pageId);
            validation.CheckObjectForNull(page);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(page.WorkSpaceId);
            validation.CheckObjectForNull(workSpace);

            validation.CheckId(templateId);
            Template template = unitOfWork.RepositoryBlock.GetTemplateById(templateId).Result;
            validation.CheckObjectForNull(template);

            if (workSpace != null && workSpace.UserId == UserId && page.Blocks.Count==0)
            {
                
                for (int i = 0; i < template.BlockTemplates.Count; i++)
                {
                    Block newBlock = new Block()
                    {
                        PageId = pageId,
                        X = template.BlockTemplates[i].X,
                        Y = template.BlockTemplates[i].Y,
                        Height = template.BlockTemplates[i].Height,
                        Width = template.BlockTemplates[i].Width,
                        Style = template.BlockTemplates[i].Style,
                        Title = template.BlockTemplates[i].Title
                    };
                    newBlock = unitOfWork.RepositoryBlock.Create(newBlock).Result;
                    await unitOfWork.SaveAsync();
                }
                PageTemplateDTO pageTemplateDTO = mapper.Map<PageTemplateDTO>(page);

                return pageTemplateDTO;
            }
            else
            {
                throw new Exception("No access");
            }

        }
        public async Task<UpdateBlockDTO> UpdateBlockById(UpdateBlockDTO updateBlockDTO)
        {
            validation.CheckId(updateBlockDTO.Id);
            Block block = await unitOfWork.RepositoryBlock.GetBlockById(updateBlockDTO.Id);
            validation.CheckObjectForNull(block);

            validation.CheckId(block.PageId);
            Page page = await unitOfWork.RepositoryPage.GetPageById(block.PageId);
            validation.CheckObjectForNull(page);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(page.WorkSpaceId);
            validation.CheckObjectForNull(workSpace);
            if (workSpace != null && workSpace.UserId == updateBlockDTO.UserId)
            {
                // block = mapper.Map<Block>(updateBlockDTO);
                block.X = updateBlockDTO.X;
                block.Y = updateBlockDTO.Y;
                block.Height = updateBlockDTO.Height;
                block.Width = updateBlockDTO.Width;
                unitOfWork.RepositoryBlock.Update(block);
                await unitOfWork.SaveAsync();

                UpdateBlockDTO blockUpdatedDTO = mapper.Map<UpdateBlockDTO>(block);

                return blockUpdatedDTO;
            }
            else
            {
                throw new Exception("No access");
            }
        }

        public async Task<BlockDTO> CreateBlock(string UserId, BlockDTO blockDTO)
        {
            validation.CheckId(blockDTO.PageId);
            Page page = await unitOfWork.RepositoryPage.GetPageById(blockDTO.PageId);
            validation.CheckObjectForNull(page);

            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(page.WorkSpaceId);
            validation.CheckObjectForNull(workSpace);
            
            //Нужно ли делать проверку на валидность данных X,Y,Width,Height????? - или это делается на стороне клиента?

            if (workSpace.UserId == UserId)
            {
                Block block = mapper.Map<Block>(blockDTO);
                Block newBlock = await unitOfWork.RepositoryBlock.Create(block);
                await unitOfWork.SaveAsync();
                BlockDTO newblockDTO = mapper.Map<BlockDTO>(newBlock);

                return newblockDTO;
            }
            else
            {
                throw new Exception("No access");
            }
        }

        public async Task<ChangeBlockTitleDTO> ChangeBlockTitleById(ChangeBlockTitleDTO changeBlockTitleDTO)
        {
            validation.CheckId(changeBlockTitleDTO.Id);
            validation.CheckObjectForValid(changeBlockTitleDTO);

            Block block = await unitOfWork.RepositoryBlock.GetBlockById(changeBlockTitleDTO.Id);
            validation.CheckObjectForNull(block);

            validation.CheckId(block.PageId);
            Page page = await unitOfWork.RepositoryPage.GetPageById(block.PageId);
            validation.CheckObjectForNull(page);

            validation.CheckId(page.WorkSpaceId);
            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(page.WorkSpaceId);
            validation.CheckObjectForNull(workSpace);
            if (workSpace.UserId == changeBlockTitleDTO.UserId)
            {
                block.Title = changeBlockTitleDTO.Title;
                unitOfWork.RepositoryBlock.Update(block);
                await unitOfWork.SaveAsync();

                ChangeBlockTitleDTO changeBlockTitle = mapper.Map<ChangeBlockTitleDTO>(block);
                return changeBlockTitle;
            }
            else
            {
                throw new Exception("No access");
            }
        }

        public async Task<BlockDuplicateDTO> DuplicateBlock(string UserId, int id)
        {
            validation.CheckId(id);

            Block block = await unitOfWork.RepositoryBlock.GetBlockById(id);
            validation.CheckObjectForNull(block);

            validation.CheckId(block.PageId);
            Page page = await unitOfWork.RepositoryPage.GetPageById(block.PageId);
            validation.CheckObjectForNull(page);

            validation.CheckId(page.WorkSpaceId);
            Models.WorkSpace workSpace = await unitOfWork.RepositoryWorkSpace.GetWorkSpaceById(page.WorkSpaceId);
            validation.CheckObjectForNull(workSpace);

            if (workSpace != null && workSpace.UserId == UserId)
            {
                Block newBlock = new Block()
                {
                    Title = block.Title,
                    Style = block.Style,
                    X = block.X,
                    Y = block.Y,
                    Height = block.Height,
                    Width = block.Width,
                    PageId = block.PageId
                };
                newBlock = await unitOfWork.RepositoryBlock.Create(newBlock);
                await unitOfWork.SaveAsync();

                for (int i = 0; i < block.Elements.Count; i++)
                {
                    Element newElement = new Element { BlockId = newBlock.Id, ContentHtml = block.Elements[i].ContentHtml,Position = block.Elements[i].Position };
                    await unitOfWork.RepositoryElement.Create(newElement);
                    await unitOfWork.SaveAsync();
                }
                BlockDuplicateDTO blockDuplicateDTO = mapper.Map<BlockDuplicateDTO>(newBlock);

                return blockDuplicateDTO;
            }
            else
            {
                throw new Exception("No access");
            }
        }
    }
}
