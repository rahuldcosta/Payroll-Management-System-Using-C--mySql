using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
       // backgroungimageId.src = Page.ResolveUrl("~/Images/PASS.jpg"); 
            Label1.Text = "Welcome " + Session["username"];

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Abandon();

        Response.Redirect("AdminLogin.aspx?mode=logout");
    }
}
