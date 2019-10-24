
CREATE PROCEDURE SP_USER_U
(
	@P_ID INT,
	@P_Name		varchar(50),
	@P_Nickname	varchar(50),
	@P_RG		varchar(50),
	@P_CPF		varchar(50),
	@P_Enabled	bit,	
	@P_TVP_ADDRESS TVP_ADDRESS READONLY
 )
 AS
 BEGIN
 
	BEGIN TRY

		BEGIN TRANSACTION

		UPDATE TB_USER SET
			Name		= @P_Name,
			Nickname	= @P_Nickname,
			RG			= @P_RG,
			CPF			= @P_CPF,			
			Enabled		= @P_Enabled
		WHERE ID = @P_ID
		
		-- Delete the previous address
		DELETE FROM TB_ADDRESS WHERE USERCODE = @P_ID
	
		-- Insert the new ones
		INSERT TB_ADDRESS
		SELECT 
			Address,
			UserCode,
			Enabled
		FROM TVP_ADDRESS			

		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH
		
		IF(@@TRANCOUNT>0)
		BEGIN
			ROLLBACK TRANSACTION
		END

	END CATCH

 END
