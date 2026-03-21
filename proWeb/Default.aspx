<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <h1> <b> Products management </b></h1>

        <div class="row">
            Code
           <asp:TextBox ID="Code" runat="server" TextMode="SingleLine" Width="300px"></asp:TextBox>
        </div>

        <div class="row">
            Name
            <asp:TextBox ID="Name" runat="server" TextMode="SingleLine" Width="300px"></asp:TextBox>
        </div>


        <div class="row">
            Amount
            <asp:TextBox ID="Amount" runat="server" TextMode="SingleLine" Width="125px"></asp:TextBox>
        </div>

        <div class="row">
            Category
            <asp:DropDownList ID="ddlCategory" runat="server" Width="200px"></asp:DropDownList>
        </div>

        <div class="row">
            Price
            <asp:TextBox ID="Price" runat="server" TextMode="SingleLine" Width="125px"></asp:TextBox>
        </div>

        <div class="row">
            Creation Date
            <asp:TextBox ID="Date" runat="server" TextMode="Date" Width="175px"></asp:TextBox>
        </div>

        <br />

        <asp:Button ID="Create" runat="server" Text="Create" OnClick="BtnCreate_Click"/>
        <asp:Button ID="Update" runat="server" Text="Update" OnClick="BtnUpdate_Click"/>
        <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="BtnDelete_Click"/>
        <asp:Button ID="Read" runat="server" Text="Read" OnClick="BtnRead_Click"/>
        <asp:Button ID="ReadFirst" runat="server" Text="Read First" OnClick="BtnReadFirst_Click"/>
        <asp:Button ID="ReadPrev" runat="server" Text="Read Prev" OnClick="BtnReadPrev_Click"/>
        <asp:Button ID="ReadNext" runat="server" Text="Read Next" OnClick="BtnReadNext_Click"/>

        <br /><br />
        <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label>
        
    </main>

</asp:Content>
