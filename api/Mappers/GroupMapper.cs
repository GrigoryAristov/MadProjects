using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using api.Dtos.Group;
using api.Models;

namespace api.Mappers
{
    public static class GroupMapper
    {
        public static GroupDto ToGroupDto(this StudentGroup groupModel)
        {
            return new GroupDto
            {
                Number = groupModel.Number,
                Students = groupModel.Students.Select(s => s.ToStudentDto()).ToList()
            };
        }

        public static StudentGroup ToGroupFromCreateDto(this CreateGroupRequestDto groupDto)
        {
            return new StudentGroup
            {
                Number = groupDto.Number
            };
        }
    }
}