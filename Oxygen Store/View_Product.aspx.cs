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
    public partial class View_Product : System.Web.UI.Page
    {
        ConClss ob = new ConClss();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Cat_id = Convert.ToInt32(Session["cid"]);
                string _getPrdct = "select * from product where Category_id=" + Cat_id + "";
                DataSet ds = ob.Fun_Adapter(_getPrdct);
                DataList1.DataSource = ds;
                DataList1.DataBind();
                string _itemTextQuery = "select Category_Name from category where Category_id=" + Cat_id + "";
                string _itemText = ob.Fun_Scalar(_itemTextQuery);
                Label1.Text = _itemText + " items";

            }
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            Session["P_id"] = e.CommandArgument;
            int p_id = Convert.ToInt32(Session["P_id"]);
            Response.Redirect("Products.aspx");
        }
    }
}