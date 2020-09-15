using hr_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hr_system.Repository
{
    public interface ICourseService
    {
        bool AddCourse(Course course);
        bool Enroll(Employee employee, Course course);
        IEnumerable<Course> GetCourses();
        Course GetById(int id);
        bool RemoveCourse(Course course);
        bool IsCourseAlreadyExist(string courseName);
    }
}