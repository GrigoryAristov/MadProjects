using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Degree;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/degree")]
    [ApiController]
    public class DegreeConrtoller : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IDegreeRepository _degreeRepo;
        public DegreeConrtoller(ApplicationDBContext context, IDegreeRepository degreeRepo)
        {
            _context = context;
            _degreeRepo = degreeRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var degree = await _degreeRepo.GetAllAsync();

            var degreeDto = degree.Select(s => s.ToDegreeDto());

            return Ok(degree);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var degree = await _degreeRepo.GetByIdAsync(id);

            if(degree == null)
            {
                return NotFound();
            }
            
            return Ok(degree);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDegreeRequestDto degreeDto){
            var degreeModel = degreeDto.ToDegreeFromCreateDto();
            await _degreeRepo.CreateAsync(degreeModel);
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDegreeRequestDto updateDto)
        {
            var degreeModel = await _degreeRepo.UpdateAsync(id, updateDto);

            if(degreeModel == null)
            {
                return NotFound();
            }

            degreeModel.Degree = updateDto.Degree;

            await _context.SaveChangesAsync();

            return Ok(degreeModel.ToDegreeDto());
        }
    }
}