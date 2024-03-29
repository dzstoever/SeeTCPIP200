USE [SeeCommon]
GO
/****** Object:  Table [dbo].[Expositions15E]    Script Date: 01/15/2009 10:52:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Expositions15E](
	[ID] [int] IDENTITY(0,1) NOT NULL,
	[CommandName] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Exposition] [varchar](4096) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [pprimE_15E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[CommandName] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Expositions15E]  WITH CHECK ADD  CONSTRAINT [pforgnE_15E] FOREIGN KEY([CommandName])
REFERENCES [dbo].[Commands15E] ([Name])
GO
ALTER TABLE [dbo].[Expositions15E] CHECK CONSTRAINT [pforgnE_15E]