using Abhishek.Model.Domain;
using Abhishek.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Abhishek.Repositories
{
    public class UserData
    {


        public List<User> GetAllUsers()
        {
            string ReadAllUsers = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\JsonData\UserEntry.json");
            return JsonSerializer.Deserialize<List<User>>(ReadAllUsers);
        }

        public ActionResult<Response<List<UserDetailsDTO>>> GetUserDetails()
        {
            string ReadAllUsers = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\JsonData\UserEntry.json");
            var user = JsonSerializer.Deserialize<List<User>>(ReadAllUsers);
            if (user.Count == 0)
            {
                return new Response<List<UserDetailsDTO>>
                {
                    StatusMessage = "No users present!."
                };
            }
            else
            {
                string ReadAllUserDetails = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\JsonData\UserDetails.json");
                var userdetails = JsonSerializer.Deserialize<List<UserDetails>>(ReadAllUserDetails);
                if (userdetails.Count == 0)
                {
                    return new Response<List<UserDetailsDTO>>
                    {
                        StatusMessage = "No users data Found."
                    };
                }
                else
                {


                    var result = (from item in user
                                  join itemdetails in userdetails on item.UserId equals itemdetails.UserId
                                  select new UserDetailsDTO()
                                  {
                                      UserId = item.UserId,
                                      UserName = item.UserName,
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



        public ActionResult<Response<AddUserDTO>> AddUser(AddUserDTO userdto)
        {
            string ReadAllUser = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\JsonData\UserEntry.json");
            var UserUpdated = JsonSerializer.Deserialize<List<User>>(ReadAllUser);

            var usercheck = (from e in UserUpdated where e.UserName.Equals(userdto.UserName) select e).Count();
            if (usercheck > 0)
                return new Response<AddUserDTO>
                {

                    StatusMessage = "User already exists"
                };
            var maxIduser = (from e in UserUpdated orderby e.UserId descending select e.UserId).FirstOrDefault();
            var IdUser = maxIduser + 1;

            var adduser = new User()
            {
                UserId = IdUser,
                UserName = userdto.UserName,
                Password = userdto.Password,
            };


            UserUpdated.Add(adduser);

            string json = JsonSerializer.Serialize(UserUpdated);
            File.WriteAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\JsonData\UserEntry.json", json);

            string ReadAllUser1 = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\JsonData\UserDetails.json");
            var UserUpdated1 = JsonSerializer.Deserialize<List<UserDetails>>(ReadAllUser1);

            var maxId = (from e in UserUpdated1 orderby e.Id descending select e.Id).FirstOrDefault();
            var IdEntry = maxId + 1;

            var adduser2 = new UserDetails()
            {
                Id = IdEntry,
                UserId = IdUser,

                FirstName = userdto.FirstName,
                LastName = userdto.LastName,
                UserEmail = userdto.UserEmail,
                IsStudent = userdto.IsStudent,
                Role = userdto.Role,
            };


            UserUpdated1.Add(adduser2);
            string json1 = JsonSerializer.Serialize(UserUpdated1);
            File.WriteAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\JsonData\UserDetails.json", json1);

            return new Response<AddUserDTO>
            {
                Result = userdto,
                StatusMessage = "Data has been added successfully!."
            };
            ;
        }



        public ActionResult<Response<AddUserDTO>> GetUserDetailsById(int userid)
        {


            string userdetails = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\JsonData\UserEntry.json");
            var users = JsonSerializer.Deserialize<List<User>>(userdetails);
            if (users.Count == 0)
            {
                return new Response<AddUserDTO>
                {
                    StatusMessage = "No Users present"
                };
            }
            else
            {
                string Details = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\JsonData\UserDetails.json");
                var userdetails1 = JsonSerializer.Deserialize<List<UserDetails>>(Details);
                if (userdetails1 != null)
                {

                    var result = (from item in users
                                  join itemDetail in userdetails1 on item.UserId equals itemDetail.UserId

                                  select new AddUserDTO()
                                  {
                                      UserName = item.UserName,
                                      Password = item.Password,
                                      
                                      FirstName = itemDetail.FirstName,
                                      LastName = itemDetail.LastName,
                                      UserEmail = itemDetail.UserEmail,
                                      Role = itemDetail.Role,
                                      IsStudent = itemDetail.IsStudent,
                                  }).FirstOrDefault();
                    if (result != null)
                    {
                        return new Response<AddUserDTO>
                        {
                            Result = result,
                            StatusMessage = "Ok"
                        };
                    }
                    else
                    {
                        return new Response<AddUserDTO>
                        {
                            StatusMessage = "No Data found"
                        };
                    }
                }
                else
                {
                    return new Response<AddUserDTO>
                    {
                        StatusMessage = "No Data found"
                    };
                }
            }

        }
        public ActionResult<Response<UserLogin>> LoginUser(UserLogin userlogin)
        {
            string ReadAllUser = File.ReadAllText(@"C:\Users\parom\source\repos\Abhishek\Abhishek\JsonData\UserEntry.json");
            var UserUpdated = JsonSerializer.Deserialize<List<User>>(ReadAllUser);

            var usercheck = (from e in UserUpdated where e.UserName.Equals(userlogin.UserName) select e).Count();
            if (usercheck > 0)
            {
                return new Response<UserLogin>
                {
                    StatusMessage = "User login successfull"
                };
            }
            else
            {
                
                return new Response<UserLogin>
                {
                    StatusMessage = "User credentials does not exist"
                };
            }
    }
    }
}








