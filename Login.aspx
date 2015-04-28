<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-offset-4 col-sm-4">
        <h1 class="text-center">Login</h1>
        <asp:Literal ID="litWarning" runat="server" />
        <div class="form-group">
            <label>Username</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter username.." />
        </div>
        <div class="form-group">
            <label>Password</label>
            <asp:TextBox ID="txtUserpass" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter password.." />
        </div>
        <div class="form-group">
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-block" />
        </div>
    </div>
</asp:Content>

