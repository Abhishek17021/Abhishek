using Abhishek.Model.DTO;
using System.IO;
using System.Text.Json;

namespace Abhishek.Repositories
{
    public class SchoolRepository<T> : ISchoolRepository<T> where T : class
    {
        
       

        public List<T> Get(string path)
        {
            string ReadAllUsers = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(ReadAllUsers);
        }

        

        public void Add(string path, List<T> ReadAllUsers)
        {
            string SaveUser = JsonSerializer.Serialize(ReadAllUsers);
            File.WriteAllText(path, SaveUser);
        }

        public List<T> GetById(string path, int id)
        {
            string ReadAllUsers = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(ReadAllUsers);
        }
    }
}