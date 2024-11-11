using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Project;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDBContext _context;
        public ProjectRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Project> CreateAsync(Project projectModel)
        {
            await _context.Projects.AddAsync(projectModel);
            await _context.SaveChangesAsync();
            return projectModel;
        }

        public async Task<Project?> DeleteAsync(int id)
        {
            var projectModel = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if(projectModel == null)
            {
                return null;
            }

            _context.Projects.Remove(projectModel);
            await _context.SaveChangesAsync();
            return projectModel;
        }

        public async Task<List<Project>> GetAllAsync(Pagination pagination)
        {
            var skipNumber = (pagination.PageNumber - 1) * pagination.PageSize;
            return await _context.Projects.Include(c => c.Repositories).Skip(skipNumber).Take(pagination.PageSize).ToListAsync();
        }


        public async Task<Project?> GetByIdAsync(int id)
        {
             return await _context.Projects.Include(c => c.Repositories).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> ProjectExisting(int id)
        {
            return _context.Projects.AnyAsync(s => s.Id == id);
        }

        public async Task<Project?> UpdateAsync(int id, UpdateProjectRequestDto projectDto)
        {
            var exictingProject = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);

            if(exictingProject == null)
            {
                return null;
            }

            exictingProject.Name = projectDto.Name;
            exictingProject.Description = projectDto.Description;
            exictingProject.InviteCode = projectDto.InviteCode;
            exictingProject.Date = projectDto.Date;
            exictingProject.NumParticipants = projectDto.NumParticipants;
            exictingProject.Approved = projectDto.Approved;
            exictingProject.Grade = projectDto.Grade;

            await _context.SaveChangesAsync();
            
            return exictingProject;
        }
    }
}