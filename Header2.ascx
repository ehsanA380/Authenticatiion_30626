<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header2.ascx.cs" Inherits="Authenticatiion_30626.Header2" %>
<div id="navbar_container">
    <ul id="nav">
        <li class="<%: Request.Path.EndsWith("Home.aspx") ? "nav-active" : "" %>">
          <a class="link <%: Request.Path.EndsWith("Home.aspx") ? "active" : "" %>" href="Home.aspx">Home</a>
        </li>
       <li class=" <%: Request.Path.EndsWith("ChangePasswordForm.aspx") ? "nav-active" : "" %>">
          <a class="link <%: Request.Path.EndsWith("ChangePasswordForm.aspx") ? "active" : "" %>" href="ChangePasswordForm.aspx">Change Password</a>
        </li>
      
        <li class=" <%: Request.Path.EndsWith("Logout.aspx") ? "nav-active" : "" %>">
          <a class="link <%: Request.Path.EndsWith("Logout.aspx") ? "active" : "" %>" href="Logout.aspx">Logout</a>
        </li>

    </ul>
</div>