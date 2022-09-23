﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace PenDown
{
    public partial class Index : System.Web.UI.Page
    {
        string strConn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] != null)
            {
                //destroying the last session
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Logged out successfully!'); Session.Abandon();", true);
            }
        }
        
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = string.Empty;
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();
            string isValid = IsValidCredentials();
            if (isValid == "true")
            {
                SqlConnection conn = new SqlConnection(strConn);
                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    //check if email is not registered
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[user] WHERE email='" + email + "'", conn);
                    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (temp == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No such user exists. Register first.'); window.location = 'Register.aspx';", true);
                        return;
                    }
                    else
                    {
                        SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [dbo].[user] WHERE email='" + email + "'", conn);
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            username = reader["user_name"].ToString();
                            string correctPassword = Decrypt(reader["password"].ToString());
                            //if password does not match
                            if (!string.Equals(correctPassword, password))
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Incorrect password')", true);
                                return;
                            }
                            else
                            {
                                //else redirect to Welcome page
                                Session["Username"] = username;
                                Response.Redirect("LoginSuccess.aspx");
                            }
                        }
                    }
                }
                catch (Exception ex)
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
                //show appropriate alert
                string alertMessage = "alert('" + isValid + "')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", alertMessage, true);
            }
        }

        protected string IsValidCredentials()
        {
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();

            //email and password cannot be blank
            if (string.IsNullOrEmpty(email))
                return "Email cannot be blank!";
            if (string.IsNullOrEmpty(password))
                return "Password cannot be blank!";

            //Email pattern validation
            string emailRegex = @"^(?=.{1,64}@)[A-Za-z0-9_-]+(\\.[A-Za-z0-9_-]+)*@"
                                    + "[^-][A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z]{2,})$";
            Regex regex = new Regex(emailRegex);
            if (!regex.IsMatch(email))
                return "Provide a valid email id!";

            //Password pattern validation
            string passwordRegex = @"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$";
            Regex regex2 = new Regex(passwordRegex);
            if (!regex2.IsMatch(password))
                return "Invalid Password Format: Password must be 8-20 characters long with allowed characters - a-z, A-Z, 0-9, ., _";

            return "true";
        }

        protected string Decrypt(string encrypted)
        {
            string decrypted = string.Empty;
            UTF8Encoding utf8 = new UTF8Encoding();
            Decoder decoder = utf8.GetDecoder();
            byte[] toDecodeByte = Convert.FromBase64String(encrypted);
            int charCount = decoder.GetCharCount(toDecodeByte,0,toDecodeByte.Length);
            char[] decodedChar = new char[charCount];
            decoder.GetChars(toDecodeByte,0,toDecodeByte.Length,decodedChar,0);
            decrypted = new string(decodedChar);
            return decrypted;
        }
    }
}