USE [ProEventos]
GO

/****** Object:  Table [dbo].[Associado_Empresa]    Script Date: 26/11/2023 00:33:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Associado_Empresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Associado_Id] [int] NOT NULL,
	[Associado_CPF] [nchar](11) NOT NULL,
	[Empresa_Id] [int] NOT NULL,
	[Empresa_CNPJ] [nchar](14) NOT NULL,
 CONSTRAINT [PK_Associado_Empresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Associado_Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Associado_Empresa_Associado_Empresa] FOREIGN KEY([Id])
REFERENCES [dbo].[Associado_Empresa] ([Id])
GO

ALTER TABLE [dbo].[Associado_Empresa] CHECK CONSTRAINT [FK_Associado_Empresa_Associado_Empresa]
GO


