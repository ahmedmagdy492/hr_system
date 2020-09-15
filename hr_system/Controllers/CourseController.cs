using hr_system.Attributes;
using hr_system.Repository;
using hr_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace hr_system.Controllers
{
    [OAuthAuthorize]
    [RoutePrefix("api")]
    public class CourseController : ApiController
    {
        private readonly ICourseService _courseService;
        private readonly IEmployeeService _employeeService;

        public CourseController(
            ICourseService courseService,
            IEmployeeService employeeService
            )
        {
            this._courseService = courseService;
            this._employeeService = employeeService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_courseService.GetCourses());
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri]int id)
        {
            var course = _courseService.GetById(id);

            if (course == null) return NotFound();
            return Ok(course);
        }

        // POST /api/Course/Enroll
        [Route("Course/Enroll")]
        [HttpPost]
        public IHttpActionResult Enroll([FromBody]EnrollEmployeeViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid model data provided");

            var employee = _employeeService.GetById(model.EmployeeId);
            var course = _courseService.GetById(model.CourseId);

            if(employee != null && course != null)
            {
                var result = _courseService.Enroll(employee, course);
                if (!result)
                    return BadRequest("Student is already Enrolled in this course or has already taken that course before");
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody]AddCourseViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Course Data");

            var isAlreadyCreated = _courseService.IsCourseAlreadyExist(model.CourseName);

            if(!isAlreadyCreated)
            {
                var result = _courseService.AddCourse(new Models.Course
                {
                    Name = model.CourseName,
                    Duration = model.CourseDuration
                });

                if (result)
                    return Ok();
            }
            return BadRequest("An Error Has Occurred: Ensure that the course with this name is not exist");
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            var course = _courseService.GetById(id);

            if (course == null) return NotFound();
            var result = _courseService.RemoveCourse(course);

            if (result)
                return Ok();
            return BadRequest("Cannot delete this course due to an internal error");
        }
    }
}
