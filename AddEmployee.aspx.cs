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

public partial class AddEmployee : System.Web.UI.Page
{
    string strcon = WebConfigurationManager.ConnectionStrings["PayrollConnectionString1"].ConnectionString;
    SqlConnection con;
    String s;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }
        

        s = ConfigurationManager.AppSettings.Get("p");
        if (s != null)
        {
            con = new SqlConnection(s);
            con.Open();
        }
        

    }
    protected void addEmp_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
        String sql;
        sql = "insert into Employee values(@Employee_id,@Name,@Lastname,@DOB,@Gender,@Pincode,@Address,@State,@Contact_No,@Designation,@deptid,@DOJ,@bid,@Employee_Type,@BasicSal)";
        cmd = new SqlCommand(sql, con);
        con.Open();
        cmd.Parameters.AddWithValue("@Employee_id", eid.Text);
        cmd.Parameters.AddWithValue("@Name", ename.Text);
        cmd.Parameters.AddWithValue("@Lastname", TextBox2.Text);
         cmd.Parameters.AddWithValue("@DOB", Dob.Text);
         cmd.Parameters.AddWithValue("@Gender", genRadioButtonList.Text);
         cmd.Parameters.AddWithValue("@Pincode", pin.Text);
         cmd.Parameters.AddWithValue("@Address", addrtxtbox.Text);
         cmd.Parameters.AddWithValue("@State", state.Text);
         cmd.Parameters.AddWithValue("@Contact_No", contactno.Text);
         cmd.Parameters.AddWithValue("@Designation", designation.Text);
         cmd.Parameters.AddWithValue("@deptid", DropDownList2.Text);
         cmd.Parameters.AddWithValue("@DOJ", doj.Text);
         cmd.Parameters.AddWithValue("@Employee_Type", etypeRadioButtonList1.Text);
         cmd.Parameters.AddWithValue("@bid", DropDownList1.Text);
         cmd.Parameters.AddWithValue("@BasicSal", TextBox1.Text);
         
                
       
        try
        {
            cmd.ExecuteNonQuery();
            Label2.Text = "Insertion Successful";
            TextBox2.Text=TextBox1.Text = eid.Text = ename.Text = Dob.Text = genRadioButtonList.Text = pin.Text = addrtxtbox.Text = state.Text = contactno.Text = designation.Text = doj.Text = etypeRadioButtonList1.Text = "";
            con.Close();
        }
        catch (SqlException ex)
        {

            Label2.Text = ex.Message.ToString();



        }
        Session["label3"] = Label2.Text;
        Response.Redirect("~/Employee.aspx");
    }


    protected void Button5_Click(object sender, EventArgs e)
    {

    }
}

