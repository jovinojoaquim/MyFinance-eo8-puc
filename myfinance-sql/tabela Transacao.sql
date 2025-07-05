create table transacao(
  id int auto_increment not null,
  historico varchar(100) null,
  data datetime null,
  valor decimal(9,2),
  planocontaid int not null, 
  primary key (id),
  foreign key (planocontaid) references planoconta(id)  
)