using Abhishek.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Abhishek.Business_Logic_Layer;


namespace Abhishek.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeService _employeeService = new EmployeeService();
        StudentService _Studentservice = new StudentService();
        [HttpGet]
        public List<Employee> GetAllEmployees()
        {

            return _employeeService.GetAllEmployees();

        }
        [HttpGet("{ id}")]

        public Employee GetEmployee(int id)
        {
            return _employeeService.GetEmployee(id);

        }
        [HttpPost]
        public bool Post(Employee employee)
        {

            if (ModelState.IsValid)

                return _employeeService.Post(employee);
            return false;

        }


        [HttpGet("Student")]
        public List<Student> GetAllStudent()
        {
            var fileStudent = System.IO.File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\StudentEntry.json");
            return JsonSerializer.Deserialize<List<Student>>(fileStudent);
        }
        [HttpGet("Student/{id}")]


        public Student GetStudent(int rollnumber)
        {

            return _Studentservice.GetStudent(rollnumber);

        }

        [HttpPost("student")]
        public bool Post(Student students)
        {
            if (ModelState.IsValid)

                return _Studentservice.Post(students);
            return false;
        }

    }
    }

