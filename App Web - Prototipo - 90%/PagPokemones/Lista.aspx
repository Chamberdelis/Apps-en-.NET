<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="PagPokemones.Formulario_web11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" />



    <h2>Aqui va la lista de Pokemones.</h2>
    <hr />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar" runat="server" />
                        <asp:TextBox ID="txtFiltrarRapido" CssClass="form-control" OnTextChanged="txtFiltrarRapido_TextChanged"
                            AutoPostBack="true" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <asp:CheckBox Text="Filtro Avanzado" AutoPostBack="true"
                            ID="chkAvanzado" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" />
                    </div>
                </div>


            </div>



            <%if (chkAvanzado.Checked)
                {%>

            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Campo" runat="server" />
                        <asp:DropDownList ID="ddlCampo" CssClass="form-control" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Tipo" />
                            <asp:ListItem Text="Numero" />
                        </asp:DropDownList>
                    </div>

                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                    </div>

                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Estado" runat="server" />
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlEstado">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                        </asp:DropDownList>
                    </div>

                </div>
            </div>

            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" CssClass="btn btn-primary" ID="btnBuscarAvanzado"
                            OnClick="btnBuscarAvanzado_Click" runat="server" />
                    </div>

                </div>

            </div>

            <%} %>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <asp:GridView ID="dgvPokemon" CssClass="table table-dark" runat="server"
                AutoGenerateColumns="false" DataKeyNames="Id"
                OnSelectedIndexChanged="dgvPokemon_SelectedIndexChanged"
                OnPageIndexChanging="dgvPokemon_PageIndexChanging"
                AllowPaging="true" PageSize="5">

                <Columns>
                    <asp:BoundField HeaderText="Numero" DataField="Numero" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                    <asp:BoundField HeaderText="Debilidad" DataField="Debilidad" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍️" />

                </Columns>

            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>


    <a href="FormPokemon.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
