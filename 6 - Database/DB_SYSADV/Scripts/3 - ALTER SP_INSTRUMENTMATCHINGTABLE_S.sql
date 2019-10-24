SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









 ALTER PROCEDURE [dbo].[SP_INSTRUMENTMATCHINGTABLE_S]
 (
	@P_SourceSystemID INT

 )
 AS
 BEGIN
 
	SELECT 
		SymbolCode, 
		SecurityType, 
		InstrumentID,
		OrderStrategyID,
		PriceFactor,
		PremiumFactor,
		StrikeFactor
	FROM tb_source_system_instrument
	WHERE sourcesystemid = @P_SourceSystemID



 END







GO


