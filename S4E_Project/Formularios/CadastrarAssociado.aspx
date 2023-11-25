<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CadastrarAssociado.aspx.vb" Inherits="S4E_Project.CadastrarAssociado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <style>
        select.form-control:not([size]):not([multiple]) {
            height: calc(2.25rem + 11px);
        }
    </style>
    <section class="content">
        <div class="container-fluid">
            <div class="card-header" style="margin-bottom: 12px;">
                <div class="text-header">
                    <h3 class="text-header">Cadastra Associado</h3>
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
                <div class="col-12">
                    <div class="card card-margin">
                        <div class="card-body">
                            <div class="panel-body">
                                <div class="form">
                                    <div class="form-group">
                                        <label>Nome</label>
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="nome" placeholder="Nome do Associado"></asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <label>CPF</label>
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="cpf" placeholder="CPF do Associado"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Data de Nascimento</label>
                                        <asp:TextBox runat="server" type="date" class="form-control" ID="dataNascimento"></asp:TextBox>
                                    </div>
                                    <div class="form">
                                        <label>Empresas</label>
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ListEmpresa">
                                        </asp:DropDownList>
                                    </div>


                                    <%--   <asp:Button runat="server" ID="Incluir" CssClass="btn btn-primary" Text="Incluir" OnClick="Incluir_Click" />--%>
                                    <%-- <button id ="addEmpresa" class="btn btn-success" onclick="IncluirEmpresa()">Incluir Empresa</button>--%>
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
