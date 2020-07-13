CREATE TABLE [FeeSchedule].[FeeScheduleData] (
    [ID]                 INT             IDENTITY (1, 1) NOT NULL,
    [CPTCode]            VARCHAR (50)    NOT NULL,
    [BillingSpecialty]   VARCHAR (255)   NOT NULL,
    [DoctorSpecialty]    VARCHAR (255)   NOT NULL,
    [Region]             INT             NULL,
    [BasicUnit]          DECIMAL (18, 2) DEFAULT ((1.00)) NOT NULL,
    [ConversionFactor]   DECIMAL (18, 2) NOT NULL,
    [EffectiveStartDate] DATETIME        NOT NULL,
    [EffectiveEndDate]   DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([Region]) REFERENCES [FeeSchedule].[FeeScheduleRegion] ([ID])
);

