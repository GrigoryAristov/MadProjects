using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                UserName = userModel.UserName,
                Email = userModel.Email
            };
        }

    }
}