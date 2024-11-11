using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Proffessor;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/professor")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProfessorRepository _professorRepo;
        public ProfessorController(ApplicationDBContext context, IProfessorRepository professorRepo)
        {
            _context = context;
            _professorRepo = professorRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var professors = await _professorRepo.GetAllAsync();
            var professorDto = professors.Select(s => s.ToProffesorDto());
            return Ok(professorDto);
        }
        [HttpPost("{degreeId:int}/{userId}")]
        public async Task<IActionResult> Create([FromRoute] int degreeId, string userId, [FromBody] CreateProfessorDto professorDto){
            // if(!await _professorRepo.ProfessorExists(userId) | !await _professorRepo.ProfessorExists(degreeId))
            // {
            //     return BadRequest();
            // }
            var profesorModel = professorDto.ToProfessorFromCreateDto(degreeId, userId);
            await _professorRepo.CreateAsync(profesorModel);
            return Ok(profesorModel);
        }
    }
}