Imports Model

Public Class Curso_Add
    Inherits System.Web.UI.Page

    Private mdc As ModelDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbDataCadastro.Text = DateTime.Now.ToShortDateString()
    End Sub

    Protected Sub btnCadastrar_Click(sender As Object, e As EventArgs) Handles btnCadastrar.Click
        Me.onInsert()
    End Sub


    Private Sub onInsert()
        mdc = New ModelDataContext()
        Try
            Dim curso As New Model.Curso()
            curso.idAluno = 1
            curso.idMateria = 1
            curso.Nome = tbNome.Text.Trim()
            curso.Descricao = tbDescricao.Text.Trim()
            curso.dataCadastro = Convert.ToDateTime(tbDataCadastro.Text.Trim())

            mdc.Curso.InsertOnSubmit(curso)
            mdc.SubmitChanges()


            Response.Redirect("Curso.aspx")
        Catch generatedExceptionName As Exception
            Throw
        Finally
            mdc.Dispose()
        End Try

    End Sub


End Class