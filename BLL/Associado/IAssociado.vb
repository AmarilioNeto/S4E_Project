
Imports DTO
Public Interface IAssociado
    Function Salvar(associado As Associado) As Associado
    Function VerificaCPF(cpf As String) As String
    Function ObterEmpresas() As DataTable
    Function ObterAssociados(filtro As Dictionary(Of String, String)) As DataTable
    Function Deletar(id As Integer) As Boolean
    Function ObterAssciadoById(id As Integer) As DataTable
    Function ObterEmpresaRelacionadasAssociado(id As Integer) As DataTable
    Function AtualizarAssocido(associado As Associado, id As Integer, listRemovidasRelacionamento As List(Of String)) As Associado
    Function AtualizarAssociadoSemRelacionamento(associado As Associado, id As Integer) As Associado
End Interface
