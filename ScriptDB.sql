USE [master]
GO
/****** Object:  Database [facturacion]    Script Date: 4/12/2020 12:10:59 a. m. ******/
CREATE DATABASE [facturacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'facturacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\facturacion.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'facturacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\facturacion_log.ldf' , SIZE = 2560KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [facturacion] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [facturacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [facturacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [facturacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [facturacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [facturacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [facturacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [facturacion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [facturacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [facturacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [facturacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [facturacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [facturacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [facturacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [facturacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [facturacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [facturacion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [facturacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [facturacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [facturacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [facturacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [facturacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [facturacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [facturacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [facturacion] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [facturacion] SET  MULTI_USER 
GO
ALTER DATABASE [facturacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [facturacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [facturacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [facturacion] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [facturacion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [facturacion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [facturacion] SET QUERY_STORE = OFF
GO
USE [facturacion]
GO
/****** Object:  Table [dbo].[categoria_producto]    Script Date: 4/12/2020 12:10:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria_producto](
	[id] [tinyint] NOT NULL,
	[nombre] [varchar](45) NOT NULL,
 CONSTRAINT [PK_categoria_producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 4/12/2020 12:10:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[documento] [varchar](20) NOT NULL,
	[nombres] [varchar](45) NOT NULL,
	[apellidos] [varchar](45) NOT NULL,
	[telefono] [varchar](13) NULL,
	[email] [varchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_factura]    Script Date: 4/12/2020 12:10:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_factura](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_factura] [numeric](18, 0) NOT NULL,
	[id_producto] [numeric](18, 0) NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_detalle_factura] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[factura]    Script Date: 4/12/2020 12:10:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[factura](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_cliente] [varchar](20) NOT NULL,
	[fecha] [date] NOT NULL,
	[id_forma_pago] [tinyint] NOT NULL,
	[total_factura] [decimal](18, 0) NULL,
 CONSTRAINT [PK_factura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[forma_pago]    Script Date: 4/12/2020 12:10:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[forma_pago](
	[id] [tinyint] NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[sigla] [varchar](5) NULL,
 CONSTRAINT [PK_metodo_pago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 4/12/2020 12:10:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[codigo_producto] [numeric](18, 0) NOT NULL,
	[producto] [varchar](100) NOT NULL,
	[costo] [decimal](18, 0) NOT NULL,
	[stock] [int] NOT NULL,
	[id_categoria_producto] [tinyint] NOT NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[codigo_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[detalle_factura]  WITH CHECK ADD  CONSTRAINT [FK_detalle_factura_factura] FOREIGN KEY([id_factura])
REFERENCES [dbo].[factura] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_factura] CHECK CONSTRAINT [FK_detalle_factura_factura]
GO
ALTER TABLE [dbo].[detalle_factura]  WITH CHECK ADD  CONSTRAINT [FK_detalle_factura_productos] FOREIGN KEY([id_producto])
REFERENCES [dbo].[productos] ([codigo_producto])
GO
ALTER TABLE [dbo].[detalle_factura] CHECK CONSTRAINT [FK_detalle_factura_productos]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [FK_factura_forma_pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[forma_pago] ([id])
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [FK_factura_forma_pago]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [FK_factura_usuario] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[clientes] ([documento])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [FK_factura_usuario]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_categoria_producto] FOREIGN KEY([id_categoria_producto])
REFERENCES [dbo].[categoria_producto] ([id])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_categoria_producto]
GO
USE [master]
GO
ALTER DATABASE [facturacion] SET  READ_WRITE 
GO
