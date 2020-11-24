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

public partial class Payslip : System.Web.UI.Page
{
    string strcon = WebConfigurationManager.ConnectionStrings["PayrollConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }
        MultiView1.SetActiveView(View1);
        if (!IsPostBack)
        {
            //hratxt1.Text = bonustxt1.Text = incenttxt1.Text = pftxt1.Text = datxt1.Text = mdtxt1.Text = unpltxt1.Text = npltxt1.Text = presnttxt1.Text = "";
            ddlYear.Items.Clear();
            

            for (int i = DateTime.Now.Year; i >= 1990; i--)
            {
                ddlYear.Items.Add(i.ToString());
                
            }
            ddlMonth.Items.Clear();
           
            ListItem lt = new ListItem();

            for (int i = 1; i <= 12; i++)
            {
                lt = new ListItem();
                lt.Text = Convert.ToDateTime(i.ToString() + "/1/1900").ToString("MMMM");
                lt.Value = i.ToString();
                ddlMonth.Items.Add(lt);
               

            }
        }

       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button6_Click(object sender, EventArgs e)   //Apply Selection of Empid and date
    {
        MultiView1.SetActiveView(View2);

        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd;
       
        String Mon = Convert.ToDateTime(ddlMonth.Text.ToString() + "/1/1900").ToString("MMMM");
        String Dater = Mon + " " + ddlYear.Text;

        SqlDataReader read;
        String sql = "SELECT  Employee.Employee_id, Employee.Name,Employee.Employee_Type, Employee.Designation, DEPT.dname, Employee.BasicSal, salary.reciptno, salary.hra, salary.bonus, salary.incentive, salary.da, salary.med, salary.nopaid, salary.paid, salary.Date FROM   DEPT INNER JOIN Employee ON DEPT.deptid = Employee.deptid INNER JOIN salary ON Employee.Employee_id = salary.Employee_id where Employee.Employee_id=@eid AND salary.Date=@dt";
        
        cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@dt", Dater);
        cmd.Parameters.AddWithValue("@eid", DropDownList4.Text);


        Label20.Text = Dater.ToString();
        con.Open();
        read = cmd.ExecuteReader();

        if (read.Read())
        {
            Label2.Text = read["Name"].ToString();
            Label3.Text = read["Employee_id"].ToString();
            Label13.Text = read["reciptno"].ToString();
            Label14.Text = read["dname"].ToString();
            Label15.Text = read["Designation"].ToString();
            Label21.Text = read["Employee_Type"].ToString();
           
            decimal y = (decimal)read["BasicSal"];
            decimal x, hra;
            Label4.Text = y.ToString("#.##");
            if (read["hra"].ToString() != "0")
            {
                x = Convert.ToInt32(read["hra"].ToString());

                 hra = (x / 100m) * y;
                Label5.Text = hra.ToString("#.##");
            }
            else
            {
                Label5.Text="0";
            }
            Label6.Text = read["med"].ToString();
            if (read["da"].ToString() != "0")
            {
                x = Convert.ToInt32(read["da"].ToString());

                hra = (x / 100m) * y;

                Label7.Text = hra.ToString("#.##");
            }
            else
            {
                Label7.Text = "0";
            }

            Label8.Text = read["bonus"].ToString();
            Label9.Text = read["incentive"].ToString();

            int m = Convert.ToInt32(read["paid"].ToString());
            //Label19.Text = m.ToString();
            if (m < 3)
            {
                if (m == 2)
                { Label19.Text = "0.00"; }
                else if (m == 1)
                {
                    decimal p = (y / 30m);
                    Label19.Text = p.ToString("#.##");
                }
                else
                {
                    decimal p = (y / 30m) * 2m;
                    Label19.Text = p.ToString("#.##");
                }
            }
            else
            {
                Label19.Text = "0.00";
            }
            decimal total = y + decimal.Parse(Label5.Text.ToString()) + decimal.Parse(Label7.Text.ToString()) + decimal.Parse(Label6.Text.ToString()) + decimal.Parse(Label8.Text.ToString()) + decimal.Parse(Label9.Text.ToString());
            Label10.Text = total.ToString("#.##");   //total allowances


            decimal pf = (y * (12m / 100m)) + decimal.Parse(Label7.Text.ToString());
            lblpf.Text = pf.ToString("#.##");

            decimal unpai= (y /30m) * decimal.Parse(read["nopaid"].ToString());
            lblunpl.Text = unpai.ToString("#.##");

            decimal utotal = pf + unpai;
            Label11.Text = utotal.ToString("#.##"); //total dedections

            decimal sal = total - utotal;
            Label12.Text = sal.ToString("#.##"); //Net Salary
            read.Close();
            con.Close();
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
    }
}
