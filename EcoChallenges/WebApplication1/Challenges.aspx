<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Challenges.aspx.cs" Inherits="WebApplication.Challenges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>Eco Challenges - Challenges</title>
  <link rel="stylesheet" href="styles/challenges.style.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  <div class="intro">
    <img class="earthIcon" src="images/earth.png">
    <h1 class="pageTitle">CHALLENGES</h1>
  </div>

  <div class="cards">
    <asp:Repeater ID="CardRepeater" runat="server">
      <ItemTemplate>
        <div class="card">
          <img src="images/card.png" alt="Card Image">
          <h2><%# Eval("title") %></h2>
          <p><%# Eval("createdAt") %></p>
          <div class="cardButtons">
            <asp:HyperLink NavigateUrl='<%# "~/Challenge.aspx?id=" + Eval("id") %>' runat="server">VIEW</asp:HyperLink>
            <!-- <button class="button viewComments"><i class="fa-solid fa-comment"></i></button> -->
          </div>
        </div>
      </ItemTemplate>
    </asp:Repeater>
  </div>
</asp:Content>
