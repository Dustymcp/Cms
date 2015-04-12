<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-6">
        <div class="img-thumbnail">
            <asp:Literal runat="server" ID="litFrontpageImage"></asp:Literal>
        </div>
        <div class="col-sm-12">
            <asp:Literal runat="server" ID="litPageInfo" />
        </div>
    </div>

    <div class="col-sm-3">

        <ul class="list-group">
            <li class="list-group-item list-group-item-heading active">Åbningstider</li>
            <li class="list-group-item">Mandag:
                <asp:Literal runat="server" ID="litOpeningHoursMonday"></asp:Literal></li>
            <li class="list-group-item">Tirsdag:
                <asp:Literal runat="server" ID="litOpeningHoursTuesday"></asp:Literal></li>
            <li class="list-group-item">Onsdag:
                <asp:Literal runat="server" ID="litOpeningHoursWednesday"></asp:Literal></li>
            <li class="list-group-item">Torsdag:
                <asp:Literal runat="server" ID="litOpeningHoursThursday"></asp:Literal></li>
            <li class="list-group-item">Fredag:
                <asp:Literal runat="server" ID="litOpeningHoursFriday"></asp:Literal></li>
            <li class="list-group-item">Lørdag:
                <asp:Literal runat="server" ID="litOpeningHoursSaturday"></asp:Literal></li>
            <li class="list-group-item">Søndag:
                <asp:Literal runat="server" ID="litOpeningHoursSunday"></asp:Literal></li>
            <li class="list-group-item">
                <asp:Literal runat="server" ID="litComment" /></li>
        </ul>

    </div>

    <div class="col-sm-3">
        <ul class="list-group">
            <li class="list-group-item list-group-item-heading active">Priser</li>
            <asp:Literal runat="server" ID="litPriceList10" />
        </ul>
    </div>
    <div class="col-sm-6 ">
        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->

            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <asp:Literal runat="server" ID="litProducts" />
            </div>

            <!-- Controls -->
            <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
        <div class="col-sm-4">&nbsp;</div>
    </div>
    <div class="col-sm-12">&nbsp;</div>
</asp:Content>

