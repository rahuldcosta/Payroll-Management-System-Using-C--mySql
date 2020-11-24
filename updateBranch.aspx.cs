using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class updateBranch : System.Web.UI.Page
{
    string strcon = WebConfigurationManager.ConnectionStrings["PayrollConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }
        MultiView1.ActiveViewIndex = 0;
        Label2.Visible = false;
    }
    protected void upbr_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        String sql;
        sql = "update  branches set bname=@name,location=@loc,contact=@no,cname=@cn,State=@st where bid=@id";
        cmd = new SqlCommand(sql, con);
        con.Open();
        cmd.Parameters.AddWithValue("@id", Label4.Text);
        cmd.Parameters.AddWithValue("@name", addrtxt.Text);
        cmd.Parameters.AddWithValue("@loc", RadioButtonList1.Text);
        cmd.Parameters.AddWithValue("@no", contacttxt.Text);
        cmd.Parameters.AddWithValue("@cn", cnametxt.Text);
        cmd.Parameters.AddWithValue("@st", statetxt.Text);

        Label2.Visible = true;
        try
        {
            cmd.ExecuteNonQuery();
            Label2.Text = "Update Successful";
            Label4.Text = addrtxt.Text = RadioButtonList1.Text = contacttxt.Text = cnametxt.Text = statetxt.Text = "";
            con.Close();
            
        }
        catch (SqlException ex)
        {

            Label2.Text = ex.Message.ToString();



        }
        Label2.Visible = true;
        MultiView1.ActiveViewIndex = 0;
        Session["out"] = Label2.Text;
        Response.Redirect("~/Branchview.aspx");
    }
   
    protected void Button7_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        SqlConnection con = new SqlConnection(strcon);
        int r;
        SqlCommand cmd;

        SqlDataReader read;
        String sql = "Select * from branches where bid=@eeud";
        cmd = new SqlCommand(sql, con);
        r = int.Parse(DropDownList1.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@eeud", r);
        con.Open();
        read = cmd.ExecuteReader();

        if (read.Read())
        {
            Label4.Text = read["bid"].ToString();
            addrtxt.Text = read["bname"].ToString();
            RadioButtonList1.Text = read["location"].ToString();
            contacttxt.Text = read["contact"].ToString();

            cnametxt.Text = read["cname"].ToString();
            statetxt.Text = read["State"].ToString();


            read.Close();
            con.Close();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
