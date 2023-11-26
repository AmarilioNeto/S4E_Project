Imports BLL
Public Class AlterarAssociado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer = Convert.ToInt32(Session("Id_Associado"))
        Dim BLL As New AssociadoBLL
        If id > 0 Then
            Dim associado = BLL.ObterAssciadoById(id)
            Dim Data As DateTime = Convert.ToDateTime(associado.Rows(0).ItemArray(3).ToString())
            nome.Text = associado.Rows(0).ItemArray(1).ToString()
            cpf.Text = associado.Rows(0).ItemArray(2).ToString()
            dataNascimento.Text = Data.ToString("yyyy-MM-dd")
            Dim empresasAssociadas = BLL.ObterEmpresaRelacionadasAssociado(id)
            For index As Integer = 0 To empresasAssociadas.Rows.Count - 1
                Dim nome = empresasAssociadas.Rows(index).ItemArray(1)
                Dim cnpj = empresasAssociadas.Rows(index).ItemArray(2)
                Dim concat = nome + " / " + cnpj
                EmpresasRelacionadas.Items.Add(concat)
                'parei aqui falta  desvincular da emprasa ao associado e testar cpf antes de salvar a alteração
            Next

        Else
            Response.Redirect("ConsultarAssociado.aspx")

        End If


    End Sub

End Class