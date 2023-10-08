using Abhishek.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Abhishek.Service
{
    public interface IUserService
    {
        public Response<List<UserDetailsDTO>> GetUserDetails();
        public Response<UserDetailsDTO> GetUserDetailsById(int userid);
        public Response<UserDTO> AddUserDetails(UserDTO userdto);

        public Response<ScoreDTO> AddScoreDetails(ScoreDTO scoredto);


    }
}
