Imports BLL
Public Class AlterarAssociado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack <> True Then
                Dim id As Integer = Convert.ToInt32(Session("Id_Associado"))
                Dim BLL As New AssociadoBLL
                If id > 0 Then
                    Dim associado = BLL.ObterAssciadoById(id)
                    Dim Data As DateTime = Convert.ToDateTime(associado.Rows(0).ItemArray(3).ToString())
                    nome.Text = associado.Rows(0).ItemArray(1).ToString()
                    cpf.Text = associado.Rows(0).ItemArray(2).ToString()
                    Session("CpfAssociadoAtual") = associado.Rows(0).ItemArray(2).ToString()
                    dataNascimento.Text = Data.ToString("yyyy-MM-dd")

                    Dim empresasAssociadas = BLL.ObterEmpresaRelacionadasAssociado(id)
                    ' caso o Associado for Cadastrado sem relacionamento de empresa será possivel incluir aqui o relacionamento
                    If empresasAssociadas.Rows.Count = 0 Then
                        Dim empresasNaoAssociadas = BLL.ObterEmpresas()
                        If empresasNaoAssociadas.Rows.Count > 0 Then
                            For index As Integer = 0 To empresasNaoAssociadas.Rows.Count - 1
                                Dim nomeEmpresa = empresasNaoAssociadas.Rows(index).ItemArray(0)
                                Dim cnpj = empresasNaoAssociadas.Rows(index).ItemArray(1)
                                Dim idEmpresa = empresasNaoAssociadas.Rows(index).ItemArray(2)
                                Dim concat = nomeEmpresa + " / " + cnpj
                                ListarEmpresa.Items.Add(concat)
                            Next

                        End If
                        EmpresasJaRelacioandas.Visible = False
                        EmpresasNaoRelacioandas.Visible = True

                    Else
                        For index As Integer = 0 To empresasAssociadas.Rows.Count - 1
                            Dim nome = empresasAssociadas.Rows(index).ItemArray(1)
                            Dim cnpj = empresasAssociadas.Rows(index).ItemArray(2)
                            Dim concat = nome + " / " + cnpj
                            EmpresasRelacionadas.Items.Add(concat)
                            EmpresasJaRelacioandas.Visible = True
                            EmpresasNaoRelacioandas.Visible = False
                        Next
                    End If



                Else
                    Response.Redirect("ConsultarAssociado.aspx")

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub RemoveEmpresaRelacionada_Click(sender As Object, e As EventArgs)
        Try
            If EmpresasRelacionadas.SelectedItem Is Nothing Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Você deve Escolher pelo menos uma empresa') ", True)
                Return
            Else
                EmpresasRemovidas.Items.Add(EmpresasRelacionadas.SelectedItem.Text)
                For Each index In EmpresasRemovidas.Items
                    EmpresasRelacionadas.Items.Remove(index)
                Next

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub AddEmpresasRelacioanda_Click(sender As Object, e As EventArgs)
        Try

            If EmpresasRemovidas.SelectedItem Is Nothing Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Você deve Escolher pelo menos uma empresa') ", True)
                Return
            Else
                EmpresasRelacionadas.Items.Add(EmpresasRemovidas.SelectedItem.Text)
                For Each index In EmpresasRelacionadas.Items
                    EmpresasRemovidas.Items.Remove(index)
                Next
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
                ListarEmpresa.Items.Add(EmpresasAdicionadas.SelectedItem.Text)
                For Each index In ListarEmpresa.Items
                    EmpresasAdicionadas.Items.Remove(index)
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub AtualizarNaoRelaiconadas_Click(sender As Object, e As EventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(Session("Id_Associado"))
            Dim associado As New DTO.Associado
            Dim BLL As New AssociadoBLL
            associado.Nome = nome.Text
            associado.Cpf = cpf.Text
            associado.DataNascimento = Convert.ToDateTime(dataNascimento.Text)
            associado.ListEmpresas = New List(Of String)
            For Each index In EmpresasAdicionadas.Items
                associado.ListEmpresas.Add(index.ToString())
            Next
            Dim verificaCpf As String = BLL.VerificaCPF(associado.Cpf.ToString())

            If verificaCpf <> "True" And verificaCpf.ToString() <> Session("CpfAssociadoAtual") Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Associado Já Cadastrado') ", True)
                Return
            Else

                Dim assciadoSalvo As DTO.Associado = BLL.AtualizarAssociadoSemRelacionamento(associado, id)
                If associado Is Nothing Then
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Erro ao tentar Atualizar Associado') ", True)

                    Return
                Else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Associado Atualizado com sucesso !!!') ", True)

                End If
            End If

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub AltualizarJaRelocionadas_Click(sender As Object, e As EventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(Session("Id_Associado"))
            Dim associado As New DTO.Associado
            Dim BLL As New AssociadoBLL
            associado.Nome = nome.Text
            associado.Cpf = cpf.Text
            associado.DataNascimento = Convert.ToDateTime(dataNascimento.Text)
            associado.ListEmpresas = New List(Of String)
            For Each index In EmpresasRelacionadas.Items
                associado.ListEmpresas.Add(index.ToString())
            Next
            Dim listRemovidasRelacionamento As New List(Of String)
            If EmpresasRemovidas.Items.Count > 0 Then
                For Each index In EmpresasRemovidas.Items
                    listRemovidasRelacionamento.Add(index.ToString())
                Next
            End If

            Dim verificaCpf As String = BLL.VerificaCPF(associado.Cpf.ToString())

            If verificaCpf <> "True" And verificaCpf.ToString() <> Session("CpfAssociadoAtual") Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Associado Já Cadastrado') ", True)
                Return
            Else
                Dim assciadoSalvo As DTO.Associado = BLL.AtualizarAssocido(associado, id, listRemovidasRelacionamento)
                If associado Is Nothing Then
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Erro ao tentar Atualizar Associado') ", True)

                    Return
                Else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('Associado Atualizado com sucesso !!!') ", True)

                End If
            End If

        Catch ex As Exception

        End Try

    End Sub
End Class