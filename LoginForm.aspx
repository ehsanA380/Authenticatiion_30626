<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Authenticatiion_30626.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="form_container" class="loginForm">
        <asp:Label ID="lblmsg" runat="server"  ></asp:Label>
     <h2>Login</h2>
     <table>
         
         <tr>
             <td><asp:Label ID="lblemail" runat="server" AssociatedControlID="txtemail">Email:</asp:Label> </td>
             <td><asp:TextBox ID="txtemail" runat="server" ></asp:TextBox></td>
         </tr>
         <tr>
              <td><asp:Label ID="lblpassword" runat="server" AssociatedControlID="txtpassword">Password:</asp:Label> </td>
             <td><asp:TextBox ID="txtpassword" runat="server" ></asp:TextBox></td>
         </tr>
        
         <tr>   
             <td><asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click" /></td>
         </tr>
        
     </table>

 </div>
   
</asp:Content>
