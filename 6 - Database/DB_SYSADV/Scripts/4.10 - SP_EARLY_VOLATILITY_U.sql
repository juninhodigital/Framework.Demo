IF EXISTS(SELECT 1 FROM sys.objects WHERE name = 'SP_EARLY_VOLATILITY_D' AND TYPE = 'P')
BEGIN
    DROP PROCEDURE SP_EARLY_VOLATILITY_D
END
GO

CREATE PROCEDURE [dbo].[SP_EARLY_VOLATILITY_D]
(
    @ID INT
)
AS
BEGIN
    DELETE TB_EARLY_EXPIRY_VOLATILITY_CALIBRATION 
    WHERE ID = @ID
END

GRANT EXECUTE ON SP_EARLY_VOLATILITY_D TO PUBLIC
GO