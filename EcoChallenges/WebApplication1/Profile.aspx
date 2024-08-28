<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>Eco Challenges - Profile</title>
  <link rel="stylesheet" href="styles/profile.style.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  <div class="intro">
    <h1 class="pageTitle"><i class="fa-solid fa-user"></i> PROFILE</h1>
  </div>

  <div class="boxSection">
    <div class="boxNav">
      <i id="user" class="fa-solid fa-user boxNavItem selected"><span class="tooltipText">USER INFO</span></i>
      <i id="changePassword" class="fa-solid fa-pen-to-square boxNavItem" visible="false" runat="server"><span class="tooltipText">CHANGE PASSWORD</span></i>
      <i id="challenges" class="fa-solid fa-list-check boxNavItem"><span class="tooltipText">USER CHALLENGES</span></i>
    </div>

    <div id="boxUser" class="boxMain">
      <span class="boxTitle">USER INFO</span>
      <div class="userInfo">
        <asp:Label ID="ActionLabel" runat="server"></asp:Label>
        <div>
          <span class="userInfoTitle">Name</span>
          <asp:Label ID="UsernameLabel" CssClass="userInfoContent" runat="server"></asp:Label>
        </div>
        <div id="UserEmailDiv" visible="false" runat="server">
          <span id="UserEmailLabelSpan" class="userInfoTitle" runat="server">Email</span>
          <asp:Label ID="UserEmailLabel" CssClass="userInfoContent" runat="server"></asp:Label>
        </div>
        <div>
          <span class="userInfoTitle">City</span>
          <asp:Label ID="CityLabel" CssClass="userInfoContent" runat="server"></asp:Label>
        </div>
        <div>
          <span class="userInfoTitle">Challenges Number</span>
          <asp:Label ID="ChallengesNumberLabel" CssClass="userInfoContent" runat="server"></asp:Label>
        </div>
        <div class="pointsAndDelete">
          <div>
            <span class="userInfoTitle">Points</span>
            <asp:Label ID="UserPointsLabel" CssClass="userInfoContent" runat="server"></asp:Label>
          </div>
          <div id="DeleteButtonDiv" visible="false" runat="server">
            <asp:Button ID="DeleteButton" CssClass="button" Text="Delete Account" BackColor="DarkRed" OnClick="DeleteButton_Click" runat="server" />
          </div>
        </div>
      </div>
    </div>

    <div id="boxChangePassword" class="boxMain" hidden Visible="false" runat="server">
      <span class="boxTitle">CHANGE PASSWORD</span>
      <div class="changePassword form">
        <div>
          <div class="inputGroup">
            <asp:Label AssociatedControlID="OldPasswordTextBox" runat="server">Current Password</asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="OldPasswordTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="OldPasswordTextBox" TextMode="Password" runat="server"></asp:TextBox>
          </div>
          <div class="inputGroup">
            <asp:Label AssociatedControlID="NewPasswordTextBox" runat="server">New Password</asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="NewPasswordTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
            <asp:TextBox ID="NewPasswordTextBox" TextMode="Password" runat="server"></asp:TextBox>
          </div>
        </div>
        <asp:Button ID="SaveButton" CssClass="button" Text="SAVE" OnClick="SaveButton_Click" runat="server" />
      </div>
    </div>

    <div id="boxChallenges" class="boxMain" hidden>
      <span class="boxTitle">USER CHALLENGES</span>
      <div class="challenges">
        <asp:Repeater ID="ChallengeRepeater" OnItemDataBound="ChallengeRepeater_ItemDataBound" runat="server">
          <ItemTemplate>
            <div class="challenge">
              <div>
                <asp:Label ID="ChallengeTitle" CssClass="challengeTitle" runat="server"></asp:Label>
                <span class="challengeDate">Started in: <%# Eval("startedAt") %></span>
                <asp:Label ID="ChallengeFinishedIn" CssClass="challengeDate" runat="server"></asp:Label>
              </div>
              <asp:HyperLink NavigateUrl='<%# "~/Challenge.aspx?id=" + Eval("challengeId") %>' CssClass="button" runat="server">VIEW</asp:HyperLink>
            </div>
          </ItemTemplate>
        </asp:Repeater>
      </div>
    </div>

  </div>

  <script>
    const boxes = { user: "boxUser", body_changePassword: "body_boxChangePassword", challenges: "boxChallenges" };
    [...document.getElementsByClassName("boxNavItem")].forEach((element) => {
      element.onclick = () => {
        element.classList.add("selected");
        [...document.getElementsByClassName("boxNavItem")].forEach((element2) => {
          if (element2.id !== element.id) element2.classList.remove("selected");
        });

        [...document.getElementsByClassName("boxMain")].forEach((boxElement) => {
          if (boxElement.id === boxes[element.id]) boxElement.style.display = "block";
          else boxElement.style.display = "none";
        });
      }
    });
  </script>
</asp:Content>
