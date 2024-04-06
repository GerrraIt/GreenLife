Create database test
go
use test
go
create table test
(
	Id int identity primary Key,
	[Login] varchar (50) not null,
	[Name] varchar (50) not null,
	Surnname varchar (50) not null,
	[Password] varchar (50) not null,
)
go
insert into test values ('admin', 'Roman','Potskhoraya','nicepro2526')
insert into test values ('admin', 'qwerty','Surname','password')
go

select *from test