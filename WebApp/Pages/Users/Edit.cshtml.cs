using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace WebApp.Pages.Users
{
    public class EditModel : PageModel
    {
        public UserInfo userInfo = new UserInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public String dateOfBirthFormated = "";
        String connectionString = "Server=tcp:mstarttaskserver.database.windows.net,1433;Initial Catalog=mstartTaskDB;Persist Security Info=False;User ID=EsraaM;Password=Esraa.1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public String checkMale = "";
        public String checkFemale = "";
        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "Select * from Users WHERE ID=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userInfo.ID = reader.GetInt32(0);
                                userInfo.Update_DateTime_UTC = reader.GetDateTime(2);
                                userInfo.Username = reader.GetString(4);
                                userInfo.Email = reader.GetString(5);
                                userInfo.First_Name = reader.GetString(6);
                                userInfo.Last_Name = reader.GetString(7);
                                userInfo.Gender = reader.GetInt32(9);
                                userInfo.Date_Of_Birth = reader.GetDateTime(10);
                                dateOfBirthFormated = userInfo.Date_Of_Birth.ToString("yyyy-MM-dd");

                                if(userInfo.Gender == 0)
                                {
                                    checkMale = "checked";
                                } 
                                else
                                {
                                    checkFemale = "checked";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }

        public void OnPost()
        {
            userInfo.ID = int.Parse(Request.Form["id"]);
            userInfo.Email = Request.Form["email"];
            userInfo.Username = Request.Form["username"];
            userInfo.First_Name = Request.Form["first_name"];
            userInfo.Last_Name = Request.Form["last_name"];
            String gender = Request.Form["gender"];
            String dateOfBirth = Request.Form["date_of_birth"];
            userInfo.Update_DateTime_UTC = DateTime.Now;


            if (userInfo.Email.Length == 0 || userInfo.Username.Length == 0 || userInfo.First_Name.Length == 0 || userInfo.Last_Name.Length == 0 || dateOfBirth.Length == 0 || gender.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            userInfo.Gender = int.Parse(gender);
            userInfo.Date_Of_Birth = Convert.ToDateTime(dateOfBirth);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE Users " +
                        "SET Email=@Email, Username=@Username, First_Name=@First_Name, Last_Name=@Last_Name, Gender=@Gender, Date_Of_Birth=@Date_Of_Birth, Update_DateTime_UTC=@Update_DateTime_UTC " +
                        "WHERE ID=@ID";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", userInfo.ID);
                        sqlCommand.Parameters.AddWithValue("@Email", userInfo.Email);
                        sqlCommand.Parameters.AddWithValue("@Username", userInfo.Username);
                        sqlCommand.Parameters.AddWithValue("@First_Name", userInfo.First_Name);
                        sqlCommand.Parameters.AddWithValue("@Last_Name", userInfo.Last_Name);
                        sqlCommand.Parameters.AddWithValue("@Gender", userInfo.Gender);
                        sqlCommand.Parameters.AddWithValue("@Date_Of_Birth", userInfo.Date_Of_Birth);
                        sqlCommand.Parameters.AddWithValue("@Update_DateTime_UTC", userInfo.Update_DateTime_UTC);


                        sqlCommand.ExecuteNonQuery();
                    }
                }

                successMessage = "User updated correctly";

                Response.Redirect("/Users/Index");
            } catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }
    }
}
