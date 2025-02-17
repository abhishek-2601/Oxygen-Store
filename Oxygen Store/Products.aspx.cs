﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Oxygen_Store
{
    public partial class Products : System.Web.UI.Page
    {
        ConClss ob = new ConClss();
        int _quantity = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            int p_id = Convert.ToInt32(Session["P_id"]);
            string _getPrdct = "select * from product where Product_id=" + p_id + "";
            SqlDataReader dr = ob.Fun_Reader(_getPrdct);
            while (dr.Read())
            {
                Image1.ImageUrl = dr["Product_Photo"].ToString();
                Label2.Text = dr["Product_Name"].ToString();
                Label4.Text = dr["Product_Details"].ToString();
                Label3.Text = dr["Product_Price"].ToString() + "/-";
                if (dr["Product_Stock"].ToString() != "0")
                {
                    Label5.Text = "Only " + dr["Product_Stock"].ToString() + " Available";
                }
                else
                {
                    Label5.Text = "Out of Stock";
                    Label5.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int p_id = Convert.ToInt32(Session["P_id"]);
            string _getProductprice = "select Product_Price from product where Product_id=" + p_id + "";
            int product_price = Convert.ToInt32(ob.Fun_Scalar(_getProductprice));

            string sel = "select max(Cart_id) from Carts";
            string C_id = ob.Fun_Scalar(sel);
            int Cart_id = 0;
            if (C_id == "")
            {
                Cart_id = 0;
            }
            else
            {
                int NewCart_id = Convert.ToInt32(C_id);
                Cart_id = NewCart_id + 1;
            }
            int _quantity = Convert.ToInt32(TextBox1.Text);
            int _totalPrice = _quantity * product_price;
            string _addtoCart = "insert into Carts values(" + Cart_id + "," + _quantity + ",'" + _totalPrice + "','active','" + Session["user_id"] + "'," + p_id + ")";
            int i = ob.Fun_NonQuery(_addtoCart);
            if (i == 1)
            {
                Button2.Visible = true;
                Button1.Enabled = false;
                Button1.Text = "Added to Cart";
                Button1.BackColor = System.Drawing.Color.Gray;

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(TextBox1.Text) + 1;
            TextBox1.Text = quantity.ToString();
            _quantity = Convert.ToInt32(TextBox1.Text);

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(TextBox1.Text) - 1;
            TextBox1.Text = quantity.ToString();
            _quantity = Convert.ToInt32(TextBox1.Text);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}
    