using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Project;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync(Pagination pagination);
        Task<Project?> GetByIdAsync(int id);
        Task<Project> CreateAsync(Project projectModel);
        Task<Project?> UpdateAsync(int id, UpdateProjectRequestDto projectDto);
        Task<Project?> DeleteAsync(int id);
        Task<bool> ProjectExisting(int id);
    }
}