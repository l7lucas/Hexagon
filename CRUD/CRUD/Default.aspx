<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">
        <h1>Bem Vindo!</h1>
        <br /> 
        <p class="lead">Projeto CRUD de usuário,</p>        
        <p>referente ao exercício de conhecimento HEXAGON.
        </p>
        <br />
        <br />
        <a runat="server" href="~/cadastro" class="btn btn-primary btn-lg">Tela de Cadastro</a>

    </div>

    
    

</asp:Content>
