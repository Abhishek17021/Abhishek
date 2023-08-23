using Abhishek.Model.Domain;
using Abhishek.Model.DTO;
using Abhishek.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Abhishek.Service
{
    public class UserService
    {
        UserData userdata = new UserData();
        
        public List<User> GetAllUsers()
         {
            return userdata.GetAllUsers();
         }

        public ActionResult<Response<List<UserDetailsDTO>>> GetUserDetails()
        {
            return userdata.GetUserDetails();
        }

        public ActionResult<Response<UserDTO>> GetUserDetailsById(int userid)
        {
            return userdata.GetUserDetailsById(userid);
        }
        public ActionResult<Response<UserDTO>> AddUser(UserDTO userdto)
        {

            
            return userdata.AddUser(userdto);
        }

       
        

    }
}
