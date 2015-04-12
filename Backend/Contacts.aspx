<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="Contacts.aspx.cs" Inherits="Backend_Contacts" %>

<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-5 well">
        <asp:Repeater runat="server" ID="rptMail">
            <HeaderTemplate>


                <h2 class="text-center">Mail Overview</h2>

            </HeaderTemplate>
            <ItemTemplate>
                <div class="list-group">

                    <div class="col-sm-10">
                        <a href="Contacts.aspx?Id=<%#Eval("Id") %>&Read=true" class="list-group-item  <%#Bootstrap.Active(Eval("Watched").ToString())%> <%#Bootstrap.SetFocus(Eval("Id").ToString(), Request.QueryString["Id"]) %>">
                            <%#Bootstrap.Badge("New",Eval("Watched").ToString()) %>

                            <h4 class="list-group-item-heading"><%#Eval("Title") %></h4>
                            <p class="list-group-item-text">
                                <%#Eval("Sender") %> @ <%#Convert.ToDateTime(Eval("Created")).ToString() %>
                            </p>
                        </a>
                    </div>
                    <div class="col-sm-2">
                        <a href="Contacts.aspx?Id=<%#Eval("Id") %>&Delete=true" ><span class="btn btn-default btn-sm glyphicon glyphicon-remove-sign"></span></a>
                        <a href="mailto:<%#Eval("Sender").ToString()%>"><span class="btn btn-default btn-sm glyphicon glyphicon-envelope"></span></a>
                    </div>
                </div>

            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="col-sm-1">&nbsp;</div>
    <asp:Panel ID="pnlReader" runat="server" Visible="False">
        <div class="col-sm-6 well">
            <h2 class="text-center">Reader</h2>
            <div class="list-group">

                <div class="list-group-item">
                    <h4 class="list-group-item-heading">
                    
                        <asp:Literal runat="server" ID="litMailTitle" />
                            </h4>
                     </div>



                    <p class="list-group-item">
                        <span class="glyphicon glyphicon-envelope"></span>
                          
                        <asp:Literal runat="server" ID="litMailSender" />
                        

                    </p>
                    <p class="list-group-item">
                        <span class="glyphicon glyphicon-text-background"></span>
                        
                        <asp:Literal runat="server" ID="litMailContent" />
                    </p>

               
            </div>
        </div>
    </asp:Panel>
</asp:Content>


