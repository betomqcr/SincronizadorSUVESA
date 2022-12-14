USE [SINCRONIZADOR]
GO
/****** Object:  Table [dbo].[Albaran]    Script Date: 02/08/2022 16:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albaran](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [nvarchar](1) NOT NULL,
	[NombreMascota] [nvarchar](1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Id_Qvet_Migrado] [int] NOT NULL,
	[facturado] [bit] NOT NULL,
	[Cedula] [nvarchar](12) NOT NULL,
	[Id_Mascota_Qvet] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[NHC_Mascota] [nvarchar](20) NOT NULL,
	[ID_Factura_Suvesa] [int] NOT NULL,
	[Responsable] [nvarchar](100) NOT NULL,
	[Tipo_Cliente] [nvarchar](50) NULL,
	[CHIP_Mascota] [nvarchar](50) NULL,
 CONSTRAINT [PK__Encabeza__3213E83F57F0CDB1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Albaran_Detalle]    Script Date: 02/08/2022 16:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albaran_Detalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idEncabezado] [int] NOT NULL,
	[Descripcion] [nvarchar](1) NOT NULL,
	[CodigoInternoQvet] [int] NOT NULL,
	[Cantidad] [decimal](10, 4) NOT NULL,
	[IVA] [int] NOT NULL,
	[descuento] [float] NOT NULL,
	[PrecioVenta] [decimal](18, 4) NOT NULL,
	[Total] [decimal](18, 4) NOT NULL,
	[Unidad] [nvarchar](50) NULL,
 CONSTRAINT [PK__Detalle__3213E83F8341DE7E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora_Albaran]    Script Date: 02/08/2022 16:09:54 ******/
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
