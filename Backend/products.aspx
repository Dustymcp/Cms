<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="Backend_products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <script type="text/javascript">   $(document).ready(function () {
       $("#productTable").DataTable();
   });</script>
    <div class="col-sm-12">
        <h1>Products</h1>
         <table id="productTable">
            <thead>
                <tr>
                    <th>Remove</th>
                    <th>Edit</th>
                    <th>Title</th>
                    <th>Image</th>
                    <th>Price</th>
               
                </tr>
            </thead>
            <tbody>
               
                    <asp:Literal runat="server" ID="litProductTable" />

            </tbody>
        </table>
    </div>
    <div class="col-sm-4">
        <div class="form-group">
            <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" placeholder="Title.." />
            <asp:TextBox runat="server" ID="txtComment" CssClass="form-control" placeholder="Description.." />
            <asp:DropDownList runat="server" ID="ddlImages" CssClass="form-control" />
            <asp:TextBox runat="server" ID="txtPrice" TextMode="Number" CssClass="form-control" placeholder="Price.." />
            <asp:Button runat="server" ID="btnSubmitProduct" OnClick="btnSubmitProduct_OnClick" Text="Add product" CssClass="btn btn-block" />
        </div>
    </div>
</asp:Content>

