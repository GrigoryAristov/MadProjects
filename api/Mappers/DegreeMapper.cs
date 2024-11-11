using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.Degree;
using api.Models;

namespace api.Mappers
{
    public static class DegreeMapper
    {
        public static DegreeDto ToDegreeDto(this DegreeCode degreeModel)
        {
            return new DegreeDto
            {
                Degree = degreeModel.Degree,
                //Professors = degreeModel.Professors.Select(c => c.ToProffesorDto()).ToList()
            };
        }
        public static DegreeCode ToDegreeFromCreateDto(this CreateDegreeRequestDto degreeDto)
        {
            return new DegreeCode
            {
                Degree = degreeDto.Degree,
            };
        }
    }
}