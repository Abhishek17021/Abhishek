
using Abhishek.Data_Access_Layer;
using Abhishek.Data_Access_Layer.Data;
using Abhishek.Entities;
using Abhishek.StudentData;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Abhishek.Business_Logic_Layer
{
    public class EmployeeService
    {
        DataEmployee emp = new DataEmployee();
        public List<Employee> GetAllEmployees()
        {
            return emp.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {
            if (emp == null)
            {
                throw new Exception("Entered Employee doesnot exist");
            }
            return emp.GetEmployee(id);
        }
        public bool Post(Employee employees)
        {
           return emp.Post(employees);
            }
        }

    }
