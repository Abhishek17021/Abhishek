using Abhishek.Model.Domain;

namespace Abhishek.Model.DTO
{
    public class LoginResponseDTO
    {
       
        public int UserId { get; set; }
        
        public UserDetailsDTO UserDetailsdto { get; set; }
    }

}
