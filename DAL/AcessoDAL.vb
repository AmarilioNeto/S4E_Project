Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DTO
Public Class AcessoDAL
    Private Shared Function GetDbConnection() As SqlConnection
        Try

            Dim conString As String = ConfigurationManager.ConnectionStrings("ConnetionString").ConnectionString
            Dim connection As SqlConnection = New SqlConnection(conString)
            connection.Open()
            Return connection
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Overloads Shared Function GetDataTable(ByVal sql As String) As DataTable
        Using connection As SqlConnection = GetDbConnection()
            Using da As New SqlDataAdapter(sql, connection)
                Dim Table As New DataTable
                da.Fill(Table)
                Return Table
            End Using
        End Using
    End Function
End Class
