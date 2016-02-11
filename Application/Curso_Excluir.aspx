﻿<%@ Page Title="" Language="vb" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Curso_Excluir.aspx.vb" Inherits="Application.Curso_Excluir" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">
    
    <asp:Panel runat="server" ID="pnlExcluir" Visible="true">
        <h1>Excluir Curso</h1>
        <ul>
            <li>
                <asp:Label Text="Cód. Curso" ID="label1" runat="server"></asp:Label>
                <asp:TextBox ID="tbCodCurso" Text="" Enabled="False" CssClass="disable radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Nome" runat="server" Text="Descrição"></asp:Label>
                <asp:TextBox ID="tbNome" Enabled="False" CssClass="disable radiusInput" runat="server"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="Label3" runat="server" Text="Data de Cadastro"></asp:Label>
                <asp:TextBox ID="tbDescricao" Enabled="False" CssClass="disable radiusInput" runat="server"></asp:TextBox>
            </li>

            <li>
                <asp:Button ID="btnExcluir" CssClass="btnDelete btn" OnClick="btnExcluir_Click"  runat="server" Text="Excluir" />
            </li>
        </ul>
    </asp:Panel>
    

</asp:Content>
