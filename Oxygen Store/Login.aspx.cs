using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Oxygen_Store
{
    public partial class Login : System.Web.UI.Page
    {
        ConClss ob = new ConClss();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(User_id) from Log where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            string cid = ob.Fun_Scalar(str);
            int _cid = Convert.ToInt32(cid);
            if (_cid == 1)
            {
                string getId = "select User_id from Log where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string user_id = ob.Fun_Scalar(getId);
                Session["user_id"] = user_id;
                string getLogType = "select User_Type from Log where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string Log_Type = ob.Fun_Scalar(getLogType);
                if (Log_Type == "admin")
                {
                    Response.Redirect("Admin_Profile.aspx");
                }
                else if (Log_Type == "user")
                {
                    Response.Redirect("Profile.aspx");
                }
            }
            else
            {
                Label3.Visible = true;
                Label3.Text = "Invalid user";
            }
        }
    }
}