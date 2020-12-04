using HogwartsSideProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsSideProject.DAL
{
    public interface IStudentDAO
    {
        IList<Student> GetStudents();
        int CreateStudent(Student newStudent);
    }
}
