using System.ComponentModel.DataAnnotations;

namespace Intro.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is compulsory")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is compulsory")]
        public string LastName { get; set; }
        public string Email { get; set;}
        public int Age { get; set;}
    }
}
