using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Data.SqlClient;
using Someren.Models;

namespace Someren.Repositories
{
    public abstract class DbSomerenRepository<T> where T : BaseModel
    {
        private readonly string? _connectionString;
        public DbSomerenRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Someren");
        }

        
        public T? GetById(int modelId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"{getSelectQuery()} WHERE {getModelIdFiled()} = @{getModelIdFiled()}";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue($"@{getModelIdFiled()}", modelId);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    T model = readModel(reader);
                    reader.Close();
                    return model;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }

        protected abstract string getModelIdFiled();
        protected abstract string getSelectQuery();
        protected abstract T readModel(SqlDataReader reader);
        protected abstract string? getDefaultClause();
        protected abstract string? getOrderClause();
        protected abstract string getDeleteQuery();
        protected abstract bool isSoftDeletable();
        protected abstract string getUpdateQuery();
        protected abstract void bindUpdateValues(SqlCommand command, T model);
        protected abstract void bindInsertValues(SqlCommand command, T model);
        protected abstract string getAddQuery();
        public List<T> GetAll()
        {
            List<T> items = new List<T>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(getSelectQuery() + " " + getDefaultClause() + " " + getOrderClause(), connection);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(readModel(reader));
                }

                reader.Close();
            }

            return items;
        }

        public void Add(T model)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                string query = getAddQuery();

                SqlCommand command = new SqlCommand(query, connection);
                bindInsertValues(command, model);

                command.Connection.Open();
                int nrOfRowsAffected = command.ExecuteNonQuery();
                if (nrOfRowsAffected == 0)
                {
                    throw new Exception("No records updated!");
                }
            }
        }



        public void Update(T model)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"{getUpdateQuery()} WHERE {getModelIdFiled()} = @modelId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@modelId", model.getId());
                bindUpdateValues(command, model);


                command.Connection.Open();
                int nrOfRowsAffected = command.ExecuteNonQuery();
                if (nrOfRowsAffected == 0)
                {
                    throw new Exception("No records updated!");
                }
            }

        }

        public void Delete(T model)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"{getDeleteQuery()} WHERE {getModelIdFiled()} = @modelId";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@modelId", model.getId());
                if (isSoftDeletable())
                {
                    command.Parameters.AddWithValue("@Deleted", 1);
                }

                command.Connection.Open();
                int nrOfRowsAffected = command.ExecuteNonQuery();
                if (nrOfRowsAffected == 0)
                {
                    throw new Exception("No records deleted!");
                }

            }
        }

    }
}
