using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models
{
    public class Account
    {
        public int ID { get; set; }

        public int? User_ID { get; set; }

        public DateTime Server_DateTime { get; set; }

        public DateTime DateTime_UTC { get; set; }

        public DateTime Update_DateTime_UTC { get; set; }

        [Required(ErrorMessage = "Account Number is required.")]
        [RegularExpression("^[0-9]{7}$", ErrorMessage = "Account Number must be 7 digits.")]
        public string Account_Number { get; set; }

        public decimal Balance { get; set; }

        public string Currency { get; set; }

        [Column(TypeName = "int")]
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }
    }
}
