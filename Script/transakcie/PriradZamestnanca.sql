CREATE OR ALTER   PROCEDURE PriradZamestnanca(@p_ID_objednavky INT)
AS 
BEGIN
	DECLARE 
	@ErrorMessage NVARCHAR(1000),
	@ErrorSeverity INT,
	@ErrorState INT,
	@v_vyrobca VARCHAR(15),
	@v_min INT,
	@v_max INT,
	@v_pocet INT,
	@v_zamestnanec INT;

	BEGIN TRY
		BEGIN TRANSACTION[W1]

			SET @v_min = (SELECT MIN(ID) FROM zamestnanec);
			SET @v_max = (SELECT MAX(ID) FROM zamestnanec);
			SET @v_vyrobca = (SELECT motocykel.vyrobca FROM objednavka JOIN motocykel ON objednavka.Motocykel_ID = motocykel.ID WHERE objednavka.ID = @p_ID_objednavky );
			SET @v_zamestnanec = 
			(
				SELECT objednavka.Zamestnanec_ID
				FROM objednavka
				JOIN motocykel ON objednavka.Motocykel_ID = motocykel.ID
				WHERE motocykel.vyrobca = @v_vyrobca
				GROUP BY  objednavka.Zamestnanec_ID
				HAVING COUNT(*) >= ALL 
				(
					SELECT COUNT(*)
					FROM objednavka
					JOIN motocykel ON objednavka.Motocykel_ID = motocykel.ID
					WHERE Motocykel.vyrobca = @v_vyrobca
				)
			);
			IF(@v_zamestnanec IS NULL)
			BEGIN
				SET @v_zamestnanec = ( SELECT FLOOR(RAND()*@v_max) + @v_min);
				SET @v_pocet = (SELECT COUNT(*) FROM zamestnanec WHERE ID = @v_zamestnanec);
				IF(@v_pocet < 1)
				begin
					SET	@v_zamestnanec =(SELECT ID FROM zamestnanec WHERE ID = @v_max); 
				END
			END
			PRINT(@v_zamestnanec);

			UPDATE objednavka
			SET Zamestnanec_ID = @v_zamestnanec
			WHERE ID = @p_ID_objednavky;

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

exec PriradZamestnanca 3;

select * from objednavka

update objednavka
set Zamestnanec_ID = null
where ID = 3