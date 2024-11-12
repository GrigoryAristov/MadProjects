using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GrtByIdAsync(int id);
        Task<Student> CreateAsync(Student studentModel);
        Task<Student?> DeleteAsync(int id);
        Task<Student?> UpdateAsync(int id, Student studentModel);
    }
}