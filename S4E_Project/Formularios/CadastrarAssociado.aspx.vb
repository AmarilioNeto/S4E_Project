Imports BLL

Public Class CadastrarAssociado
    Inherits System.Web.UI.Page

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim BLL As New AssociadoBLL
        Dim empresas = BLL.ObterEmpresas()
        If empresas.Rows.Count > 0 Then
            For index As Integer = 0 To empresas.Rows.Count - 1
                Dim nomeEmpresa = empresas.Rows(index).ItemArray(0)
                Dim cnpj = empresas.Rows(index).ItemArray(1)
                Dim Concat = nomeEmpresa + " / " + cnpj
                ListEmpresa.Items.Add(Concat)
                'parei quei tentaNDO FZER ALGUMA COISA PARA PEGAR AS EMPRESAS E SALVAR
            Next

        End If

    End Sub
    Protected Sub Incluir_Click(sender As Object, e As EventArgs)
        Dim associado As New DTO.Associado
        Dim BLL As New AssociadoBLL
        associado.Nome = nome.Text
        associado.Cpf = cpf.Text
        associado.DataNascimento = Convert.ToDateTime(dataNascimento.Text)

        Dim verificaCpf As String = BLL.VerificaCPF(associado.Cpf.ToString())
        Dim cpfVerificado = verificaCpf
        If cpfVerificado = False Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alerta", $"alertaPopUp('CPF {associado.Cpf} já está Cadastrado') ", True)
            Return
        Else

            Dim assciadoSalvo As DTO.Associado = BLL.Salvar(associado)
        End If

    End Sub
End Class