using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ApplicationDBContext _context;
        public ProfessorRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Professor> CreateAsync(Professor professorModel)
        {
            await _context.Professors.AddAsync(professorModel);
            await _context.SaveChangesAsync();
            return professorModel;
        }

        public async Task<Professor?> DeleteAsync(int id)
        {
            var stockModel = await _context.Professors.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null)
            {
                return null;
            }
            _context.Professors.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Professor>> GetAllAsync()
        {
            return await _context.Professors.Include(c => c.ProjectGroups).ToListAsync();
        }

        public async Task<Professor?> GetByIdAsync(int id)
        {
             return await _context.Professors.Include(c => c.ProjectGroups).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> ProfessorExists(int id)
        {
            return _context.Professors.AnyAsync(s => s.Id == id);
        }
    }
}