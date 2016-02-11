Imports Model

Public Class Aluno_Add
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbDataCadastro.Text = DateTime.Now.ToShortDateString()
    End Sub

    Private Sub onInsert()

        Try
            Using mdc As New ModelDataContext()
                Dim aluno As New Model.Aluno()
                aluno.Nome = tbNome.Text.Trim()
                aluno.Endereco = tbEndereco.Text.Trim()
                aluno.Cep = tbCEP.Text.Trim()
                aluno.Telefone = tbTelefone.Text.Trim()
                aluno.Celular = tbCelular.Text.Trim()
                aluno.dataNascimento = DateTime.Parse(tbDataNasc.Text.Trim())
                aluno.dataCadastro = DateTime.Parse(DateTime.Now.ToShortDateString())
					
                mdc.Aluno.InsertOnSubmit(Aluno)
                mdc.SubmitChanges()


                Response.Redirect("Aluno.aspx")
            End Using
        Catch generatedExceptionName As Exception
            Throw
        End Try



    End Sub


    Protected Sub btnCadastrar_Click(sender As Object, e As EventArgs) Handles btnCadastrar.Click
        onInsert()
    End Sub
End Class