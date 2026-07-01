<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Authenticatiion_30626.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center;margin-top:30px;">welcome to Home!</h1>
    <div id="grid_container" >
        <asp:GridView ID="gv_user" runat="server"  AutoGenerateColumns="false" OnRowCommand="gv_user_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%#Eval("uname") %>
                    </ItemTemplate>
                </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <%#Eval("uemail") %>
                    </ItemTemplate>
                </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Password">
                    <ItemTemplate>
                        <%#Eval("upassword") %>
                    </ItemTemplate>
                </asp:TemplateField>
            
                <asp:TemplateField HeaderText="DOB">
                    <ItemTemplate>
                        <%#Eval("udob","{0:dd-MMMM-yyyy}") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <%#Eval("GenderName") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <%#Eval("CountryName") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                        <%#Eval("StateName") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <%#Eval("CityName") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Hobbies">
                    <ItemTemplate>
                        <%#Eval("uhobbies") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="img" runat="server" Width="80px" Height="50px"  ImageUrl='<%# "~/Images/" + Eval("uimage") %>'  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="delete_row" CommandArgument='<%# Eval("uid") + "," + Eval("uimage") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btn_edit" runat="server" Text="Update" CommandName="edit_row" CommandArgument='<%#Eval("uid") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
