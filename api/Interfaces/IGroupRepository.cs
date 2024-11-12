using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Group;
using api.Models;

namespace api.Interfaces
{
    public interface IGroupRepository
    {
        Task<List<StudentGroup>> GetAllAsync();
        Task<StudentGroup?> GetByIdAsync(int id);
        Task<StudentGroup> CreateAsync(StudentGroup groupModel);
        Task<StudentGroup?> UpdateAsync(int id, UpdateGroupRequestDto groupDto);
        Task<StudentGroup?> DeleteAsync(int id);
        Task<bool> GroupExists(int id);
    }
}