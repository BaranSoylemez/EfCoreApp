using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? Studentname { get; set; }
        public string? Studentsurname { get; set; }
        public string NameSurname { 
            get{
                return this.Studentname + " " + this.Studentsurname;
                    }
        }
            
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public ICollection<CourseRegister> CourseRegisters { get; set; } = new List<CourseRegister>();
    }
}
