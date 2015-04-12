<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Backend_Settings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Settings</h1>
    <div class="col-sm-6">
                   <AjaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />

        <asp:TextBox runat="server" ID="txtSiteName" placeholder="Sitename.."/>
        <cc1:Editor ID="txtPageInfo" runat="server"  />
        <asp:TextBox runat="server" ID="txtFooterInfo" placeholder="Footer text.." />
        <asp:DropDownList runat="server" ID="ddlList"/>
        <asp:Button runat="server" ID="btnSubmit" Text="Save" OnClick="btnSubmit_OnClick"/>
        <asp:Button runat="server" ID="btnEdit" Text="Edit" OnClick="btnEdit_OnClick"/>
    </div>
</asp:Content>

