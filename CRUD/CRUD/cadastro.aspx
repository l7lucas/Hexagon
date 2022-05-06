<%@ Page Title="Cadastro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="CRUD.cadastro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <script>

        // CPF
        function vCPF() {
            var cpf = document.getElementById("txt_cpf").value;
            var cpfValido = /^(([0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2})|([0-9]{11}))$/;
            if (cpfValido.test(cpf) == true) {
                document.getElementById("CPFVal").style.display = 'block';
                document.getElementById("CPFInv").style.display = 'none';
            } else {
                document.getElementById("CPFVal").style.display = 'none';
                document.getElementById("CPFInv").style.display = 'block';
            }
        }

        function fCPF(objeto, mascara) {
            obj = objeto
            masc = mascara
            setTimeout("fMascEx()", 1)
        }

        function fMascEx() {
            obj.value = masc(obj.value)
        }

        function mCPF(cpf) {
            cpf = cpf.replace(/\D/g, "")
            cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
            cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
            cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
            return cpf
        }

        //RG

        function fRG(objeto, mascara) {
            obj = objeto
            masc = mascara
            setTimeout("fRGEx()", 1)
        }

        function fRGEx() {
            obj.value = masc(obj.value)
        }

        function mRG(rg) {
            rg = rg.replace(/\D/g, "")
            rg = rg.replace(/(\d{2})(\d)/, "$1.$2")
            rg = rg.replace(/(\d{3})(\d)/, "$1.$2")
            rg = rg.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
            return rg
        }

        function ConfirmDelete() {
            return confirm("Excluir Usuário?");
        }

    </script>

    <div class="text-center">
        <h2 class="display-4">Cadastrar Novo Usuário</h2>
        <br />
    </div>


    <div class="centralize">
        <table align="center" style="height: 200px; width: 300px">
            <tr>
                <td style="text-align: left;">
                    <label>ID</label></td>
                <td>
                    <input type="text" runat="server" name="txt_id" id="txt_id" maxlength="50"></td>
            </tr>
            <tr>
                <td style="text-align: left;">
                    <label>Nome</label></td>
                <td>
                    <input type="text" runat="server" name="txt_nome" id="txt_nome" maxlength="50"></td>
            </tr>
            <tr>
                <td width="50%" style="text-align: left;">
                    <label>Sobrenome</label></td>
                <td>
                    <input type="text" runat="server" name="txt_sobrenome" id="txt_sobrenome" maxlength="200"></td>
            </tr>
            <tr>
                <td width="50%">
                    <div id="CPFVal" style="display: block">
                        <label>CPF</label>
                    </div>
                    <div id="CPFInv" style="display: none">
                        <font color="red">CPF Inválido</font>
                    </div>
                </td>
                <td>
                    <input type="text" runat="server" name="txt_cpf" id="txt_cpf" maxlength="14"
                        onkeydown="javascript: fCPF( this, mCPF );" onblur="javascript: vCPF();">
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <label>RG</label></td>
                <td>
                    <input type="text" runat="server" name="txt_rg" id="txt_rg" maxlength="11"
                        onkeydown="javascript: fRG( this, mRG );">
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <label>E-mail</label></td>
                <td>
                    <input type="text" runat="server" name="txt_email" id="txt_email" maxlength="150"></td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <label>Nacionalidade</label></td>
                <td>
                    <input type="text" runat="server" name="txt_nacionalidade" id="txt_nacionalidade" maxlength="50">
        </table>
        <br />
    </div>

    <div class="text-center">
        <asp:Button runat="server" ID="btn_cadastrar" class="btn btn-primary btn-lg" Text="Cadastrar" OnClick="Cadastrar" Width="200px" Style="margin: 0 15px;" />
        <asp:Button runat="server" ID="btn_atualizar" class="btn btn-primary btn-lg" Text="Atualizar" OnClick="Update" Width="200px" Style="margin: 0 15px;" />
        <asp:Button runat="server" ID="btn_delete" class="btn btn-primary btn-lg" Text="Apagar" onClientClick="return ConfirmDelete();" OnClick="Delete" Width="200px" Style="margin: 0 15px;" />
        <asp:Button runat="server" ID="btn_pesquisar" class="btn btn-primary btn-lg" Text="Pesquisar" OnClick="Search" Width="200px" Style="margin: 0 15px;" />
        <br />
    </div>
    <div class="text-center">
        <br />
        <asp:GridView ID="UsersGridView" runat="server" Width="1200px" align="center" HeaderStyle-HorizontalAlign="Center" HorizontalAlign="center">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>        
        <br />
        <a runat="server" href="~/Default" class="btn btn-default">Voltar Para A Tela Inicial &raquo;</a>
        <br />
        <br />
        <br />
    </div>


</asp:Content>

