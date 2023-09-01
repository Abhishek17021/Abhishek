using Abhishek.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Abhishek.Repositories
{
    public interface ISchoolRepository<T> where T : class
    {
        ActionResult<Response<List<T>>> GetUserDetails();
    }
}
