<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend.master" AutoEventWireup="true" CodeFile="Prices.aspx.cs" Inherits="prices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <table class="table table-bordered">
            <tr>
                <th>Product</th>
                <th>Price</th>
            </tr>

            <asp:Literal runat="server" ID="litTablePrice" />

        </table>
    </div>
</asp:Content>

