<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="OpeningHours.aspx.cs" Inherits="Backend_OpeningHours" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <AjaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></AjaxToolkit:ToolkitScriptManager>
    <h1>Opening Hours</h1>
    <label>Monday</label>
    <asp:TextBox runat="server" ID="txtMonday" CssClass="form-control" />
    <label>Tuesday</label>

    <asp:TextBox runat="server" ID="txtTuesday" CssClass="form-control" />
    <label>Wednesday</label>

    <asp:TextBox runat="server" ID="txtWednesday" CssClass="form-control" />
    <label>Thursday</label>

    <asp:TextBox runat="server" ID="txtThursday" CssClass="form-control" />
    <label>Friday</label>

    <asp:TextBox runat="server" ID="txtFriday" CssClass="form-control" />
    <label>Saturday</label>

    <asp:TextBox runat="server" ID="txtSaturday" CssClass="form-control" />
    <label>Sunday</label>

    <asp:TextBox runat="server" ID="txtSunday" CssClass="form-control" />
    <label>Comment</label>
    <asp:TextBox runat="server" ID="txtComment" CssClass="form-control"/>
    <label>Edit the selection</label>
    <asp:Button runat="server" ID="btnEditOpeningHours" CssClass="btn btn-block" OnClick="btnEditOpeningHours_OnClick" Text="Edit"/>

</asp:Content>

