using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.Data
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }
        public string? TrainerName { get; set; }
        public string? TrainerSurname { get; set; }
        public string Namesurname
        {
            get
            {
                return this.TrainerName + " " + this.TrainerSurname;
            }
        }
        public string? TrainerEmail { get; set; }
        public string? TrainerPhone{ get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
