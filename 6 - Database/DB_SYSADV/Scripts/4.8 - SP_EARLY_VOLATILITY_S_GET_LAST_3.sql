EXEC SP_DROP_IF_EXISTS 'SP_EARLY_VOLATILITY_S_GET_LAST_3'
GO

CREATE PROCEDURE SP_EARLY_VOLATILITY_S_GET_LAST_3
(
	@Database DATETIME,
	@UnderlyingAssetCode INT,
	@MaturityPillarLabel VARCHAR(255),
	@Strike FLOAT
)
AS
BEGIN

	SELECT [Description],
		UnderlyingAssetCode,
		UnderlyingAssetLabel,
		MaturityPillarCode,
		MaturityPillarLabel,
		MaturitySetCode,
		MaturitySetLabel,
		Strike,
		[Database],
		Omega,
		Alpha1,
		Alpha2,
		Alpha3,
		Beta,
		Vol1Day,
		VolPillar1,
		VolPillar2,
		VolPillar3,
		ExpiryPillar1,
		ExpiryPillar2,
		ExpiryPillar3,
		DayCountBasis,
		CreatedOn,
		UserCode,
		Username,
		[Enabled]
	FROM TB_EARLY_EXPIRY_VOLATILITY_CALIBRATION WITH(NOLOCK)
	WHERE [Database] = @Database
	AND UnderlyingAssetCode = @UnderlyingAssetCode
	AND MaturityPillarLabel = @MaturityPillarLabel
	AND Strike = @Strike

END

GRANT EXECUTE ON SP_EARLY_VOLATILITY_S_GET_LAST_3 TO PUBLIC
GO


