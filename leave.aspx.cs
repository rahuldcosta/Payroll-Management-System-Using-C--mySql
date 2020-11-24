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


public partial class leave : System.Web.UI.Page
{
    string strcon = WebConfigurationManager.ConnectionStrings["PayrollConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            MultiView1.SetActiveView(View1);
            Panel1.Visible = false;
            Label2.Visible = false;
            DropDownList1.Items.Clear();
            DropDownList4.Items.Clear();

            for (int i = DateTime.Now.Year; i >= 1990; i--)
            {
                DropDownList1.Items.Add(i.ToString());
                DropDownList4.Items.Add(i.ToString());
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View3);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        String sql;

        sql = "insert into leave values(@Employee_id,@paid,@Date)";
        cmd = new SqlCommand(sql, con);

        con.Open();
        //cmd.Parameters.AddWithValue("@reciptno", recipt0.Text);
        cmd.Parameters.AddWithValue("@Employee_id", TextBox1.Text);
        cmd.Parameters.AddWithValue("@Date", DropDownList1.Text);
        cmd.Parameters.AddWithValue("@paid", TextBox2.Text);
        

        try
        {
            cmd.ExecuteNonQuery();
            Label2.Text = "Insertion Successful";
            TextBox1.Text = TextBox2.Text = ""; 
            con.Close();
            
        }
        catch (SqlException ex)
        {

            Label2.Text = ex.Message.ToString();



        }
        MultiView1.SetActiveView(View1);
        Label2.Visible = true;


    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        TextBox1.Text = TextBox2.Text = "";
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        Label2.Visible = false;
    }
}
