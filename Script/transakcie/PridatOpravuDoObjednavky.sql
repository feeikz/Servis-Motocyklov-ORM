CREATE OR ALTER     PROCEDURE PridatOpravuDoObjednavky(@p_ID_dielu int, @p_ID_prace int, @p_pocet_hodin int, @p_ID_objednavky int, @p_ID_zamestnanca int)
AS
BEGIN
	DECLARE 
	@v_nazov_dielu VARCHAR(30),
	@v_vyrobca VARCHAR(13),
	@v_datum DATE,
	@v_nakupna_cena_dielu NUMERIC,
	@v_cena_dielu NUMERIC,
	@v_cena_prace NUMERIC,
	@v_Oprava_ID INT,
	@v_cena NUMERIC,
	@ErrorMessage NVARCHAR(1000),
	@ErrorSeverity INT,
	@ErrorState INT;

	BEGIN TRY
		BEGIN TRANSACTION[W1]

			SET @v_cena_dielu = (SELECT predajna_cena FROM nahradny_diel WHERE ID = @p_ID_dielu);
			SET @v_cena_prace = (SELECT cena FROM praca WHERE ID = @p_ID_prace);
			SET @v_cena = @v_cena_dielu + @v_cena_prace;

			INSERT INTO  oprava(cena, pocet_hodin, datum, Objednavka_ID, Zamestnanec_ID)
			VALUES (@v_cena, @p_pocet_hodin, GETDATE(), @p_ID_objednavky, @p_ID_zamestnanca);

			SET @v_Oprava_ID = (SELECT MAX(ID) FROM oprava);
			SET @v_nazov_dielu = (SELECT nazov FROM nahradny_diel WHERE ID = @p_ID_dielu)
			SET @v_vyrobca = (SELECT vyrobca FROM nahradny_diel WHERE ID = @p_ID_dielu)
			SET @v_datum =(SELECT datum_nakupu FROM nahradny_diel WHERE ID = @p_ID_dielu)
			SET @v_nakupna_cena_dielu = (SELECT nakupna_cena FROM nahradny_diel WHERE ID = @p_ID_dielu)

			INSERT INTO oprava_praca(Oprava_ID, Praca_ID)
			values(@v_Oprava_ID,@p_ID_dielu);

			INSERT INTO Historia_ND (nazov, vyrobca, datum_nakupu, nakupna_cena, predajna_cena, Oprava_ID)
			VALUES (@v_nazov_dielu, @v_vyrobca, @v_datum, @v_nakupna_cena_dielu, @v_cena_dielu, @v_Oprava_ID);

			DELETE FROM nahradny_diel WHERE ID = @p_ID_dielu

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

END;
GO


exec PridatOpravuDoObjednavky 8,2,2,2,2


select * from oprava_praca

select * from oprava