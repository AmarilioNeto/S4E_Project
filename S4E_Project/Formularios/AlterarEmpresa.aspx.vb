
Imports BLL
Public Class AlterarEmpresa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack <> True Then
                Dim id As Integer = Convert.ToInt32(Session("Id_Empresa"))
                Dim BLL As New EmpresaBLL
                If id > 0 Then
                    Dim associado = BLL.ObterEmpresaById(id)
                    nome.Text = associado.Rows(0).ItemArray(1).ToString()
                    cnpj.Text = associado.Rows(0).ItemArray(2).ToString()
                    Session("CnpjEmpresaAtual") = associado.Rows(0).ItemArray(2).ToString()

                    Dim empresasAssociadas = BLL.ObterEmpresaRelacionadasAssociado(id)
                    ' caso a Empresa for Cadastrada sem relacionamento de Associado será possivel incluir aqui o relacionamento
                    If empresasAssociadas.Rows.Count = 0 Then
                        Dim empresasNaoAssociadas = BLL.ObterAssociado()
                        If empresasNaoAssociadas.Rows.Count > 0 Then
                            For index As Integer = 0 To empresasNaoAssociadas.Rows.Count - 1
                                Dim nomeAssociado = empresasNaoAssociadas.Rows(index).ItemArray(0)
                                Dim cpf = empresasNaoAssociadas.Rows(index).ItemArray(1)
                                Dim idAssociado = empresasNaoAssociadas.Rows(index).ItemArray(2)
                                Dim concat = nomeAssociado + " / " + cpf
                                ListarAssociados.Items.Add(concat)
                            Next

                        End If
                        AssociadosJaRelacioandos.Visible = False
                        AssociadosNaoRelacioandos.Visible = True

                    Else
                        For index As Integer = 0 To empresasAssociadas.Rows.Count - 1
                            Dim nome = empresasAssociadas.Rows(index).ItemArray(1)
                            Dim cnpj = empresasAssociadas.Rows(index).ItemArray(2)
                            Dim concat = nome + " / " + cnpj
                            AssociadosRelacionados.Items.Add(concat)
                            AssociadosJaRelacioandos.Visible = True
                            AssociadosNaoRelacioandos.Visible = False
                        Next
                    End If



                Else
                    Response.Redirect("ConsultarEmpresa.aspx")

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub RemoveAssociadoRelacionado_Click(sender As Object, e As EventArgs)
        Try
            If AssociadosRelacionados.SelectedItem Is Nothing Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Você deve Escolher pelo menos uma empresa') ", True)
                Return
            Else
                AssociadosRemovidos.Items.Add(AssociadosRelacionados.SelectedItem.Text)
                For Each index In AssociadosRemovidos.Items
                    AssociadosRelacionados.Items.Remove(index)
                Next

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub AddAsscociadoRelacionado_Click(sender As Object, e As EventArgs)
        Try

            If AssociadosRemovidos.SelectedItem Is Nothing Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Você deve Escolher pelo menos uma empresa') ", True)
                Return
            Else
                AssociadosRelacionados.Items.Add(AssociadosRemovidos.SelectedItem.Text)
                For Each index In AssociadosRelacionados.Items
                    AssociadosRemovidos.Items.Remove(index)
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub AltualizarJaRelocionados_Click(sender As Object, e As EventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(Session("Id_Empresa"))
            Dim empresa As New DTO.Empresa
            Dim BLL As New EmpresaBLL
            empresa.Nome = nome.Text
            empresa.Cnpj = cnpj.Text
            empresa.ListAssociados = New List(Of String)
            For Each index In AssociadosRelacionados.Items
                empresa.ListAssociados.Add(index.ToString())
            Next
            Dim listRemovidasRelacionamento As New List(Of String)
            If AssociadosRemovidos.Items.Count > 0 Then
                For Each index In AssociadosRemovidos.Items
                    listRemovidasRelacionamento.Add(index.ToString())
                Next
            End If

            Dim verificaCpnj As String = BLL.VerificaCNPJ(empresa.Cnpj.ToString())

            If verificaCpnj <> "True" And verificaCpnj.ToString() <> Session("CnpjEmpresaAtual") Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Associado Já Cadastrado') ", True)
                Return
            Else
                Dim assciadoSalvo As DTO.Empresa = BLL.AtualizarEmpresa(empresa, id, listRemovidasRelacionamento)
                If empresa Is Nothing Then
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Erro ao tentar Atualizar Empresa') ", True)

                    Return
                Else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Empresa Atualizada com sucesso !!!') ", True)

                End If
            End If

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub AddAssociado_Click(sender As Object, e As EventArgs)
        Try
            If ListarAssociados.SelectedItem Is Nothing Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Você deve Escolher pelo menos uma empresa') ", True)
                Return
            Else
                AssociadosAdicionados.Items.Add(ListarAssociados.SelectedItem.Text)
                For Each index In AssociadosAdicionados.Items
                    ListarAssociados.Items.Remove(index)
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
                ListarAssociados.Items.Add(AssociadosAdicionados.SelectedItem.Text)
                For Each index In ListarAssociados.Items
                    AssociadosAdicionados.Items.Remove(index)
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub AtualizarNaoRelaiconados_Click(sender As Object, e As EventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(Session("Id_Empresa"))
            Dim empresa As New DTO.Empresa
            Dim BLL As New EmpresaBLL
            empresa.Nome = nome.Text
            empresa.Cnpj = cnpj.Text
            empresa.ListAssociados = New List(Of String)
            For Each index In AssociadosAdicionados.Items
                empresa.ListAssociados.Add(index.ToString())
            Next
            Dim verificaCpf As String = BLL.VerificaCNPJ(empresa.Cnpj.ToString())

            If verificaCpf <> "True" And verificaCpf.ToString() <> Session("CnpjEmpresaAtual") Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Empresa Já Cadastrada') ", True)
                Return
            Else

                Dim assciadoSalvo As DTO.Empresa = BLL.AtualizarEmpresaSemRelacionamento(empresa, id)
                If empresa Is Nothing Then
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Erro ao tentar Atualizar Empresa') ", True)

                    Return
                Else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Empresa Atualizada com sucesso !!!') ", True)

                End If
            End If

        Catch ex As Exception

        End Try

    End Sub
End Class