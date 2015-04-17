<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Contact</h1>

    <asp:Literal runat="server" ID="litWarning" />
    <div class="col-sm-6">
        <div class="form-group">
            <asp:TextBox runat="server" ID="txtTitel" CssClass="form-control" placeholder="Title.." />
        </div>
        <div class="form-group">

            <asp:TextBox runat="server" ID="txtSender" CssClass="form-control" placeholder="Your Email.." TextMode="Email" />
        </div>

        <div class="form-group">

            <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" CssClass="form-control" placeholder="Your message.." Height="200" />
        </div>

        <div class="form-group">

            <asp:Button runat="server" ID="btnSubmitMail" Text="Submit Mail" OnClick="btnSubmitMail_OnClick" CssClass="btn btn-block" />
        </div>
    </div>
    <div class="col-sm-6">
        <asp:Literal runat="server" ID="litGoogleMapEmbed"/>
    </div>
</asp:Content>

