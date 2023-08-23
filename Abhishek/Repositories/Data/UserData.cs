using Abhishek.Model.Domain;
using Abhishek.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Abhishek.Repositories.Data
{
    public class UserData
    {


        public List<User> GetAllUsers()
        {
            string ReadAllUsers = System.IO.File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\UserEntry.json");
            return JsonSerializer.Deserialize<List<User>>(ReadAllUsers);
        }

        public ActionResult<Response<List<UserDetailsDTO>>> GetUserDetails()
        {
            string ReadAllUsers = System.IO.File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\UserEntry.json");
            var user = JsonSerializer.Deserialize<List<User>>(ReadAllUsers);
            if (user.Count == 0)
            {
                return new Response<List<UserDetailsDTO>>
                {
                    StatusMessage = "No recored found!."
                };
            }
            else
            {
                string ReadAllUserDetails = System.IO.File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\UserDetails.json");
                var userdetails = JsonSerializer.Deserialize<List<UserDetails>>(ReadAllUserDetails);
                if (userdetails.Count == 0)
                {
                    return new Response<List<UserDetailsDTO>>
                    {
                        StatusMessage = "No Data Found."
                    };
                }
                else
                {


                    var result = (from item in user
                                  join itemdetails in userdetails on item.UserId equals itemdetails.UserId
                                  select new UserDetailsDTO()
                                  {
                                      UserId = item.UserId,

                                      FirstName = itemdetails.FirstName,
                                      LastName = itemdetails.LastName,
                                      UserEmail = itemdetails.UserEmail,
                                      IsStudent = itemdetails.IsStudent,
                                      Role = itemdetails.Role
                                  }).ToList();
                    if (result.Count > 0)
                    {
                        return new Response<List<UserDetailsDTO>>
                        {
                            Result = result,
                            StatusMessage = "Ok"
                        };
                    }

                    else
                    {
                        return new Response<List<UserDetailsDTO>>
                        {
                            StatusMessage = "No Matching Records found"
                        };


                    }
                }
            }
        }



        public ActionResult<Response<UserDTO>> AddUser(UserDTO userdto)
        {
            string ReadAllUser = System.IO.File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\UserEntry.json");
            var UserUpdated = JsonSerializer.Deserialize<List<User>>(ReadAllUser);

            var usercheck = (from e in UserUpdated where e.UserName.Equals(userdto.UserName) select e).Count();
            if (usercheck > 0)
                return new Response<UserDTO>
                {
                   
                    StatusMessage = "User already exists"
                };
            var maxIduser = (from e in UserUpdated orderby e.UserId descending select e.UserId).FirstOrDefault();
            userdto.UserId = maxIduser + 1;

            var adduser = new User()
            {
                UserId = userdto.UserId,
                UserName = userdto.UserName,
                Password = userdto.Password,
            };


            UserUpdated.Add(adduser);

            string json = JsonSerializer.Serialize(UserUpdated);
            File.WriteAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\UserEntry.json", json);

            string ReadAllUser1 = System.IO.File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\UserDetails.json");
            var UserUpdated1 = JsonSerializer.Deserialize<List<UserDetails>>(ReadAllUser1);

            var maxId = (from e in UserUpdated1 orderby e.ID descending select e.ID).FirstOrDefault();
            userdto.ID = maxId + 1;

            var adduser2 = new UserDetails()
            {
                ID = userdto.ID,
                UserId = userdto.UserId,

                FirstName = userdto.FirstName,
                LastName = userdto.LastName,
                UserEmail = userdto.UserEmail,
                IsStudent = userdto.IsStudent,
                Role = userdto.Role,
            };


            UserUpdated1.Add(adduser2);
            string json1 = JsonSerializer.Serialize(UserUpdated1);
            File.WriteAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\UserDetails.json", json1);

            return new Response<UserDTO>
            {
                Result = userdto,
                StatusMessage = "Data has been added successfully!."
            };
            ;
        }



        public ActionResult<Response<UserDTO>> GetUserDetailsById(int userid)
        {


            string userdetails = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\UserEntry.json");
            var users = JsonSerializer.Deserialize<List<User>>(userdetails);
            if (users.Count == 0)
            {
                return new Response<UserDTO>
                {
                    StatusMessage = "No Users present"
                };
            }
            else
            {
                string Details = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\Repositories\Data\UserDetails.json");
                var userdetails1 = JsonSerializer.Deserialize<List<UserDetails>>(Details);
                if (userdetails1 != null)
                {

                    var result = (from item in users
                                  join itemDetail in userdetails1 on item.UserId equals itemDetail.UserId

                                  select new UserDTO()
                                  {
                                      UserName = item.UserName,
                                      Password = item.Password,
                                      UserId = item.UserId,
                                      FirstName = itemDetail.FirstName,
                                      LastName = itemDetail.LastName,
                                      UserEmail = itemDetail.UserEmail,
                                      Role = itemDetail.Role,
                                      IsStudent = itemDetail.IsStudent,
                                  }).FirstOrDefault();
                    if (result !=null)
                    {
                        return new Response<UserDTO>
                        {
                            Result = result,
                            StatusMessage = "Ok"
                        };
                    }
                    else
                    {
                        return new Response<UserDTO>
                        {
                            StatusMessage = "No Matching Records found"
                        };
                    }
                }
                else
                {
                    return new Response<UserDTO>
                    {
                        StatusMessage = "No Matching Records found"
                    };
                }
            }

        }

    }
}


  

            
        
    

