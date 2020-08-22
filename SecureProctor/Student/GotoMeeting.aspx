<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="GotoMeeting.aspx.cs" Inherits="SecureProctor.Student.GotoMeeting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">

    <table align="center">

        <tr>

            <td>

                <asp:Label Text="Transaction ID" runat="server"></asp:Label>

            </td>

            <td>

                <asp:TextBox ID="txtTransactionID" runat="server"></asp:TextBox>

            </td>

        </tr>

        <tr>

            <td>

                <asp:Label ID="Label1" Text="GoTOMeeting" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtGotoMeeting" runat="server"></asp:TextBox>
            </td>

        </tr>

        <tr>

            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="submit" OnClick="btnSubmit_Click"></asp:Button></td>
        </tr>

        <tr>

            <td>
                <asp:Label ID="lblSuccess" runat="server"></asp:Label>

            </td>

        </tr>





    </table>


</asp:Content>
