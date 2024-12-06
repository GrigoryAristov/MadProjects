using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.RoleCode;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RoleCodeRepository : IRoleCodeRepository
    {
        private readonly ApplicationDBContext _context;
        public RoleCodeRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<RoleCode> CreateAsync(RoleCode rolecodeModel1)
        {
            await _context.RoleCodes.AddAsync(rolecodeModel1);
            await _context.SaveChangesAsync();
            return rolecodeModel1;
        }

        public async Task<RoleCode?> DeleteAsync(int id)
        {
            var rolecodeModel = await _context.RoleCodes.FirstOrDefaultAsync(x => x.Id == id);
            if(rolecodeModel == null)
            {
                return null;
            }
            _context.RoleCodes.Remove(rolecodeModel);
            await _context.SaveChangesAsync();
            return rolecodeModel;
        }

        public async Task<List<RoleCode>> GetAllAsync()
        {
            return await _context.RoleCodes.ToListAsync();
        }

        public async Task<RoleCode?> GetByIdAsync(int id)
        {
            return await _context.RoleCodes.FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> RoleCodeExists(int id)
        {
            return _context.RoleCodes.AnyAsync(s => s.Id == id);
        }

        public async Task<RoleCode?> UpdateAsync(int id, UpdateRoleCodeRequestDto rolecodeDro)
        {
            var exictingRoleCode = await _context.RoleCodes.FirstOrDefaultAsync(x => x.Id == id);

            if(exictingRoleCode == null)
            {
                return null;
            }

            exictingRoleCode.Role= rolecodeDro.Role;

            await _context.SaveChangesAsync();
            
            return exictingRoleCode;
        }
    }
}