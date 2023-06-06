<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormPokemon.aspx.cs" Inherits="PagPokemones.Formulario_web13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" />

    <div class="row">
        <div class="col-6">

            <h2>Formulario de Alta</h2>


            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNumero" class="form-label">Numero</label>
                <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddTipo" class="form-label">Tipo</label>
                <asp:DropDownList ID="ddTipo" runat="server" CssClass="form-select"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <label for="ddTipo" class="form-label">Debilidad</label>
                <asp:DropDownList ID="ddDebilidad" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagen" class="form-label">Url Imagen</label>
                        <asp:TextBox ID="txtImagen" CssClass="form-control" runat="server" AutoPostBack="true"
                            OnTextChanged="txtImagen_TextChanged"></asp:TextBox>
                    </div>

                    <div class="mb-3 row">
                        <div class="col">
                            <asp:Image ID="pbxImagen" ImageUrl="data:image/png;base64,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"
                                runat="server" Width="60%" />
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>


            <br />
            <div class="mb-3">
                <asp:Button ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />

                <asp:Button Text="Inactivar" ID="btnInactivar" CssClass="btn btn-warning" OnClick="btnInactivar_Click"
                    runat="server" />

                <a href="Lista.aspx">Volver</a>
            </div>





        </div>
    </div>

    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button ID="btnEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar"
                            OnClick="btnEliminar_Click" />
                    </div>
                    <% if (ConfirmaEliminacion)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmarEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminacion" OnClick="btnConfirmaEliminacion_Click"
                            CssClass="btn btn-outline-danger" runat="server" />
                    </div>

                    <%}
                    %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
