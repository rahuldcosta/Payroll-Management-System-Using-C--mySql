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


public partial class Branches : System.Web.UI.Page
{
    string strcon = WebConfigurationManager.ConnectionStrings["PayrollConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }
        Label2.Visible=false;
        Label3.Text = "Insert data of new branch";
    }
    protected void addbr_Click(object sender, EventArgs e) //Add branch
    {

        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        String sql;
        sql = "insert into branches values(@bid,@bname,@location,@contact,@cname,@State)";
        cmd = new SqlCommand(sql, con);
        con.Open();
        cmd.Parameters.AddWithValue("@bid", idtxtbox.Text);
        cmd.Parameters.AddWithValue("@bname", addrtxt.Text);
        cmd.Parameters.AddWithValue("@location", RadioButtonList1.Text);
        cmd.Parameters.AddWithValue("@contact", contacttxt.Text);
        cmd.Parameters.AddWithValue("@cname", cnametxt.Text);
        cmd.Parameters.AddWithValue("@State", statetxt.Text);

       
        try
        {
            cmd.ExecuteNonQuery();
            Label2.Text = "Insertion Successful";
            idtxtbox.Text = addrtxt.Text = RadioButtonList1.Text = contacttxt.Text = cnametxt.Text = statetxt.Text = "";
            con.Close();
            Label2.Visible = true;
           
        }
        catch (SqlException ex)
        {

           Label2.Text = ex.Message.ToString();



        }
        Session["out"] = Label2.Text;
        Response.Redirect("~/Branchview.aspx");

    }
    protected void Button2_Click(object sender, EventArgs e)   //Discard button
    {

    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}
