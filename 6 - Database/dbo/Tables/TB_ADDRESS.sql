CREATE TABLE [dbo].[TB_ADDRESS] (
    [ID]       INT           IDENTITY (1, 1) NOT NULL,
    [Address]  VARCHAR (100) NOT NULL,
    [UserCode] INT           NULL,
    [Enabled]  BIT           NOT NULL,
    CONSTRAINT [PK_TB_ADDRESS] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_TB_ADDRESS_TB_USER] FOREIGN KEY ([UserCode]) REFERENCES [dbo].[TB_USER] ([ID])
);

