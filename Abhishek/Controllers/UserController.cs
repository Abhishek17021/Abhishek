using Abhishek.Model.Domain;
using Abhishek.Model.DTO;
using Abhishek.Service;
using Microsoft.AspNetCore.Mvc;
//using Abhishek.Business_Logic_Layer;


namespace Abhishek.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService userService = new UserService();


        
        [HttpGet("UserDetails/id")]
        public ActionResult<Response<AddUserDTO>> GetUserDetailsById(int userid)
        {
            return userService.GetUserDetailsById(userid);
        }
        [HttpPost("UserDetails")]
        public ActionResult<Response<AddUserDTO>> AddUserDetails(AddUserDTO userdto)
        {
            return userService.AddUserDetails(userdto);


        }

        [HttpGet("UserDetails")]
        public ActionResult<Response<List<T>>> GetUserDetails()
        {
            return userService.GetUserDetails();
        }
        [HttpPost("UserLogin")]
        public ActionResult<Response<UserLogin>> LoginUser(UserLogin userlogin)
        {
            return userService.LoginUser(userlogin);

        }
         
    }
}


    

