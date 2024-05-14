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
    public partial class Users : System.Web.UI.Page
    {
        ConClss ob = new ConClss();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["user_id"]);
            string getUsers = "Select * from users";
            DataSet ds = ob.Fun_Adapter(getUsers);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}