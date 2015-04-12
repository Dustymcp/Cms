<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="Pages.aspx.cs" Inherits="Pages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="list-group">
        <li class="list-group-item list-group-item-heading">
            <h1>
                <asp:Literal runat="server" ID="litTitle" />
            </h1>
        </li>
        <li class="list-group-item">
            <h3 class="text-cursive">Category:
                <asp:Literal runat="server" ID="litCategory" />
            </h3>
        </li>
        <li class="list-group-item">Posted by 
        <asp:Literal runat="server" ID="litCreator" />
        </li>
        <li class="list-group-item">
            <asp:Literal runat="server" ID="litCreated" />
        </li>
        <li class="list-group-item" style="min-height: 200px;">
            <asp:Literal runat="server" ID="litContent" />
        </li>
    </ul>
</asp:Content>

