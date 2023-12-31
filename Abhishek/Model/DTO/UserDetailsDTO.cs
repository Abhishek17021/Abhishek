﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Abhishek.Model.Domain;

namespace Abhishek.Model.DTO
{
    public class UserDetailsDTO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string Role { get; set; }
        public Boolean IsStudent { get; set; }
        
        public int UserId { get; set; }

    }
}
