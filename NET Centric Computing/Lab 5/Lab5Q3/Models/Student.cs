using System.ComponentModel.DataAnnotations;

namespace Lab5Q3.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Student Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; }

        [Required(ErrorMessage = "Semester is required")]
        [Range(1, 8, ErrorMessage = "Semester must be between 1 and 8")]
        public int Semester { get; set; }
    }
}
