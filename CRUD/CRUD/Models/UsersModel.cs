using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class UsersModel
    {
        public int id { get; set; }
        public String nome { get; set; }
        public String sobrenome { get; set; }
        public String cpf { get; set; }
        public String rg { get; set; }
        public String email { get; set; }
        public String nacionalidade { get; set; }

    }
}