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
                //save the new user's data
                string encryptedPassword = Encrypt();
                try
                {
                    string XmlPath = string.Empty;
                    XmlPath = Server.MapPath("~/XMLFiles/") + "UsersInfo.xml";

                    XmlDocument xmlDocument = new XmlDocument();

                    if (!File.Exists(XmlPath))
                    {
                        //create the XML file if it does not exist
                        XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                        XmlElement root = xmlDocument.CreateElement("UsersList");
                        XmlElement parent = xmlDocument.CreateElement("User");
                        XmlAttribute userName = xmlDocument.CreateAttribute("Name");
                        XmlAttribute email = xmlDocument.CreateAttribute("Email");
                        XmlAttribute password = xmlDocument.CreateAttribute("Password");

                        userName.Value = Name.Text.Trim();
                        email.Value = Email.Text.Trim();
                        password.Value = encryptedPassword;

                        xmlDocument.AppendChild(xmlDeclaration);
                        xmlDocument.AppendChild(root);
                        root.AppendChild(parent);
                        parent.Attributes.Append(userName);
                        parent.Attributes.Append(email);
                        parent.Attributes.Append(password);
                        xmlDocument.Save(XmlPath);
                    }
                    else
                    {
                        xmlDocument.Load(XmlPath);
                        XmlElement root = xmlDocument.DocumentElement;

                        //if email id is already registered
                        XmlNodeList nodeList = xmlDocument.SelectNodes("/UsersList/User[@Email='" + Email.Text + "']");
                        if (nodeList.Count > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email is already registered with us! Please Login.'); window.location = 'Index.aspx';", true);
                            return;
                        }

                        XmlElement parent = xmlDocument.CreateElement("User");
                        XmlAttribute userName = xmlDocument.CreateAttribute("Name");
                        XmlAttribute email = xmlDocument.CreateAttribute("Email");
                        XmlAttribute password = xmlDocument.CreateAttribute("Password");

                        userName.Value = Name.Text;
                        email.Value = Email.Text;
                        password.Value = encryptedPassword;

                        root.AppendChild(parent);
                        parent.Attributes.Append(userName);
                        parent.Attributes.Append(email);
                        parent.Attributes.Append(password);
                        xmlDocument.Save(XmlPath);
                    }
                    Response.Redirect("RegistrationSuccess.aspx");
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('We're sorry, please try again after some time')", true);
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
            string password = Password.Text.Trim();
            string encrypted = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            encrypted = Convert.ToBase64String(encode);
            return encrypted;
        }
    }
}