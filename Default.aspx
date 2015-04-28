<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-12">
        <div class="col-sm-12 jumbotron">

            <div class="col-sm-6 text-center">
                <asp:Literal runat="server" ID="litPageInfo" />
            </div>
            <div class="col-sm-6">
                <div id="carousel-example-generic" class="carousel slide img-border" data-ride="carousel">
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
        </div>
    </div>

    <div class="col-sm-6">
        <asp:Literal runat="server" ID="litFrontpageImage"></asp:Literal>

    </div>


    <ul class="list-group col-sm-3">
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



    <div class="col-sm-3">
        <ul class="list-group">
            <li class="list-group-item list-group-item-heading active">Priser</li>
            <asp:Literal runat="server" ID="litPriceList10" />
        </ul>
    </div>

    <div class="col-sm-12">&nbsp;</div>
        <div class="col-sm-12">

        <h2 class="text-center">På centralbar finder du også</h2>

        <div class="col-sm-12 well">

            <div class="col-sm-4 ">
                <div class="row text-center">

                    <img src="img/ico1.png" />
                </div>
                <h4 class="text-center">Dart</h4>
                <p>Dart skiven er på væggen der er endda tilknyttet en dart klub til stedet og turneringer forekommer kontakt os for mere information.</p>
            </div>
            <div class="col-sm-4 ">
                <div class="row text-center">
                    <img src="img/ico2.png" />
                </div>

                <h4 class=" text-center">Rygning tilladt indenfor!</h4>
                <p>Vi er selvfølgelig små nok til at have en fornuftig rygepolitik.</p>

            </div>
            <div class="col-sm-4 ">
                <div class="row text-center">

                    <img src="img/ico3.png" />
                </div>
                <h4 class="text-center">Spillemaskiner/Jukebox</h4>
                <p>Musikken vælger i selv, selvfølgelig kan du også veksle i baren til spillemaskinerne.</p>
            </div>
        </div>
    </div>
        <div class="col-sm-12 text-center">
            <a href="#" ><img src="img/facebook.png"/></a>
        </div>
</asp:Content>

