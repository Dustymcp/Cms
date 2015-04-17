<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="Images.aspx.cs" Inherits="Backend_Images" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/fileinput.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Literal runat="server" ID="litWarning" />
    <div class="col-lg-12">
        <asp:FileUpload ID="fileUpload" runat="server" AllowMultiple="True" CssClass="file-input-new" />
        <br />
        <asp:Button ID="btnSubmitFiles" runat="server" OnClick="btnSubmitFiles_OnClick" Text="Upload" CssClass="btn btn-default" />
    </div>
    <div class="divider">&nbsp;</div>
    <asp:Repeater ID="rptFileOverview" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>


            <div class=" col-sm-2">
                <div class="well">

                    <a href="Images.aspx?Id=<%#Eval("Id") %>&Delete=true"><span class="glyphicon glyphicon-remove"></span></a>

                    <a href="ImagesSingle.aspx?Id=<%#Eval("Id") %>">
                        <img src="../upload/<%#Eval("Filename") %>.ashx?w=200&h=200&mode=stretch" class="img-thumbnail" style="border: 1px solid black;" /></a>
                    <p></p>

                </div>
            </div>

        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>

