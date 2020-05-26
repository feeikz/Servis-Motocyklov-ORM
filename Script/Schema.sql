CREATE TABLE zakaznik (
    ID					 INTEGER PRIMARY KEY IDENTITY NOT NULL,
    meno				 VARCHAR(30) NOT NULL,
    priezvisko			 VARCHAR(30) NOT NULL,
    telefon				 VARCHAR(13) NOT NULL,
    pristup				 INTEGER CHECK(pristup = 1 or pristup = 2 or pristup = 3) NOT NULL,
	karta				 INTEGER CHECK(karta = 0 or karta = 1 or karta = 2 or karta = 3) NULL,
	login				 VARCHAR(15) NOT NULL,	
	heslo				 VARCHAR(15) NOT NULL
)

CREATE TABLE zamestnanec (
    ID					  INTEGER PRIMARY KEY IDENTITY NOT NULL,
    meno                  VARCHAR(30) NOT NULL,
    priezvisko            VARCHAR(30) NOT NULL,
    telefon               VARCHAR(13) NOT NULL,
    cena_prace		      INTEGER NOT NULL,
    pristup               INTEGER CHECK(pristup = 1 or pristup = 2 or pristup = 3) NOT NULL,
    login				 VARCHAR(15) NOT NULL,	
	heslo				 VARCHAR(15) NOT NULL
)

CREATE TABLE motocykel (
    ID			           INTEGER PRIMARY KEY IDENTITY NOT NULL,
    vyrobca                VARCHAR(15) NOT NULL,
	model				   VARCHAR(10) NOT NULL,	
	typ					   VARCHAR(6) CHECK(typ = 'enduro' or typ = 'cross') NOT NULL,
	obsah_valca			   INTEGER NOT NULL,
	rok_vyroby			   INTEGER NOT NULL
)

CREATE TABLE objednavka (
	ID					  INTEGER PRIMARY KEY IDENTITY NOT NULL,
	datum_vytvorenia	  DATE NOT NULL,
	datum_uhradenia		  DATE NULL,
	uhradene			  INTEGER CHECK (uhradene = 1 or uhradene = 0 )NOT NULL,
	Zakaznik_ID			  INTEGER FOREIGN KEY REFERENCES zakaznik(ID) NOT NULL,
	Zamestnanec_ID		  INTEGER FOREIGN KEY REFERENCES zamestnanec(ID) NULL,
	Motocykel_ID	      INTEGER FOREIGN KEY REFERENCES motocykel(ID) NOT NULL
)

CREATE TABLE oprava (
	ID					  INTEGER PRIMARY KEY IDENTITY NOT NULL,
	cena				  INTEGER NOT NULL,
	pocet_hodin			  INTEGER NOT NULL,
	datum				  DATE NOT NULL,
	Objednavka_ID		  INTEGER FOREIGN KEY REFERENCES objednavka(ID) NOT NULL,
	Zamestnanec_ID		  INTEGER FOREIGN KEY REFERENCES zamestnanec(ID) NOT NULL,
)

CREATE TABLE nahradny_diel (
	ID					  INTEGER PRIMARY KEY IDENTITY NOT NULL,
	nazov				  VARCHAR(30) NOT NULL,
	vyrobca				  VARCHAR(15) NOT NULL,
	datum_nakupu		  DATE NOT NULL,
	nakupna_cena		  MONEY NOT NULL,
	predajna_cena		  MONEY NOT NULL,
	Oprava_ID			  INTEGER FOREIGN KEY REFERENCES oprava(ID) NULL
)


CREATE TABLE praca (
    ID		              INTEGER PRIMARY KEY IDENTITY NOT NULL,
    nazov	              VARCHAR(50) NOT NULL,
    cena		          MONEY NOT NULL,
)

CREATE TABLE oprava_praca (
	Oprava_ID			  INTEGER  FOREIGN KEY REFERENCES oprava(ID) NOT NULL,
	Praca_ID			  INTEGER  FOREIGN KEY REFERENCES praca(ID) NOT NULL,
	CONSTRAINT [PK_OP] PRIMARY KEY CLUSTERED ( [Oprava_ID], [Praca_ID] )
)

CREATE TABLE Historia_ND (
	ID					  INTEGER PRIMARY KEY IDENTITY NOT NULL,
	nazov				  VARCHAR(30) NOT NULL,
	vyrobca				  VARCHAR(15) NOT NULL,
	datum_nakupu		  DATE NOT NULL,
	nakupna_cena		  MONEY NOT NULL,
	predajna_cena		  MONEY NOT NULL,
	Oprava_ID			  INTEGER FOREIGN KEY REFERENCES oprava(ID) NOT NULL
)






