using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Authenticatiion_30626
{
    public partial class LoginForm : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source=LAPTOP-N40D0KFL;initial catalog=db_auth30626;integrated security=true;");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("loginUser",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            if(dt.Rows.Count == 0)
            {
                
                ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "popupmsg",
                        "showPopup('email or password is incorrect!','red');",
                        true
                 );
            }
            else
            {
                Session["id"]=dt.Rows[0]["uid"];
                Response.Redirect("Home.aspx");
            }
        }
    }
}