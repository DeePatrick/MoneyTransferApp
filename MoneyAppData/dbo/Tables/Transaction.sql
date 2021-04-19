CREATE TABLE [dbo].[Transaction](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionType] [int] NOT NULL,
	[IsWithdrawal] [bit] NOT NULL,
	[PayeeName] [nvarchar](max) NULL,
	[BankName] [nvarchar](max) NOT NULL,
	[AccountNo] [nvarchar](10) NOT NULL,
	[Location] [nvarchar](max) NULL,
	[BankCharge] [decimal](20, 2) NOT NULL,
	[Amount] [decimal](20, 2) NOT NULL,
	[CardNo] [nvarchar](max) NULL,
	[CardType] [int] NOT NULL,
	[CreateDate] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CustomerId] [int] NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transaction] ADD  DEFAULT (N'') FOR [BankName]
GO

ALTER TABLE [dbo].[Transaction] ADD  DEFAULT (N'') FOR [AccountNo]
GO

ALTER TABLE [dbo].[Transaction] ADD  DEFAULT ((0.0)) FOR [BankCharge]
GO

ALTER TABLE [dbo].[Transaction] ADD  DEFAULT ((0.0)) FOR [Amount]
GO

ALTER TABLE [dbo].[Transaction] ADD  DEFAULT ((0)) FOR [CardType]
GO

ALTER TABLE [dbo].[Transaction] ADD  CONSTRAINT [FK_Transaction_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO

ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Customers_CustomerId]
GO


