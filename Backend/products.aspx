<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="Backend_products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">   $(document).ready(function () {
       $("#productTable").DataTable();
   });</script>
    <h1>Products</h1>
    <asp:Literal runat="server" ID="litWarning"></asp:Literal>
    <div class="col-sm-8">
        <table id="productTable" class="table-bordered table-hover">
            <thead>
                <tr>
                    <th>Remove</th>
                    <th>Edit</th>
                    <th>Title</th>
                    <th>Price</th>
                    <th>Image</th>

                </tr>
            </thead>
            <tbody>

                <asp:Literal runat="server" ID="litProductTable" />

            </tbody>
        </table>
    </div>
    <div class="col-sm-4">
        <div class="form-group">
            <label>Title</label>
            <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" placeholder="Enter title.." />
        </div>
        <div class="form-group">
            <label>Description</label>
            <asp:TextBox runat="server" ID="txtComment" CssClass="form-control" placeholder="Enter product description.." />
        </div>
        <div class="form-group">
            <label>Image</label>
            <asp:DropDownList runat="server" ID="ddlImages" CssClass="form-control" />
        </div>
        <div class="form-group">
           <label>Price</label>
             <asp:TextBox runat="server" ID="txtPrice" TextMode="Number" CssClass="form-control" placeholder="Enter product price.." />
        </div>
        <div class="form-group">
        <asp:Button runat="server" ID="btnEditProduct" OnClick="btnEditProduct_OnClick" Text="Edit product" CssClass="btn btn-block" Visible="False" />
        <asp:Button runat="server" ID="btnSubmitProduct" OnClick="btnSubmitProduct_OnClick" Text="Add product" CssClass="btn btn-block" />
        </div>

    </div>
</asp:Content>

