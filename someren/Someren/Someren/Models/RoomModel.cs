namespace Someren.Models
{
    public class RoomModel : BaseModel
    {
        public int RoomId { get; set; }
        public int? RoomNumber { get; set; }
        public int? AmountOfBeds { get; set; }
        public int? FloorNumber { get; set; }
        public string BuildingName { get; set; }
        public bool Deleted { get; set; }

        public RoomModel()
        {
            RoomNumber = 0;
            AmountOfBeds = 0;
            FloorNumber = 0;
            BuildingName = "";
            Deleted = false;
        }

        public RoomModel(int roomId, int roomNumber, int amountOfBeds, int floorNumber, string buildingName, bool deleted)
        {
            RoomId = roomId;
            RoomNumber = roomNumber;
            AmountOfBeds = amountOfBeds;
            FloorNumber = floorNumber;
            BuildingName = buildingName;
            Deleted = deleted;
        }

        public override int getId()
        {
            return RoomId;
        }
    }

}
