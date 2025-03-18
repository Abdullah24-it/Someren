using System.Reflection;
using Microsoft.Data.SqlClient;
using Someren.Models;

namespace Someren.Repositories
{
    public class RoomRepository : DbSomerenRepository<RoomModel>
    {
        public RoomRepository(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void bindInsertValues(SqlCommand command, RoomModel model)
        {
            command.Parameters.AddWithValue("@RoomNumber", model.RoomNumber);
            command.Parameters.AddWithValue("@AmountOfBeds", model.AmountOfBeds);
            command.Parameters.AddWithValue("@FloorNumber", model.FloorNumber);
            command.Parameters.AddWithValue("@BuildingName", model.BuildingName);
            command.Parameters.AddWithValue("@Deleted", 0);
        }

        protected override void bindUpdateValues(SqlCommand command, RoomModel room)
        {
            command.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
            command.Parameters.AddWithValue("@AmountOfBeds", room.AmountOfBeds);
            command.Parameters.AddWithValue("@FloorNumber", room.FloorNumber);
            command.Parameters.AddWithValue("@BuildingName", room.BuildingName);
        }

        protected override string getAddQuery()
        {
            return "INSERT INTO ROOM (roomNumber, amountOfBeds, floorNumber, buildingName) VALUES (@RoomNumber, @AmountOfBeds, @FloorNumber, @BuildingName)"; 
        }

        protected override string? getDefaultClause()
        {
            return "WHERE deleted = 0";
        }

        protected override string getDeleteQuery()
        {
            return "UPDATE ROOM SET deleted = @deleted";
        }

        protected override string getModelIdFiled()
        {
            return "roomId";
        }

        protected override string? getOrderClause()
        {
            return "ORDER BY roomNumber";
        }

        protected override string getSelectQuery()
        {
            return "SELECT * FROM ROOM";
        }

        protected override string getUpdateQuery()
        {
            return "UPDATE ROOM SET RoomNumber = @RoomNumber, AmountOfBeds = @AmountOfBeds, FloorNumber = @FloorNumber, BuildingName = @BuildingName";
        }

        protected override bool isSoftDeletable()
        {
            return true;
        }

        protected override RoomModel readModel(SqlDataReader reader)
        {
            int roomId = (int)reader["RoomId"];
            int roomNumber = (int)reader["RoomNumber"];
            int amountOfBeds = (int)reader["AmountOfBeds"];
            int floorNumber = (int)reader["FloorNumber"];
            string buildingName = (string)reader["BuildingName"];
            bool deleted = (bool)reader["Deleted"];
            return new RoomModel(roomId, roomNumber, amountOfBeds, floorNumber, buildingName, deleted);
        }
    }
}
