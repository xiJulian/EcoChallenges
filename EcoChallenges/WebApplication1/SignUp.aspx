<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebApplication.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>Eco Challenges - Sign Up</title>
  <link rel="stylesheet" href="styles/signup.style.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  <div class="intro">
    <div class="formTitle">
      <h1><i class="fa-solid fa-user-plus"></i> SIGN UP</h1>
    </div>
    
    <asp:Label ID="ErrorLabel" Visible="false" ForeColor="MediumVioletRed" runat="server"></asp:Label>
    
    <div class="form">
      <div class="groups">
        <div class="group">
          <asp:Label AssociatedControlID="FirstNameTextBox" runat="server"><i class="fa-solid fa-id-card"></i> First Name</asp:Label>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="FirstNameTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
          <asp:TextBox ID="FirstNameTextBox" TextMode="SingleLine" TabIndex="1" runat="server"></asp:TextBox>

          <asp:Label AssociatedControlID="EmailTextBox" runat="server"><i class="fa-solid fa-at"></i> Email</asp:Label>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="EmailTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
          <asp:TextBox ID="EmailTextBox" TextMode="Email" TabIndex="3" runat="server"></asp:TextBox>

          <asp:Label AssociatedControlID="PasswordTextBox" runat="server"><i class="fa-solid fa-key"></i> Password</asp:Label>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="PasswordTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
          <asp:TextBox ID="PasswordTextBox" TextMode="Password" TabIndex="5" runat="server"></asp:TextBox>
        </div>
        <div class="group">
          <asp:Label AssociatedControlID="LastNameTextBox" runat="server"><i class="fa-solid fa-id-card"></i> Last Name</asp:Label>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="LastNameTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
          <asp:TextBox ID="LastNameTextBox" TextMode="SingleLine" TabIndex="2" runat="server"></asp:TextBox>

          <asp:Label AssociatedControlID="CityDropDownList" runat="server"><i class="fa-solid fa-globe"></i> City</asp:Label>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="CityDropDownList" InitialValue="Select" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
          <asp:DropDownList ID="CityDropDownList" TabIndex="4" AppendDataBoundItems="true" runat="server">
            <asp:ListItem Selected="True">Select</asp:ListItem>
          </asp:DropDownList>

          <asp:Label AssociatedControlID="ConfirmPasswordTextBox" runat="server"><i class="fa-solid fa-key"></i> Confirm Password</asp:Label>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ConfirmPasswordTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
          <asp:CompareValidator ID="CompareValidator1" ControlToValidate="ConfirmPasswordTextBox" ControlToCompare="PasswordTextBox" Display="Dynamic" ErrorMessage="Password doesn't match!" ForeColor="MediumVioletRed" runat="server"></asp:CompareValidator>
          <asp:TextBox ID="ConfirmPasswordTextBox" TextMode="Password" TabIndex="6" runat="server"></asp:TextBox>
        </div>
      </div>

      <div class="formButtons">
        <asp:Button ID="SignUpButton" CssClass="button signupButton" Text="SIGN UP" OnClick="SignUpButton_Click" runat="server" />
        <div>
          Already have an account?
            <asp:HyperLink runat="server" CssClass="link" NavigateUrl="~/SignIn.aspx">Sign in.</asp:HyperLink>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
