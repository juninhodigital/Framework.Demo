EXEC SP_DROP_IF_EXISTS 'TB_EARLY_EXPIRY_VOLATILITY_CALIBRATION'
GO

CREATE TABLE TB_EARLY_EXPIRY_VOLATILITY_CALIBRATION
(
    ID INT IDENTITY,
    [Description] VARCHAR(50),
    UnderlyingAssetCode INT,
    UnderlyingAssetLabel VARCHAR(30),
    MaturityPillarCode INT,
    MaturityPillarLabel VARCHAR(30),
    MaturitySetCode INT,
    MaturitySetLabel VARCHAR(30),
    Strike FLOAT,
    CalibrationDate DATETIME,
    Omega FLOAT,
    Alpha1 FLOAT,
    Alpha2 FLOAT,
    Alpha3 FLOAT,
    Beta FLOAT,
    Vol1Day FLOAT,
    VolPillar1 FLOAT,
    VolPillar2 FLOAT,
    VolPillar3 FLOAT,
    ExpiryPillar1 DATETIME,
    ExpiryPillar2 DATETIME,
    ExpiryPillar3 DATETIME,
    DayCountBasis FLOAT,
    CreatedOn DATETIME,
    UserCode INT,
    Username VARCHAR(50),
    [Enabled] BIT
)
GO
