<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="Prices.aspx.cs" Inherits="Backend_Prices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal runat="server" ID="litWarning"/>
    <h1>Prices</h1>
    <p>Add your pricelist here, the order its shown in here is the same on the pricepage, so just move around your items, with edit.</p>
    <p>
        <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="Id">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
            </Columns>
        </asp:GridView>
    </p>

    <h3>Insert Price</h3>
    <p>Insert your product name, and the price. this will show up on the frontpage and in the pricing page.</p>
    <asp:DetailsView CssClass="table table-bordered" ID="DetailsView1" runat="server" AutoGenerateRows="False" DefaultMode="Insert" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>

    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="PriceModel+Price" DeleteMethod="DeletePrice" InsertMethod="CreatePrice" SelectMethod="ReadPrices" TypeName="PriceModel+Repository" UpdateMethod="UpdatePrice"></asp:ObjectDataSource>

    
</asp:Content>

 