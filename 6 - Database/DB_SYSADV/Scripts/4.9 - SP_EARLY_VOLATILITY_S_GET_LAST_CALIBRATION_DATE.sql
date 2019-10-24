﻿IF EXISTS(SELECT NAME FROM sys.objects WHERE name = 'SP_EARLY_VOLATILITY_S_GET_LAST_CALIBRATION_DATE' AND TYPE = 'P')
BEGIN
    DROP PROCEDURE SP_EARLY_VOLATILITY_S_GET_LAST_CALIBRATION_DATE
END
GO

CREATE PROCEDURE [dbo].[SP_EARLY_VOLATILITY_S_GET_LAST_CALIBRATION_DATE]
AS
BEGIN
	SELECT MAX([Database]) 
	FROM TB_EARLY_EXPIRY_VOLATILITY_CALIBRATION
END

GRANT EXECUTE ON SP_EARLY_VOLATILITY_S_GET_LAST_CALIBRATION_DATE TO PUBLIC
GO
