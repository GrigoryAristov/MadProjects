using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Project;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProjectRepository _projectRepo;
        public ProjectController(ApplicationDBContext context, IProjectRepository projectRepo)
        {
            _context = context;
            _projectRepo = projectRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Pagination pagination)
        {
            var projects = await _projectRepo.GetAllAsync(pagination);

            var projectDto = projects.Select(s => s.ToProjectDto());

            return Ok(projects);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var projects = await _projectRepo.GetByIdAsync(id);

            if(projects == null)
            {
                return NotFound();
            }

            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequestDto projectDto)
        {
            var projectModel = projectDto.ToProjectFromCreateDto();
            await _projectRepo.CreateAsync(projectModel);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProjectRequestDto updateDto)
        {
            var projectModel = await _projectRepo.UpdateAsync(id, updateDto);

            if(projectModel == null)
            {
                return NotFound();
            }

            projectModel.Name = updateDto.Name;
            projectModel.Description = updateDto.Description;
            projectModel.InviteCode = updateDto.InviteCode;
            projectModel.Date = updateDto.Date;
            projectModel.NumParticipants = updateDto.NumParticipants;
            projectModel.Approved = updateDto.Approved;
            projectModel.Grade = updateDto.Grade;

            await _context.SaveChangesAsync();

            return Ok(projectModel.ToProjectDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var projectModel = await _projectRepo.DeleteAsync(id);

            if(projectModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}