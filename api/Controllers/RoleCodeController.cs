using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.RoleCode;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/rolecode")]
    public class RoleCodeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IRoleCodeRepository _rolecodeRepo;
        public RoleCodeController(ApplicationDBContext context, IRoleCodeRepository rolecodeRepo)
        {
            _context = context;
            _rolecodeRepo = rolecodeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rolecode = await _rolecodeRepo.GetAllAsync();

            var rolecodeDto = rolecode.Select(s => s.ToRoleCodeDto());

            return Ok(rolecode);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var rolecode = await _rolecodeRepo.GetByIdAsync(id);

            if(rolecode == null)
            {
                return NotFound();
            }

            return Ok(rolecode);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleCodeRequestDto rolecodeDto)
        {
            var rolecodeModel = rolecodeDto.ToRoleCodeFromCreateDto();
            await _rolecodeRepo.CreateAsync(rolecodeModel);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoleCodeRequestDto updateDto)
        {
            var rolecodeModel = await _rolecodeRepo.UpdateAsync(id, updateDto);

            if(rolecodeModel == null)
            {
                return NotFound();
            }

            rolecodeModel.Role = updateDto.Role;

            await _context.SaveChangesAsync();

            return Ok(rolecodeModel.ToRoleCodeDto());
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var rolecodeModel = await _rolecodeRepo.DeleteAsync(id);

            if(rolecodeModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}