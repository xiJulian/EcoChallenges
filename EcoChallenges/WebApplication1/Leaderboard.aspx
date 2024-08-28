<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="WebApplication.Leaderboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>Eco Challenges - Leaderboard</title>
  <link rel="stylesheet" href="styles/leaderboard.style.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  <div class="intro">
    <img class="earthIcon" src="images/earth.png">
    <h1 class="pageTitle">LEADERBOARD</h1>
  </div>

  <div class="leaderboard">
    <asp:GridView ID="LeaderboardGridView" CssClass="leaderboardTable" Width="100%" GridLines="None" CellSpacing="-1" BorderWidth="0" AutoGenerateColumns="false" OnRowDataBound="LeaderboardGridView_RowDataBound" runat="server">
      <Columns> 
        <asp:BoundField DataField="" HeaderText="Rank" />
        <asp:BoundField DataField=""  HeaderText="Name" />
        <asp:BoundField DataField="city.name" HeaderText="City" />
        <asp:BoundField DataField="points" HeaderText="Points" />
      </Columns>
    </asp:GridView>
  </div>
</asp:Content>
