<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CadastrarEmpresa.aspx.vb" Inherits="S4E_Project.CadastrarEmpresa" %>
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
                    <h3 class="text-header">Cadastra Empresa</h3>
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
                                <div class="form">
                                    <div class="form-group">
                                        <label>Nome</label>
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="nome" placeholder="Nome do Empresa"></asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <label>CNPJ</label>
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="cnpj" placeholder="CNPJ do Empresa"></asp:TextBox>
                                    </div>
                                   
                                    <div class="form-group ">
                                       
                                        <label>Associado</label>
                                        <asp:DropDownList runat="server" SelectionMode="Multiple" DataValueField ="id"  CssClass="form-control" ID="ListarAssociado">
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Button runat="server" ID="AddAssociado" CssClass ="btn btn-success" Text ="Incluir Associado" OnClick="AddAssociado_Click" />
                                    </div>
                                     <div class="form-group">
                                        <label>Associados Adcionads</label>
                                        <asp:ListBox runat="server"  SelectionMode="Multiple"  class="form-control" ID="AssociadosAdicionados"></asp:ListBox>
                                         <br />
                                         <asp:Button runat="server" ID="RemoveAssociado" CssClass ="btn btn-danger" Text ="Remover Associado" OnClick="RemoveAssociado_Click" />
                                    </div>

                                    
                                       <asp:Button runat="server" ID="Incluir" CssClass="btn btn-primary" Text="Salvar" OnClick="Incluir_Click" />
 
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
