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

public partial class Branchview : System.Web.UI.Page
{
    string strcon = WebConfigurationManager.ConnectionStrings["PayrollConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }
        if (Session["out"] != null)
        {
            Label4.Text = " " + Session["out"];
        }
        else
        {
            Label4.Text = "NULL";
        }
        
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        Label3.Visible = false;
        Label4.Visible = false;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Label3.Visible = true;
        
      //  MultiView1.ActiveViewIndex = 1;
   
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        String sql;
        sql = "delete from branches where bid=@id";

        cmd = new SqlCommand(sql, con);
        int r;
        r = Convert.ToInt32(idtxtbox.SelectedValue);

        cmd.Parameters.AddWithValue("@id", r);
        con.Open();

        try
        {
            cmd.ExecuteNonQuery();

            Label3.Text = "Deletion Successful";
            con.Close();
        }
        catch (SqlException ex)
        {
            Label3.Text = ex.Message.ToString();
        }
      //  idtxtbox.Text = "";
        //idtxtbox.bind;
       // idtxtbox.DataSource = SqlDataSource3;
        idtxtbox.DataBind();
        //If you only want to show one grid at a time
        idtxtbox.DataSource = null;
        idtxtbox.DataBind();

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Label4.Visible = false;

    }
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void idtxtbox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
