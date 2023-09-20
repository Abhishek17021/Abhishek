using Abhishek.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Abhishek.Repositories;

namespace Abhishek.Service
{
    public class UserLoginService

    {
        UserLoginRepository userloginrepo =new UserLoginRepository();

        public ActionResult<Response<LoginResponseDTO>> LoginUser(UserLogin userlogin)
        {
            if (userlogin == null)
            {
                return new Response<LoginResponseDTO>
                {
                    ErrorMessage = "User credentials provided doesnot exist"
                };
            }

            return userloginrepo.LoginUser(userlogin);


        }

       
    }
}
