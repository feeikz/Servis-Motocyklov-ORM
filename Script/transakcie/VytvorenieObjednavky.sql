CREATE OR ALTER   PROCEDURE VytvorenieObjednavky (@p_ID_zakaznik INT, @p_ID_motocykel INT, @p_ID_zamestnanec INT, @p_ID_diel INT, @p_ID_praca INT, @p_ID_pocet_hodin INT)
AS
BEGIN
	DECLARE
	@ErrorMessage NVARCHAR(1000),
	@ErrorSeverity INT,
	@ErrorState INT,
	@v_cena_dielu NUMERIC,
	@v_cena_prace NUMERIC,
	@v_objednavka_ID INT,
	@v_cena NUMERIC,
	@nazov VARCHAR(30),
	@vyrobca VARCHAR(15),
	@nakupna_cena NUMERIC, 
	@predajna_cena NUMERIC, 
	@v_datum DATE,
	@Oprava_ID INT;
	
	BEGIN TRY
		BEGIN TRANSACTION[W1]

			INSERT INTO objednavka(datum_vytvorenia, datum_uhradenia, uhradene, Zakaznik_ID, Zamestnanec_ID, Motocykel_ID)
			VALUES (GETDATE(), null, 0, @p_ID_zakaznik, @p_ID_zamestnanec, @p_ID_motocykel);

			SET @v_objednavka_ID = (SELECT MAX(ID) FROM objednavka);
			SET @v_cena_dielu = (SELECT predajna_cena FROM nahradny_diel WHERE ID = @p_ID_diel);
			SET @v_cena_prace = (SELECT cena FROM praca WHERE ID = @p_ID_praca);
			SET @v_cena = @v_cena_prace + @v_cena_dielu;

			INSERT INTO Oprava(cena, pocet_hodin, datum, Objednavka_ID, Zamestnanec_ID)
			VALUES (@v_cena, @p_ID_pocet_hodin, GETDATE(), @v_objednavka_ID, @p_ID_zamestnanec);

		
			SET @nazov = (SELECT nazov FROM nahradny_diel WHERE ID = @p_ID_diel );
			SET @vyrobca = (SELECT vyrobca FROM nahradny_diel WHERE ID = @p_ID_diel);
			SET @nakupna_cena = (SELECT nakupna_cena FROM nahradny_diel WHERE ID = @p_ID_diel);
			SET @predajna_cena = (SELECT predajna_cena FROM nahradny_diel WHERE ID = @p_ID_diel);
			SET @v_datum = (SELECT datum_nakupu FROM nahradny_diel WHERE ID = @p_ID_diel);
			SET @Oprava_ID = (SELECT MAX(ID) FROM oprava);

			INSERT INTO oprava_praca(Oprava_ID, Praca_ID)
			VALUES(@Oprava_ID, @p_ID_praca);

			INSERT INTO historia_nd(nazov, vyrobca, datum_nakupu, nakupna_cena, predajna_cena, Oprava_ID)
			VALUES (@nazov, @vyrobca,@v_datum ,@nakupna_cena, @predajna_cena, @Oprava_ID);

			DELETE FROM nahradny_diel
			WHERE ID = @p_ID_diel;

			IF @@TRANCOUNT > 0
				COMMIT TRANSACTION  [W1]
	END TRY 
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE()
		SET @ErrorSeverity = ERROR_SEVERITY()
		SET @ErrorState = ERROR_STATE()

		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION  [W1]
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState )
	END CATCH
END




select * from zakaznik
select * from zamestnanec
select * from motocykel
select * from praca
select * from nahradny_diel
select * from objednavka
select * from oprava
select * from Historia_ND



