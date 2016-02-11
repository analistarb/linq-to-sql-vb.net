Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Model


Public Class Materias_Add
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
            Dim materia As New Materia()

            materia.Nome = tbNome.Text.Trim()
            materia.Descricao = tbDescricao.Text.Trim()
            materia.dataCadastro = Convert.ToDateTime(tbDataCadastro.Text.Trim())

            mdc.Materia.InsertOnSubmit(materia)
            mdc.SubmitChanges()


            Response.Redirect("Materias.aspx")
        Catch generatedExceptionName As Exception
            Throw
        Finally
            mdc.Dispose()
        End Try

    End Sub



End Class