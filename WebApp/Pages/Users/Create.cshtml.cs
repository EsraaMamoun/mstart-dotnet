using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApp.Pages.Users
{
    public class CreateModel : PageModel
    {
        public UserInfo userInfo = new UserInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            userInfo.Email = Request.Form["email"];
            userInfo.Username = Request.Form["username"];
            userInfo.First_Name = Request.Form["first_name"];
            userInfo.Last_Name = Request.Form["last_name"];
            String gender = Request.Form["gender"];
            String dateOfBirth = Request.Form["date_of_birth"];
            userInfo.DateTime_UTC = DateTime.Now;
            userInfo.Update_DateTime_UTC = DateTime.Now;
            userInfo.Server_DateTime = DateTime.Now;
            userInfo.Status = 0;

            if (userInfo.Email.Length == 0 || userInfo.Username.Length == 0 || userInfo.First_Name.Length == 0 || userInfo.Last_Name.Length == 0 || dateOfBirth.Length == 0 || gender.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            userInfo.Gender = int.Parse(gender);
            userInfo.Date_Of_Birth = Convert.ToDateTime(dateOfBirth);

            try
            {
                String connectionString = "Server=tcp:mstarttaskserver.database.windows.net,1433;Initial Catalog=mstartTaskDB;Persist Security Info=False;User ID=EsraaM;Password=Esraa.1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Users" +
                        "(Email, Username, First_Name, Last_Name, Gender, Date_Of_Birth, DateTime_UTC, Update_DateTime_UTC, Server_DateTime, Status) VALUES " +
                        "(@Email, @Username, @First_Name, @Last_Name, @Gender, @Date_Of_Birth, @DateTime_UTC, @Update_DateTime_UTC, @Server_DateTime, @Status);";

                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Email", userInfo.Email);
                        sqlCommand.Parameters.AddWithValue("@Username", userInfo.Username);
                        sqlCommand.Parameters.AddWithValue("@First_Name", userInfo.First_Name);
                        sqlCommand.Parameters.AddWithValue("@Last_Name", userInfo.Last_Name);
                        sqlCommand.Parameters.AddWithValue("@Gender", userInfo.Gender);
                        sqlCommand.Parameters.AddWithValue("@Date_Of_Birth", userInfo.Date_Of_Birth);
                        sqlCommand.Parameters.AddWithValue("@DateTime_UTC", userInfo.DateTime_UTC);
                        sqlCommand.Parameters.AddWithValue("@Update_DateTime_UTC", userInfo.Update_DateTime_UTC);
                        sqlCommand.Parameters.AddWithValue("@Server_DateTime", userInfo.Server_DateTime);
                        sqlCommand.Parameters.AddWithValue("@Status", userInfo.Status);


                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            userInfo.Email = "";
            userInfo.Username = "";
            userInfo.First_Name = "";
            userInfo.Last_Name = "";
            userInfo.Gender = 0;
            userInfo.Date_Of_Birth = DateTime.Now;
            userInfo.DateTime_UTC = DateTime.Now;
            userInfo.Update_DateTime_UTC = DateTime.Now;
            userInfo.Server_DateTime = DateTime.Now;

            successMessage = "New user added correctly";

            Response.Redirect("/Users/Index");
        }
    }
}
