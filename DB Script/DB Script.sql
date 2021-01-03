USE [FeedbackCollection]
GO
/****** Object:  Table [dbo].[CommentVotes]    Script Date: 1/3/2021 11:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentVotes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CommentId] [bigint] NOT NULL,
	[VoteType] [tinyint] NULL,
	[VoteUserId] [int] NULL,
	[VotedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_CommentVotes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUsers]    Script Date: 1/3/2021 11:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUsers](
	[UserId] [int] NOT NULL,
	[CUserName] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostComments]    Script Date: 1/3/2021 11:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[CommentText] [nvarchar](max) NOT NULL,
	[CommentedUserId] [int] NOT NULL,
	[CommentedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_PostComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPosts]    Script Date: 1/3/2021 11:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPosts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostText] [nvarchar](max) NOT NULL,
	[PostedUserId] [int] NOT NULL,
	[AddedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_UserPosts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CommentVotes] ON 
GO
INSERT [dbo].[CommentVotes] ([Id], [CommentId], [VoteType], [VoteUserId], [VotedOn]) VALUES (1, 1, 1, 1, CAST(N'2021-01-03T21:28:37.540' AS DateTime))
GO
INSERT [dbo].[CommentVotes] ([Id], [CommentId], [VoteType], [VoteUserId], [VotedOn]) VALUES (2, 1, 1, 2, CAST(N'2021-01-03T21:28:41.063' AS DateTime))
GO
INSERT [dbo].[CommentVotes] ([Id], [CommentId], [VoteType], [VoteUserId], [VotedOn]) VALUES (3, 1, 2, 3, CAST(N'2021-01-03T21:31:24.070' AS DateTime))
GO
INSERT [dbo].[CommentVotes] ([Id], [CommentId], [VoteType], [VoteUserId], [VotedOn]) VALUES (4, 2, 1, 1, CAST(N'2021-01-03T21:31:33.913' AS DateTime))
GO
INSERT [dbo].[CommentVotes] ([Id], [CommentId], [VoteType], [VoteUserId], [VotedOn]) VALUES (5, 2, 2, 4, CAST(N'2021-01-03T21:31:49.047' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[CommentVotes] OFF
GO
INSERT [dbo].[CUsers] ([UserId], [CUserName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[CUsers] ([UserId], [CUserName]) VALUES (2, N'User1')
GO
INSERT [dbo].[CUsers] ([UserId], [CUserName]) VALUES (3, N'User2')
GO
INSERT [dbo].[CUsers] ([UserId], [CUserName]) VALUES (4, N'User3')
GO
SET IDENTITY_INSERT [dbo].[PostComments] ON 
GO
INSERT [dbo].[PostComments] ([Id], [PostId], [CommentText], [CommentedUserId], [CommentedOn]) VALUES (1, 1, N'Comment 1', 2, CAST(N'2021-01-03T21:25:11.740' AS DateTime))
GO
INSERT [dbo].[PostComments] ([Id], [PostId], [CommentText], [CommentedUserId], [CommentedOn]) VALUES (2, 1, N'Comment 2', 3, CAST(N'2021-01-03T21:25:23.430' AS DateTime))
GO
INSERT [dbo].[PostComments] ([Id], [PostId], [CommentText], [CommentedUserId], [CommentedOn]) VALUES (3, 1, N'Comment 3', 4, CAST(N'2021-01-03T21:25:33.293' AS DateTime))
GO
INSERT [dbo].[PostComments] ([Id], [PostId], [CommentText], [CommentedUserId], [CommentedOn]) VALUES (4, 2, N'Comment 4', 2, CAST(N'2021-01-03T21:26:16.953' AS DateTime))
GO
INSERT [dbo].[PostComments] ([Id], [PostId], [CommentText], [CommentedUserId], [CommentedOn]) VALUES (5, 2, N'Comment 5', 3, CAST(N'2021-01-03T21:26:24.800' AS DateTime))
GO
INSERT [dbo].[PostComments] ([Id], [PostId], [CommentText], [CommentedUserId], [CommentedOn]) VALUES (6, 2, N'Comment 6', 4, CAST(N'2021-01-03T21:26:41.037' AS DateTime))
GO
INSERT [dbo].[PostComments] ([Id], [PostId], [CommentText], [CommentedUserId], [CommentedOn]) VALUES (7, 2, N'Comment 7', 4, CAST(N'2021-01-03T21:26:56.723' AS DateTime))
GO
INSERT [dbo].[PostComments] ([Id], [PostId], [CommentText], [CommentedUserId], [CommentedOn]) VALUES (8, 3, N'Comment 8', 2, CAST(N'2021-01-03T21:27:20.887' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[PostComments] OFF
GO
SET IDENTITY_INSERT [dbo].[UserPosts] ON 
GO
INSERT [dbo].[UserPosts] ([Id], [PostText], [PostedUserId], [AddedOn]) VALUES (1, N'Post 1', 1, CAST(N'2021-01-03T21:23:15.150' AS DateTime))
GO
INSERT [dbo].[UserPosts] ([Id], [PostText], [PostedUserId], [AddedOn]) VALUES (2, N'Post 2', 1, CAST(N'2021-01-03T21:24:01.460' AS DateTime))
GO
INSERT [dbo].[UserPosts] ([Id], [PostText], [PostedUserId], [AddedOn]) VALUES (3, N'Post 3', 1, CAST(N'2021-01-03T21:24:09.050' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserPosts] OFF
GO
ALTER TABLE [dbo].[CommentVotes] ADD  CONSTRAINT [DF_CommentVotes_VotedOn]  DEFAULT (getdate()) FOR [VotedOn]
GO
ALTER TABLE [dbo].[PostComments] ADD  CONSTRAINT [DF_PostComments_CommentedOn]  DEFAULT (getdate()) FOR [CommentedOn]
GO
ALTER TABLE [dbo].[UserPosts] ADD  CONSTRAINT [DF_UserPosts_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  StoredProcedure [dbo].[GetUserPostComments]    Script Date: 1/3/2021 11:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<SK Mohtasim Billah>
-- Create date: <3rd Jan 2021>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserPostComments]

AS
BEGIN
	select up.PostText 'Post',pm.CommentText 'Comment',(select CUserName from CUsers where UserId=up.PostedUserId) 'User',
	(select AddedOn from UserPosts where Id=up.Id) 'PostAddedOn',
	(select AddedOn from PostComments where Id=pm.Id) 'CommentsAddedOn',
	(select sum(case when cv.VoteType=1 then 1 else 0 end) ) 'Upvote'
	,(select sum(case when cv.VoteType=2 then 1 else 0 end) ) 'Downvote'
	from UserPosts up inner join PostComments pm on up.Id=pm.PostId
		left join  CommentVotes cv on pm.Id=cv.CommentId
	group by cv.CommentId, up.PostText,pm.CommentText,up.Id,up.PostedUserId,pm.Id,AddedOn
	order by up.Id,pm.Id
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1= Upvote, 2=Downvote' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CommentVotes', @level2type=N'COLUMN',@level2name=N'VoteType'
GO
