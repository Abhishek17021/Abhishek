﻿using Abhishek.Model.Domain;
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
       

        IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        
        }


        
        [HttpGet("UserDetails/id")]
        public Response<UserDetailsDTO> GetUserDetailsById(int userid)
        {
            return _userService.GetUserDetailsById(userid);
        }
        [HttpPost("UserDetails")]
        public ActionResult<Response<UserDTO>> AddUserDetails(UserDTO userdto)
        {
            return _userService.AddUserDetails(userdto);


        }

        [HttpGet("UserDetails")]
        public Response<List<UserDetailsDTO>> GetUserDetails()
        {
            return _userService.GetUserDetails();
        }
        [HttpPost("ScoreList")]
        public ActionResult<Response<ScoreDTO>> AddScoreDetails(ScoreDTO scoredto)
        {
            return _userService.AddScoreDetails(scoredto);


        }


    }
}


    

