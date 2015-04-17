<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Backend_Settings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Settings</h1>
    <div class="col-sm-6">
        <AjaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
        <div class="form-group">
            <label>Sitename</label>
            <asp:TextBox runat="server" ID="txtSiteName" placeholder="Sitename.." CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Frontpage Content</label>
            <cc1:Editor ID="txtPageInfo" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Footer information</label>
            <asp:TextBox runat="server" ID="txtFooterInfo" placeholder="Footer text.." CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Frontpage Image</label>
            <asp:DropDownList runat="server" ID="ddlList" CssClass="form-control" />
        </div>
        <label>Show Frontpage Links</label>
        <div class="checkbox">
            <label>
                <asp:CheckBox runat="server" ID="chkPriceModel" />
                Prices
            </label>
        </div>
        <div class="checkbox">
            <label>
                <asp:CheckBox runat="server" ID="chkOpeningHours" />
                OpeningHours
            </label>
        </div>
        <div class="checkbox">
            <label>
                <asp:CheckBox runat="server" ID="chkProducts" />
                Products
            </label>
        </div>
        <div class="checkbox">
            <label>
                <asp:CheckBox runat="server" ID="chkContacts" />
                Contact
            </label>
        </div>
                <label>Google Embed Link</label>
        
    <div class="input-group">
  
                      <asp:TextBox runat="server" ID="txtEmbedLink" CssClass="form-control" placeholder="Get the http://adress from googlemaps embed and place here to show on contact page." />
            <span class="input-group-btn">

        <button class="btn btn-default" type="button" data-toggle="modal" data-target="#myModal">Help</button>
      </span>
    </div><!-- /input-group -->

        <div class="form-group">
      
            <label>Height</label>

            <asp:TextBox runat="server" ID="txtHeight" TextMode="Number" CssClass="form-control" />
            <label>Width</label>

            <asp:TextBox runat="server" ID="txtWidth" TextMode="Number" CssClass="form-control" />
        </div>
        <asp:Button runat="server" ID="btnEdit" Text="Edit" OnClick="btnEdit_OnClick" CssClass="btn btn-block" />
    </div>
    <div class="col-sm-2">&nbsp; </div>
    <div class="col-sm-4">
        
    </div>
   <!-- Button trigger modal -->


<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Modal title</h4>
      </div>
      <div class="modal-body">
       <h3>Google map</h3>
        <asp:Literal runat="server" ID="litGoogleMapEmbed" />
        <p>View the map from google(press the view larger map button)</p>
        <p>Goto share or embed map<img class="img-responsive" src="http://puu.sh/hfR5A/81e10ad15c.png" /></p>
        <p>
            Copy the link
            <img class="img-responsive" src="http://puu.sh/hfRdT/fb89dc9ee4.png" />
        </p>
        <p>Insert it into the google embed link and your done!</p>

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
</asp:Content>

