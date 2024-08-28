<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="WebApplication.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>Eco Challenges - Reset Password</title>
  <link rel="stylesheet" href="styles/resetpassword.style.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  <div class="intro">
    <div class="formTitle">
      <h1><i class="fa-solid fa-rotate"></i> RESET PASSWORD</h1>
    </div>

    <asp:Label ID="ErrorLabel" Visible="false" ForeColor="MediumVioletRed" runat="server"></asp:Label>

    <div class="form">
      <asp:Label AssociatedControlID="EmailTextBox" runat="server"><i class="fa-solid fa-at"></i> Email</asp:Label>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="EmailTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
      <asp:TextBox ID="EmailTextBox" TextMode="Email" runat="server"></asp:TextBox>

      <div class="formButtons">
        <asp:Button ID="ResetPasswordButton" CssClass="button" Text="Reset Password" OnClick="ResetPasswordButton_Click" runat="server"></asp:Button>
      </div>
    </div>

    <asp:Label ID="SuccessLabel" Visible="false" runat="server"></asp:Label>
  </div>
</asp:Content>
