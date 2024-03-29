USE [SeeCommon]
GO
/****** Object:  Table [dbo].[Messages15E]    Script Date: 01/15/2009 10:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Messages15E](
	[Name] [char](7) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Family] [varchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Summary] [varchar](512) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Detail] [varchar](2048) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AdminAction] [varchar](1024) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OperatorAction] [varchar](1024) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SystemAction] [varchar](1024) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [mprim_15E] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF