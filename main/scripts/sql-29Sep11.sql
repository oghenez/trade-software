if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[portfolioDetail]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[portfolioDetail]
GO

CREATE TABLE [dbo].[portfolioDetail] (
	[portfolio] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[code] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[subCode] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[data] [nvarchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

