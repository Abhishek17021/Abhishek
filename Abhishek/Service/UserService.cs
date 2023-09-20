using Abhishek.Model.Domain;
using Abhishek.Model.DTO;
using Abhishek.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Json;

namespace Abhishek.Service
{
    public class UserService 
    {
        
        public  Response<List<UserDetailsDTO>> GetUserDetails()
        {
            var genericUserObject = new SchoolRepository<User>();
            var user = genericUserObject.Get(@".\Json\UserEntry.json");

            if (user == null)
            {
                return new Response<List<UserDetailsDTO>>
                {

                    ErrorMessage = "No users present!."
                };
            }
            else
            {
                var genericUserDetailsObject = new SchoolRepository<UserDetails>();
                var userdetails = genericUserDetailsObject.Get(@".\Json\UserDetails.json");
                if (userdetails == null)
                {
                    return new Response<List<UserDetailsDTO>>
                    {
                        ErrorMessage = "No users data Found."
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


        public Response<UserDetailsDTO> GetUserDetailsById(int userid)
        {
            var genericUserObject = new SchoolRepository<User>();
            var users = genericUserObject.Get(@".\Json\UserEntry.json");
            try
            {
                if (users == null)
                {
                    return new Response<UserDetailsDTO>
                    {
                        StatusMessage = "No Users present"
                    };
                }
                else
                {
                    var genericUserDetailsObject = new SchoolRepository<UserDetails>();
                    var userdetails = genericUserDetailsObject.Get(@".\Json\UserDetails.json");

                    if (userdetails != null)
                    {

                        var result = (from item in users
                                      join itemDetail in userdetails on item.UserId equals itemDetail.UserId
                                      where itemDetail.UserId == userid

                                      select new UserDetailsDTO()
                                      {
                                          UserId = item.UserId,
                                          UserName = item.UserName,
                                          FirstName = itemDetail.FirstName,
                                          LastName = itemDetail.LastName,
                                          UserEmail = itemDetail.UserEmail,
                                          Role = itemDetail.Role,
                                          IsStudent = itemDetail.IsStudent,
                                      }).FirstOrDefault();
                        if (result != null)
                        {
                            return new Response<UserDetailsDTO>
                            {
                                Result = result,
                                StatusMessage = "Ok"
                            };
                           
                        }

                        else
                        {
                            return new Response<UserDetailsDTO>
                            {
                                StatusMessage = "No Data found"
                            };
                        }
                    }
                    else
                    {
                        return new Response<UserDetailsDTO>
                        {
                            StatusMessage = "No Data found"
                        };
                    }
                }
            }
            


            catch (Exception ex)
            {
                throw ex;
            }
        }


    
    public ActionResult<Response<UserDTO>> AddUserDetails(UserDTO userdto)
        {

            var genericUserOobject = new SchoolRepository<User>();
            var UserUpdated = genericUserOobject.Get(@".\Json\UserEntry.json");

            var usercheck = (from e in UserUpdated where e.UserName.Equals(userdto.UserName) select e).Count();


            if (usercheck > 0)
                return new Response<UserDTO>
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

            genericUserOobject.Add(@".\Json\UserEntry.json", UserUpdated);

            var genericUserDetailsObject = new SchoolRepository<UserDetails>();
            var UserUpdated1 = genericUserDetailsObject.Get(@".\Json\UserDetails.json");

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
            genericUserDetailsObject.Add(@".\Json\UserDetails.json", UserUpdated1);

            return new Response<UserDTO>
            {
                Result = userdto,
                StatusMessage = "Data has been added successfully!."
            };


        }

        
    }
        

    }

