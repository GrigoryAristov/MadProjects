using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly ApplicationDBContext _context;

        public UserController(IUserRepository userRepo, ApplicationDBContext context)
        {
            _context = context;
            _userRepo = userRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAllAsync();
            var userDto = users.Select(u => u.ToUserDto());
            return Ok(userDto);
        }
        
    }
}