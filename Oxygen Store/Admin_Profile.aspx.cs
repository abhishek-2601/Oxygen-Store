using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Oxygen_Store
{
    public partial class Admin_Profile : System.Web.UI.Page
    {
        ConClss ob = new ConClss();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["user_id"]);
            string getData = "select Adm_Name from admin where Adm_id=" + id + "";
            SqlDataReader dr = ob.Fun_Reader(getData);
            while (dr.Read())
            {
                Label1.Text = "Welcome " + dr["Adm_Name"].ToString();
            }
        }
    }
}