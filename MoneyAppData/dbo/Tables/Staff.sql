
CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [nvarchar](450) NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[DOB] [datetime2](7) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[LocalGovt] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Town] [nvarchar](max) NULL,
	[State] [nvarchar](max) NOT NULL,
	[Position] [nvarchar](max) NOT NULL,
	[Salary] [int] NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[ProfilePicture] [nvarchar](max) NULL,
	[Loan] [int] NOT NULL,
	[Debt] [int] NOT NULL,
	[PayCentreId] [int] NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT (N'') FOR [FirstName]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT (N'') FOR [LastName]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DOB]
GO

ALTER TABLE [dbo].[Staff] ADD  CONSTRAINT [DF_Staff_loan]  DEFAULT ((0)) FOR [Loan]
GO

ALTER TABLE [dbo].[Staff] ADD  CONSTRAINT [DF_Staff_debt]  DEFAULT ((0)) FOR [Debt]
GO

--ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
--REFERENCES [dbo].[AspNetUsers] ([Id])
--GO

--ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_AspNetUsers_ApplicationUserId]
--GO

--ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Centres_PayCentreId] FOREIGN KEY([PayCentreId])
--REFERENCES [dbo].[Centres] ([Id])
--GO

--ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Centres_PayCentreId]
--GO


