using Abhishek.Entities;
using Abhishek.StudentData;
using Microsoft.AspNetCore.Mvc;

namespace Abhishek.Business_Logic_Layer
{
    public class StudentService
    {
         DataStudent stud = new DataStudent();
        public List<Student> GetAllSTudents()
        {
            return stud.GetAllStudents();
        }
        public Student GetStudent(int rollnumber)
        {
            if (stud == null)
            {
                throw new Exception("Entered Student doesnot exist");
            }
            return stud.GetStudent(rollnumber);
        }
        public bool Post(Student students)
        {
            return stud.Post(students);
        }

    }
}
