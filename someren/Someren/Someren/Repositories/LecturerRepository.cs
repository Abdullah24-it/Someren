using Microsoft.Data.SqlClient;
using Someren.Models;
namespace Someren.Repositories
{
	public class LecturerRepository : DbSomerenRepository<LecturerModel>
	{
		public LecturerRepository(IConfiguration configuration) : base(configuration)
		{
		}

		protected override void bindInsertValues(SqlCommand command, LecturerModel model)
		{
			command.Parameters.AddWithValue("@FirstName", model.FirstName);
			command.Parameters.AddWithValue("@LastName", model.LastName);
			command.Parameters.AddWithValue("@Age", model.Age);
			command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
			command.Parameters.AddWithValue("@Deleted", 0);
		}

		protected override void bindUpdateValues(SqlCommand command, LecturerModel model)
		{
			command.Parameters.AddWithValue("@FirstName", model.FirstName);
			command.Parameters.AddWithValue("@LastName", model.LastName);
			command.Parameters.AddWithValue("@Age", model.Age);
			command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
		}

		protected override string getAddQuery()
		{
			return "INSERT INTO LECTURER (firstName, lastName, age, phoneNumber, deleted) VALUES (@FirstName, @LastName, @Age, @PhoneNumber, @Deleted)";
		}

		protected override string? getDefaultClause()
		{
			return "WHERE deleted = 0";
		}

		protected override string getDeleteQuery()
		{
			return "UPDATE LECTURER SET Deleted = @Deleted";
		}

		protected override string getModelIdFiled()
		{
			return "lecturerId";
		}

		protected override string? getOrderClause()
		{
			return "ORDER BY lastName";
		}

		protected override string getSelectQuery()
		{
			return "SELECT * FROM LECTURER";
		}

		protected override string getUpdateQuery()
		{
			return "UPDATE LECTURER SET FirstName = @FirstName, LastName = @LastName, Age = @Age, PhoneNumber = @PhoneNumber";
		}

		protected override bool isSoftDeletable()
		{
			return true;
		}

		protected override LecturerModel readModel(SqlDataReader reader)
		{
			int lecturerId = (int)reader["LecturerId"];
			string firstName = (string)reader["FirstName"];
			string lastName = (string)reader["LastName"];
			int age = (int)reader["Age"];
			string phoneNumber = (string)reader["PhoneNumber"];
			bool deleted = (bool)reader["Deleted"];
			return new LecturerModel(lecturerId, firstName, lastName, age, phoneNumber, deleted);
		}
	}
}
