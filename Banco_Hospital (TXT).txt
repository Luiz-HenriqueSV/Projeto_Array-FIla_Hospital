create database if not exists banco_Hospital;
use banco_hospital;
create table if not exists Pacientes(
ID_Paciente int auto_increment not null primary key,
idade int not null,
nome varchar(100),
preferencial boolean default false,
lugar_fila enum("Aguardando", "Atendido") default "Aguardando"
);

insert into Pacientes values(
("","","","")
);
select * from Pacientes where lugar_fila='Aguardando' order by preferencial DESC, id ASC;
update Pacientes set lugar_fila='Atendido' where id='';
alter table Pacientes auto_increment = 1;
update pacientes set nome="", idade="", preferencial="" where ID_Paciente="";
select * from Pacientes;
delete from Pacientes where ID_Paciente >= 0;