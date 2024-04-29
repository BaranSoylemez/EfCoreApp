using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.Data
{
    public class CourseRegister
    {
        [Key]
        public int RegId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; }=null!;
        public DateTime RegDate { get; set; }
    }
}
