<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Authenticatiion_30626.Header" %>
<div id="navbar_container">
    <ul id="nav">
        
        <li class=" <%: Request.Path.EndsWith("RegisterForm.aspx") ? "nav-active" : "" %>">
          <a class="link <%: Request.Path.EndsWith("RegisterForm.aspx") ? "active" : "" %>" href="RegisterForm.aspx">Sign Up</a>
        </li>
        <li class=" <%: Request.Path.EndsWith("LoginForm.aspx") ? "nav-active" : "" %>">
          <a class="link <%: Request.Path.EndsWith("LoginForm.aspx") ? "active" : "" %>" href="LoginForm.aspx">Sign In</a>
        </li>

    </ul>
</div>


