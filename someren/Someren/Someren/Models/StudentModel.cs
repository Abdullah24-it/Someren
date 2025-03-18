namespace Someren.Models
{
    public class StudentModel: BaseModel
    {
        public int StudentId { get; set; }
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Class {  get; set; }
        public bool Deleted { get; set; }
        public override int getId()
        {
            return StudentId;
        }

        public StudentModel()
        {
            StudentNumber = "";
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            Class = "";
            Deleted = false;
        }

        public StudentModel(int studentId, string studentNumber, string firstName, string lastName, string phoneNumber, string @class, bool deleted)
        {
            StudentId = studentId;
            StudentNumber = studentNumber;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Class = @class;
            Deleted = false;
        }
    }
}
