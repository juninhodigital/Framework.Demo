EXEC SP_DROP_IF_EXISTS 'TVP_GET_LAST'
GO

CREATE TYPE TVP_GET_LAST AS TABLE
(
	[Index] INT,
	[MaturityPillarLabel] VARCHAR(255),
	[Strike] FLOAT,
	[UnderlyingAssetCode] INT,
	[Database] DATETIME 
)
GO

GRANT EXECUTE ON TYPE::TVP_GET_LAST TO PUBLIC
GO