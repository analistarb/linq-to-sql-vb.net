﻿Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Model


Public Class Materias_Excluir
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

            Dim materia As Materia = mdc.Materia.First(Function(mat) mat.idMateria = Integer.Parse(tbCodigo.Text.Trim()))

            mdc.Materia.DeleteOnSubmit(materia)
            mdc.SubmitChanges()


            Response.Redirect("Materias.aspx")


        Catch generatedExceptionName As Exception
        Finally
            mdc.Dispose()
        End Try
    End Sub







    Private Sub populateFields(Optional pGetID As Integer = 0)

        mdc = New ModelDataContext()
        Try
            If pGetID > 0 Then

                Dim materia As Materia = mdc.Materia.First(Function(mat) mat.idMateria = pGetID)

                tbCodigo.Text = pGetID.ToString()
                tbNome.Text = materia.Nome.Trim()

                tbDescricao.Text = materia.Descricao.Trim()
            Else
                Response.Redirect("Materias.aspx")
            End If


        Catch generatedExceptionName As Exception
        Finally
            mdc.Dispose()
        End Try
    End Sub




End Class