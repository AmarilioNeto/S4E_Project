Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Response.Redirect(MontarURL("Formularios/CadastrarAssociado.aspx"))
    End Sub
    Protected Shared Function MontarURL(url As String) As String
        If url.StartsWith("/") Then
            url = url.Substring(1)
        End If

        Return GetBaseUrl() + url
    End Function
    Protected Shared Function GetBaseUrl()
        Dim Request = HttpContext.Current.Request
        Dim appUrl = HttpRuntime.AppDomainAppVirtualPath

        If appUrl <> "/" Then
            appUrl += "/"
        End If
        Dim baseUrl = String.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, appUrl)

            Return baseUrl
    End Function
End Class