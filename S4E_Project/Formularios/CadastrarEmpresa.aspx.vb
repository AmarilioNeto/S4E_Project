Imports BLL
Public Class CadastrarEmpresa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack <> True Then
                If IsPostBack <> True Then
                    Dim BLL As New EmpresaBLL
                    Dim associado = BLL.ObterAssociado()
                    If associado.Rows.Count > 0 Then
                        For index As Integer = 0 To associado.Rows.Count - 1
                            Dim nomeAssociado = associado.Rows(index).ItemArray(0)
                            Dim cpf = associado.Rows(index).ItemArray(1)
                            Dim id = associado.Rows(index).ItemArray(2)
                            Dim concat = nomeAssociado + " / " + cpf
                            ListarAssociado.Items.Add(concat)
                        Next

                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub AddAssociado_Click(sender As Object, e As EventArgs)
        Try
            If ListarAssociado.SelectedItem Is Nothing Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Você deve Escolher pelo menos uma empresa') ", True)
                Return
            Else
                AssociadosAdicionados.Items.Add(ListarAssociado.SelectedItem.Text)
                For Each index In AssociadosAdicionados.Items
                    ListarAssociado.Items.Remove(index)
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub RemoveAssociado_Click(sender As Object, e As EventArgs)
        Try
            If AssociadosAdicionados.SelectedItem Is Nothing Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Você deve Escolher pelo menos uma empresa') ", True)
                Return
            Else

                For index As Integer = 0 To AssociadosAdicionados.Items.Count - 1
                    If AssociadosAdicionados.Items(index).Selected = True Then
                        Dim item = AssociadosAdicionados.Items(index).Text
                        ListarAssociado.Items.Add(item)
                    End If
                Next

                For index As Integer = AssociadosAdicionados.Items.Count - 1 To 0 Step -1

                    If AssociadosAdicionados.Items(index).Selected = True Then
                        Dim item = AssociadosAdicionados.Items(index).Text
                        AssociadosAdicionados.Items.Remove(item)

                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Incluir_Click(sender As Object, e As EventArgs)


        Try
            Dim empresa As New DTO.Empresa

            Dim BLL As New EmpresaBLL
            empresa.Nome = nome.Text
            empresa.Cnpj = cnpj.Text.Replace(".", "").Replace("/", "").Replace("-", "").Trim()
            empresa.ListAssociados = New List(Of String)
            For Each index In AssociadosAdicionados.Items
                empresa.ListAssociados.Add(index.ToString())
            Next

            Dim verificaCnpj As String = BLL.VerificaCNPJ(empresa.Cnpj.ToString())

            If verificaCnpj <> "True" Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('CPF {empresa.Cnpj} já está Cadastrado') ", True)
                Return
            Else
                Dim assciadoSalvo As DTO.Empresa = BLL.SalvarEmpresa(empresa)
                If empresa Is Nothing Then
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Erro ao tentar Cadastra Empresa') ", True)

                    Return
                Else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Empresa Cadastrado com sucesso !!!') ", True)

                    Return
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class