using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Authenticatiion_30626
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source=LAPTOP-N40D0KFL;initial catalog=db_auth30626;integrated security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGender();
                BindHobbies();
                BindCountry();
                if (Request.QueryString["idd"] != null && Request.QueryString["idd"] != "")
                {
                    SqlCommand cmd = new SqlCommand("SP_USERS", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action","edit");
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["idd"]);
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    conn.Close();
                    txtname.Text = dt.Rows[0]["uname"].ToString();
                    txtemail.Text = dt.Rows[0]["uemail"].ToString();
                    txtpwd.Text = dt.Rows[0]["upassword"].ToString();
                    string date = Convert.ToDateTime(dt.Rows[0]["udob"]).ToString("MM/dd/yyyy").ToString();
                    txtdob.Text = date;
                    ddlcountry.SelectedValue = dt.Rows[0]["ucountry"].ToString();
                    BindStates();
                    ddlstate.SelectedValue = dt.Rows[0]["ustate"].ToString();
                    BindCities();
                    ddlcity.SelectedValue = dt.Rows[0]["ucity"].ToString();
                    rblgender.SelectedValue = dt.Rows[0]["ugender"].ToString();
                    string[] hobbies = dt.Rows[0]["uhobbies"].ToString().Split(',');
                    for(int i=0; i < cblhobbies.Items.Count; i++)
                    {
                        for(int j=0; j < hobbies.Length; j++)
                        {
                            if (cblhobbies.Items[i].Text == hobbies[j].ToString())
                            {
                                cblhobbies.Items [i].Selected = true;
                            }
                        }
                    }
                    ViewState["prev_image"] = dt.Rows[0]["uimage"].ToString();
                    btn_register.Text = "Update";


                }
            }
            
        }

        public void BindGender()
        {
            SqlCommand cmd = new SqlCommand("SP_USERS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "gender");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            rblgender.DataTextField = "genderName";
            rblgender.DataValueField = "genderId";
            rblgender.DataSource = dt;
            rblgender.DataBind();
        }
        public void BindHobbies()
        {
            SqlCommand cmd = new SqlCommand("SP_USERS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "hobby");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            cblhobbies.DataTextField = "hobbyName";
            cblhobbies.DataValueField = "hobbyId";
            cblhobbies.DataSource = dt;
            cblhobbies.DataBind();
        }
        public void BindCountry()
        {
            SqlCommand cmd = new SqlCommand("SP_USERS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "country");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            ddlcountry.DataTextField = "countryName";
            ddlcountry.DataValueField = "countryId";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--SELECT--", "0"));
            ddlstate.Items.Insert(0, new ListItem("--SELECT--", "0"));
            ddlcity.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }
        public void BindStates()
        {
            SqlCommand cmd = new SqlCommand("SP_USERS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "state");
            cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            ddlstate.DataTextField = "stateName";
            ddlstate.DataValueField = "stateId";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }
        public void BindCities()
        {
            SqlCommand cmd = new SqlCommand("SP_USERS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "city");
            cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            ddlcity.DataTextField = "cityName";
            ddlcity.DataValueField = "cityId";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--SELECT--", "0"));
        }
        public void ClearData()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtpwd.Text = "";
            txtdob.Text = "";
            ddlcountry.SelectedIndex= 0;
            ddlstate.SelectedIndex= 0;
            ddlcity.SelectedIndex= 0;
            rblgender.ClearSelection();
            cblhobbies.ClearSelection();
            btn_register.Text = "Register";
        }
        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStates();
            BindCities();
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCities();
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            //login to combine hobbies
            string hobbies="";
            for(int i = 0; i < cblhobbies.Items.Count; i++)
            {
                if (cblhobbies.Items[i].Selected == true)
                {
                    hobbies += cblhobbies.Items[i].Text + ",";
                }
            }

            hobbies = hobbies.TrimEnd(',');

            //logic to add image
            string imageName = DateTime.Now.Ticks.ToString() + Path.GetFileName(fuimage.PostedFile.FileName);


            
            if (btn_register.Text == "Register")
            {
                SqlCommand cmd = new SqlCommand("SP_USERS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@password", txtpwd.Text);
                cmd.Parameters.AddWithValue("@dob", txtdob.Text);
                cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@hobbies", hobbies);
                cmd.Parameters.AddWithValue("@image", imageName);


                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                if(result == 1)
                {
                    fuimage.SaveAs(Server.MapPath("~/Images/" + imageName));
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "popupmsg",
                        "showPopup('User registered successfully. ','green');",
                        true
                    );
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "redirectDelay",
                        "setTimeout(function(){ window.location.href='LoginForm.aspx'; }, 4000);",
                        true
                    );
                }
            }else if (btn_register.Text == "Update")
            {

                SqlCommand cmd = new SqlCommand("SP_USERS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action","update");
                cmd.Parameters.AddWithValue("@id", Request.QueryString["idd"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@password", txtpwd.Text);
                cmd.Parameters.AddWithValue("@dob", txtdob.Text);
                cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@hobbies", hobbies);
                cmd.Parameters.AddWithValue("@image", fuimage.PostedFile.FileName != "" ? imageName : ViewState["prev_image"]);


                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if(fuimage.PostedFile.FileName!="" && fuimage.PostedFile.FileName != null)
                {
                    File.Delete(Server.MapPath("~/Images/" + ViewState["prev_image"]));
                    fuimage.SaveAs(Server.MapPath("~/Images/" + imageName));
                }
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "popupmsg",
                        "showPopup('User Updated successfully. ','green');",
                        true
                    );
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "redirectDelay",
                        "setTimeout(function(){ window.location.href='LoginForm.aspx'; }, 4000);",
                        true
                    );
                }
            }
                ClearData();
        }
    }
}