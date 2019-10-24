IF EXISTS(SELECT NAME FROM sys.objects WHERE NAME = 'SP_EARLY_VOLATILITY_I' AND TYPE = 'P')
BEGIN
    DROP PROCEDURE SP_EARLY_VOLATILITY_I
END
GO

CREATE PROCEDURE [dbo].[SP_EARLY_VOLATILITY_I]
(
	@ID INT,
	@Description VARCHAR(255),
	@UnderlyingAssetCode INT,
	@UnderlyingAssetLabel VARCHAR(255),
	@MaturityPillarCode INT,
	@MaturityPillarLabel VARCHAR(255),
	@MaturitySetCode INT,
	@MaturitySetLabel VARCHAR(255),
	@Strike FLOAT,
	@Database DATETIME,
	@Omega  FLOAT,
	@Alpha1 FLOAT,
	@Alpha2 FLOAT,
	@Alpha3 FLOAT,
	@Beta FLOAT,
	@Vol1Day FLOAT,
	@VolPillar1 FLOAT,
	@VolPillar2 FLOAT,
	@VolPillar3 FLOAT,
	@ExpiryPillar1 DATETIME,
	@ExpiryPillar2 DATETIME,
	@ExpiryPillar3 DATETIME,
	@DayCountBasis FLOAT,
	@CreatedOn DATETIME,
	@UserCode INT,
	@Username FLOAT,
	@Enabled BIT
)
AS
BEGIN
	INSERT INTO TB_EARLY_EXPIRY_VOLATILITY_CALIBRATION 
	SELECT	@Description,
			@UnderlyingAssetCode,
			@UnderlyingAssetLabel,
			@MaturityPillarCode,
			@MaturityPillarLabel,
			@MaturitySetCode,
			@MaturitySetLabel,
			@Strike,
			@Database,
			@Omega,
			@Alpha1,
			@Alpha2,
			@Alpha3,
			@Beta,
			@Vol1Day,
			@VolPillar1,
			@VolPillar2,
			@VolPillar3,
			@ExpiryPillar1,
			@ExpiryPillar2,
			@ExpiryPillar3,
			@DayCountBasis,
			@CreatedOn,
			@UserCode,
			@Username,
			@Enabled
	
END

GRANT EXECUTE ON SP_EARLY_VOLATILITY_I TO PUBLIC
GO
