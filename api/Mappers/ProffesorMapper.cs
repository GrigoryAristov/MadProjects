using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Proffessor;
using api.Models;

namespace api.Mappers
{
    public static class ProffesorMapper
    {
        public static ProffessorDto ToProffesorDto(this Professor profesorModel)
        {
            return new ProffessorDto
            {
                //ProjectGroups = profesorModel.ProjectGroups.Select(c => c.ToProjectDto()).ToList()
                UserId = profesorModel.UserId
            };
        }
        public static Professor ToProfessorFromCreateDto(this CreateProfessorDto professorDto, int degreeId, string userId)
        {
            return new Professor
            {
                DegreeCodeId = degreeId,
                UserId = userId
            };
        }
    }
}