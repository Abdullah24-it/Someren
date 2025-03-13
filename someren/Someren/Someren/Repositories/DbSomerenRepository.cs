using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Data.SqlClient;
using Someren.Models;

namespace Someren.Repositories
{
    public class DbSomerenRepository : IStudentRepository
    {
        private readonly string? _connectionString;
        public DbSomerenRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Someren");
        }

        private StudentModel ReadStudent(SqlDataReader reader)
        {
            Console.WriteLine(reader.ToString());
            int studentId = (int)reader["StudentId"];
            string firstName = (string)reader["FirstName"];
            string lastName = (string)reader["LastName"];
            string phoneNumber = (string)reader["PhoneNumber"];
            string @class = (string)reader["Class"];
            return new StudentModel(studentId, firstName, lastName, phoneNumber, @class);
        }

        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Student";
                SqlCommand command = new SqlCommand(query, connection);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StudentModel student = ReadStudent(reader);
                    students.Add(student);
                }

                reader.Close();
            }
            return students;
        }
        
    }
}
