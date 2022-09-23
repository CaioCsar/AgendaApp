CREATE DATABASE bdcrud;
USE bdcrud;

CREATE TABLE IF NOT EXISTS agenda(
  ageId int(11) NOT NULL AUTO_INCREMENT,
  ageNome varchar(100) DEFAULT NULL,
  ageEMail varchar(100) DEFAULT NULL,
  ageTelefone varchar(14) DEFAULT NULL,
  PRIMARY KEY (ageId)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

INSERT INTO agenda (ageId, ageNome, ageEMail, ageTelefone) VALUES
	(1, 'Picasso', 'picasso@exemplo.com', 5579912341234),	
	(2, 'Jucanildo Santos', 'jucanildo@exemplo.com', 5579843212321),
	(3, 'Cornelio Procopio', 'cornelio@exemplo.com', 5579877654432),
	(4, 'Mirassol Queimado', 'mirassol@exemplo.com', 5579999876565);