USE [GiustiFCamara]
GO
/****** Object:  Table [dbo].[Funcionalidade]    Script Date: 16/09/2017 12:34:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Funcionalidade]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Funcionalidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[FuncionalidadeIdPai] [int] NULL,
	[UtilizaMenu] [bit] NOT NULL,
	[LinkMenu] [varchar](50) NULL,
 CONSTRAINT [PK_Funcionalidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 16/09/2017 12:34:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Perfil]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PerfilFuncionalidade]    Script Date: 16/09/2017 12:34:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PerfilFuncionalidade]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PerfilFuncionalidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PerfilId] [int] NOT NULL,
	[FuncionalidadeId] [int] NOT NULL,
 CONSTRAINT [PK_Acesso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PerfilUsuario]    Script Date: 16/09/2017 12:34:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PerfilUsuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PerfilUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PerfilId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_PerfilUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/09/2017 12:34:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Senha] [varchar](300) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[DataInclusao] [datetime] NOT NULL,
	[DataAlteracao] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Livro]    Script Date: 15/09/2017 19:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Livro]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Livro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Autor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Funcionalidade] ON 

GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[Funcionalidade] WHERE [Id] = 1)
BEGIN
INSERT [dbo].[Funcionalidade] ([Id], [Nome], [FuncionalidadeIdPai], [UtilizaMenu], [LinkMenu]) VALUES (1, N'Livros', NULL, 1, N'livros')
END
GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[Funcionalidade] WHERE [Id] = 2)
BEGIN
INSERT [dbo].[Funcionalidade] ([Id], [Nome], [FuncionalidadeIdPai], [UtilizaMenu], [LinkMenu]) VALUES (2, N'Livros Consulta', 1, 0, NULL)
END
GO
SET IDENTITY_INSERT [dbo].[Funcionalidade] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 

GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[Perfil] WHERE [Id] = 1)
BEGIN
INSERT [dbo].[Perfil] ([Id], [Nome]) VALUES (1, N'Master')
END
GO
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[PerfilFuncionalidade] ON 

GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[PerfilFuncionalidade] WHERE [Id] = 1)
BEGIN
INSERT [dbo].[PerfilFuncionalidade] ([Id], [PerfilId], [FuncionalidadeId]) VALUES (1, 1, 1)
END
GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[PerfilFuncionalidade] WHERE [Id] = 2)
BEGIN
INSERT [dbo].[PerfilFuncionalidade] ([Id], [PerfilId], [FuncionalidadeId]) VALUES (2, 1, 2)
END
GO
SET IDENTITY_INSERT [dbo].[PerfilFuncionalidade] OFF
GO

SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[Usuario] WHERE [Id] = 1)
BEGIN
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [Ativo], [DataInclusao], [DataAlteracao]) VALUES (1, N'Lucas Giusti', N'giusti', N'1000:fXJZy1QqQ13JMTNQFiLN8Jsosc5rWT0P:5CHJXCLjmQRthPvotnQ6g81gaN4=', 1, CAST(N'2017-09-16 03:56:06.583' AS DateTime), NULL)
END
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO

SET IDENTITY_INSERT [dbo].[PerfilUsuario] ON 

GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[PerfilUsuario] WHERE [Id] = 1)
BEGIN
INSERT [dbo].[PerfilUsuario] ([Id], [PerfilId], [UsuarioId]) VALUES (1, 1, 1)
END
GO
SET IDENTITY_INSERT [dbo].[PerfilUsuario] OFF
GO

SET IDENTITY_INSERT [dbo].[Livro] ON 

GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[Livro] WHERE [Id] = 1)
BEGIN
INSERT [dbo].[Livro] ([Id], [Nome], [Autor]) VALUES (1, N'Steve Jobs', N'Walter Isaacson')
END
GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[Livro] WHERE [Id] = 2)
BEGIN
INSERT [dbo].[Livro] ([Id], [Nome], [Autor]) VALUES (2, N'Walt Disney - O triunfo da imaginação americana', N'Neal Gabler')
END
GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[Livro] WHERE [Id] = 3)
BEGIN
INSERT [dbo].[Livro] ([Id], [Nome], [Autor]) VALUES (3, N'A arte da guerra', N'Sun Tzu')
END
GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[Livro] WHERE [Id] = 4)
BEGIN
INSERT [dbo].[Livro] ([Id], [Nome], [Autor]) VALUES (4, N'Guerreiros não nascem prontos', N'José Luiz Tejon')
END
GO
IF NOT EXISTS(SELECT 1 FROM [dbo].[Livro] WHERE [Id] = 5)
BEGIN
INSERT [dbo].[Livro] ([Id], [Nome], [Autor]) VALUES (5, N'Nosso lar', N'Chico Xavier')
END
GO
SET IDENTITY_INSERT [dbo].[Livro] OFF
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcionalidade_Funcionalidade]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcionalidade]'))
ALTER TABLE [dbo].[Funcionalidade]  WITH CHECK ADD  CONSTRAINT [FK_Funcionalidade_Funcionalidade] FOREIGN KEY([FuncionalidadeIdPai])
REFERENCES [dbo].[Funcionalidade] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Funcionalidade_Funcionalidade]') AND parent_object_id = OBJECT_ID(N'[dbo].[Funcionalidade]'))
ALTER TABLE [dbo].[Funcionalidade] CHECK CONSTRAINT [FK_Funcionalidade_Funcionalidade]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PerfilFuncionalidade_Funcionalidade]') AND parent_object_id = OBJECT_ID(N'[dbo].[PerfilFuncionalidade]'))
ALTER TABLE [dbo].[PerfilFuncionalidade]  WITH CHECK ADD  CONSTRAINT [FK_PerfilFuncionalidade_Funcionalidade] FOREIGN KEY([FuncionalidadeId])
REFERENCES [dbo].[Funcionalidade] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PerfilFuncionalidade_Funcionalidade]') AND parent_object_id = OBJECT_ID(N'[dbo].[PerfilFuncionalidade]'))
ALTER TABLE [dbo].[PerfilFuncionalidade] CHECK CONSTRAINT [FK_PerfilFuncionalidade_Funcionalidade]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PerfilFuncionalidade_Perfil]') AND parent_object_id = OBJECT_ID(N'[dbo].[PerfilFuncionalidade]'))
ALTER TABLE [dbo].[PerfilFuncionalidade]  WITH CHECK ADD  CONSTRAINT [FK_PerfilFuncionalidade_Perfil] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfil] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PerfilFuncionalidade_Perfil]') AND parent_object_id = OBJECT_ID(N'[dbo].[PerfilFuncionalidade]'))
ALTER TABLE [dbo].[PerfilFuncionalidade] CHECK CONSTRAINT [FK_PerfilFuncionalidade_Perfil]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PerfilUsuario_Perfil]') AND parent_object_id = OBJECT_ID(N'[dbo].[PerfilUsuario]'))
ALTER TABLE [dbo].[PerfilUsuario]  WITH CHECK ADD  CONSTRAINT [FK_PerfilUsuario_Perfil] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfil] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PerfilUsuario_Perfil]') AND parent_object_id = OBJECT_ID(N'[dbo].[PerfilUsuario]'))
ALTER TABLE [dbo].[PerfilUsuario] CHECK CONSTRAINT [FK_PerfilUsuario_Perfil]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PerfilUsuario_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[PerfilUsuario]'))
ALTER TABLE [dbo].[PerfilUsuario]  WITH CHECK ADD  CONSTRAINT [FK_PerfilUsuario_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PerfilUsuario_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[PerfilUsuario]'))
ALTER TABLE [dbo].[PerfilUsuario] CHECK CONSTRAINT [FK_PerfilUsuario_Usuario]
GO