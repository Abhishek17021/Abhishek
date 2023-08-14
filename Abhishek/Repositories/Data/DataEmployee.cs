using Abhishek.Entities;
using System.Text.Json;


namespace Abhishek.Data_Access_Layer.Data
{
    public class DataEmployee
    {
        public static List<Employee> employees = new List<Employee>()
        {

        new Employee() { Id = 1,Name= "Abhishek", Location= "ghi"},
        new Employee() { Id = 2,Name= "saket", Location="def" },
        new Employee() { Id= 3,Name= "Rahul", Location="abc" },
        };

        
        public List<Employee> GetAllEmployees()
        {
            string ReadAllEmployee = System.IO.File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\EmployeeEntry.json");
            return JsonSerializer.Deserialize<List<Employee>>(ReadAllEmployee);
        }   
           public Employee GetEmployee(int id)
        {
            var employee = employees.Find(x => x.Id == id);

            return employee;
        }

        public bool Post(Employee employee)
        {
            string ReadAllEmployee = System.IO.File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\EmployeeEntry.json");
            var EmpUpdated=JsonSerializer.Deserialize<List<Employee>>(ReadAllEmployee);

            var empcheck = (from e in EmpUpdated where e.Name.Equals(employee.Name) select e).Count();
                if (empcheck > 0)
                    return false;
                var maxIdEmp = (from e in EmpUpdated orderby e.Id descending select e.Id).FirstOrDefault();
                employee.Id = maxIdEmp + 1;

            var emp = new Employee()
            {
                Id = employee.Id,
            Name = employee.Name,
                Location = employee.Location,
            };

           EmpUpdated.Add(emp);
           
            string json = JsonSerializer.Serialize(EmpUpdated);
                File.WriteAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\EmployeeEntry.json", json);
           
                return true;
            




        }
    }
}



    
