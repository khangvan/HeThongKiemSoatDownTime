USE [PTR]
GO

/****** Object:  Table [dbo].[FailGroup]    Script Date: 07/02/2014 09:25:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[FailGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](50) NULL,
 CONSTRAINT [PK_FailGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

