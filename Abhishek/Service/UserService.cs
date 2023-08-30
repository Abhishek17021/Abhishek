using Abhishek.Model.Domain;
using Abhishek.Model.DTO;
using Abhishek.Repositories;
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

        public ActionResult<Response<AddUserDTO>> GetUserDetailsById(int userid)
        {
            if (userid < 0)
            {
                return new Response<AddUserDTO>
                {

                    ErrorMessage = "User ID cannot be Zero, Please enter valid user id"
                };
            }

            return userdata.GetUserDetailsById(userid);
        }
        public ActionResult<Response<AddUserDTO>> AddUser(AddUserDTO userdto)
        {
            if (userdto == null)
            {
                return new Response<AddUserDTO>
                {
                    ErrorMessage = "No Data Found"
                };
            }


            return userdata.AddUser(userdto);
        }
        public ActionResult<Response<UserLogin>> LoginUser(UserLogin userlogin)
        {
            if (userlogin == null)
            {
                return new Response<UserLogin>
                {
                    ErrorMessage = "User credentials provided doesnot exist"
                };
            }

            return userdata.LoginUser(userlogin);


        }

    }
}
