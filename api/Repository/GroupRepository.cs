using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Group;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDBContext _context;
        public GroupRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<StudentGroup> CreateAsync(StudentGroup groupModel)
        {
            await _context.Groups.AddAsync(groupModel);
            await _context.SaveChangesAsync();
            return groupModel;
        }

        public async Task<StudentGroup?> DeleteAsync(int id)
        {
            var groupModel = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);
            if(groupModel == null)
            {
                return null;
            }
            _context.Groups.Remove(groupModel);
            await _context.SaveChangesAsync();
            return groupModel;
        }

        public async Task<List<StudentGroup>> GetAllAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<StudentGroup?> GetByIdAsync(int id)
        {
            return await _context.Groups.Include(c => c.Students).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> GroupExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentGroup?> UpdateAsync(int id, UpdateGroupRequestDto groupDto)
        {
            var exicitingGroup = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);

            if(exicitingGroup == null)
            {
                return null;
            }

            exicitingGroup.Number = groupDto.Number;

            await _context.SaveChangesAsync();

            return exicitingGroup;
        }
    }
}