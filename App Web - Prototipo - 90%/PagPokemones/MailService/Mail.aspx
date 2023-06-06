<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="PagPokemones.Formulario_web18" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtmail" class="form-label">Mail destinatario</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtmail" TextMode="Email"/>
                              
            </div>
            <div class="mb-3">
                <label for="txtAsunto" class="form-label">Asunto</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtAsunto"/>
                
            </div>
             <div class="mb-3">
                <label for="txtMensaje" class="form-label">Mensaje</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtMensaje" TextMode="MultiLine"/>
                
            </div>
            
            <asp:Button Text="Enviar" runat="server" CssClass="btn btn-primary" OnClick="btnEnviar_Click" ID="btnEnviar" />
        </div>
    </div>

</asp:Content>
