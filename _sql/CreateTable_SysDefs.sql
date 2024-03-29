USE [SeeCommon]
GO
/****** Object:  Table [dbo].[SysDefs]    Script Date: 01/15/2009 10:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SysDefs](
	[DateCreated] [datetime] NULL,
	[Name] [varchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DbName] [varchar](45) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IpAddress] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Port] [int] NULL,
	[UserId] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Password] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UtcOffset] [int] NULL,
	[StartPollTime] [datetime] NULL,
	[EndPollTime] [datetime] NULL,
	[monOn] [bit] NULL,
	[monCpu] [bit] NULL,
	[monJobs] [bit] NULL,
	[monIps] [bit] NULL,
	[monBSDC] [bit] NULL,
	[monConns] [bit] NULL,
	[monFTPs] [bit] NULL,
	[useConsole] [bit] NULL,
	[pollIntervalms] [int] NULL,
 CONSTRAINT [primkey] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF