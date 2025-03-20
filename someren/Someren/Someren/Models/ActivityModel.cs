namespace Someren.Models
{
    public class ActivityModel : BaseModel
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public DateTime ActivityDate { get; set; }
        public bool Deleted { get; set; }

        public ActivityModel()
        {
            ActivityName = "";
            ActivityDate = DateTime.MinValue;
            Deleted = false;
        }

        public ActivityModel(int activityId, string activityName, DateTime activityDate, bool deleted)
        {
            ActivityId = activityId;
            ActivityName = activityName;
            ActivityDate = activityDate;
            Deleted = deleted;
        }

        public override int getId()
        {
            return ActivityId;
        }
    }
}
