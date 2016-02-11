Imports Model

Public Class Aluno_Excluir
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

    Protected Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        Me.onDelete()
    End Sub


    Private Sub onDelete()
        mdc = New ModelDataContext()
        Try

            Dim aluno As Model.Aluno = mdc.Aluno.First(Function(alun) alun.idAluno = Integer.Parse(tbCodAluno.Text.Trim()))

            mdc.Aluno.DeleteOnSubmit(aluno)
            mdc.SubmitChanges()


            Response.Redirect("Aluno.aspx")


        Catch generatedExceptionName As Exception
        Finally
            mdc.Dispose()
        End Try
    End Sub







    Private Sub populateFields(Optional pGetID As Integer = 0)

        mdc = New ModelDataContext()
        Try
            If pGetID > 0 Then
                Dim aluno As Model.Aluno = mdc.Aluno.First(Function(alun) alun.idAluno = pGetID)

                tbCodAluno.Text = pGetID.ToString()
                tbNome.Text = aluno.Nome.Trim()
                tbEndereco.Text = aluno.Endereco.Trim()


                tbCEP.Text = aluno.Cep.Trim()
                tbTelefone.Text = aluno.Telefone.Trim()
                tbCelular.Text = aluno.Celular.Trim()

                tbDataNasc.Text = DateTime.Parse(aluno.dataNascimento.ToString()).ToShortDateString()
                tbDataCadastro.Text = DateTime.Parse(aluno.dataCadastro.ToString()).ToShortDateString()
            Else
                Response.Redirect("Aluno.aspx")
            End If


        Catch generatedExceptionName As Exception
        Finally
            mdc.Dispose()
        End Try





    End Sub

End Class