<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="OpeningHours.aspx.cs" Inherits="OpeningHours" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Opening Hours</h1>
    <div class="container">

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
</asp:Content>

