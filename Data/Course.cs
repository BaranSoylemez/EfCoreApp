using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.Data
{
    public class Course
    {
        [Key] 
        public int CourseId { get; set; }

        [Required(ErrorMessage ="Kurs Adı Boş Geçilemez!")]
        public string? CourseName { get; set; }

        [Required(ErrorMessage = "Eğitmen Alanı Boş Geçilemez!")]
        public int? TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;
        public ICollection<CourseRegister> CourseRegisters { get; set; } = new List<CourseRegister>();
    }
}
