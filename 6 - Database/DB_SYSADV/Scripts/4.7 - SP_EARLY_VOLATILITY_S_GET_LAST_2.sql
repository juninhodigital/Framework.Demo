EXEC SP_DROP_IF_EXISTS 'SP_EARLY_VOLATILITY_S_GET_LAST_2'
GO

CREATE PROCEDURE SP_EARLY_VOLATILITY_S_GET_LAST_2
(
	@UnderlyingAssetCode INT,
	@MaturityLabel VARCHAR(255),
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
	WHERE UnderlyingAssetCode = @UnderlyingAssetCode
	AND MaturitySetLabel = @MaturityLabel
	AND Strike = @Strike

END

GRANT EXECUTE ON SP_EARLY_VOLATILITY_S_GET_LAST_2 TO PUBLIC
GO


