USE [Project]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 2021/7/15 下午 01:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberId] [uniqueidentifier] NOT NULL,
	[MemberName] [nvarchar](100) NOT NULL,
	[ProjectId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTable]    Script Date: 2021/7/15 下午 01:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTable](
	[ProjectId] [uniqueidentifier] NOT NULL,
	[ProjectName] [nvarchar](100) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectTable] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Member] ([MemberId], [MemberName], [ProjectId]) VALUES (N'b15d1bfd-1a7d-432d-9cc7-2b359c490606', N'Member1', N'edff51c5-51c5-44c2-887c-09a433b586a7')
GO
INSERT [dbo].[Member] ([MemberId], [MemberName], [ProjectId]) VALUES (N'f3d61a22-e02c-4c21-a62a-4446a93255d8', N'Member2', N'edff51c5-51c5-44c2-887c-09a433b586a7')
GO
INSERT [dbo].[ProjectTable] ([ProjectId], [ProjectName], [CreateTime], [UpdateTime]) VALUES (N'edff51c5-51c5-44c2-887c-09a433b586a7', N'Project1', CAST(N'2021-07-13T00:00:00.000' AS DateTime), CAST(N'2021-07-13T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[ProjectTable] ([ProjectId], [ProjectName], [CreateTime], [UpdateTime]) VALUES (N'c26f13ca-c599-4368-8387-9e0fb3b1ad3c', N'swagger update', CAST(N'2021-07-13T14:41:47.997' AS DateTime), CAST(N'2021-07-14T21:46:43.673' AS DateTime))
GO
INSERT [dbo].[ProjectTable] ([ProjectId], [ProjectName], [CreateTime], [UpdateTime]) VALUES (N'ba0887f3-0d02-4dcb-a599-c0f2c8e1098e', N'string', CAST(N'2021-07-13T14:59:41.830' AS DateTime), CAST(N'2021-07-13T14:59:59.600' AS DateTime))
GO
/****** Object:  StoredProcedure [dbo].[usp_Project_Delete]    Script Date: 2021/7/15 下午 01:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Project_Delete]
	@ProjectId UNIQUEIDENTIFIER
AS
BEGIN

	DELETE ProjectTable 
	WHERE ProjectId = @ProjectId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Project_GetAll]    Script Date: 2021/7/15 下午 01:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Project_GetAll]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		ProjectId
		,ProjectName
		,[CreateTime]
		,[UpdateTime]
	FROM Project.dbo.ProjectTable

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Project_GetByProjectId]    Script Date: 2021/7/15 下午 01:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Project_GetByProjectId]
	@ProjectId UNIQUEIDENTIFIER
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		[ProjectId]
		,[ProjectName]
		,[CreateTime]
		,[UpdateTime]
	FROM [Project].[dbo].[ProjectTable]
	WHERE ProjectId = @ProjectId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Project_GetByProjectName]    Script Date: 2021/7/15 下午 01:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Project_GetByProjectName]
	@ProjectName NVARCHAR(100)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		[ProjectId]
		,[ProjectName]
		,[CreateTime]
		,[UpdateTime]
	FROM [Project].[dbo].[ProjectTable]
	WHERE ProjectName = @ProjectName

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Project_GetMemberByProjectId]    Script Date: 2021/7/15 下午 01:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Project_GetMemberByProjectId]
	@ProjectId UNIQUEIDENTIFIER
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		p.ProjectId
		,ProjectName
		,m.MemberName
	FROM dbo.ProjectTable p
	JOIN dbo.Member m ON p.ProjectId = m.ProjectId 
	WHERE p.ProjectId = @ProjectId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Project_Insert]    Script Date: 2021/7/15 下午 01:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Project_Insert]
	@ProjectId UNIQUEIDENTIFIER,
	@ProjectName NVARCHAR(100)
AS
BEGIN

	INSERT INTO ProjectTable ([ProjectId], [ProjectName], [CreateTime], [UpdateTime])
	VALUES (@ProjectId, @ProjectName,  GETDATE(),  GETDATE())

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Project_Update]    Script Date: 2021/7/15 下午 01:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Project_Update]
	@ProjectId UNIQUEIDENTIFIER,
	@ProjectName NVARCHAR(100)
AS
BEGIN

	UPDATE ProjectTable 
	SET ProjectName = @ProjectName,
		UpdateTime = GETDATE()
	WHERE ProjectId = @ProjectId

END
GO
