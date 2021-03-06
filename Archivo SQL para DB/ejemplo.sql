USE [ejercicio]
GO
/****** Object:  Table [dbo].[Autores]    Script Date: 13/11/2021 4:21:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autores](
	[IdAutor] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [nvarchar](150) NULL,
	[FechaNacimiento] [date] NULL,
	[CiudadProcedencia] [nvarchar](50) NULL,
	[Email] [nvarchar](150) NULL,
 CONSTRAINT [PK_Autores] PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 13/11/2021 4:21:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[idLibro] [int] IDENTITY(1,1) NOT NULL,
	[NombreLibro] [nvarchar](150) NULL,
	[Paginas] [int] NULL,
	[IdAutor] [int] NULL,
	[AnnioPublicacion] [int] NULL,
	[Genero] [nvarchar](150) NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[idLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Libros]  WITH CHECK ADD  CONSTRAINT [FK_Libros_Autores] FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Autores] ([IdAutor])
GO
ALTER TABLE [dbo].[Libros] CHECK CONSTRAINT [FK_Libros_Autores]
GO
