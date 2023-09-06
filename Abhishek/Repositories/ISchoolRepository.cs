using Abhishek.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Abhishek.Repositories
{
    public interface ISchoolRepository<T> where T : class
    {

        public List<T> Get(string path);
        void Add(string path, List<T> ReadAllUsers);

        public List<T> GetById(string path,int id);

       
    }
}
