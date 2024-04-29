using Microsoft.EntityFrameworkCore;

namespace EfCoreApp.Data
{
    public class DataContext:DbContext

    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {
                
        }
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>(); 
        public DbSet<CourseRegister> CourseRegisters => Set<CourseRegister>();
        public DbSet<Trainer> Trainers => Set<Trainer>();
    }
}
