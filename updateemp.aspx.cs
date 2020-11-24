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

public partial class updateemp : System.Web.UI.Page
{
     string strcon = WebConfigurationManager.ConnectionStrings["PayrollConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }
        Panel1.Visible = false;
        DropDownList3.Visible = true;
        DropDownList4.Visible = true;
        Label7.Visible = true;
        Label2.Visible = true;
        Label3.Text = "";
        Button3.Visible = true;
        
    }
    protected void Button3_Click(object sender, EventArgs e)  //submit click
    {
        SqlConnection con = new SqlConnection(strcon);
        int r;
        SqlCommand cmd;
       
        SqlDataReader read;
        String sql = "Select * from Employee where Employee_id=@eeud";
        cmd = new SqlCommand(sql, con);

        r = int.Parse(DropDownList3.Text.ToString().Trim());
        cmd.Parameters.AddWithValue("@eeud", r);
        con.Open();
        read = cmd.ExecuteReader();

        if (read.Read())
        {
            Label5.Text = read["Employee_id"].ToString();
            ename.Text = read["Name"].ToString();
            TextBox2.Text = read["Lastname"].ToString();
            // Dob.Text=read["DOB"].ToString();
                 genRadioButtonList.Text=read["Gender"].ToString();
                    pin.Text=read[ "Pincode"].ToString();
                         addrtxtbox.Text=read["Address"].ToString();
                         DropDownList2.SelectedValue = read["deptid"].ToString();
                         //DropDownList1.SelectedValue = read["bid"].ToString();
                        // DropDownList2.SelectedIndex = DropDownList2.Items.IndexOf(DropDownList2.Items.FindByValue("2"));
                        // DDL.SelectedIndex = DDL.Items.IndexOf(DDL.Items.FindByText("PassedValue"));
                             state.Text=read["State"].ToString();
                                 contactno.Text=read["Contact_No"].ToString();
                                     designation.Text=read["Designation"].ToString();
                                    
                                                 etypeRadioButtonList1.Text=read["Employee_Type"].ToString();
                                                 TextBox1.Text = read["BasicSal"].ToString();
            read.Close();
            con.Close();
        }
        
        Panel1.Visible = true;
        DropDownList3.Visible = false;
        DropDownList4.Visible = false;
        Label7.Visible = false;
        Label2.Visible = false;
        Button3.Visible = false;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button4_Click(object sender, EventArgs e)   //update to DB
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        String sql;
        sql = "update Employee set Employee_id=@eid,Name=@nam,Lastname=@ln,Gender=@gen,Pincode=@pin,Address=@add,State=@st,Contact_No=@no,Designation=@des,deptid=@deptno,Employee_Type=@etype,bid=@b_id,BasicSal=@BS  where Employee_id=@eid";
        
        
        cmd = new SqlCommand(sql, con);
        
        cmd.Parameters.AddWithValue("@eid", Label5.Text);
        cmd.Parameters.AddWithValue("@nam", ename.Text);
        cmd.Parameters.AddWithValue("@ln", TextBox2.Text);
       cmd.Parameters.AddWithValue("@gen", genRadioButtonList.Text);
        cmd.Parameters.AddWithValue("@pin", Convert.ToInt32(pin.Text));
        cmd.Parameters.AddWithValue("@st", state.Text);
        cmd.Parameters.AddWithValue("@no", contactno.Text);
        cmd.Parameters.AddWithValue("@des", designation.Text);
        cmd.Parameters.AddWithValue("@deptno", DropDownList2.Text);       
        cmd.Parameters.AddWithValue("@etype", etypeRadioButtonList1.Text);
        cmd.Parameters.AddWithValue("@add", addrtxtbox.Text);
        cmd.Parameters.AddWithValue("@b_id", DropDownList1.Text);
        cmd.Parameters.AddWithValue("@BS", TextBox1.Text);
        con.Open();
      
        try
        {
            cmd.ExecuteNonQuery();
             Label3.Text = "Update Successfully";
             

            con.Close();
        }
        catch (SqlException ex)
        {
            Label3.Text = ex.Message.ToString();
        }
        Session["label3"] = Label3.Text;

        Panel1.Visible = false;
        DropDownList3.Visible = true;
        DropDownList4.Visible = true;
        Label7.Visible = true;
        Label2.Visible = true;
        Button3.Visible = true;
        Response.Redirect("~/Employee.aspx");
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
