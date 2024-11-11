using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Project;
using api.Models;

namespace api.Mappers
{
    public static class ProjectMapper
    {
        public static ProjectDto ToProjectDto(this Project projectModel)
        {
            return new ProjectDto
            {
                Name = projectModel.Name,
                Description = projectModel.Description,
                InviteCode = projectModel.InviteCode,
                Date = projectModel.Date,
                NumParticipants = projectModel.NumParticipants,
                Approved = projectModel.Approved,
                Grade = projectModel.Grade,
                Repositories = projectModel.Repositories.Select(c => c.ToRepoDto()).ToList(),
                //ProjectGroupProjects = projectModel.ProjectGroupProjects.Select(c => c.ToRepoDto()).ToList(),
                //UserProjects = projectModel.UserProjects.Select(c => c.ToRepoDto()).ToList(),
                //Sprints = projectModel.Sprints.Select(c => c.ToRepoDto()).ToList(),
            };
        }

        public static Project ToProjectFromCreateDto(this CreateProjectRequestDto projectDto)
        {
            return new Project
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                InviteCode = projectDto.InviteCode,
                Date = projectDto.Date,
                NumParticipants = projectDto.NumParticipants,
                Approved = projectDto.Approved,
                Grade = projectDto.Grade,
            };
        }

    }
}