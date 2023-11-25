
Imports DTO
Public Interface IAssociado
    Function Salvar(associado As Associado) As Associado
    Function VerificaCPF(cpf As String) As String
    Function ObterEmpresas() As DataTable
End Interface
