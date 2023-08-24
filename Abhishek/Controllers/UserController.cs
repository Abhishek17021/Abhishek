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
        UserService userService=new UserService();
        

        [HttpGet]
        public List<User> GetAllUsers()
        {
         return userService.GetAllUsers();
        }
          [HttpGet("UserDetails/{id}")]
       public ActionResult<Response<AddUserDTO>> GetUserDetailsById(int userid)
            {
                 return userService.GetUserDetailsById(userid);
            }
         [HttpPost]
             public ActionResult<Response<AddUserDTO>> AddUser(AddUserDTO userdto)
             {
                  return userService.AddUser(userdto);


        }

        [HttpGet("UserDetails")]
        public ActionResult <Response<List<UserDetailsDTO>>> GetUserDetails()
        {
           return userService.GetUserDetails();
        }
        
    }
       
}


    

