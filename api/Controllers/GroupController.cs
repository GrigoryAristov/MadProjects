using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Group;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace api.Controllers
{
    [Route("api/group")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IGroupRepository _groupRepo;
        public GroupController(ApplicationDBContext context, IGroupRepository groupRepo)
        {
            _context = context;
            _groupRepo = groupRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var group = await _groupRepo.GetAllAsync();

            var groupDto = group.Select(s => s.ToGroupDto());

            return Ok(group);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var degree = await _groupRepo.GetByIdAsync(id);

            if(degree == null)
            {
                return NotFound();
            }
            
            return Ok(degree);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGroupRequestDto groupDto){
            var groupModel = groupDto.ToGroupFromCreateDto();
            await _groupRepo.CreateAsync(groupModel);
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGroupRequestDto updateDto)
        {
            var groupModel = await _groupRepo.UpdateAsync(id, updateDto);

            if(groupModel == null)
            {
                return NotFound();
            }

            groupModel.Number = updateDto.Number;

            await _context.SaveChangesAsync();

            return Ok(groupModel.ToGroupDto());
        }
    }
}