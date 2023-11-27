Imports DTO
Imports DAL
Imports System.Data.SqlClient

Public Class EmpresaBLL
    Implements IEmpresa

    Public Function ObterAssociado() As DataTable Implements IEmpresa.ObterAssociado
        Try
            Dim sql As String = $"select Nome, Cpf, Id from Associado"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            Return table
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function VerificaCNPJ(cpnj As String) As String Implements IEmpresa.VerificaCNPJ
        Try

            Dim sql As String = $"select Cnpj from Empresa where Cnpj = '{cpnj}'"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            If table.Rows.Count = 0 Then
                Return "True"
            Else
                Return table.Rows(0).ItemArray(0)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function SalvarEmpresa(empresa As Empresa) As Empresa Implements IEmpresa.SalvarEmpresa
        Try

            Dim sql As String = $"Insert into Empresa (Nome, Cnpj) values('{empresa.Nome}','{empresa.Cnpj}')"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            For Each Index In empresa.ListAssociados
                Dim sql2 As String = $"exec SalvarAssociadoEmpresa '{empresa.Cnpj}','{Index.Split("/")(1).Trim()}' "
                Dim table2 As New DataTable
                table = AcessoDAL.GetDataTable(sql2)
            Next
            Return GetEmpresa(table)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetEmpresa(ByVal table As DataTable) As Empresa
        Try
            'transformandoo resultado tabela em objeto associado
            Dim _associado As New Empresa
            If table.Rows.Count > 0 Then
                _associado.Nome = table.Rows(0).ItemArray(1)
                _associado.Cnpj = table.Rows(0).ItemArray(2)
                Return _associado
            Else
                _associado = Nothing
                Return _associado
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function Deletar(id As Integer) As Boolean Implements IEmpresa.Deletar
        Try
            Dim sql As String = $"exec DeletarEmpresaById @id = {id}"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            If table.Rows.Count = 0 Then
                Return True
            Else
                Return False

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObterEmpresa(filtro As Dictionary(Of String, String)) As DataTable Implements IEmpresa.ObterEmpresa
        Try
            Dim id = 0
            Dim nome = ""
            Dim cnpj = ""
            For Each valor In filtro
                If valor.Key = "nome" Then
                    nome = valor.Value
                End If
                If valor.Key = "id" Then
                    id = Convert.ToInt32(valor.Value)
                End If
                If valor.Key = "cpf" Then
                    cnpj = valor.Value
                End If
            Next

            Dim sql As String = $"exec ObterEmpresaByFiltro @Id = {id}, @Nome = '{nome}', @Cnpj = '{cnpj}'"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            Return table
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObterEmpresaById(id As Integer) As DataTable Implements IEmpresa.ObterEmpresaById
        Try
            Dim sql As String = $"select Id, Nome, Cnpj from Empresa where Id = {id}"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            Return table
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ObterEmpresaRelacionadasAssociado(id As Integer) As DataTable Implements IEmpresa.ObterEmpresaRelacionadasAssociado
        Try
            Dim sql As String = $"exec ObterAssociadosRelacionadasEmpresa @id= {id}"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            Return table
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function AtualizarEmpresa(empresa As Empresa, id As Integer, listRemovidasRelacionamento As List(Of String)) As Empresa Implements IEmpresa.AtualizarEmpresa
        Try
            If listRemovidasRelacionamento.Count > 0 Then
                For Each Index In listRemovidasRelacionamento
                    Dim sql3 As String = $"delete Associado_Empresa where Empresa_Id = {id} and Associado_CPF = '{Index.Split("/")(1).Trim()}' "
                    Dim table3 As New DataTable
                    table3 = AcessoDAL.GetDataTable(sql3)

                Next
            End If
            Dim sql As String = $"Update Empresa set Nome = '{empresa.Nome}', Cnpj = '{empresa.Cnpj}' where id = {id}"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            If empresa.ListAssociados.Count > 0 Then
                For Each Index In empresa.ListAssociados
                    Dim sql2 As String = $"exec UpdateEmpresaAssociado '{empresa.Cnpj}', {id} ,'{Index.Split("/")(1).Trim()}'"
                    Dim table2 As New DataTable
                    table = AcessoDAL.GetDataTable(sql2)
                Next
            End If
            Return GetEmpresa(table)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function AtualizarEmpresaSemRelacionamento(empresa As Empresa, id As Integer) As Empresa Implements IEmpresa.AtualizarEmpresaSemRelacionamento
        Try
            Dim sql As String = $"Update Empresa set Nome = '{empresa.Nome}', Cnpj = '{empresa.Cnpj}' where id = {id}"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            For Each Index In empresa.ListAssociados
                Dim sql2 As String = $"exec SalvarAssociadoEmpresa '{empresa.Cnpj}','{Index.Split("/")(1).Trim()}' "
                Dim table2 As New DataTable
                table = AcessoDAL.GetDataTable(sql2)
            Next
            Return GetEmpresa(table)
        Catch ex As Exception
            Throw ex
        End Try

    End Function
End Class
