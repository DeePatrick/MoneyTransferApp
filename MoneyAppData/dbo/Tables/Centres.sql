CREATE TABLE [dbo].[Centres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CentreName] [nvarchar](100) NOT NULL,
	[CentreAddress] [nvarchar](100) NOT NULL,
	[CentreAccountNo] [nvarchar](10) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[UpdateDate] [nvarchar](max) NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Capital] [decimal](20, 2) NOT NULL,
	[CentreTabNumber] [nvarchar](10) NULL,
	[CentrePhone] [nvarchar](14) NULL,
	[CentrePOSNumber] [nvarchar](10) NULL,
 CONSTRAINT [PK_Centres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Centres] ADD  CONSTRAINT [DF_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
GO