using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.RoleCode;
using api.Models;

namespace api.Interfaces
{
    public interface IRoleCodeRepository
    {
        Task<List<RoleCode>> GetAllAsync();
        Task<RoleCode?> GetByIdAsync(int id);
        Task<RoleCode> CreateAsync(RoleCode rolecodeModel1);
        Task<RoleCode?> UpdateAsync(int id, UpdateRoleCodeRequestDto rolecodeDro);
        Task<RoleCode?> DeleteAsync(int id);
        Task<bool> RoleCodeExists (int id);
    }
}