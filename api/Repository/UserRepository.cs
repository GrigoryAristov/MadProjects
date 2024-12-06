using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<User?> DeleteAsync(string id)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(userModel == null)
            {
                return null;
            }
            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.Include(u => u.RoleCodes).ToListAsync();
        }

        public async Task<User?> UpdateAsync(string id, User userModel)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if(existingUser == null)
            {
                return null;
            }
            existingUser.UserName = userModel.UserName;
            existingUser.Email = userModel.Email;
            existingUser.PhoneNumber = userModel.PhoneNumber;

            await _context.SaveChangesAsync();

            return existingUser;
            
        }
    }
}