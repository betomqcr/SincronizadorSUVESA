USE [SINCRONIZADOR]
GO
/****** Object:  Table [dbo].[Albaran]    Script Date: 04/08/2022 15:37:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albaran](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [nvarchar](max) NOT NULL,
	[NombreMascota] [nvarchar](max) NULL,
	[Fecha] [datetime] NOT NULL,
	[Id_Qvet_Migrado] [bigint] NOT NULL,
	[facturado] [bit] NULL,
	[Cedula] [nvarchar](20) NULL,
	[Id_Mascota_Qvet] [bigint] NULL,
	[Email] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[NHC_Mascota] [nvarchar](max) NULL,
	[ID_Factura_Suvesa] [bigint] NULL,
	[Responsable] [nvarchar](max) NOT NULL,
	[Tipo_Cliente] [nvarchar](max) NULL,
	[CHIP_Mascota] [nvarchar](max) NULL,
 CONSTRAINT [PK__Encabeza__3213E83F57F0CDB1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Albaran_Detalle]    Script Date: 04/08/2022 15:37:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albaran_Detalle](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[idEncabezado] [bigint] NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[CodigoInternoQvet] [bigint] NOT NULL,
	[Cantidad] [decimal](10, 4) NOT NULL,
	[IVA] [bigint] NOT NULL,
	[descuento] [decimal](18, 4) NULL,
	[PrecioVenta] [decimal](18, 4) NOT NULL,
	[Total] [decimal](18, 4) NOT NULL,
	[Unidad] [nvarchar](50) NULL,
 CONSTRAINT [PK__Detalle__3213E83F8341DE7E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora_Albaran]    Script Date: 04/08/2022 15:37:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora_Albaran](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo] [nvarchar](1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[hora] [time](7) NOT NULL,
	[usuario] [nvarchar](1) NOT NULL,
	[CantidadRegistrosProcesados] [numeric](18, 4) NOT NULL,
 CONSTRAINT [PK__Auditori__3213E83F11386423] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Albaran_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_IdEncabezado] FOREIGN KEY([idEncabezado])
REFERENCES [dbo].[Albaran] ([id])
GO
ALTER TABLE [dbo].[Albaran_Detalle] CHECK CONSTRAINT [FK_IdEncabezado]
GO
