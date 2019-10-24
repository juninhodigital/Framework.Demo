EXEC SP_DROP_IF_EXISTS 'SP_EARLY_VOLATILITY_S_GET_LAST_4'
GO

CREATE PROCEDURE SP_EARLY_VOLATILITY_S_GET_LAST_4
(
	@P_TVP_GET_LAST TVP_GET_LAST READONLY
)
AS
BEGIN

    DECLARE @CalibrationDate DATETIME;
	EXEC SP_EARLY_VOLATILITY_S_GET_LAST_CALIBRATION_DATE @CalibrationDate OUTPUT;

	SELECT
	    B.[Index] AS [Index],
	    [Description],
		A.UnderlyingAssetCode,
		A.UnderlyingAssetLabel,
		A.MaturityPillarCode,
		A.MaturityPillarLabel,
		A.MaturitySetCode,
		A.MaturitySetLabel,
		A.Strike,
		A.CalibrationDate,
		A.Omega,
		A.Alpha1,
		A.Alpha2,
		A.Alpha3,
		A.Beta,
		A.Vol1Day,
		A.VolPillar1,
		A.VolPillar2,
		A.VolPillar3,
		A.ExpiryPillar1,
		A.ExpiryPillar2,
		A.ExpiryPillar3,
		A.DayCountBasis,
		A.CreatedOn,
		A.UserCode,
		A.Username,
		A.[Enabled]
	FROM TB_EARLY_EXPIRY_VOLATILITY_CALIBRATION A WITH(NOLOCK)

	INNER JOIN @P_TVP_GET_LAST B
	ON A.CalibrationDate      = @CalibrationDate
	AND A.UnderlyingAssetCode = B.UnderlyingAssetCode 
	AND A.MaturityPillarLabel = B.MaturityPillarLabel 
	AND A.Strike			  = B.Strike
	ORDER BY B.[Index]

END
GO

GRANT EXECUTE ON SP_EARLY_VOLATILITY_S_GET_LAST_4 TO PUBLIC
GO