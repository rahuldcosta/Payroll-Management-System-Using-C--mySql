<%@ Page Language="C#" MasterPageFile="~/page.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        font-size: large;
    }
        .style2
        {
            font-size: large;
            font-weight: bold;
        }
        .style3
        {
            font-size: large;
        }
        .style4
        {
            font-size: large;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="title">
    Welcome to Payroll Managment System</h1>
			&nbsp;<p>
    <b><span class="style4">Payroll Managment System</span><span class="style3"> is a software from RD-J3 software building 
                technologies that makes the work of account department easy by computerizing the 
                entire process of salary desposition.</span><br class="style3" />
        <span class="style3">All the transaction records are kept safe in the databases and the different 
                user interface forms helps the User perform his/her work efficiently</span></b></p>
<p class="style2">
    Breif about the project:</p>
<ol>
    <li class="style2">Keeping track of the Employees and their Salaries</li>
    <li class="style2">Calculating the final in hand salary the employees will get</li>
    <li class="style2">Providing an efficient search mechanism</li>
</ol>
</asp:Content>

