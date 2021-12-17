insert into Categoria (nome) values 
('Metal'),
('PapelPapelao'),
('Plastico'),
('Vidro'),
('Madeira'),
('LixoOrganico'),
('ResiduoPerigoso'),
('ResiduoHospitalar'),
('LixoRadioativo'),
('LixoNaoReciclavel')

insert into Empresa_Coletora (Nome, Email, Cnpj, Telefone, Senha) values
('Recicla Mais', 'reciclaMais@gmail.com', '12345678912351','21968645988', 'TesteSenha'),
('E-Colleta', 'e-colleta@gmail.com', '23345678912351', '21968645223', 'TesteSenha'),
('Serra-Plast','serra-plast@gmail.com', '35454267891235', '21991478963', 'TesteSenha'),
('Atos','atos.net@atos.com','33475567708295','21984896849','TesteSenha'),
('Santos Reciclaveis', 'santos@gmail.com', '19273546516573', '21928495826', 'TesteSenha'),
('Mega Reciclaveis', 'mega-reciclaveis@gmail.com', '59677586910513', '21465567728', 'TesteSenha'),
('New Reciclaveis', 'new-reciclaveis@gmail.com', '49576576819503', '21162547526', 'TesteSenha'),
('SuperCollect', 'super-collect@gmail.com', '19273546516321', '21948192846', 'TesteSenha'),
('NiceCollect', 'nice-collect@gmail.com', '19273455678848', '21948596876', 'TesteSenha')

insert Endereco (bairro, rua, status, numero, cep, cidade, complemento,estado, id_empresa_coletora) values
('Alto', 'Rua das palmeiras', 0 , '135',  '25964369',  'Teresópolis',  'Casa', 'RJ',  1 ),
('Santa Clara','Av Rio Branco',0 ,'2698', '69864598', 'Rio de janeiro', 'Apt 101','RJ', 2),
( 'Vargem Grande', 'Rua Tupinambás', 0 , '280',  '29684598',  'São Paulo',  'Casa', 'SP', 3),
( 'Salaco','Estrada das Rosas',0 ,'980', '69875364', 'Teresópolis', 'Apt 101','RJ', 4),
( 'Sebastiana','Estrada Grande Rota',0 ,'6262', '69874563', 'São Tomé', 'Casa 15','MG', 6),
( 'Agriões','Rua Santo Antônio',0 ,'21', '89634563', 'São Tomé', 'Apt 100','RS', 6),
( 'Granja Florestas','Rua Primeiro de Maio',0 ,'05', '79879501', 'Santana de Parnaíba', 'Casa 04','GO', 7),
( 'Santa Clara','Avenia Rio Ribeiro',0 ,'200', '36874869', 'Av Rotariana', 'Apt 500','BA', 8),
('Perpétuo','Av Santa Rosa',0 ,'90', '79879593', 'Petropolis', 'Casa 04','RJ', 9),
('Albuqeurque','Rua Mato Grosso',0 ,'09', '19274553', 'Itaipava', 'Casa 06','RJ', 10)


insert into Categoria_Empresa(id_categoria, id_empresa_coletora) values
(1,2),
(2,2),
(3,2),
(6,2),
(8,3),
(6,4),
(5,5),
(4,9),
(3,7),
(2,5),
(8,4),
(6,3)