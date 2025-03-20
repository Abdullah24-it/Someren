namespace Someren.Models
{
    public class LecturerModel : BaseModel
    {
        public int LecturerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public int Age { get; set; }
		public string PhoneNumber { get; set; }
        public bool Deleted { get; set; }


        public LecturerModel()
        {
            FirstName = "";
            LastName = "";
			Age = 0;
			PhoneNumber = "";
            Deleted = false;
        }

        public LecturerModel(int lecturerId, string firstName, string lastName, int age, string phoneNumber, bool deleted)
        {
            LecturerId = lecturerId;
            FirstName = firstName;
            LastName = lastName;
			Age = age;
			PhoneNumber = phoneNumber;
            Deleted = false;
        }

        public override int getId()
        {
            return LecturerId;
        }
    }
}
