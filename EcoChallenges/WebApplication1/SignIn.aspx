<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="WebApplication.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>Eco Challenges - Sign In</title>
  <link rel="stylesheet" href="styles/signin.style.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  <div class="intro">
    <div class="formTitle">
      <!-- <i class="arrow fa-solid fa-arrow-left"></i> -->
      <h1><i class="fa-solid fa-user"></i> SIGN IN</h1>
    </div>

    <asp:Label ID="ErrorLabel" Visible="false" ForeColor="MediumVioletRed" runat="server"></asp:Label>

    <div class="form">
      <asp:Label AssociatedControlID="EmailTextBox" runat="server"><i class="fa-solid fa-at"></i> Email</asp:Label>
      <asp:RequiredFieldValidator CssClass="" ID="RequiredFieldValidator1" ControlToValidate="EmailTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
      <asp:TextBox ID="EmailTextBox" TextMode="Email" runat="server"></asp:TextBox>

      <asp:Label AssociatedControlID="PasswordTextBox" runat="server"><i class="fa-solid fa-key"></i> Password</asp:Label>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="PasswordTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
      <asp:TextBox ID="PasswordTextBox" TextMode="Password" runat="server"></asp:TextBox>

      <div class="formButtons">
        <div class="signinButtons">
          <asp:Button ID="SignInButton" CssClass="button" Text="SIGN IN" OnClick="SignInButton_Click" runat="server"></asp:Button>
          <asp:HyperLink runat="server" NavigateUrl="~/ResetPassword.aspx" CssClass="forgotPassword">Forgot password?</asp:HyperLink>
        </div>
        <div>
          Don't have an account?
            <asp:HyperLink runat="server" NavigateUrl="~/SignUp.aspx">Create one!</asp:HyperLink>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
