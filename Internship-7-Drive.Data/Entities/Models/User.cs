﻿
namespace Internship_7_Drive.Data.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
    }
}
