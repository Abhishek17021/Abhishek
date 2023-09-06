using Abhishek.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Abhishek.Repositories
{
    public interface ISchoolRepository<T> where T : class
    {

        // public  Response<List<T>> ReadUsers(string path);
        void SaveUser(string path, List<T> ReadAllUsers);

       //Response<T> GetUserDetailsById(int id);
    }
}
