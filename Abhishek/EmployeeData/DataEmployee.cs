using Abhishek.Models;

namespace Abhishek.EmployeeData
{
    public class DataEmployee
    {
        public static List<Employee> employees = new List<Employee>()
        {
        new Employee() { Id = 1,Name= "Kavita", Location= "Kolkata"},
        new Employee() { Id = 2,Name= "Piyush", Location="Pune" },
        new Employee() { Id = 3,Name= "Mansi", Location="Hyd" },

     };
    }
}
