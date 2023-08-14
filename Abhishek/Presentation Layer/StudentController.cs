using Abhishek.Business_Logic_Layer;
using Abhishek.Entities;
using Abhishek.StudentData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Abhishek.Controllers
{ 
  [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    { 
       StudentService _Studentservice = new StudentService();

    //[//HttpGet]
    //public List<Student> GetAllStudent()
    //{
    //    var fileStudent = System.IO.File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Data Access Layer\Data\StudentEntry.json");
        //return JsonSerializer.Deserialize<List<Student>>(fileStudent);
   // }
    //[HttpGet("{id}")]
//

   // public Student GetStudent(int rollnumber)
    //{
//
        //return _Studentservice.GetStudent(rollnumber);

   // }

    [HttpPost]
    public bool Post(Student students)
    {
        if (ModelState.IsValid)
        {
         return true;
        }
        return _Studentservice.Post(students);
    }

}
}



    


