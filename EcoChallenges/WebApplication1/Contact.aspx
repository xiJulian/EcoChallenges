<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>Eco Challenges - Contact Us</title>
  <link rel="stylesheet" href="styles/contact.style.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  <div class="intro">
    <img class="earthIcon" src="images/earth.png">
    <h1 class="pageTitle">CONTACT</h1>
  </div>

  <div class="boxSection">
    <div class="boxMain">
      <span class="boxTitle">MESSAGE FORM</span>
      <div class="messageForm form">
        <asp:Label ID="ActionLabel" runat="server"></asp:Label>
        <div>
          <div class="inputGroup">
            <asp:Label AssociatedControlID="SubjectTextBox" runat="server">Subject</asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="SubjectTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="SubjectTextBox" runat="server"></asp:TextBox>
          </div>
          <div class="inputGroup">
            <asp:Label AssociatedControlID="BodyTextBox" runat="server">Body</asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="BodyTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="BodyTextBox" TextMode="Multiline" runat="server"></asp:TextBox>
          </div>
        </div>
        <asp:Button ID="SendButton" CssClass="button" Text="SEND" OnClick="SendButton_Click" runat="server" />
      </div>
    </div>
  </div>
</asp:Content>
