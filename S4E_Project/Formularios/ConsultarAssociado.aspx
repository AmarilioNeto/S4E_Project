<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ConsultarAssociado.aspx.vb" Inherits="S4E_Project.ConsultarAssociado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <div class="card-header" style="margin-bottom: 12px;">
                <div class="text-header">
                    <h3 class="text-header">Consultar Associado</h3>
                </div>
            </div>
            <!-- Modal -->
            <div class="modal fade" id="modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title " id="exampleModalLongTitle" style="font-size: large; font-family: Arial">Atenção</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body" id="mensagem">
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>

                        </div>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-lg-12">
                    <div class="card card-margin">
                        <div class="card-body">
                            <div class="panel-body">
                                <div class="form" style="display: flex; justify-content: space-between">

                                    <div class="form-group" style="margin-right: 1em;">
                                        <label>Nome</label>
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="nome" placeholder="Nome do Associado"></asp:TextBox>

                                    </div>
                                    <div class="form-group" style="margin-right: 1em;">
                                        <label>Id</label>
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="Id" placeholder="Id doAssociado"></asp:TextBox>

                                    </div>
                                    <div class="form-group" style="margin-right: 1em;">
                                        <label>CPF</label>
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="cpf" placeholder="CPF do Associado"></asp:TextBox>
                                    </div>
                                    <div class="form-group" style="margin-right: 1em;">
                                        <label>Data de Nascimento</label>
                                        <asp:TextBox runat="server" type="date" class="form-control" ID="dataNascimento"></asp:TextBox>
                                    </div>
                                    <div class="form-group" style="margin-right: 1em; margin-top: auto;">
                                        <asp:Button runat="server" ID="Consultar" CssClass="btn btn-primary" Text="Consultar" OnClick="Consultar_Click" />
                                    </div>

                                </div>
                                <br />
                                <div>
                                    <asp:GridView ID="gdvAssociado" runat="server"
                                        CssClass="table table-bordered table-striped dtr-inline table-head-fixed"
                                        AutoGenerateColumns="False"
                                        EmptyDataText="Sem dados à exibir."
                                        OnRowCommand="gdvAssociado_RowCommand"
                                        DataKeyNames="Id"
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("Id") %>' runat="server" ID="lblId" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nome">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("Nome") %>' runat="server" ID="lblNome" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cpf">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("Cpf") %>' runat="server" ID="lblCpf" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Data de Nascimento">
                                                <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("DataNascimento") %>' runat="server" ID="lblDataNacimento" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" CommandArgument='<%# Container.DataItemIndex %>' CommandName="Editar" Text="Editar"  ControlStyle-CssClass="btn btn-primary btn-item" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" CommandArgument='<%# Container.DataItemIndex %>' CommandName="Excluir" Text="Excluir"  ControlStyle-CssClass="btn btn-danger btn-item" />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <script src="../Scripts/Associado-Js/Associado.js"></script>

</asp:Content>
