insert into dbo.zakaznik(meno, priezvisko, telefon, pristup, karta, login, heslo)
values  ('Janko', 'Mrkva', '+421950789456', 1, null, 'login001', 'heslo123'),
		('Marcel', 'Stlp', '+421950963147',  1, null, 'login002', 'heslo123' ),
		('Jozef', 'Slivka', '+421950123456', 1, null, 'login003', 'heslo123' ),
		('Jozef', 'Mravec', '+421950240006',  1, null , 'login004', 'heslo123'),
		('Marek', 'Zabojink', '+421950220031' , 1, null, 'login005', 'heslo123' ),
		('Igor', 'Majdak', '+421950069369',  1, null, 'login006', 'heslo123' ),
		('Matus', 'Ihlancik' , '+421950033022',  1, null , 'login007', 'heslo123'),
		('Frantisek', 'Lehotsky', '+421950377988',  1, null, 'login008', 'heslo123' ),
		('Filip', 'Zdrzal', '+421950305024', 1, null, 'login009', 'heslo123' ),
		('Marek', 'Facha', '+421950097349',  1, null, 'login010', 'heslo123' )

insert into dbo.zamestnanec(meno, priezvisko, telefon, cena_prace, pristup,login, heslo)
values ('Jakub', 'Ostron', '+421950235678', 6, 2, 'emp001', 'heslo'),
	   ('Ondrej', 'Bajza', '+421950415203', 6, 2, 'emp002', 'heslo'),
	   ('Frederik', 'Zajac', '+421950785689', 8 ,3, 'emp003', 'heslo')

insert into dbo.motocykel(vyrobca, model, typ, obsah_valca, rok_vyroby)
values ('KTM', 'SX', 'cross', 250, 2003),
		('KTM', 'SX-F', 'cross', 250, 2011),
		('Yamaha', 'YZ-F', 'cross', 450, 2018),
		('Kawasaki', 'KX-F', 'cross', 250, 2010),
		('Honda', 'CR', 'cross', 125, 2006),
		('Honda', 'CR-F', 'cross', 450, 2011),
		('KTM', 'EXC', 'enduro', 300, 2017),
		('Suzuki', 'RM-Z', 'cross', 250, 2005),
		('KTM', 'EXC', 'enduro', 250, 2013),
		('KTM', 'XCW', 'enduro', 150, 2015)

insert into nahradny_diel(nazov, vyrobca, datum_nakupu, nakupna_cena, predajna_cena, Oprava_ID)
values
('Piestna sada 50', 'Vertex', '2019-5-17', 50, 80, null),
('Piestna sada 125', 'Vertex', '2019-5-17', 80, 110, null),
('Ventilova sada 250', 'Vertex', '2019-5-17', 80, 110, null),
('Ventilova sada 450', 'Vertex', '2019-5-17', 120, 150, null),
('Sada tesnení valca 125', 'Prox', '2019-5-17', 30, 50, null),
('Klukovy hriadel 125', 'Hot-rods','2019-5-20', 300, 350, null),
('Klukovy hriadel 250', 'Hot-rods','2019-5-20', 300, 350, null),
('Piestna sada 125', 'Vertex', '2019-5-25', 80, 110, null),
('Piestna sada 125', 'Vertex', '2019-5-25', 80, 110, null),
('Piestna sada 450', 'Vertex', '2019-5-25', 110, 150, null),
('Ventilova sada 250', 'Vertex', '2019-5-25', 80, 110, null),
('Sada tesnení valca 450', 'Prox','2019-6-02', 50, 70, null),
('Sada tesnení valca 450', 'Prox','2019-6-02', 50, 70, null),
('Piestna sada 250', 'Prox','2019-6-10', 90, 130, null)

insert into praca(nazov, cena)
values ('Vymena piestnej sady', 30),
		('Vymena ventolovej sady', 40),
		('Vymena sady tesneni', 20),
		('Vymena klukoveho hriadela', 70)

insert into objednavka(datum_vytvorenia, datum_uhradenia, uhradene, Zakaznik_ID, Motocykel_ID, Zamestnanec_ID)
values ('2020-3-10', '2020-3-12', 1, 9, 3, 2),
		('2020-4-13', '2020-4-16', 1, 10, 6, 1),
		('2020-4-13', '2020-4-16', 0, 4, 4, null)


insert into oprava(cena, pocet_hodin, datum, Objednavka_ID, Zamestnanec_ID)
values (160, 1, '2020-3-10', 1, 2),
		(80, 1, '2020-3-10', 1, 2),
		(180, 1, '2020-4-13', 2, 1),
		(420, 2, '2020-4-13', 2, 1),
		(90, 1, '2020-4-14', 2, 1)

insert into oprava_praca(Oprava_ID, Praca_ID)
values (1,1),
		(2,3),
		(3,1),
		(4,4),
		(5,3)

insert into historia_nd (nazov, vyrobca, datum_nakupu, nakupna_cena, predajna_cena, Oprava_ID)
values ('Piestna sada 250', 'Vertex', '2019-5-17', 100, 130, 1),
		('Sada tesnení valca 250', 'Prox', '2019-5-17', 40, 60, 2),
		('Piestna sada 450', 'Vertex', '2019-5-17', 120, 150, 3),
		('Klukovy hriadel 450', 'Hot-rods','2019-5-20', 300, 350, 4),
		('Sada tesnení valca 450', 'Prox', '2019-5-17', 50, 70, 5) 



select * from zakaznik
select * from zamestnanec
select * from motocykel		
select * from nahradny_diel
select * from praca		
select * from objednavka
select * from oprava
select * from oprava_praca
select * from historia_nd
