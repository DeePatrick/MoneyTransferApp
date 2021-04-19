CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PayCentreId] [int] NOT NULL,
	[UploadReceipts] [nvarchar](max) NULL,
	[CreateDate] [nvarchar](max) NULL,
	[UpdateDate] [nvarchar](max) NULL,
	[UpdateBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_UpdateDt]  DEFAULT (getdate()) FOR [UpdateDate]
GO

ALTER TABLE [dbo].[Customers]  ADD  CONSTRAINT [FK_Customers_Centres_PayCentreId] FOREIGN KEY([PayCentreId])
REFERENCES [dbo].[Centres] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Centres_PayCentreId]
GO
