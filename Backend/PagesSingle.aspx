<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="PagesSingle.aspx.cs" Inherits="Backend_PagesSingle" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit.HTMLEditor" Assembly="AjaxControlToolkit, Version=4.5.7.1213, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-sm-12">
        <asp:Literal runat="server" ID="litWarning" />
        <h1>
            <asp:Literal runat="server" ID="litPageTitleEditorNew"></asp:Literal></h1>
        <div class="form-group">
            <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" placeholder="Title" />
        </div>
        <div class="form-group">

            <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control" />

        </div>

        <div class="form-group">

            <AjaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" />
            <cc1:Editor ID="Editor1" runat="server" TopToolbarPreservePlace="True" Height="600" />
        </div>
        <asp:Button runat="server" ID="btnCreatePage" OnClick="btnCreatePage_OnClick" Text="Create Page" CssClass="btn btn-block" />
        <asp:Button runat="server" ID="btnEditPage" OnClick="btnEditPage_OnClick" Text="Save" CssClass="btn btn-block" Visible="false" />
    </div>
    <div class="col-sm-4">
        <h3>Create category</h3>
        <div class="form-group">
            <asp:TextBox runat="server" ID="txtCategoryName" CssClass="form-control" placeholder="Create new category.." />
        </div>
        <div class="form-group">
            <asp:Button runat="server" ID="btnCreateCategory" CssClass="btn btn-block" Text="Create category" OnClick="btnCreateCategory_OnClick" />
        </div>
    </div>
</asp:Content>

