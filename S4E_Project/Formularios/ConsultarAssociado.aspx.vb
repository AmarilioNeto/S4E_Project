
Imports BLL
Public Class ConsultarAssociado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub Consultar_Click(sender As Object, e As EventArgs)
        Try
            Dim BLL As New AssociadoBLL

            Dim filtro As New Dictionary(Of String, String)
            If Not String.IsNullOrEmpty(nome.Text) Then
                filtro.Add("nome", nome.Text)
            End If
            If Not String.IsNullOrEmpty(Id.Text) Then
                filtro.Add("id", Id.Text)
            End If
            If Not String.IsNullOrEmpty(cpf.Text) Then
                filtro.Add("cpf", cpf.Text)
            End If
            If Not String.IsNullOrEmpty(dataNascimento.Text) Then
                filtro.Add("dataNascimento", dataNascimento.Text)
            End If
            gdvAssociado.DataSource = BLL.ObterAssociados(filtro)
            gdvAssociado.DataBind()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub gdvAssociado_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try
            If e.CommandName = "Editar" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Session("Id_Associado") = gdvAssociado.DataKeys(index).Value
                Response.Redirect("AlterarAssociado.aspx")
            Else
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim id As Integer = gdvAssociado.DataKeys(index).Value
                Dim BLL As New AssociadoBLL
                Dim Deletado As Boolean = BLL.Deletar(id)
                If Deletado Then
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Associado Deletado com sucesso !!!') ", True)
                Else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp(''Erro ao tentar Deletar Associado') ", True)
                    Return
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class