using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IRepoRepository
    {
        //Task<List<Repo>> GetAllAsync(Pagination pagination);
        Task<List<Repo>> GetAllAsync();
        Task<Repo?> GetByIdAsync(int id);
        Task<Repo> CreateAsync(Repo reposirotyModel);
        Task<Repo?> UpdateAsync(int id, Repo repositoryModel );
        Task<Repo> DeleteAsync(int id);
    }
}