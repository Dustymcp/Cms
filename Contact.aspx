<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal runat="server" ID="litWarning"/>
    <asp:TextBox runat="server" ID="txtTitel"></asp:TextBox>
    <asp:TextBox runat="server" ID="txtSender" Text="Your adress"/>
    <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" Height="200"/>
    <asp:Button runat="server" ID="btnSubmitMail" Text="Submit Mail" OnClick="btnSubmitMail_OnClick"/>
</asp:Content>

