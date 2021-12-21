INSERT INTO Categoria (nome) 
VALUES  ('Metal'),
		('PapelPapelao'),
		('Plastico'),
		('Vidro'),
		('Madeira'),
		('LixoOrganico'),
		('ResiduoPerigoso'),
		('ResiduoHospitalar'),
		('LixoRadioativo'),
		('LixoNaoReciclavel')

INSERT INTO Usuario (nome, role, login, senha)		
VALUES  ('Joao', 1, 'Joao', 'f74raJPm2FZ9c8bQuBSy/g=='),
		('Maira', 1, 'Maira', 'f74raJPm2FZ9c8bQuBSy/g=='),
		('Anna', 1, 'Anna', 'f74raJPm2FZ9c8bQuBSy/g=='),
		('Carlos', 1, 'Carlos', 'f74raJPm2FZ9c8bQuBSy/g=='),
		('Ivan', 1, 'Ivan', 'f74raJPm2FZ9c8bQuBSy/g=='),
		('Sophia', 1, 'Sophia', 'f74raJPm2FZ9c8bQuBSy/g=='),
		('Eva', 1, 'Eva', 'f74raJPm2FZ9c8bQuBSy/g=='),
		('Joaquim', 1, 'Joaquim', 'f74raJPm2FZ9c8bQuBSy/g==')


INSERT INTO Empresa_Coletora (nome, email, cnpj, telefone, senha, role) 
VALUES  ('Recicla Mais', 'reciclaMais@gmail.com', '12345678912351','21968645988', 'f74raJPm2FZ9c8bQuBSy/g==', 2),
		('E-Colleta', 'e-colleta@gmail.com', '23345678912351', '21968645223', 'f74raJPm2FZ9c8bQuBSy/g==', 2),
		('Serra-Plast','serra-plast@gmail.com', '35454267891235', '21991478963', 'f74raJPm2FZ9c8bQuBSy/g==', 2),
		('Atos','atos.net@atos.com','33475567708295','21984896849','f74raJPm2FZ9c8bQuBSy/g==', 2),
		('Santos Reciclaveis', 'santos@gmail.com', '19273546516573', '21928495826', 'f74raJPm2FZ9c8bQuBSy/g==', 2),
		('Mega Reciclaveis', 'mega-reciclaveis@gmail.com', '59677586910513', '21465567728', 'f74raJPm2FZ9c8bQuBSy/g==', 2),
		('SuperCollect', 'super-collect@gmail.com', '19273546516321', '21948192846', 'f74raJPm2FZ9c8bQuBSy/g==', 2),
		('NiceCollect', 'nice-collect@gmail.com', '19273455678848', '21948596876', 'f74raJPm2FZ9c8bQuBSy/g==', 2)

INSERT INTO Endereco (bairro, rua, status, numero, cep, cidade, complemento,estado, id_empresa_coletora) 
VALUES 	('Alto', 'Rua das palmeiras', 0 , '135',  '25964369',  'Teresópolis',  'Casa', 'RJ',  3 ),
		('Santa Clara','Av Rio Branco',0 ,'2698', '69864598', 'Rio de janeiro', 'Apt 101','RJ', 4),
		( 'Vargem Grande', 'Rua Tupinambás', 0 , '280',  '29684598',  'São Paulo',  'Casa', 'SP', 5),
		( 'Salaco','Estrada das Rosas',0 ,'980', '69875364', 'Teresópolis', 'Apt 101','RJ', 4),
		( 'Sebastiana','Estrada Grande Rota',0 ,'6262', '69874563', 'São Tomé', 'Casa 15','MG', 6),
		( 'Agriões','Rua Santo Antônio',0 ,'21', '89634563', 'São Tomé', 'Apt 100','RS', 6),
		( 'Granja Florestas','Rua Primeiro de Maio',0 ,'05', '79879501', 'Santana de Parnaíba', 'Casa 04','GO', 7),
		( 'Santa Clara','Avenia Rio Ribeiro',0 ,'200', '36874869', 'Av Rotariana', 'Apt 500','BA', 2),
		('Perpétuo','Av Santa Rosa',0 ,'90', '79879593', 'Petropolis', 'Casa 04','RJ', 1),
		('Albuqeurque','Rua Mato Grosso',0 ,'09', '19274553', 'Itaipava', 'Casa 06','RJ', 8)


INSERT INTO Categoria_Empresa(id_categoria, id_empresa_coletora) 
VALUES  (1,3),
		(2,4),
		(3,5),
		(6,6),
		(8,5),
		(6,4),
		(5,5),
		(4,8),
		(3,7),
		(2,5),
		(8,4),
		(6,3)
		
INSERT INTO Categoria_Usuario(id_categoria, id_usuario) 
VALUES  (1,3),
		(2,4),
		(3,5),
		(6,6),
		(8,5),
		(6,4),
		(5,5),
		(4,8),
		(3,7),
		(2,5),
		(8,4),
		(6,3)
		
