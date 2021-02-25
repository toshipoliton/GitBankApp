USE [BankingSystem]
GO

/****** Object:  Table [dbo].[CheckingsAccount]    Script Date: 2/25/2021 9:21:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CheckingsAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](19, 4) NOT NULL,
 CONSTRAINT [PK_CheckingsAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CheckingsAccount]  WITH CHECK ADD  CONSTRAINT [FK_CheckingsAccount_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([ID])
GO

ALTER TABLE [dbo].[CheckingsAccount] CHECK CONSTRAINT [FK_CheckingsAccount_Person]
GO

