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
    public partial class ChangePasswordForm : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source=LAPTOP-N40D0KFL;initial catalog=db_auth30626;integrated security=true;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {

            }
            else
            {
                Response.Redirect("LoginForm.aspx");
            }
        }

        protected void btn_cp_Click(object sender, EventArgs e)
        {
            if (txtnewpwd.Text == txtcnfpwd.Text)
            {
                SqlCommand cmd = new SqlCommand("SP_USERS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "updatePassword");
                cmd.Parameters.AddWithValue("@id", Session["id"]);
                cmd.Parameters.AddWithValue("@oldPassword", txtoldpwd.Text);
                cmd.Parameters.AddWithValue("@password", txtnewpwd.Text);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i == 0)
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "popupmsg",
                        "showPopup('Old Password do not match!!','red');",
                        true
                    );
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "popupmsg",
                        "showPopup('Password changed Successfully!','green');",
                        true
                    );
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "popupmsg",
                        "showPopup('Password do not Match!','red');",
                        true
                    );
                
            }
            
        }
    }
}