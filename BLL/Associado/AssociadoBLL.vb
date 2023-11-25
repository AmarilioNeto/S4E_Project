
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
            Return GetAssociado(table)
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
            Dim sql As String = $"select Nome, Cnpj from Empresa"
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
