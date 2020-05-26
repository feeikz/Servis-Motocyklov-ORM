CREATE OR ALTER    PROCEDURE UdelenieVernostnychKariet
AS
BEGIN
	DECLARE
	@ErrorMessage NVARCHAR(1000),
	@ErrorSeverity INT,
	@ErrorState INT,
	@v_zakaznik INT = 1,
	@v_pocet_zakaznikov INT,
	@v_pocet INT,
	@v_cena INT;

	BEGIN TRY
		BEGIN TRANSACTION[W1]
			
			SET @v_pocet_zakaznikov = (SELECT COUNT(*) FROM zakaznik);

			WHILE @v_zakaznik <= @v_pocet_zakaznikov
				BEGIN
				--PRINT(@v_pocet_zakaznikov);
				--PRINT(@v_zakaznik);

					SET @v_pocet = (SELECT COUNT(*) FROM zakaznik WHERE ID = @v_zakaznik);

					IF(@v_pocet > 0) 
					BEGIN
						SET @v_cena = 
						(
							SELECT SUM(Oprava.cena) 
							FROM objednavka join Oprava on Objednavka.ID = Oprava.ID 
							WHERE Objednavka.uhradene = 1 AND Objednavka.Zakaznik_ID = @v_zakaznik
						);



						IF(@v_cena < 1000)
						BEGIN
							UPDATE Zakaznik
							SET karta = 1
							WHERE ID = @v_zakaznik
						END

						IF(@v_cena > 1000)
						BEGIN
							UPDATE Zakaznik
							SET karta = 2
							WHERE ID = @v_zakaznik
						END
					
						IF(@v_cena > 5000)
						BEGIN
							UPDATE Zakaznik
							SET karta = 3
							WHERE ID = @v_zakaznik
						END
					END;

				SET @v_zakaznik = @v_zakaznik + 1
					
				END; --WHILE

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





exec UdelenieVernostnychKariet

