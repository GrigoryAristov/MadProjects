using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Student;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;
        private readonly ApplicationDBContext _context;
        public StudentController(IStudentRepository studentRepo, ApplicationDBContext context)
        {
            _context = context;
            _studentRepo = studentRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepo.GetAllAsync();
            var studentDto = students.Select(s => s.ToStudentDto());
            return Ok(studentDto);
        }
        [HttpPost("{studentgroupId:int}/{userId}")]
        public async Task<IActionResult> Create([FromRoute] int studentgroupId, string userId, [FromBody] CreateStudenDto studentDto){
            // if(!await _professorRepo.ProfessorExists(userId) | !await _professorRepo.ProfessorExists(degreeId))
            // {
            //     return BadRequest();
            // }
            var studentModel = studentDto.ToStudentFromCreateDto(studentgroupId, userId);
            await _studentRepo.CreateAsync(studentModel);
            return Ok(studentModel);
        }
    }
}