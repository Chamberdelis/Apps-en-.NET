<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PagPokemones.Formulario_web19" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr />
    <h1> Registro de Trainee.</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtMail" class="form-label">Mail</label>
                <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" />


            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Clave</label>
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password" />

            </div>


            <asp:Button Text="Registrarse" runat="server" CssClass="btn btn-primary" ID="btnRegistrarse" 
                OnClick="btnRegistrarse_Click" />

            <a href="../Default.aspx">Volver</a>
                 
        </div>
    </div>

</asp:Content>
