using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Degree;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DegreeRepository : IDegreeRepository
    {
        private readonly ApplicationDBContext _context;
        public DegreeRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<DegreeCode> CreateAsync(DegreeCode degreeModel)
        {
            await _context.DegreeCodes.AddAsync(degreeModel);
            await _context.SaveChangesAsync();
            return degreeModel;
        }

        public Task<bool> DegreeExists(int id)
        {
            return _context.DegreeCodes.AnyAsync(s => s.Id == id);
        }

        public async Task<DegreeCode?> DeleteAsync(int id)
        {
            var degreeModel = await _context.DegreeCodes.FirstOrDefaultAsync(x => x.Id == id);
            if(degreeModel == null)
            {
                return null;
            }
            _context.DegreeCodes.Remove(degreeModel);
            await _context.SaveChangesAsync();
            return degreeModel;
        }

        public async Task<List<DegreeCode>> GetAllAsync()
        {
            return await _context.DegreeCodes.ToListAsync();
        }

        public async Task<DegreeCode?> GetByIdAsync(int id)
        {
            return await _context.DegreeCodes.Include(c => c.Professors).FirstOrDefaultAsync(i => i.Id == id);
        }


        public async Task<DegreeCode?> UpdateAsync(int id, UpdateDegreeRequestDto degreeDto)
        {
            var exicitingDegree = await _context.DegreeCodes.FirstOrDefaultAsync(x => x.Id == id);

            if(exicitingDegree == null)
            {
                return null;
            }

            exicitingDegree.Degree = degreeDto.Degree;

            await _context.SaveChangesAsync();

            return exicitingDegree;
        }
    }
}