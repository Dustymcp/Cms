<%@ Page Title="" Language="C#" MasterPageFile="~/backend/Backend.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="backend_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-sm-4 list-group">
        <div class="list-group-item list-group-item-heading active">Users <span class="badge">
            <asp:Literal runat="server" ID="litUserCount" /></span></div>

        <asp:Literal runat="server" ID="litUserTop10" />

    </div>
    <div class="col-sm-4 list-group">
        <div class="list-group-item list-group-item-heading active">Latest images<span class="badge"><asp:Literal runat="server" ID="litImageCount" /></span></div>
       
        <div id="carousel" class="carousel slide" data-ride="carousel">

            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
            <asp:Literal runat="server" ID="litImagesLatest" />

            </div>

            <!-- Controls -->
            <a class="left carousel-control" href="#carousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#carousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>

    <div class="col-sm-8 list-group">
        <div  class="list-group-item list-group-item-heading active">Pages<span class="badge "><asp:Literal runat="server" ID="litPageCount" /></span></div>
        <asp:Literal runat="server" ID="litPageLatest"/>
    </div>
</asp:Content>

