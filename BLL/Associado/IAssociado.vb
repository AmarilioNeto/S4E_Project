
Imports DTO
Public Interface IAssociado
    Function Salvar(associado As Associado) As Associado
    Function VerificaCPF(cpf As String) As String
    Function ObterEmpresas() As DataTable
    Function ObterAssociados(filtro As Dictionary(Of String, String)) As DataTable
    Function Deletar(id As Integer) As Boolean
    Function ObterAssciadoById(id As Integer) As DataTable
    Function ObterEmpresaRelacionadasAssociado(id As Integer) As DataTable
End Interface
