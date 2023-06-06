<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PagPokemones.Formulario_web14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr />
    <h1>Login</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Usuario</label>
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />


            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Clave</label>
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password" />

            </div>


            <asp:Button Text="Ingresar" runat="server" CssClass="btn btn-primary" ID="btnIngresar" 
                OnClick="btnIngresar_Click" />
        </div>
    </div>

</asp:Content>
