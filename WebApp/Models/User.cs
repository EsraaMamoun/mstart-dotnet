using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models
{
    public class User
    {
        public int ID { get; set; }

        public DateTime Server_DateTime { get; set; }

        public DateTime DateTime_UTC { get; set; }

        public DateTime Update_DateTime_UTC { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only English letters and numbers are allowed.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        [Column(TypeName = "int")]
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        [Column(TypeName = "int")]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        public DateTime Date_Of_Birth { get; set; }
    }

}
