<%@ Page Title="" Language="C#" Culture="en-US" UICulture="en-US" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="Authenticatiion_30626.RegisterForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="mng" runat="server"></asp:ScriptManager>
    <ajax:CalendarExtender ID="caldob" runat="server" TargetControlID="txtdob" PopupPosition="TopLeft" Format="MM/dd/yyyy" PopupButtonID="txtdob" />

    <div id="form_container" >
        <h2>Registration Form</h2>
        <table id="tbl">
            <tr>
                <td><asp:Label ID="lblname" runat="server" AssociatedControlID="txtname">Name:</asp:Label></td>
                <td><asp:TextBox ID="txtname" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblemail" runat="server" AssociatedControlID="txtemail">Email:</asp:Label></td>
                <td><asp:TextBox ID="txtemail" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblpwd" runat="server" AssociatedControlID="txtpwd">Password:</asp:Label></td>
                <td><asp:TextBox ID="txtpwd" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lbldob" runat="server" AssociatedControlID="txtdob">DOB:</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtdob" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblcountry" runat="server" AssociatedControlID="ddlcountry">Country:</asp:Label></td>
                <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"> </asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblstate" runat="server" AssociatedControlID="ddlstate" >State:</asp:Label></td>
                <td><asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true"> </asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblcity" runat="server" AssociatedControlID="ddlcity">City:</asp:Label></td>
                <td><asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblgender" runat="server" AssociatedControlID="rblgender">Gender:</asp:Label></td>
                <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3" ></asp:RadioButtonList></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblhobbies" runat="server" AssociatedControlID="cblhobbies">Hobbies:</asp:Label></td>
                <td><asp:CheckBoxList ID="cblhobbies" runat="server" RepeatColumns="4" ></asp:CheckBoxList></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblimage" runat="server" AssociatedControlID="fuimage">Image:</asp:Label></td>
                <td><asp:FileUpload ID="fuimage" runat="server" /></td>
            </tr>
            <tr>
                
                <td><asp:Button ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click" /></td>
            </tr>

        </table>
    </div>
</asp:Content>
