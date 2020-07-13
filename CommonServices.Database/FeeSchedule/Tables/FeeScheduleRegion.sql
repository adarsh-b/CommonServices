CREATE TABLE [FeeSchedule].[FeeScheduleRegion] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [StateID]    INT           NULL,
    [RegionName] VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([StateID]) REFERENCES [Common].[States] ([ID])
);

