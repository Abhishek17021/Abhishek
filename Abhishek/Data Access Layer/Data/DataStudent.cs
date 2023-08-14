using Abhishek.Entities;
using System.Text.Json;

namespace Abhishek.StudentData
{
    public class DataStudent
    {

        public static List<Student> students = new List<Student>()
        {
        new Student() { RollNumber = 1,Name= "Abhishek", Class= "Five"},
        new Student() { RollNumber = 2,Name= "Aman", Class="Seven" },
        new Student() { RollNumber = 3,Name= "Rahul", Class="Three" },
        };

        public List<Student> GetAllStudents()
        {
            string ReadAllStudents = System.IO.File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Data Access Layer\Data\EmployeeEntry.json");
            return JsonSerializer.Deserialize<List<Student>>(ReadAllStudents);
        }
        public Student GetStudent(int rollnumber)
        {
            var student = students.Find(x => x.RollNumber == rollnumber);

            return student;


        }

        public  bool Post(Student students)
        {
          
            string ReadAllStudents = System.IO.File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Data Access Layer\Data\StudentEntry.json");
            var student=JsonSerializer.Deserialize<List<Student>>(ReadAllStudents);

            var stucheck = (from e in student where e.Name.Equals(students.Name) select e).Count();
            if (stucheck > 0)
                return false;
            var maxIdstu = (from e in student orderby e.RollNumber descending select e.RollNumber).FirstOrDefault();
            students.RollNumber = maxIdstu + 1;
            var stu = new Student()
            {

                 RollNumber = students.RollNumber,
                Name = students.Name,
                Class= students.Class,  
            };

           
            student.Add(stu);

            string json = JsonSerializer.Serialize(student);
            File.WriteAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Data Access Layer\Data\StudentEntry.json", json);
             return true;
        }
          

        }
    }

