using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IProfessorRepository
    {
        Task<List<Professor>> GetAllAsync();
        Task<Professor?> GetByIdAsync(int id);
        Task<Professor> CreateAsync(Professor professorModel);
        Task<Professor?> DeleteAsync(int id);
        Task<bool> ProfessorExists(int id);

    }
}