<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Logeo.aspx.cs" Inherits="PagPokemones.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2> ¡Te logueaste correctamente !</h2>
    <hr />

    <div class="row">
        <div class="col-6">
            <h3> Aqui si eres User</h3>
            <asp:Button Text="User" runat="server" ID="btnUser" CssClass="btn btn-primary" OnClick="btnUser_Click" />
        </div>
<%if (Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN)
    {%>

   
        <div class="col-6">
            <h3> Aqui si eres Admin</h3>
            <asp:Button Text="Admin" runat="server" ID="btnAdmin" CssClass="btn btn-primary" OnClick="btnAdmin_Click" />
        </div>
    </div>
    <% } %>

</asp:Content>
