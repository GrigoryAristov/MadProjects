using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.RoleCode;
using api.Models;

namespace api.Mappers
{
    public static class RoleCodeMapper
    {
        public static RoleCodeDto ToRoleCodeDto(this RoleCode rolecodeModel)
        {
            return new RoleCodeDto
            {
                Role = rolecodeModel.Role,
            };
        }

        public static RoleCode ToRoleCodeFromCreateDto(this CreateRoleCodeRequestDto rolecodeDto)
        {
            return new RoleCode
            {
                Role = rolecodeDto.Role
            };

        }
    }
}