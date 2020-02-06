create database GestionC
use GestionC
create table Client (codel int primary key,nom varchar(20),ville varchar(20))
insert into Client values (3,'ayoub','khribga'),(4,'mohamed','leblad')
select * from Client
select * from Client where codel=1
--crea requete permet daficher le client de code 1
update Client set nom='othmane',ville='fes' where codel=5
delete Client where codel = 6