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
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDBContext _context;
        public StudentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Student> CreateAsync(Student studentModel)
        {
            await _context.Students.AddAsync(studentModel);
            await _context.SaveChangesAsync();
            return studentModel;
        }

        public async Task<Student?> DeleteAsync(int id)
        {
            var studentModel = await _context.Students.FirstOrDefaultAsync(x =>x.Id == id);
            if(studentModel == null)
            {
                return null;
            }
            _context.Students.Remove(studentModel);
            await _context.SaveChangesAsync();
            return studentModel;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GrtByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student?> UpdateAsync(int id, Student studentModel)
        {
            var existingStudent = await _context.Students.FindAsync(id);

            if(existingStudent == null)
            {
                return null;
            }

            existingStudent.GitHub = studentModel.GitHub;

            await _context.SaveChangesAsync();

            return existingStudent;
        }
    }
}