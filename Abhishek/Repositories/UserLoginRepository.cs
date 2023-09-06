using Abhishek.Model.Domain;
using Abhishek.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Abhishek.Repositories
{
    public class UserLoginRepository
    {
       

        public ActionResult<Response<UserLogin>> LoginUser(UserLogin userlogin)
        {
            string ReadAllUser = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\JsonData\UserEntry.json");
            var UserUpdated = JsonSerializer.Deserialize<List<User>>(ReadAllUser);

            var usercheck = (from e in UserUpdated where e.UserName.Equals(userlogin.UserName) select e).Count();
            if (usercheck > 0)
            {
                return new Response<UserLogin>
                {
                    StatusMessage = "User login successfull"
                };
            }
            else
            {

                return new Response<UserLogin>
                {
                    StatusMessage = "User credentials does not exist"
                };
            }
        }
    }
}
