using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RepoRepository : IRepoRepository
    {
        private readonly ApplicationDBContext _context;
        public RepoRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Repo> CreateAsync(Repo reposirotyModel)
        {
            await _context.Repositories.AddAsync(reposirotyModel);
            await _context.SaveChangesAsync();
            return reposirotyModel;
        }

        public async Task<Repo> DeleteAsync(int id)
        {
            var reposirotyModel = await _context.Repositories.FirstOrDefaultAsync(x => x.Id == id);
            if(reposirotyModel == null)
            {
                return null;
            }
            _context.Repositories.Remove(reposirotyModel);
            await _context.SaveChangesAsync();
            return reposirotyModel;
        }

        public async Task<List<Repo>> GetAllAsync()
        {
            return await _context.Repositories.ToListAsync();
        }

        public async Task<Repo?> GetByIdAsync(int id)
        {
            return await _context.Repositories.FindAsync(id);
        }

        public async Task<Repo?> UpdateAsync(int id, Repo repositoryModel)
        {
            var existingRepo = await _context.Repositories.FindAsync(id);
            
            if(existingRepo == null)
            {
                return null;
            }

            existingRepo.URL = repositoryModel.URL;

            await _context.SaveChangesAsync();

            return existingRepo;
        }
    }
}