
using Microsoft.Data.SqlClient;
using Someren.Models;

namespace Someren.Repositories
{
    public class StudentRepository : DbSomerenRepository<StudentModel>
    {
        public StudentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        protected override string getSelectQuery()
        {
            return "SELECT * FROM STUDENT";
        }

        protected override string getModelIdFiled()
        {
            return "studentId";
        }

        protected override StudentModel readModel(SqlDataReader reader)
        {
            int studentId = (int)reader["StudentId"];
            string studentNumber = (string)reader["StudentNumber"];
            string firstName = (string)reader["FirstName"];
            string lastName = (string)reader["LastName"];
            string phoneNumber = (string)reader["PhoneNumber"];
            string @class = (string)reader["Class"];
            bool deleted = (bool)reader["Deleted"];
            return new StudentModel(studentId, studentNumber, firstName, lastName, phoneNumber, @class, deleted);
        }

        protected override string? getDefaultClause()
        {
            return "WHERE deleted = 0";
        }

        protected override string? getOrderClause()
        {
            return "ORDER BY lastName";
        }

        protected override string getDeleteQuery()
        {
            return "UPDATE STUDENT SET Deleted = @Deleted";
        }

        protected override bool isSoftDeletable()
        {
            return true;
        }

        protected override string getUpdateQuery()
        {
            return "UPDATE STUDENT SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Class = @Class, StudentNumber = @StudentNumber";
        }

        protected override void bindUpdateValues(SqlCommand command, StudentModel student)
        {
            command.Parameters.AddWithValue("@FirstName", student.FirstName);
            command.Parameters.AddWithValue("@LastName", student.LastName);
            command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
            command.Parameters.AddWithValue("@Class", student.Class);
			command.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
		}

        protected override void bindInsertValues(SqlCommand command, StudentModel model)
        {
            command.Parameters.AddWithValue("@FirstName", model.FirstName);
            command.Parameters.AddWithValue("@LastName", model.LastName);
            command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
            command.Parameters.AddWithValue("@Class", model.Class);
			command.Parameters.AddWithValue("@StudentNumber", model.PhoneNumber);
			command.Parameters.AddWithValue("@Deleted", 0);
        }

        protected override string getAddQuery()
        {
            return "INSERT INTO STUDENT (firstName, lastName, phoneNumber, class, studentNumber deleted) VALUES (@FirstName, @LastName, @PhoneNumber, @Class, @StudentNumber, @Deleted)";
        }
    }
}
