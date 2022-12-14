using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _111_1HW5
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection o_conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString
                );
            o_conn.Open();
            SqlDataAdapter o_a = new SqlDataAdapter("select * from Users", o_conn);
            DataSet o_d = new DataSet();
            o_a.Fill(o_d, "ds_Res");
            gd_View.DataSource = o_d;
            gd_View.DataBind();
            o_conn.Close();
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            SqlConnection o_conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString
                );
            SqlDataAdapter o_a = new SqlDataAdapter("select * from Users", o_conn);
            o_conn.Open();

            SqlCommand o_cmd = new SqlCommand("Insert into Users (Name, Birthday) " +
                "values(@Name,@DateTime)", o_conn);
            o_cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
            o_cmd.Parameters["@Name"].Value = "阿貓阿狗";
            o_cmd.Parameters.Add("@DateTime", SqlDbType.DateTime);
            o_cmd.Parameters["@DateTime"].Value = "2000/10/10";
            o_cmd.ExecuteNonQuery();
            Response.Redirect("https://localhost:44393/Test.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            o_conn.Close();
        }
    }
}