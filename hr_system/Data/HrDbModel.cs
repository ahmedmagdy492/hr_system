namespace hr_system.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using hr_system.Models;

    public partial class HrDbModel : DbContext
    {
        public HrDbModel()
            : base("name=HrDbModel")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<EmployeeCourse> EmployeeCourses { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.EmployeeCourses)
                .WithRequired(e => e.Cours)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.PhoneNumbers)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.Employee_id);
        }
    }
}
