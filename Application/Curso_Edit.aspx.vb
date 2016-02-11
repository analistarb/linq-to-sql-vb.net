Imports Model

Public Class Curso_Edit
    Inherits System.Web.UI.Page

    Private mdc As ModelDataContext


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Me.populateFields(Integer.Parse(Request.QueryString("id")))
            Catch generatedExceptionName As Exception

                Me.populateFields()
            End Try
        End If
    End Sub

    Protected Sub bntAtualizar_Click(sender As Object, e As EventArgs) Handles bntAtualizar.Click
        Me.onUpdate()
    End Sub


    Private Sub onUpdate()
        mdc = New ModelDataContext()
        Try
            Dim curso As Model.Curso = mdc.Curso.First(Function(cur) cur.idCurso = Integer.Parse(tbCodCurso.Text.Trim()))

            curso.Nome = tbNome.Text.Trim()
            curso.Descricao = tbDescricao.Text.Trim()
            curso.dataAtualizacao = DateTime.Parse(DateTime.Now.ToShortDateString())

            mdc.SubmitChanges()

            Response.Redirect("Curso.aspx")


        Catch generatedExceptionName As Exception
        Finally
            mdc.Dispose()
        End Try
    End Sub







    Private Sub populateFields(Optional pGetID As Integer = 0)

        mdc = New ModelDataContext()
        Try
            If pGetID > 0 Then
                Dim curso As Model.Curso = mdc.Curso.First(Function(cur) cur.idCurso = pGetID)

                tbCodCurso.Text = pGetID.ToString()
                tbNome.Text = curso.Nome.Trim()

                tbDescricao.Text = curso.Descricao.Trim()
            Else
                Response.Redirect("Materias.aspx")
            End If


        Catch generatedExceptionName As Exception
        Finally
            mdc.Dispose()
        End Try





    End Sub

End Class