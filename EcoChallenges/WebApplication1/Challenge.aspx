<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Challenge.aspx.cs" Inherits="WebApplication.Challenge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>Eco Challenges - Challenge</title>
  <link rel="stylesheet" href="styles/challenge.style.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
  <div class="intro">
    <img class="earthIcon" src="images/earth.png">
    <h1 class="pageTitle">CHALLENGE</h1>
  </div>

  <div class="boxSection">
    <div class="boxNav">
      <i id="info" class="fa-solid fa-circle-info boxNavItem selected"><span class="tooltipText">INFO</span></i>
      <i id="top" class="fa-solid fa-ranking-star boxNavItem"><span class="tooltipText">TOP USERS</span></i>
      <i id="comments" class="fa-solid fa-rectangle-list boxNavItem"><span class="tooltipText">COMMENTS</span></i>
      <i id="user" class="fa-solid fa-user-clock boxNavItem"><span class="tooltipText">MY PROGRESS</span></i>
    </div>

    <div id="boxInfo" class="boxMain">
      <span class="boxTitle">CHALLENGE INFO</span>
      <div class="challengeInfo">
        <asp:Label ID="ActionLabel" runat="server"></asp:Label>
        <div>
          <asp:Label ID="ChallengeTitle" CssClass="challengeTitle" runat="server"></asp:Label>
          <asp:Label ID="ChallengePoints" CssClass="challengePoints" runat="server"></asp:Label>
        </div>
        <asp:Label ID="ChallengeDate" CssClass="challengeDate" runat="server">Created in: </asp:Label>
        <asp:Label ID="ChallengeDescription" CssClass="challengeDescription" runat="server"></asp:Label>
      </div>
    </div>

    <div id="boxTop" class="boxMain" hidden>
      <asp:GridView ID="TopUsersGridView" CssClass="topUsersTable" Width="100%" GridLines="None" CellSpacing="-1" BorderWidth="0" AutoGenerateColumns="false" OnRowDataBound="TopUsersGridView_RowDataBound" runat="server">
        <Columns>
          <asp:BoundField DataField="" HeaderText="Rank" />
          <asp:BoundField DataField="" HeaderText="Name" />
          <asp:BoundField DataField="" HeaderText="Time" />
        </Columns>
      </asp:GridView>
    </div>

    <div id="boxComments" class="boxMain" hidden>
      <span class="boxTitle">COMMENTS</span>
      <div class="comments">
        <asp:Repeater ID="CommentRepeater" OnItemDataBound="CommentRepeater_ItemDataBound" runat="server">
          <ItemTemplate>
            <div class="comment">
              <div>
                <asp:HyperLink ID="CommentUsername" CssClass="commentUsername" runat="server"></asp:HyperLink>
                <span class="commentDate"><%# Eval("completedAt") %></span>
              </div>
              <span class="commentContent"><%# Eval("comment") %></span>
            </div>
          </ItemTemplate>
        </asp:Repeater>
      </div>
    </div>

    <div id="boxUser" class="boxMain" hidden>
      <span class="boxTitle">MY PROGRESS</span>
      <div class="userProgress">
        <asp:Label ID="UserProgressErrorLabel" runat="server">You didn't start the challenge yet.</asp:Label>
        <div id="userProgressDetails" visible="false" runat="server">
          <div class="userProgressLabel">
            <span class="userProgressTitle">Started In</span>
            <asp:Label ID="UserProgressStartedInLabel" CssClass="userProgressContent" runat="server"></asp:Label>
          </div>
          <div id="UserProgressFinishedInDiv" class="userProgressLabel" visible="false" runat="server">
            <span class="userProgressTitle">Finished In</span>
            <asp:Label ID="UserProgressFinishedInLabel" CssClass="userProgressContent" runat="server"></asp:Label>
          </div>
          <div id="UserFinishedCommentDiv" class="userProgressLabel" visible="false" runat="server">
            <span class="userProgressTitle">Your Comment</span>
            <asp:Label ID="UserFinishedComment" CssClass="userProgressContent" runat="server"></asp:Label>
          </div>
        </div>

        <asp:Button ID="StartButton" CssClass="button" Text="START" OnClick="StartButton_Click" runat="server" />
        <div id="FinishButtonDiv" class="finishButtonDiv" visible="false" runat="server">
          <asp:Label ID="CommentTextBoxLabel" AssociatedControlID="CommentTextBox" runat="server"><i class="fa-solid fa-comment"></i> Comment:</asp:Label>
          <asp:RequiredFieldValidator ID="CommentTextBoxValidator" ControlToValidate="CommentTextBox" Display="Dynamic" ErrorMessage="This field is required!" ForeColor="MediumVioletRed" runat="server"></asp:RequiredFieldValidator>
          <asp:TextBox ID="CommentTextBox" TextMode="MultiLine" runat="server"></asp:TextBox>
          <asp:Button ID="FinishButton" CssClass="button" Text="FINISH" OnClick="FinishButton_Click" runat="server" />
        </div>
      </div>
    </div>
  </div>

  <script>
    const boxes = { info: "boxInfo", top: "boxTop", comments: "boxComments", user: "boxUser" };
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
