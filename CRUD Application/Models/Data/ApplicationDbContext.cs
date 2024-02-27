using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.Models.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFApplication;Integrated Security=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set Relations
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s=> s.DepartmentId);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc=> new {sc.StudentId , sc.CourseId});

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc=>sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            //set default Values for IsDeleted
            modelBuilder.Entity<Student>()
                .Property(s => s.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Department>()
                .Property(d => d.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Course>()
                 .Property(c => c.IsDeleted).HasDefaultValue(false);

        }
    }
}
