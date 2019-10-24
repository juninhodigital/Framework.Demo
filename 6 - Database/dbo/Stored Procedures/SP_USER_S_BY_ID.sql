
CREATE PROCEDURE SP_USER_S_BY_ID
(
	@P_ID INT
)
AS
BEGIN
 
	SELECT 
		ID,
		Name,
		Nickname,
		RG,
		CPF,
		Enabled
	FROM TB_USER A WITH(NOLOCK)

	WHERE A.ID = @P_ID

	-- Get all address
	SELECT 
		A.ID,
		A.Address,
		A.Enabled
	FROM TB_ADDRESS A WITH(NOLOCK)

	WHERE A.UserCode = @P_ID

END
