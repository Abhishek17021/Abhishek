using Abhishek.Model.Domain;
using Abhishek.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

namespace Abhishek.Repositories
{
    public class UserLoginRepository
    {
       

        public ActionResult<Response<LoginResponseDTO>> LoginUser(UserLogin userlogin)
        {
            string ReadAllUser = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Json\UserEntry.json");
            var UserUpdated = JsonSerializer.Deserialize<List<User>>(ReadAllUser);
            var loginuser=UserUpdated.FirstOrDefault(x=>x.UserName==userlogin.UserName && x.Password==userlogin.Password);
            if(loginuser==null)
            {
                return new Response<LoginResponseDTO>
                {
                    StatusMessage = "Invalid username or password!."

                };

            }
            else
            { 
                string ReadAllUser1 = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Json\UserDetails.json");
            var UserUpdated1 = JsonSerializer.Deserialize<List<UserDetails>>(ReadAllUser1);
                var loginuserdetails = UserUpdated.FirstOrDefault(x => x.UserId==loginuser.UserId);
                var result = (from item in UserUpdated
                              join itemDetail in UserUpdated1 on item.UserId equals itemDetail.UserId
                              where item.UserId == loginuser.UserId
                              select new UserDetailsDTO()
                              {
                                  UserName = userlogin.UserName,
                                  FirstName = itemDetail.FirstName,
                                  LastName = itemDetail.LastName,
                                  UserEmail = itemDetail.UserEmail,
                                  Role = itemDetail.Role,
                                  IsStudent = itemDetail.IsStudent,
                              }).FirstOrDefault();

                LoginResponseDTO login= new LoginResponseDTO()
                {
                    UserDetailsdto = result
                   
                };

                return new Response<LoginResponseDTO>
                {

                Result= login,
                StatusMessage="Ok"
               
                };
            }
        }
    }
}
