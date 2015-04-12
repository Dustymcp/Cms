<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="Pages.aspx.cs" Inherits="Backend_Pages" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">   $(document).ready(function () {
       $("#pageOverview").DataTable();
       $("#pageCategoryOverview").DataTable();
   });</script>
    <div class="col-sm-12">
        <asp:Literal runat="server" ID="litWarning"/>
        <h1>Page overview</h1>
        <p>Create a category for each of your pages, if you want more pages in each category create more pages under a new category.</p>
        <p>Remember every category represents a link on the frontpage.</p>
        <hr />
    </div>
    <div class="col-sm-12">
        <h2>Pages</h2>
        <table id="pageOverview">
            <thead>
                <tr>
                    <th>Remove</th>
                    <th>Edit</th>
                    <th>Title</th>
                    <th>Category</th>
                    <th>Created</th>
                    <th>Content</th>
                </tr>
            </thead>
            <tbody>
               
                    <asp:Literal runat="server" ID="litPageOverview" />

               
            </tbody>
        </table>
    </div>
       <div class="col-sm-12">
        <h2>Categories</h2>
           
        <table id="pageCategoryOverview">
            <thead>
                <tr>
                    <th>Remove</th>

                    <th>Name</th>
                    <th>Pages</th>
               
                </tr>
            </thead>
            <tbody>
               
                    <asp:Literal runat="server" ID="litpagecategoryoverview" />

            </tbody>
        </table>
    </div>
    <div class="col-sm-12">
      
      
         <a type="button" class="btn btn-primary btn-lg" href="PagesSingle.aspx">
            Create Page
        </a>
        <!-- Button trigger modal -->
<button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
  Create new category
</button>

<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Create category</h4>
      </div>
      <div class="modal-body">
              <h3></h3>
        <div class="form-group">
            <asp:TextBox runat="server" ID="txtCategoryName" CssClass="form-control" placeholder="Create new category.." />
        </div>
        <div class="form-group">
            <asp:Button runat="server" ID="btnCreateCategory" CssClass="btn btn-block" Text="Create category" OnClick="btnCreateCategory_OnClick" />
        </div>

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>

    </div>



</asp:Content>

