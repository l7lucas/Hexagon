using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using CRUD;
using CRUD.Models;


namespace CRUD.DAL
{
    public class UsersDAL
    {
        Connection ConStr = new Connection();
        public int Insert(UsersModel user)
        {
            SqlConnection Con = null;

            try
            {
                Con = new SqlConnection(ConStr.UsersStr);
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[tb_usuario]
									                ([nome]
									                ,[sobrenome]
									                ,[cpf]
									                ,[rg]
									                ,[email]
									                ,[nacionalidade])
									                VALUES
									                (@nome
									                ,@sobrenome
									                ,@cpf
									                ,@rg
									                ,@email
									                ,@nacionalidade) select @@identity as id_usuario ", Con);

                cmd.Parameters.AddWithValue("@nome", user.nome);
                cmd.Parameters.AddWithValue("@sobrenome", user.sobrenome);
                cmd.Parameters.AddWithValue("@cpf", user.cpf);
                cmd.Parameters.AddWithValue("@rg", user.rg);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@nacionalidade", user.nacionalidade);

                Con.Open();

                user.id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Con.Close();
            }
            return user.id;
        }

        public List<UsersModel> Select()
        {
            List<UsersModel> Users = new List<UsersModel>();
            SqlConnection Con = null;
            SqlDataReader reader = null;
            try
            {
                Con = new SqlConnection(ConStr.UsersStr);
                Con.Open();

                SqlCommand cmd = new SqlCommand(@"Select
									             id_usuario
									            ,nome
									            ,sobrenome
									            ,cpf
									            ,rg
									            ,email
									            ,nacionalidade
									            From tb_usuario", Con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UsersModel users = new UsersModel();

                    users.id = Convert.ToInt32(reader["id_usuario"]);
                    users.nome = reader["nome"].ToString();
                    users.sobrenome = reader["sobrenome"].ToString();
                    users.cpf = reader["cpf"].ToString();
                    users.rg = reader["rg"].ToString();
                    users.email = reader["email"].ToString();
                    users.nacionalidade = reader["nacionalidade"].ToString();

                    Users.Add(users);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (Con != null)
                {
                    Con.Close();
                }
            }
            return Users;
        }


        public string Update(UsersModel Users)
        {
            SqlConnection Con = null;
            string ret = "Insira ao menos um valor a ser alterado!";
            try
            {
                Con = new SqlConnection(ConStr.UsersStr);
                var n = 0;

                String Update_Query = @"update tb_usuario set ";

                if (!String.IsNullOrEmpty(Users.nome))           { Update_Query += "nome = @nome "; n = 1; }
                if (!String.IsNullOrEmpty(Users.sobrenome))      { if (n > 0) { Update_Query += ", "; } else { n = 1; } Update_Query += "sobrenome = @sobrenome "; }
                if (!String.IsNullOrEmpty(Users.cpf))            { if (n > 0) { Update_Query += ", "; } else { n = 1; } Update_Query += "cpf = @cpf "; }
                if (!String.IsNullOrEmpty(Users.rg))             { if (n > 0) { Update_Query += ", "; } else { n = 1; } Update_Query += "rg = @rg "; }
                if (!String.IsNullOrEmpty(Users.email))          { if (n > 0) { Update_Query += ", "; } else { n = 1; } Update_Query += "email = @email "; }
                if (!String.IsNullOrEmpty(Users.nacionalidade))  { if (n > 0) { Update_Query += ", "; } else { n = 1; } Update_Query += "nacionalidade = @nacionalidade "; }
                if (n > 0) { Update_Query += "where id_usuario = @id"; }

                SqlCommand cmd = new SqlCommand(Update_Query, Con);

                if (!String.IsNullOrEmpty(Users.nome))           { cmd.Parameters.AddWithValue("@nome", Users.nome); n = 1; }
                if (!String.IsNullOrEmpty(Users.sobrenome))      { cmd.Parameters.AddWithValue("@sobrenome", Users.sobrenome); }
                if (!String.IsNullOrEmpty(Users.cpf))            { cmd.Parameters.AddWithValue("@cpf", Users.cpf); }
                if (!String.IsNullOrEmpty(Users.rg))             { cmd.Parameters.AddWithValue("@rg", Users.rg); }
                if (!String.IsNullOrEmpty(Users.email))          { cmd.Parameters.AddWithValue("@email", Users.email); }
                if (!String.IsNullOrEmpty(Users.nacionalidade))  { cmd.Parameters.AddWithValue("@nacionalidade", Users.nacionalidade); }

                if (n > 0)
                {
                    cmd.Parameters.AddWithValue("@id", Users.id);
                    Con.Open();
                    ret = Update_Query;
                    cmd.ExecuteNonQuery();
                }


            }
            //catch (Exception ex)
            //{
            //    //ret = ex.Message;
            //    Console.WriteLine(ex.Message);
            //}
            finally
            {
                if (Con != null)
                {
                    Con.Close();
                }
            }
            return ret;
        }
        public bool Delete(int id)
        {
            SqlConnection Con = null;
            bool ret = true;
            try
            {
                Con = new SqlConnection(ConStr.UsersStr);
                Con.Open();

                SqlCommand cmd = new SqlCommand(@"delete from tb_usuario where id_usuario =  @id", Con);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ret = false;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (Con != null)
                {
                    Con.Close();
                }
            }
            return ret;
        }


        public List<UsersModel> Search(int id)
        {
            List<UsersModel> Users = new List<UsersModel>();
            SqlConnection Con = null;
            SqlDataReader reader = null;
            try
            {
                Con = new SqlConnection(ConStr.UsersStr);
                Con.Open();

                SqlCommand cmd = new SqlCommand(@"Select
									             id_usuario
									            ,nome
									            ,sobrenome
									            ,cpf
									            ,rg
									            ,email
									            ,nacionalidade
									            From tb_usuario
                                                where id_usuario = @id", Con);

                cmd.Parameters.AddWithValue("@id", id);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UsersModel users = new UsersModel();

                    users.id = Convert.ToInt32(reader["id_usuario"]);
                    users.nome = reader["nome"].ToString();
                    users.sobrenome = reader["sobrenome"].ToString();
                    users.cpf = reader["cpf"].ToString();
                    users.rg = reader["rg"].ToString();
                    users.email = reader["email"].ToString();
                    users.nacionalidade = reader["nacionalidade"].ToString();

                    Users.Add(users);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (Con != null)
                {
                    Con.Close();
                }
            }
            return Users;
        }

    }
}