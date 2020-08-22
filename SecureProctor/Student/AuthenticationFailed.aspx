<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="AuthenticationFailed.aspx.cs" Inherits="SecureProctor.Student.AuthenticationFailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StudentContent" runat="server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <h1 style="padding: 10px; color: #666;">
                <asp:Label ID="lblHead" runat="server" Text="Authentication"></asp:Label>
            </h1>
            <div style="margin: 100px auto 0px auto; text-align: center;" id="divError">
                <span style="font-size: 40px; color: #f84e4e;">Authentication error.</span><br />
                <br />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
