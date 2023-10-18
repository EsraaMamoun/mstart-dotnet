using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApp.Models
{
    public class User
    {
        public int ID { get; set; }

        public DateTime Server_DateTime { get; set; }

        public DateTime DateTime_UTC { get; set; }

        public DateTime Update_DateTime_UTC { get; set; }

        public string Username { get; set; }

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


public enum Status
{
    Active,
    Deleted,
}

public enum Gender
{
    Male,
    Female,
}