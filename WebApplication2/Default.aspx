<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <center>
        <h1 style="color:#0000FF;"><asp:Label ID="Label1" runat="server" Text="Gestion de orden de compra"></asp:Label></h1>
        <p>
            <strong>Order No. </strong>&nbsp;
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>&nbsp;
            <asp:Button ID="Cargar" runat="server" OnClick="cargar" Text="..." />&nbsp;
            <strong> Ordendate </strong>&nbsp;
            <asp:TextBox ID="txtDate" runat="server" Enabled="false"></asp:TextBox>&nbsp;
        </p>
    </center>
    <asp:Panel ID="Panel1" runat="server" GroupingText="Customer" Height="137px">
        <table>
            <tbody>
                <tr>
                    <th style="height: 37px">Name: </th>
                    <td style="height: 37px">
                        <asp:TextBox ID="txtName" runat="server" Enabled="false" width="1000px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th style="height: 37px">Adress: </th>
                    <td style="height: 37px">
                        <asp:TextBox ID="txtAdress" runat="server" Enabled="false" width="1000px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th style="height: 42px">Phone: </th>
                    <td style="height: 42px">
                        <asp:TextBox ID="txtPhone" runat="server" Enabled="false" width="1000px"></asp:TextBox>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    <br /><br />
    <asp:Panel ID="Panel2" runat="server" GroupingText="Informacion" Height="137px">
    <p>
        <strong>Employe</strong>&nbsp;
        <asp:TextBox ID="txtEmploye" runat="server" Enabled="false" width="1000px"></asp:TextBox>
    </p>

    <asp:GridView ID="gvDetalle" runat="server" Width="1090px"></asp:GridView>
    <br />
    <p>
        <br /><br />
        <strong>Total:</strong>&nbsp;
        <asp:TextBox ID="txtTotal" runat="server" Enabled="false" width="1000px"></asp:TextBox>
    </p>
        </asp:Panel>
    <br /><br />
</asp:Content>

