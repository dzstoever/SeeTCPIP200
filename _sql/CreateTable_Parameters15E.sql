USE [SeeCommon]
GO
/****** Object:  Table [dbo].[Parameters15E]    Script Date: 01/15/2009 10:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parameters15E](
	[CommandName] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Name] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Shortcut] [varchar](16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Required] [bit] NULL,
	[Assigned] [bit] NULL,
	[Keyword] [bit] NULL,
	[Delimited] [bit] NULL,
	[Constraints] [varchar](512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DefaultValue] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [varchar](4096) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [pprim_15E] PRIMARY KEY CLUSTERED 
(
	[CommandName] ASC,
	[Name] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Parameters15E]  WITH CHECK ADD  CONSTRAINT [pforgn_15E] FOREIGN KEY([CommandName])
REFERENCES [dbo].[Commands15E] ([Name])
GO
ALTER TABLE [dbo].[Parameters15E] CHECK CONSTRAINT [pforgn_15E]