using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Student;
using api.Models;

namespace api.Mappers
{
    public static class StudentMapper
    {
        public static StudentDto ToStudentDto(this Student studentModel)
        {
            return new StudentDto
            {
                GitHub = studentModel.GitHub,
                StudentGroupId = studentModel.StudentGroupId,
                UserId = studentModel.UserId
                
            };
        }
        public static Student ToStudentFromCreateDto(this CreateStudenDto studentDto, int studentgroupId, string userId)
        {
            return new Student
            {
                GitHub = studentDto.GitHub,
                StudentGroupId = studentgroupId,
                UserId = userId
            };
        }
        public static Student ToStudentFromUpdateDto(this UpdateStudentrequestDto studentDto)
        {
            return new Student
            {
                GitHub = studentDto.GitHub
            };
        }
    }
}