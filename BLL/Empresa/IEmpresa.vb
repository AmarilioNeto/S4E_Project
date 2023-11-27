Imports DTO

Public Interface IEmpresa
    Function ObterAssociado() As DataTable
    Function VerificaCNPJ(cpnj As String) As String
    Function SalvarEmpresa(empresa As Empresa) As Empresa
    Function Deletar(id As Integer) As Boolean
    Function ObterEmpresa(filtro As Dictionary(Of String, String)) As DataTable
    Function ObterEmpresaById(id As Integer) As DataTable
    Function ObterEmpresaRelacionadasAssociado(id As Integer) As DataTable
    Function AtualizarEmpresa(empresa As Empresa, id As Integer, listRemovidasRelacionamento As List(Of String)) As Empresa
    Function AtualizarEmpresaSemRelacionamento(empresa As Empresa, id As Integer) As Empresa

End Interface
