<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WingtipToys.Admin.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Administration</h1>
    <hr />
    <h3>Assign Manager</h3>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="UserEmail" runat="server" ItemType="WingtipToys.Models.User"
                    SelectMethod="GetApplicationUsers" AppendDataBoundItems="true"
                    DataTextField="UserName" DataValueField="UserName">
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ManagerEmail" CssClass="col-md-2 control-label">ManagerName</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ManagerEmail" runat="server" ItemType="WingtipToys.Models.User"
                    SelectMethod="GetManagers" AppendDataBoundItems="true"
                    DataTextField="UserName" DataValueField="UserName">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="AssignManager" runat="server" Text="Assign Manager" OnClick="AssignManagerButton_Click" CausesValidation="true" />
            </div>
        </div>
        <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>
    </div>

    <p></p>
    <p></p>


    <p></p>
    <h3>Remove User:</h3>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="DropDownRemoveProduct" runat="server" ItemType="WingtipToys.Models.User"
                    SelectMethod="GetProducts" AppendDataBoundItems="true"
                    DataTextField="UserName" DataValueField="UserName">
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="RemoveProductButton" runat="server" Text="Remove User" OnClick="RemoveUserButton_Click" CausesValidation="false" />
            </div>
        </div>
        <asp:Label ID="LabelRemoveStatus" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
