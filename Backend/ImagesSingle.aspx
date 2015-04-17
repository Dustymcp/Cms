<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="ImagesSingle.aspx.cs" Inherits="Backend_ImagesSingle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <a href="Images.aspx"><span class="glyphicon glyphicon-menu-left" ></span></a>
    
    <h1>Filename: <asp:Literal runat="server" ID="litImageName"/></h1>
    <asp:Literal runat="server" ID="litFullImage"/>
    <div class="col-sm-12">
    </div>
</asp:Content>

