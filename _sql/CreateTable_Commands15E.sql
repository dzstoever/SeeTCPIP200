USE [SeeCommon]
GO
/****** Object:  Table [dbo].[Commands15E]    Script Date: 01/15/2009 10:51:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Commands15E](
	[Name] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Family] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Shortcut] [varchar](16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Syntax] [varchar](4096) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [varchar](4096) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Example] [varchar](4096) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Related] [varchar](4096) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Deprecated] [bit] NULL,
 CONSTRAINT [cprim_15E] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF