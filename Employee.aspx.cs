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
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration; 

public partial class Employee : System.Web.UI.Page
{
    string strcon = WebConfigurationManager.ConnectionStrings["PayrollConnectionString1"].ConnectionString;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            Label8.Visible = false;
            Label4.Visible = false;
            TextBox3.Text = "";
           
            

        }
        if (Session["username"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        if (Session["label3"] != null)
        {
            Label10.Text = " " + Session["label3"];
            Label10.Visible = true;
        }
        else
        {
            Label10.Text = "NULL";
        }
        
       
       
    }

    
   
    protected void delEmp_Click(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        MultiView1.ActiveViewIndex = 1;
        Label10.Visible = false;
        Session["label3"] = "";
  
    }
  
    protected void Button2_Click(object sender, EventArgs e)  //serach click
    {
        MultiView1.ActiveViewIndex = 0;
        GridView1.Visible = false;
        Label10.Visible = false;
        Session["label3"] = "";

    }
    protected void Button3_Click(object sender, EventArgs e)  //Submit Button
    {
        Label4.Visible = true;
        GridView1.Visible = true;
       

    }
    protected void addEmp_Click(object sender, EventArgs e)
    {

    }
    protected void upEmp_Click(object sender, EventArgs e)
    {

    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Label8.Visible = true;
        
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        String sql;
        sql = "delete from Employee where Employee_id=@eid";

        cmd = new SqlCommand(sql, con);
        int r;
        r = Convert.ToInt32(TextBox3.Text);

        cmd.Parameters.AddWithValue("@eid", r);
        con.Open();

        try
        {
            cmd.ExecuteNonQuery();
           
            Label8.Text = "Deletion Successful";
            con.Close();
        }
        catch (SqlException ex)
        {
            Label8.Text = "Deletion Failure";
        }
        TextBox3.Text = "";
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        Label4.Visible = false;
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
