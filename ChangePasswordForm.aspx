<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ChangePasswordForm.aspx.cs" Inherits="Authenticatiion_30626.ChangePasswordForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="form_container" class="">
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <h2>Change Password</h2>
        <table>

            <tr>
                <td>
                    <asp:Label ID="lbloldpwd" runat="server" AssociatedControlID="txtoldpwd">Current Password:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtoldpwd" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblnewpwd" runat="server" AssociatedControlID="txtnewpwd">New Password:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtnewpwd" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblcnfpwd" runat="server" AssociatedControlID="txtcnfpwd">Confirm Password:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcnfpwd" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="btn_cp" runat="server" Text="Change Password" OnClick="btn_cp_Click" /></td>
            </tr>

        </table>

    </div>
</asp:Content>
