
Imports DTO
Imports DAL
Imports System.Data.SqlClient
Public Class AssociadoBLL
    Implements IAssociado
    Public Function Salvar(associado As Associado) As Associado Implements IAssociado.Salvar
        Try

            Dim sql As String = $"Insert into Associado (Nome, Cpf, DataNascimento) values('{associado.Nome}','{associado.Cpf}', '{associado.DataNascimento}')"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            For Each Index In associado.ListEmpresas
                Dim sql2 As String = $"exec SalvarAssociadoEmpresa '{Index.Split("/")(1).Trim()}', '{associado.Cpf}'"
                Dim table2 As New DataTable
                table = AcessoDAL.GetDataTable(sql2)
            Next
            Return GetAssociado(table)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Deletar(id As Integer) As Boolean Implements IAssociado.Deletar
        Try
            Dim sql As String = $"exec DeletarAssociadoById @id = {id}"
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
    Public Function VerificaCPF(cpf As String) As String Implements IAssociado.VerificaCPF
        Try

            Dim sql As String = $"select cpf from Associado where cpf = '{cpf}'"
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
    Public Function ObterEmpresas() As DataTable Implements IAssociado.ObterEmpresas
        Try
            Dim sql As String = $"select Nome, Cnpj, Id from Empresa"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            Return table
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ObterAssciadoById(id As Integer) As DataTable Implements IAssociado.ObterAssciadoById
        Try
            Dim sql As String = $"select Id, Nome, Cpf, DataNascimento from Associado where Id = {id}"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            Return table
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ObterEmpresaRelacionadasAssociado(id As Integer) As DataTable Implements IAssociado.ObterEmpresaRelacionadasAssociado
        Try
            Dim sql As String = $"exec ObterEmpresaRelacionadasAssociado @id= {id}"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            Return table
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ObterAssociados(filtro As Dictionary(Of String, String)) As DataTable Implements IAssociado.ObterAssociados
        Try
            Dim id = 0
            Dim nome = ""
            Dim cpf = ""
            Dim dataNasicmento = ""
            For Each valor In filtro
                If valor.Key = "nome" Then
                    nome = valor.Value
                End If
                If valor.Key = "id" Then
                    id = Convert.ToInt32(valor.Value)
                End If
                If valor.Key = "cpf" Then
                    cpf = valor.Value
                End If
                If valor.Key = "dataNascimento" Then
                    dataNasicmento = valor.Value
                End If
            Next

            Dim sql As String = $"exec ObterAssociadoByFiltro @Id = {id}, @Nome = '{nome}', @Cpf = '{cpf}', @DataNascimento='{dataNasicmento}'"
            Dim table As New DataTable
            table = AcessoDAL.GetDataTable(sql)
            Return table
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetAssociado(ByVal table As DataTable) As Associado
        Try
            'transformandoo resultado tabela em objeto associado
            Dim _associado As New Associado
            If table.Rows.Count > 0 Then
                _associado.Nome = table.Rows(0).ItemArray(1)
                _associado.Cpf = table.Rows(0).ItemArray(2)
                _associado.DataNascimento = table.Rows(0).ItemArray(3)
                Return _associado
            Else
                _associado = Nothing
                Return _associado
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
