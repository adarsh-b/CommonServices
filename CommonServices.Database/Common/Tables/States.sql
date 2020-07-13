CREATE TABLE [Common].[States] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [StateName] VARCHAR (100) NULL,
    [ShortCode] VARCHAR (3)   NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

