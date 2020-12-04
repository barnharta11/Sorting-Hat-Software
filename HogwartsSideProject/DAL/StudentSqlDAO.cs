using HogwartsSideProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HogwartsSideProject.DAL
{
    public class StudentSqlDAO : IStudentDAO
    {
        public string connectionString;
        public StudentSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"Select s.*, h.housename, t.classname from Student s join Hogwarts h on h.houseid = s.hogwartshouse join TechElevator t on t.classid = s.teclass";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student();
                    student.StudentId = Convert.ToInt32(reader["StudentId"]);
                    student.FirstName = Convert.ToString(reader["FirstName"]);
                    student.LastName = Convert.ToString(reader["LastName"]);
                    student.Gender = Convert.ToString(reader["Gender"]);
                    student.HogwartsHouse = Convert.ToString(reader["Housename"]);
                    student.HogwartsHouseID = Convert.ToInt32(reader["HogwartsHouse"]);
                    student.TEClass = Convert.ToString(reader["Classname"]);
                    student.TEClassID = Convert.ToInt32(reader["TEClass"]);

                    students.Add(student);
                }

            }
            return students;
        }
        public int CreateStudent(Student newStudent)
        {
            if (string.IsNullOrEmpty(newStudent.FirstName))
            {
                throw new ArgumentException("Student is Null or Empty");
            }

            string sql = "Insert into student (firstname, lastname, gender, hogwartshouse, teclass) values (@FirstName, @LastName, @Gender, @HogwartsHouse, @TEClass); Select @@Identity;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@FirstName", newStudent.FirstName);
                    command.Parameters.AddWithValue("@LastName", newStudent.LastName);
                    command.Parameters.AddWithValue("@Gender", newStudent.Gender);
                    command.Parameters.AddWithValue("@HogwartsHouse", newStudent.HogwartsHouseID);
                    command.Parameters.AddWithValue("@TEClass", newStudent.TEClassID);

                    
                    int newStudentID = Convert.ToInt32(command.ExecuteScalar()); 

                    return newStudentID;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}

