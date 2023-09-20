using Abhishek.Model.DTO;
using Abhishek.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Abhishek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
       
        UserLoginService userloginservice = new UserLoginService();

        [HttpPost]
        public ActionResult<Response<LoginResponseDTO>> LoginUser(UserLogin userlogin)
        {
            return userloginservice.LoginUser(userlogin);

        }
    }
}
