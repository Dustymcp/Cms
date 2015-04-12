<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Backend_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-lg-4 well">
        <h2 class="text-center">User Control</h2>
        <asp:Literal ID="litWarning" runat="server" />
        <div class="form-group">
            <label for="txtUserName">Username</label>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control focus" placeholder="Enter username.." TabIndex="1" />
        </div>
        <asp:Panel ID="pnlPassword" runat="server">
            <div class="form-group">
                <label for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter password.." TabIndex="2" />
            </div>
        </asp:Panel>

        <div class="form-group">
            <label for="ddlUserLevel">Choose account type</label>
            <asp:DropDownList ID="ddlUserLevel" runat="server" CssClass="form-control dropdown" TabIndex="3">
                <asp:ListItem Text="Admin" Value="1" />
                <asp:ListItem Text="User" Value="2" />
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="txtFirstName">First name</label>
            <asp:TextBox ID="txtFirstName" runat="server" placeholder="Enter users first name.." CssClass="form-control" TabIndex="4" />
        </div>
        <div class="form-group">
            <label for="txtLastName">Last name</label>
            <asp:TextBox ID="txtLastName" runat="server" placeholder="Enter users last name.." CssClass="form-control" TabIndex="5" />
        </div>
        <div class="form-group">
            <label for="txtStreetAdress">Street adress</label>
            <asp:TextBox ID="txtStreetAdress" runat="server" placeholder="Enter users street adress" CssClass="form-control" TabIndex="6" />
        </div>
        <div class="form-group">
            <label for="txtStreetnumber">Adress nr.</label>
            <asp:TextBox ID="txtStreetnumber" runat="server" TextMode="Number" Text="0" CssClass="form-control" TabIndex="7" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnEditUser" runat="server" Text="Edit User" OnClick="btnEditUser_Click" CssClass="form-control" TabIndex="8" Visible="false" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="form-control" TabIndex="9" Visible="false" OnClick="btnBack_Click" />

            <asp:Button ID="btnSubmitUser" runat="server" Text="Insert User" OnClick="btnSubmitUser_Click" CssClass="form-control" TabIndex="8" />
        </div>
    </div>
    <div class="col-lg-1">&nbsp</div>
    <div class="col-lg-7 well">
        <h2 class="text-center">Overview</h2>
        <asp:Repeater ID="rpt" runat="server">
            <HeaderTemplate>

                <table class="table table-hover table-bordered table-responsive" style="background-color: #ffffff;">
                    <tr>
                        <th><a href="Users.aspx?sortOrder=Id&Skip=0&Take=10">Id</a></th>
                        <th><a href="Users.aspx?sortOrder=UserName&Skip=0&Take=10">Username</a></th>
                        <th>Level</th>
                        <th><a href="Users.aspx?sortOrder=First&Skip=0&Take=10">First name</a></th>
                        <th><a href="Users.aspx?sortOrder=Last&Skip=0&Take=10">Last name</a></th>
                        <th><a href="Users.aspx?sortOrder=Adress&Skip=0&Take=10">Street address</a></th>
                        <th>Street nr.</th>
                        <th>Delete</th>
                        <th>Edit</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>


                <!-- Bind to specific properties i.e. UserName from UserModel.User -->
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLevel" runat="server" Text='<%#UserModel.UserLevelDictionary((int)Eval("UserLevel"))%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStreetAdress" runat="server" Text='<%#Eval("StreetAdress") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStreetNumber" runat="server" Text='<%#Eval("StreetNumber") %>'></asp:Label>
                    </td>
                    <td>
                        <a href="#" onclick="if (confirm('Are you sure you want to delete this user ?')) { window.location.href = 'Users.aspx?Id=<%#Eval("Id") %>&Delete=true&Skip=0&Take=10'}"><span class="glyphicon glyphicon-remove"></span></a>
                    </td>
                    <td>
                        <a href="Users.aspx?Id=<%#Eval("Id") %>&Edit=true&Skip=0&Take=10"><span class="glyphicon glyphicon-edit"></span></a>
                    </td>

                </tr>

            </ItemTemplate>
            <FooterTemplate>
                </table>
            
            </FooterTemplate>
        </asp:Repeater>

        <asp:Button ID="btnLast" runat="server" OnClick="btnLast_Click" Text="Prev" CssClass="btn btn-default" />
        <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next" CssClass="btn btn-default" />

    </div>


</asp:Content>

