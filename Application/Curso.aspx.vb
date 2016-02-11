Imports Model

Public Class Curso
    Inherits System.Web.UI.Page

    Private mdc As ModelDataContext



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.populateGrid()
        End If
    End Sub

    Private Sub populateGrid(Optional pIndex As Integer = -1)
        mdc = New ModelDataContext()

        Try
            Dim sourceCurso = From cur In mdc.Curso

            Select Case pIndex
                Case 0
                    If True Then
                        sourceCurso = From cur In mdc.Curso Where cur.idCurso = Integer.Parse(tbPesqID.Text.Trim())

                        Exit Select
                    End If
                Case 1
                    If True Then
                        sourceCurso = From cur In mdc.Curso Where cur.Nome.Contains(tbPesqNome.Text.Trim())

                        Exit Select
                    End If
                Case 2
                    If True Then
                        sourceCurso = From cur In mdc.Curso Where cur.Descricao.Contains(tbPesqDescricao.Text.Trim())

                        Exit Select
                    End If

            End Select



            gwDados.DataSource = sourceCurso
            gwDados.DataBind()
        Catch generatedExceptionName As Exception
            Throw
        Finally
            mdc.Dispose()
        End Try

    End Sub


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.populateGrid(rlbTypeSearch.SelectedIndex)
    End Sub

    Protected Sub btnLimpaPesq_Click(sender As Object, e As EventArgs) Handles btnLimpaPesq.Click
        Me.populateGrid()
        tbPesqID.Text = ""
        tbPesqNome.Text = ""
        tbPesqDescricao.Text = ""
    End Sub
End Class