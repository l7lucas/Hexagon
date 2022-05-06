using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD.Models;
using CRUD.DAL;

namespace CRUD
{
    public partial class cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Select();
            }
        }

        UsersDAL DAL = new UsersDAL();
        protected void Cadastrar(object sender, EventArgs e)
        {
            UsersModel Users = new UsersModel();
            bool allchecked = true;
            string missing = "";

            if (!String.IsNullOrEmpty(txt_nacionalidade.Value)) { Users.nacionalidade = txt_nacionalidade.Value; } else { missing = "Nacionalidade"; allchecked = false; }
            if (!String.IsNullOrEmpty(txt_email.Value)) { Users.email = txt_email.Value; } else { missing = "E-mail"; allchecked = false; }
            if (!String.IsNullOrEmpty(txt_rg.Value)) { Users.rg = txt_rg.Value; } else { missing = "RG"; allchecked = false; }
            if (!String.IsNullOrEmpty(txt_cpf.Value)) { Users.cpf = txt_cpf.Value; } else { missing = "CPF"; allchecked = false; }
            if (!String.IsNullOrEmpty(txt_sobrenome.Value)) { Users.sobrenome = txt_sobrenome.Value; } else { missing = "Sobrenome"; allchecked = false; }
            if (!String.IsNullOrEmpty(txt_nome.Value)) { Users.nome = txt_nome.Value; } else { missing = "Nome"; allchecked = false; }

            if (allchecked) { Insert(Users); }
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", " alert('Favor preencher o campo " + missing + "!')", true);
        }
        void Insert(UsersModel Users)
        {
            int id = DAL.Insert(Users);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert",
            @"alert('Usuário cadastrado com sucesso! Sua ID é Nº: " + id + " ')", true);
            Select();
        }
        void Select()
        {
            UsersGridView.DataSource = DAL.Select();
            UsersGridView.DataBind();
        }
        protected void Update(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_id.Value))
            {
                UsersModel Users = new UsersModel();
                Users.id = Convert.ToInt32(txt_id.Value);

                if (!String.IsNullOrEmpty(txt_nacionalidade.Value)) { Users.nacionalidade = txt_nacionalidade.Value; }
                if (!String.IsNullOrEmpty(txt_email.Value)) { Users.email = txt_email.Value; }
                if (!String.IsNullOrEmpty(txt_rg.Value)) { Users.rg = txt_rg.Value; }
                if (!String.IsNullOrEmpty(txt_cpf.Value)) { Users.cpf = txt_cpf.Value; }
                if (!String.IsNullOrEmpty(txt_sobrenome.Value)) { Users.sobrenome = txt_sobrenome.Value; }
                if (!String.IsNullOrEmpty(txt_nome.Value)) { Users.nome = txt_nome.Value; }

                String Update_Return = DAL.Update(Users);
                if (!String.IsNullOrEmpty(Update_Return))
                {
                    Select();
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", " alert('" + Update_Return + "')", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", " alert('Usuário " + Users.id + " atualizado com sucesso!')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", " alert('Entre em contato com o suporte!')", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", " alert('Por Favor, preencha o campo ID para indicar um usuário!')", true);
            }
        }

        protected void Delete(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_id.Value))
            {
                UsersModel Users = new UsersModel();
                Users.id = Convert.ToInt32(txt_id.Value);
                if (DAL.Delete(Users.id))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", " alert('Usuário " + Users.id + " excluído com sucesso!')", true);
                    Select();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", " alert('Por Favor, preencha o campo ID para indicar um usuário!')", true);
            }
        }

        protected void Search(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_id.Value))
            {
                if (DAL.Search(Convert.ToInt32(txt_id.Value)) != null)
                {
                    UsersGridView.DataSource = DAL.Search(Convert.ToInt32(txt_id.Value));
                    UsersGridView.DataBind();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", " alert('A ID Nº " + txt_id.Value + " não possui registro')", true);
                }
            }
            else
            {
                Select();
            }
        }
    }
}