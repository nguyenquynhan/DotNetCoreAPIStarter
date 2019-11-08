USE [master]
GO
/****** Object:  Database [Todo]    Script Date: 11/8/2019 9:48:31 AM ******/
CREATE DATABASE [Todo]
GO
USE [Todo]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/8/2019 9:48:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Roles] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([Id], [Username], [Password], [FirstName], [LastName], [Roles]) VALUES (1, N'Admin', N'123', N'Supper', N'Admin', N'Admin')
GO
INSERT [dbo].[User] ([Id], [Username], [Password], [FirstName], [LastName], [Roles]) VALUES (2, N'Guess', N'123', N'Ms', N'Guess', NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
USE [master]
GO
ALTER DATABASE [Todo] SET  READ_WRITE 
GO
