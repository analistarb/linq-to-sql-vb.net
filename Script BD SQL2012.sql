USE [schoolSystem]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 04/02/2016 20:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aluno](
	[idAluno] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[Endereco] [varchar](255) NULL,
	[Cep] [varchar](17) NULL,
	[Telefone] [varchar](17) NULL,
	[Celular] [varchar](17) NULL,
	[dataNascimento] [date] NULL,
	[dataCadastro] [datetime] NULL,
	[dataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_ALUNO] PRIMARY KEY CLUSTERED 
(
	[idAluno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 04/02/2016 20:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Curso](
	[idCurso] [int] IDENTITY(1,1) NOT NULL,
	[idAluno] [int] NOT NULL,
	[idMateria] [int] NOT NULL,
	[Nome] [varchar](255) NULL,
	[Descricao] [varchar](255) NULL,
	[dataCadastro] [datetime] NULL,
	[dataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_CURSO] PRIMARY KEY CLUSTERED 
(
	[idCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 04/02/2016 20:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materia](
	[idMateria] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[Descricao] [varchar](255) NULL,
	[dataCadastro] [datetime] NULL DEFAULT (getdate()),
	[dataAtualizacao] [datetime] NULL,
 CONSTRAINT [PK_MATERIA] PRIMARY KEY CLUSTERED 
(
	[idMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([idMateria], [Nome], [Descricao], [dataCadastro], [dataAtualizacao]) VALUES (1, N'Banco de Dados II', N'Estudos de Banco de Dados e similares', CAST(N'2016-01-01 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Materia] ([idMateria], [Nome], [Descricao], [dataCadastro], [dataAtualizacao]) VALUES (2, N'Redes e Internet', N'Redes e Internet', CAST(N'2016-01-02 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Materia] OFF
ALTER TABLE [dbo].[Aluno] ADD  DEFAULT (getdate()) FOR [dataCadastro]
GO
ALTER TABLE [dbo].[Curso] ADD  DEFAULT (getdate()) FOR [dataCadastro]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_ALUNO] FOREIGN KEY([idMateria])
REFERENCES [dbo].[Materia] ([idMateria])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_ALUNO]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_MATERIA] FOREIGN KEY([idAluno])
REFERENCES [dbo].[Aluno] ([idAluno])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_MATERIA]
GO
