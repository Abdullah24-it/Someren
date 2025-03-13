namespace Someren.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Class {  get; set; }

        public StudentModel(int studentId, string firstName, string lastName, string phoneNumber, string @class)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Class = @class;
        }
    }
}
