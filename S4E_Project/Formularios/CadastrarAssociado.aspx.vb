Imports BLL

Public Class CadastrarAssociado
    Inherits System.Web.UI.Page

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack <> True Then
                Dim BLL As New AssociadoBLL
                Dim empresas = BLL.ObterEmpresas()
                If empresas.Rows.Count > 0 Then
                    For index As Integer = 0 To empresas.Rows.Count - 1
                        Dim nomeEmpresa = empresas.Rows(index).ItemArray(0)
                        Dim cnpj = empresas.Rows(index).ItemArray(1)
                        Dim id = empresas.Rows(index).ItemArray(2)
                        Dim concat = nomeEmpresa + " / " + cnpj
                        ListarEmpresa.Items.Add(concat)
                    Next

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub Incluir_Click(sender As Object, e As EventArgs)
        Try
            Dim associado As New DTO.Associado

            Dim BLL As New AssociadoBLL
            associado.Nome = nome.Text
            associado.Cpf = cpf.Text.Replace(".", "").Replace("-", "").Trim()
            associado.DataNascimento = Convert.ToDateTime(dataNascimento.Text)
            associado.ListEmpresas = New List(Of String)
            For Each index In EmpresasAdicionadas.Items
                associado.ListEmpresas.Add(index.ToString())
            Next

            Dim verificaCpf As String = BLL.VerificaCPF(associado.Cpf.ToString())

            If verificaCpf <> "True" Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('CPF {associado.Cpf} já está Cadastrado') ", True)
                Return
            Else
                Dim assciadoSalvo As DTO.Associado = BLL.Salvar(associado)
                If associado Is Nothing Then
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Erro ao tentar Cadastra Associado') ", True)

                    Return
                Else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Associado Cadastrado com sucesso !!!') ", True)

                    Return
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub AddEmpresa_Click(sender As Object, e As EventArgs)
        Try
            If ListarEmpresa.SelectedItem Is Nothing Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Você deve Escolher pelo menos uma empresa') ", True)
                Return
            Else
                EmpresasAdicionadas.Items.Add(ListarEmpresa.SelectedItem.Text)
                For Each index In EmpresasAdicionadas.Items
                    ListarEmpresa.Items.Remove(index)
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub RemoveEmpresa_Click(sender As Object, e As EventArgs)
        Try
            If EmpresasAdicionadas.SelectedItem Is Nothing Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Você deve Escolher pelo menos uma empresa') ", True)
                Return
            Else
                For index As Integer = 0 To EmpresasAdicionadas.Items.Count - 1
                    If EmpresasAdicionadas.Items(index).Selected = True Then
                        Dim item = EmpresasAdicionadas.Items(index).Text
                        ListarEmpresa.Items.Add(item)
                    End If
                Next

                For index As Integer = EmpresasAdicionadas.Items.Count - 1 To 0 Step -1

                    If EmpresasAdicionadas.Items(index).Selected = True Then
                        Dim item = EmpresasAdicionadas.Items(index).Text
                        EmpresasAdicionadas.Items.Remove(item)

                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class