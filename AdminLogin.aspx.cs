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

public partial class AdminLogin : System.Web.UI.Page
{
    private string strcon = WebConfigurationManager.ConnectionStrings["PayrollConnectionString1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private bool UserLogin(string un, string pw)
    {
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd = new SqlCommand("Select username from users where username=@un and password=@pw", con);
        cmd.Parameters.AddWithValue("@un",un);
        cmd.Parameters.AddWithValue("@pw",pw);
        con.Open();
        string result = Convert.ToString(cmd.ExecuteScalar());
        if(String.IsNullOrEmpty(result)) return false; return true;
    }


    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string un = Login1.UserName;
        string pw = Login1.Password;
        bool result = UserLogin(un,pw);
        if (result)
        {
            
            e.Authenticated = true;
            Session["username"] = un;
            Session["out"] = "";
        }
        else e.Authenticated = false;
    }
}
