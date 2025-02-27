use master

create database DesafioDapper

use DesafioDapper


create table Produto
(
IdProduto int not null identity(1,1),
Descricao varchar(255) null

Constraint [PK_Produto] primary key(IdProduto)
)

insert into Produto(Descricao) values('Teclado')


create table Nota
(
Id Int not null Identity(1,1),
Nota int not null,
Serie Varchar(3) 

Constraint [PK_Nota] primary key(id)
)

create table ItemNota
(
Id Int not null,
Seq Int not null identity(1,1),
IdProduto int not null,
Quantidade float not null

Constraint [PK_ItemNota] primary key(id,seq)
Constraint [FK_ItemNota_IdProduto] foreign key(IdProduto) references Produto(IdProduto)
)


insert into Nota(Nota,Serie) values(1010,'4')
insert into ItemNota(Id,IdProduto,Quantidade) values(1,1,3)
insert into ItemNota(Id,IdProduto,Quantidade) values(1,3,1)

select 
	Nota.Id,
	Nota.Nota,
	Nota.Serie,
	ItemNota.Seq,
	ItemNota.IdProduto,
	ItemNota.Quantidade
from Nota
inner join ItemNota on
	Nota.Id = ItemNota.Id


select * from Produto
