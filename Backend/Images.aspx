<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="Images.aspx.cs" Inherits="Backend_Images" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/fileinput.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">   $(document).ready(function () {
       $("#imageTable").DataTable();
   });</script>

    <asp:Literal runat="server" ID="litWarning" />
    <h1>Upload</h1>


    <div class="col-sm-8">

        <table class="table table-bordered" id="imageTable">
            <thead>
                <tr>
                    <th>Image</th>
                    <th>Id</th>
                    <th>Filename</th>
                    <th>Delete</th>

                </tr>
            </thead>
            <tbody>
                <asp:Literal runat="server" ID="litTableImages" />
            </tbody>
        </table>
    </div>

    <div class="col-sm-4 well">
        <h3>Fileupload</h3>
        <p>It is possible to upload multiple files, just dont upload files over 3mb pr file. images cant be larger than 3200x3200</p>
        <p>*Remember to only upload image files, png|jpeg|gif|jpg</p>
        <asp:FileUpload ID="fileUpload" runat="server" AllowMultiple="True" CssClass="file-input-new" />
        <br />
        <asp:Button ID="btnSubmitFiles" runat="server" OnClick="btnSubmitFiles_OnClick" Text="Upload" CssClass="btn btn-default" />
    </div>
</asp:Content>

