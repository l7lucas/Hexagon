Create table tb_usuario
(
    id_usuario int  IDENTITY(1,1) primary key NOT NULL,
    nome varchar(200),
    sobrenome varchar(200),
    cpf varchar(200),
    rg varchar(200),
    email varchar(200),
    nacionalidade varchar(200),
	data_cadastro GETDATE(),
	inativo bit
)
drop table tb_usuario

alter table [tb_usuario] 