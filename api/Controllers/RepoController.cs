using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Repo;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/repo")]
    [ApiController]
    public class RepoController : ControllerBase
    {
        private readonly IRepoRepository _repoRepo;
        private readonly IProjectRepository _projectRepo;

        public RepoController(IRepoRepository repoRepo, IProjectRepository _projectRepo)
        {
            _repoRepo = repoRepo;
            //_projectRepo = projectRepo;
        }
        [HttpGet]
        // [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var repos = await _repoRepo.GetAllAsync();

            var repoDto = repos.Select(s => s.ToRepoDto());

            return Ok(repoDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var repo = await _repoRepo.GetByIdAsync(id);

            if(repo == null)
            {
                return NotFound();
            }

            return Ok(repo.ToRepoDto());
        }
        [HttpPost("{projectId}")]
        public async Task<IActionResult> Crete([FromRoute] int projectId, [FromBody] CreateRepoDto repoDto)
        {
            // if(!await _projectRepo.ProjectExists(projectId))
            // {
            //     return BadRequest("Project does not exist");
            // }

            var repoModel = repoDto.ToRepoFromCreateDto(projectId);
            await _repoRepo.CreateAsync(repoModel);
            return CreatedAtAction(nameof(GetById), new{id = repoModel.Id}, repoModel.ToRepoDto());
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var repoModel = await _repoRepo.DeleteAsync(id);

            if(repoModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRepoRequestDto updateDto)
        {
            var repo = await _repoRepo.UpdateAsync(id, updateDto.ToRepoFromUpdateDto());

            if(repo == null)
            {
                return NotFound();
            }

            return Ok(repo.ToRepoDto());
        }
    }
}