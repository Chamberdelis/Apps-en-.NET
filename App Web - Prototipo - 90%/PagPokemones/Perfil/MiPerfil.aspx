<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="PagPokemones.Formulario_web110" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mi Perfil</h1>
    <asp:Label Text="Te has logueado correctamente." runat="server" />

    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label ID="lblMail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtMail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label2" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="Label3" runat="server" Text="Fecha Nacimiento"></asp:Label>
                <asp:TextBox ID="txtFecha" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label ID="Label1" runat="server" Text="Subir Imagen"></asp:Label>
                <input type="file" id="inpImagen" runat="server" class="form-control" />
            </div>
            <div>
                <asp:Image ID="imgImagenMiPerfil" runat="server" CssClass="img-fluid mb-3" ImageUrl="https://us.123rf.com/450wm/mattbadal/mattbadal1911/mattbadal191100006/135029891-falta-la-p%C3%A1gina-de-imagen-para-el-dise%C3%B1o-del-sitio-web-o-el-dise%C3%B1o-de-la-aplicaci%C3%B3n-m%C3%B3vil-no-hay.jpg?ver=6" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <a href="../Default.aspx">Cancelar</a>
            
        </div>

    </div>
</asp:Content>
