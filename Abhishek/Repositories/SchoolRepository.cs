using Abhishek.Model.DTO;
using System.IO;
using System.Text.Json;

namespace Abhishek.Repositories
{
    public class SchoolRepository<T> : ISchoolRepository<T> where T : class
    {
        public Response<T> GetUserDetailsById(int id)
        {
            throw new NotImplementedException();
        }

       

        public List<T> ReadUsers(string path)
        {
            string ReadAllUsers = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(ReadAllUsers);
        }

        

        public void SaveUser(string path, List<T> ReadAllUsers)
        {
            string SaveUser = JsonSerializer.Serialize(ReadAllUsers);
            File.WriteAllText(path, SaveUser);
        }

            
    }
}