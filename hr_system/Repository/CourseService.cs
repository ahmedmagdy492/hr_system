using hr_system.Data;
using hr_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hr_system.Repository
{
    public class CourseService : ICourseService
    {
        private readonly HrDbModel _context;

        public CourseService(HrDbModel context)
        {
            this._context = context;
        }

        private bool IsAlreadyEnrolled(int empId, int courseId)
        {
            var emp = _context.EmployeeCourses.FirstOrDefault(ec => ec.EmployeeId == empId && ec.CourseId == courseId);
            return emp == null ? false : true;
        }

        public bool AddCourse(Course course)
        {
            _context.Courses.Add(course);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool Enroll(Employee employee, Course course)
        {
            var isAlreadyEnrolled = IsAlreadyEnrolled(employee.Id, course.Id);

            if(!isAlreadyEnrolled)
            {
                var employeeEnrollment = new EmployeeCourse
                {
                    CourseId = course.Id,
                    EmployeeId = employee.Id,
                    Mark = 0
                };
                _context.EmployeeCourses.Add(employeeEnrollment);
                var result = _context.SaveChanges();
                return result > 0;
            }
            return false;
        }

        public Course GetById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses;
        }

        public bool RemoveCourse(Course course)
        {
            _context.Courses.Remove(course);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool IsCourseAlreadyExist(string courseName)
        {
            var result = _context.Courses.FirstOrDefault(c => c.Name == courseName);
            return result == null ? false : true;
        }
    }
}