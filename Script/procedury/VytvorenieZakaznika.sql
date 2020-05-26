CREATE OR ALTER PROCEDURE VytvorenieZakaznikaZoZamestnanca (@p_ID INT)
AS
BEGIN
	DECLARE 
	@v_meno VARCHAR(30),
	@v_priezvisko VARCHAR(30),
	@v_telefon VARCHAR(13),
	@v_pristup int;
			
	SET @v_meno = (SELECT meno FROM zamestnanec WHERE ID = @p_ID);
	SET @v_priezvisko = (SELECT priezvisko FROM zamestnanec WHERE ID = @p_ID);
	SET @v_telefon =  (SELECT telefon FROM zamestnanec WHERE ID = @p_ID);
	SET @v_pristup =  (SELECT pristup FROM zamestnanec WHERE ID = @p_ID)

	INSERT INTO zakaznik(meno,priezvisko, telefon, pristup, karta)
	VALUES (@v_meno, @v_priezvisko, @v_telefon, @v_pristup, null);

	
END
