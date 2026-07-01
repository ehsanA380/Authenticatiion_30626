using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Authenticatiion_30626
{

    public partial class Home : System.Web.UI.Page
    {
         SqlConnection conn = new SqlConnection("data source=LAPTOP-N40D0KFL;initial catalog=db_auth30626;integrated security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                if (!IsPostBack)
                {
                    BindUser();
                }
            }
            else
            {
                Response.Redirect("LoginForm.aspx");
            }
        }

        public void BindUser()
        {
            SqlCommand cmd = new SqlCommand("bindUser",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Session["id"]);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            gv_user.DataSource = dt;
            gv_user.DataBind();
        }

        protected void gv_user_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] abc = e.CommandArgument.ToString().Split(',');
            if (e.CommandName == "delete_row")
            {
                SqlCommand cmd = new SqlCommand("deleteUser", conn);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", abc[0] );
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                BindUser();
                File.Delete(Server.MapPath("~/Images/" + abc[1]));
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "popupmsg",
                    "showPopup('User deleted successfully!','green');",
                    true
                );
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "redirectDelay",
                    "setTimeout(function(){ window.location.href='LoginForm.aspx'; }, 4000);",
                    true
                );
                

            }else if(e.CommandName == "edit_row")
            {
                Response.Redirect("RegisterForm.aspx?idd=" + e.CommandArgument);
            }
        }
    }
}