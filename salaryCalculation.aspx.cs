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

public partial class salaryCalculation : System.Web.UI.Page
{
    
    string strcon = WebConfigurationManager.ConnectionStrings["PayrollConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }
        Label8.Visible = false;
        Label7.Visible = false;
      
       
        if (!IsPostBack)
        {
            hratxt1.Text = bonustxt1.Text = incenttxt1.Text = datxt1.Text = mdtxt1.Text = unpltxt1.Text = npltxt1.Text = "";
            ddlYear.Items.Clear();
            ddlYear0.Items.Clear();

            for (int i = DateTime.Now.Year; i >= 1990; i--)
            {
                ddlYear.Items.Add(i.ToString());
                ddlYear0.Items.Add(i.ToString());
            }
            ddlMonth.Items.Clear();
            ddlMonth0.Items.Clear();
            ListItem lt = new ListItem();
           
            for (int i = 1; i <= 12; i++)
            {
                lt = new ListItem();
                lt.Text = Convert.ToDateTime(i.ToString() + "/1/1900").ToString("MMMM");
                lt.Value = i.ToString();
                ddlMonth.Items.Add(lt);
                ddlMonth0.Items.Add(lt);

            }
        }
        
        Label4.Visible = false;
        


    }
    protected void insert_Click(object sender, EventArgs e)   //Insert to DB
    {
        Panel1.Visible = false;
        MultiView1.ActiveViewIndex = 0;

        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        String sql;

        sql = "insert into salary(hra,bonus,incentive,da,med,nopaid,paid,Employee_id,Date) values(@hra,@bonus,@incentive,@da,@med,@nopaid,@paid,@Employee_id,@Date)";
        cmd = new SqlCommand(sql, con);
        String Mon = Convert.ToDateTime(ddlMonth0.Text.ToString() + "/1/1900").ToString("MMMM");
        String Dater = Mon + " " + ddlYear0.Text;
        
        con.Open();
        //cmd.Parameters.AddWithValue("@reciptno", recipt0.Text);
        cmd.Parameters.AddWithValue("@hra", hratxt0.Text);
        cmd.Parameters.AddWithValue("@bonus", bonustxt0.Text);
        cmd.Parameters.AddWithValue("@incentive", incenttxt0.Text);
        
        cmd.Parameters.AddWithValue("@da", datxt0.Text);
        cmd.Parameters.AddWithValue("@med", mdtxt0.Text);
        cmd.Parameters.AddWithValue("@nopaid", unpltxt0.Text);
        cmd.Parameters.AddWithValue("@paid", npltxt0.Text);
        
        cmd.Parameters.AddWithValue("@Employee_id", DropDownList2.Text);
        cmd.Parameters.AddWithValue("@Date", Dater);

        Label4.Visible = true;

        try
        {
            cmd.ExecuteNonQuery();
            Label4.Text = "Insertion Successful";
            hratxt0.Text = bonustxt0.Text = incenttxt0.Text  = datxt0.Text = mdtxt0.Text = unpltxt0.Text = npltxt0.Text = "";
            con.Close();
        }
        catch (SqlException ex)
        {

            Label4.Text = ex.Message.ToString();



        }

    }
    protected void mainInsert_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Panel1.Visible = false;
        mainInsert.Visible = false;
        mainupdate.Visible = false;
        Label7.Visible = true;
        Label7.Text = "Insert values below to be saved";

    }
    protected void mainupdate_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        Label6.Visible = false;
        Label2.Visible = true;
        Label8.Visible = true;
        Label8.Text = "Select the employee to be updated and enter the values below";
        
      

    }
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {

    }
    protected void Button5_Click(object sender, EventArgs e)
    {

      
        MultiView1.SetActiveView(View3);
        mainInsert.Visible = false;
        mainupdate.Visible = false;
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
       
        //MultiView1.ActiveViewIndex = 0;
        hratxt0.Text = bonustxt0.Text = incenttxt0.Text = datxt0.Text = mdtxt0.Text = unpltxt0.Text = npltxt0.Text = "";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View4);
    }
    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Label4.Text = DropDownList2.Text;
    }
    
    protected void updates_Click(object sender, EventArgs e)   //Update to DB
    {

        MultiView1.SetActiveView(View4);
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        String sql;
        String Mon = Convert.ToDateTime(ddlMonth.Text.ToString() + "/1/1900").ToString("MMMM");
        String Dater = Mon + " " + ddlYear.Text;
        sql = "update salary set hra=@hra,bonus=@bonus,incentive=@incentive,da=@da,med=@med,nopaid=@nopaid,paid=@paid  where Employee_id=@eid AND Date=@dt";


        cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@dt", Dater);
        cmd.Parameters.AddWithValue("@eid", DropDownList4.Text);


        cmd.Parameters.AddWithValue("@hra", hratxt1.Text);
        cmd.Parameters.AddWithValue("@bonus", bonustxt1.Text);
        cmd.Parameters.AddWithValue("@incentive", incenttxt1.Text);
      
        cmd.Parameters.AddWithValue("@da", datxt1.Text);
        cmd.Parameters.AddWithValue("@med", mdtxt1.Text);
        cmd.Parameters.AddWithValue("@nopaid", unpltxt1.Text);
        cmd.Parameters.AddWithValue("@paid", npltxt1.Text);
       

        con.Open();
        Label6.Visible = true;
        try
        {
            cmd.ExecuteNonQuery();
            Label6.Text = "Update Successfully";


            con.Close();
            hratxt1.Text = bonustxt1.Text = incenttxt1.Text = datxt1.Text = mdtxt1.Text = unpltxt1.Text = npltxt1.Text = "";
        }
        catch (SqlException ex)
        {
            Label6.Text = ex.Message.ToString();
        }
        



    }


    protected void Button9_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        ddlMonth.Visible = true;
        ddlYear.Visible = true;


        SqlDataReader read;
        String sql = "Select * from Employee e where e.Employee_id=@eid ";
        cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@eid", DropDownList2.Text);
        con.Open();
        read = cmd.ExecuteReader();

        if (read.Read())
        {
            //    Label9.Text = read["Employee_Type"].ToString();
            if (read["Employee_Type"].ToString() == "Temporary")
            {
                hratxt0.Visible = false;
                datxt0.Visible = false;
            }
            else
            {
                hratxt0.Visible = true;
                datxt0.Visible = true;
            }


            read.Close();
            con.Close();
        }
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        SqlDataReader read;
        String sql = "Select * from Employee e where e.Employee_id=@eid ";
        cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@eid", DropDownList4.Text);
        con.Open();
        read = cmd.ExecuteReader();

        if (read.Read())
        {
            //    Label9.Text = read["Employee_Type"].ToString();
            if (read["Employee_Type"].ToString() == "Temporary")
            {
                hratxt1.Visible = false;
                datxt1.Visible = false;
            }
            else
            {
                hratxt1.Visible = true;
                datxt1.Visible = true;
            }


            read.Close();
            con.Close();
        }
        
        
        
        
        Panel2.Visible = true;
        
        ddlMonth.Visible = true;
        ddlYear.Visible = true;
        String Mon = Convert.ToDateTime(ddlMonth.Text.ToString() + "/1/1900").ToString("MMMM");
        String Dater = Mon + " " + ddlYear.Text;

        
         sql = "Select * from salary where Employee_id=@eid AND Date=@dt ";
        cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@dt", Dater);
        cmd.Parameters.AddWithValue("@eid", DropDownList4.Text);
        con.Open();
        read = cmd.ExecuteReader();

        if (read.Read())
        {

            hratxt1.Text = read["hra"].ToString();
            bonustxt1.Text = read["bonus"].ToString();

            incenttxt1.Text = read["incentive"].ToString();

            datxt1.Text = read["da"].ToString();
            mdtxt1.Text = read["med"].ToString();
            unpltxt1.Text = read["nopaid"].ToString();
            npltxt1.Text = read["paid"].ToString();


            read.Close();
            con.Close();
          
        }
    }
}
