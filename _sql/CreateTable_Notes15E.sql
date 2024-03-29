USE [SeeCommon]
GO
/****** Object:  Table [dbo].[Notes15E]    Script Date: 01/15/2009 10:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Notes15E](
	[ID] [int] IDENTITY(0,1) NOT NULL,
	[CommandName] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Note] [varchar](4096) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [pprimN_15E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[CommandName] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Notes15E]  WITH CHECK ADD  CONSTRAINT [pforgnN_15E] FOREIGN KEY([CommandName])
REFERENCES [dbo].[Commands15E] ([Name])
GO
ALTER TABLE [dbo].[Notes15E] CHECK CONSTRAINT [pforgnN_15E]