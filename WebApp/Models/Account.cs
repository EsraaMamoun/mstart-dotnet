using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Account
    {
        public int ID { get; set; }

        public int? User_ID { get; set; }

        public DateTime Server_DateTime { get; set; }

        public DateTime DateTime_UTC { get; set; }

        public DateTime Update_DateTime_UTC { get; set; }

        public string Account_Number { get; set; }

        public double Balance { get; set; }

        public string Currency { get; set; }

        [Column(TypeName = "int")]
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }
    }

}
