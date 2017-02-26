USE [PTR]
GO

/****** Object:  Table [dbo].[FailRecord]    Script Date: 07/02/2014 09:24:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FailRecord](
	[RecordId] [bigint] IDENTITY(1,1) NOT NULL,
	[Failure] [int] NULL,
	[Reporter] [nchar](10) NULL,
	[Description] [ntext] NULL,
	[PO] [nchar](9) NULL,
	[Model] [varchar](30) NULL,
	[Material] [varchar](30) NULL,
	[TimeStop] [datetime] NULL,
	[TimeResume] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_FailRecord] PRIMARY KEY CLUSTERED 
(
	[RecordId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FailRecord]  WITH CHECK ADD  CONSTRAINT [FK_FailRecord_ADC_Opcode1] FOREIGN KEY([Reporter])
REFERENCES [dbo].[ADC_Opcode] ([OpCode])
GO

ALTER TABLE [dbo].[FailRecord] CHECK CONSTRAINT [FK_FailRecord_ADC_Opcode1]
GO

ALTER TABLE [dbo].[FailRecord]  WITH CHECK ADD  CONSTRAINT [FK_FailRecord_Failure1] FOREIGN KEY([Failure])
REFERENCES [dbo].[Failure] ([Id])
GO

ALTER TABLE [dbo].[FailRecord] CHECK CONSTRAINT [FK_FailRecord_Failure1]
GO

