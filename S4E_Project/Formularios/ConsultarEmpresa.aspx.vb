Imports BLL
Public Class ConsultarEmpresa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub gdvEmpresa_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try
            If e.CommandName = "Editar" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Session("Id_Empresa") = gdvEmpresa.DataKeys(index).Value
                Response.Redirect("AlterarEmpresa.aspx")
            Else
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim id As Integer = gdvEmpresa.DataKeys(index).Value
                Dim BLL As New EmpresaBLL
                Dim Deletado As Boolean = BLL.Deletar(id)
                If Deletado Then
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Empresa Deletada com sucesso !!!') ", True)
                Else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Erro ao tentar Deletar Empresa') ", True)
                    Return
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Consultar_Click(sender As Object, e As EventArgs)
        Try
            Dim BLL As New EmpresaBLL

            Dim filtro As New Dictionary(Of String, String)
            If Not String.IsNullOrEmpty(nome.Text) Then
                filtro.Add("nome", nome.Text)
            End If
            If Not String.IsNullOrEmpty(Id.Text) Then
                filtro.Add("id", Id.Text)
            End If
            If Not String.IsNullOrEmpty(cnpj.Text) Then
                filtro.Add("cnpj", cnpj.Text)
            End If
            gdvEmpresa.DataSource = BLL.ObterEmpresa(filtro)
            gdvEmpresa.DataBind()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class