using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Degree;
using api.Models;

namespace api.Interfaces
{
    public interface IDegreeRepository
    {
        Task<List<DegreeCode>> GetAllAsync();
        Task<DegreeCode?> GetByIdAsync(int id);
        Task<DegreeCode> CreateAsync(DegreeCode degreeModel);
        Task<DegreeCode?> UpdateAsync(int id, UpdateDegreeRequestDto degreeDto);
        Task<DegreeCode?> DeleteAsync(int id);
        Task<bool> DegreeExists(int id);
    }
}