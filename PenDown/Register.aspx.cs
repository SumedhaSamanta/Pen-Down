using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;

namespace PenDown
{
    public partial class Register : System.Web.UI.Page
    {
        string strConn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //on clicking Register button
        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string isValid = IsValidRegistration();

            if (isValid == "true")
            {
                string encryptedPassword = Encrypt();
                SqlConnection conn = new SqlConnection(strConn);
                try
                {                    
                    if(conn.State== System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    //check if email is already registered
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[user] WHERE email='"+ Email.Text + "'", conn);
                    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (temp == 1)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email is already registered with us! Please Login.'); window.location = 'Index.aspx';", true);
                        return;
                    }
                    
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO [dbo].[user] (user_name, email, password) VALUES(@username, @email, @password)", conn);
                    sqlCommand.Parameters.AddWithValue("@username", Name.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@email", Email.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@password", encryptedPassword);

                    int rows = sqlCommand.ExecuteNonQuery();
                    Response.Redirect("RegistrationSuccess.aspx");
                }
                catch(Exception ex)
                {
                    string exc = ex.Message;
                    string alertMsg = "alert('We are sorry, please try again after some time. " + exc + "')";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", alertMsg, true);
                    return;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                //show appropriate alert messages
                string alertMessage = "alert('" + isValid + "')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", alertMessage, true);
            }
        }

        //validation check
        protected string IsValidRegistration()
        {
            string name = Name.Text.Trim();
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();
            string confirmPassword = ConfirmPassword.Text.Trim();

            //Name,Email,Password,Confirm Password cannot be blank
            if (string.IsNullOrEmpty(name))
                return "Name cannot be blank!";
            if (string.IsNullOrEmpty(email))
                return "Email cannot be blank!";
            if (string.IsNullOrEmpty(password))
                return "Password cannot be blank!";
            if (string.IsNullOrEmpty(confirmPassword))
                return "Confirm Password cannot be blank";

            //Email pattern validation
            string emailRegex = @"^(?=.{1,64}@)[A-Za-z0-9_-]+(\\.[A-Za-z0-9_-]+)*@"
                                    + "[^-][A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z]{2,})$";
            Regex regex = new Regex(emailRegex);
            if (!regex.IsMatch(email))
                return "Provide a valid email id!";

            //Password & Confirm Password pattern validation
            string passwordRegex = @"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$";
            Regex regex2 = new Regex(passwordRegex);
            if ((!regex2.IsMatch(password)) || (!regex2.IsMatch(confirmPassword)))
                return "Invalid Password Format: Password must be 8-20 characters long with allowed characters - a-z, A-Z, 0-9, ., _";

            //Password & Confirm Password must be same
            if (!string.Equals(password, confirmPassword))
                return "Password and Confirm Password do not match";

            return "true";
        }

        //encrypt password
        protected string Encrypt()
        {
            string password = Password.Text.ToString().Trim();
            string encrypted = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            encrypted = Convert.ToBase64String(encode);
            return encrypted;
        }
    }
}