IF EXISTS(SELECT NAME FROM sys.objects WHERE name = 'SP_EARLY_VOLATILITY_S_GET_LAST' AND TYPE = 'P')
BEGIN
    DROP PROCEDURE SP_EARLY_VOLATILITY_S_GET_LAST
END
GO

CREATE PROCEDURE [dbo].[SP_EARLY_VOLATILITY_S_GET_LAST]
(
	@Database DATETIME
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
END

GRANT EXECUTE ON SP_EARLY_VOLATILITY_S_GET_LAST TO PUBLIC
GO


