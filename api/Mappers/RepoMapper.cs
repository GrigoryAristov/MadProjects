using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Repo;
using api.Models;
using Npgsql.Replication;

namespace api.Mappers
{
    public static class RepoMapper
    {
        public static RepoDto ToRepoDto(this Repo repoModel)
        {
            return new RepoDto
            {
                URL = repoModel.URL,
                ProjectId = repoModel.ProjectId
            };
        }

        public static Repo ToRepoFromCreateDto(this CreateRepoDto repoDto, int projectDto)
        {
            return new Repo
            {
                URL = repoDto.URL,
                ProjectId = projectDto
            };
        }

        public static Repo ToRepoFromUpdateDto(this UpdateRepoRequestDto repoDto)
        {
            return new Repo
            {
                URL = repoDto.URL
            };
        }
    }
}