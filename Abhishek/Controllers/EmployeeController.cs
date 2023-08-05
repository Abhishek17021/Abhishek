using Abhishek.EmployeeData;
using Abhishek.Models;
using Abhishek.StudentData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Abhishek.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]

        public ActionResult<List<Employee>> GetAllemployees()
        {
            return Ok(DataEmployee.employees);
        }
        [HttpGet("{id}")]

        public ActionResult<Employee> GetEmployee(int id)
        {
            var Employee = DataEmployee.employees.Find(x => x.Id == id);

            if (Employee == null)
            {
                return NotFound("Entered Employee doesnot exist");
            }
            return Ok(Employee);


        }

        [HttpGet("Student")]

        public ActionResult<List<Student>> GetAllstudents()
        {
            return Ok(DataStudent.students);
        }
        [HttpGet("Student/{id}")]

        public ActionResult<Student> GetStudent(int id)
        {
            var Student = DataStudent.students.Find(x => x.Id == id);

            if (Student == null)
            {
                return NotFound("Entered Employee doesnot exist");
            }
            return Ok(Student);


        }
    }
}