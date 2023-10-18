using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApp.Pages.Users
{
    public class IndexModel : PageModel
    {
        public List<UserInfo> listUsers = new List<UserInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Server=tcp:mstarttaskserver.database.windows.net,1433;Initial Catalog=mstartTaskDB;Persist Security Info=False;User ID=EsraaM;Password=Esraa.1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using(SqlConnection connection  = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Select * from Users";
                    using(SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserInfo userInfo = new UserInfo();
                                userInfo.ID = reader.GetInt32(0);
                                userInfo.Server_DateTime = reader.GetDateTime(1);
                                userInfo.Update_DateTime_UTC = reader.GetDateTime(2);
                                userInfo.DateTime_UTC = reader.GetDateTime(3);
                                userInfo.Username = reader.GetString(4);
                                userInfo.Email = reader.GetString(5);
                                userInfo.First_Name = reader.GetString(6);
                                userInfo.Last_Name  = reader.GetString(7);
                                userInfo.Status = reader.GetInt32(8);
                                userInfo.Gender = reader.GetInt32(9);
                                userInfo.Date_Of_Birth = reader.GetDateTime(10);

                                listUsers.Add(userInfo);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class UserInfo
    {
        public int ID;

        public DateTime Server_DateTime;

        public DateTime DateTime_UTC;

        public DateTime Update_DateTime_UTC;

        public String Username;

        public String Email;

        public String First_Name;

        public String Last_Name;

        public int Status;

        public int Gender;

        public DateTime Date_Of_Birth;
    }
}
