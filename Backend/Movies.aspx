<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Backend.master" AutoEventWireup="true" CodeFile="Movies.aspx.cs" Inherits="Backend_Movies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Literal runat="server" ID="litWarning"></asp:Literal>

    <div class="col-sm-4 well">
        <h2>Create Movie</h2>
        <div class="form-group">

        <asp:ListBox runat="server" ID="ListActors" CssClass="form-control"  ></asp:ListBox>
  

    </div>
        <asp:Panel runat="server" ID="pnlSearchActors">
    
             <div class="list-group" >
            <div class="list-group-item list-group-item-heading" style="max-height: 100px;">
                                        <AjaxToolkit:ToolkitScriptManager runat="server" AjaxFrameworkMode="Enabled">
                </AjaxToolkit:ToolkitScriptManager>
                <asp:TextBox runat="server" ID="txtSearcActor" AutoCompleteType="Enabled" OnTextChanged="txtSearcActor_OnTextChanged" CssClass="form-control" TabIndex="1" />

                <AjaxToolkit:AutoCompleteExtender runat="server" ID="autocomplete" TargetControlID="txtSearcActor" ServiceMethod="GetActors" MinimumPrefixLength="1" UseContextKey="True" />

                <asp:Button runat="server" ID="btnSubmitSearch" CssClass="btn btn-block" Text="Search Actor" OnClick="btnSubmitSearch_OnClick"  />

            </div>
            <asp:Repeater runat="server" ID="rptActorList" OnItemCommand="rptActorList_OnItemCommand">
                <ItemTemplate>
                    <div class="list-group-item"><%#Eval("Name") %> <span>
                        <asp:Button runat="server" CommandName="addtocart" CommandArgument='<%#Eval("Id") %>' CssClass="glyphicon glyphicon-plus" Text="+" /></span></div>
                </ItemTemplate>

            </asp:Repeater>
        </div>
            </asp:Panel>
        
            <div class="form-group">
            <asp:DropDownList runat="server" ID="ddlImage" CssClass="form-control" />
        </div>
    <div class="form-group">

        <asp:TextBox runat="server" ID="txtMovieName" placeholder="Movie Name" CssClass="form-control" />
    </div>

    <div class="form-group">

        <asp:TextBox runat="server" ID="calMovieYear" TextMode="Date"  CssClass="form-control"/>
    </div>
          <div class="form-group">

        <asp:Label runat="server" ID="lblActors" CssClass="text-info" Text="Actors in movie" />
    </div>
    
    <div class="form-group">

        <asp:Button runat="server" ID="btnSubmitMovie" OnClick="btnSubmitMovie_OnClick" Text="Create Movie" CssClass="btn btn-block" />
    </div>
        </div>
    <div class="col-sm-4 well">
        <h2>Create Actor</h2>
            <div class="form-group">

        <asp:TextBox runat="server" ID="txtActorName" placeholder="Actor Name:" CssClass="form-control" />
    </div>
    <div class="form-group">

        <asp:Button runat="server" ID="btnSubmitActor" OnClick="btnSubmitActor_OnClick" Text="Create Actor" CssClass="btn btn-block" />
    </div>

   
    </div>
    
    

    <div class="col-sm-12" style="background-color: white;">
        <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" AllowPaging="True" DataKeyNames="Id">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
                <asp:TemplateField HeaderText="Actors">
                    <ItemTemplate>
                        <asp:GridView ID="GridView2" CssClass="table table-bordered" runat="server" DataSource='<%# Bind("Actors") %>' AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Cast:">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblName" CssClass="form-control" Text='<%# Eval("Actor.Name") %>'></asp:Label>

                                    

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Poster">
                    <ItemTemplate>
                     <img src ='../upload/<%# Eval("Image.Filename") %>.ashx?height=200&width=150&mode=crop'/>  
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ReadMovies" TypeName="MoviesModel+Repository" DataObjectTypeName="MoviesModel+Movie" DeleteMethod="RemoveMovie"></asp:ObjectDataSource>
    </div>


</asp:Content>

