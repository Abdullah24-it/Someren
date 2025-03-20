using Microsoft.Data.SqlClient;
using Someren.Models;

namespace Someren.Repositories
{
	public class ActivityRepository : DbSomerenRepository<ActivityModel>
	{
		public ActivityRepository(IConfiguration configuration) : base(configuration)
		{
		}

		protected override void bindInsertValues(SqlCommand command, ActivityModel model)
		{
			command.Parameters.AddWithValue("@ActivityName", model.ActivityName);
			command.Parameters.AddWithValue("@ActivityDate", model.ActivityDate);
			command.Parameters.AddWithValue("@Deleted", model.Deleted);
		}

		protected override void bindUpdateValues(SqlCommand command, ActivityModel model)
		{
			command.Parameters.AddWithValue("@ActivityName", model.ActivityName);
			command.Parameters.AddWithValue("@ActivityDate", model.ActivityDate);
		}

		protected override string getAddQuery()
		{
			return "INSERT INTO ACTIVITY (activityName, activityDate) VALUES (@ActivityName, @ActivityDate)";
		}

		protected override string? getDefaultClause()
		{
			return "WHERE deleted = 0";
		}

		protected override string getDeleteQuery()
		{
			return "UPDATE ACTIVITY SET deleted = @deleted";
		}

		protected override string getModelIdFiled()
		{
			return "activityId";
		}

		protected override string? getOrderClause()
		{
			return "ORDER BY activityDate";
		}

		protected override string getSelectQuery()
		{
			return "SELECT * FROM ACTIVITY";
		}

		protected override string getUpdateQuery()
		{
			return "UPDATE ACTIVITY SET ActivityName = @ActivityName, ActivityDate = @ActivityDate";
		}

		protected override bool isSoftDeletable()
		{
			return true;
		}

		protected override ActivityModel readModel(SqlDataReader reader)
		{
			int activityId = (int)reader["ActivityId"];
			string activityName = (string)reader["ActivityName"];
			DateTime activityDate = (DateTime)reader["ActivityDate"];
			bool deleted = (bool)reader["Deleted"];
			return new ActivityModel(activityId, activityName, activityDate, deleted);
		}
	}

}
