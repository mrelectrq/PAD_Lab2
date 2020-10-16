CREATE DATABASE [PADLaboratories]


CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Balance] [float] NOT NULL,
	[DateRegistered] [datetime] NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Credits] [varchar](20) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Currency](
	[USD] [float] NOT NULL,
	[EUR] [float] NOT NULL,
	[RUB] [float] NOT NULL,
	[RON] [float] NOT NULL,
	[UAH] [float] NOT NULL,
	[TYPE] [varchar](10) NOT NULL,
	[TimeCurrency] [datetime] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Currency] ADD  DEFAULT (getdate()) FOR [TimeCurrency]
GO



CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[AccountOwnerID] [int] NOT NULL,
	[AccountReceiverID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Currency] [varchar](20) NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Accounts] FOREIGN KEY([AccountOwnerID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Accounts]
GO

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Accounts1] FOREIGN KEY([AccountReceiverID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Accounts1]
GO



