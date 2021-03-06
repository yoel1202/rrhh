USE [master]
GO
/****** Object:  Database [bd_RRHH]    Script Date: 27/06/2020 10:16:01 ******/
CREATE DATABASE [bd_RRHH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bd_RRHH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\bd_RRHH.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bd_RRHH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\bd_RRHH_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [bd_RRHH] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bd_RRHH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bd_RRHH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bd_RRHH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bd_RRHH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bd_RRHH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bd_RRHH] SET ARITHABORT OFF 
GO
ALTER DATABASE [bd_RRHH] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bd_RRHH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bd_RRHH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bd_RRHH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bd_RRHH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bd_RRHH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bd_RRHH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bd_RRHH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bd_RRHH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bd_RRHH] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bd_RRHH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bd_RRHH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bd_RRHH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bd_RRHH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bd_RRHH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bd_RRHH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bd_RRHH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bd_RRHH] SET RECOVERY FULL 
GO
ALTER DATABASE [bd_RRHH] SET  MULTI_USER 
GO
ALTER DATABASE [bd_RRHH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bd_RRHH] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bd_RRHH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bd_RRHH] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [bd_RRHH] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bd_RRHH] SET QUERY_STORE = OFF
GO
USE [bd_RRHH]
GO
/****** Object:  Table [dbo].[tbl_accion_personal]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_accion_personal](
	[id_accion_personal] [int] IDENTITY(1,1) NOT NULL,
	[numero_accion] [varchar](25) NULL,
	[motivo] [varchar](45) NULL,
	[sustitucion] [varchar](45) NULL,
	[costo] [float] NULL,
	[codigo_plaza] [varchar](15) NULL,
	[puesto] [varchar](45) NULL,
	[rige_desde] [date] NULL,
	[rige_hasta] [date] NULL,
	[total_dias] [int] NULL,
	[fecha_ubicacion] [date] NULL,
	[fecha_vacaciones] [date] NULL,
	[fecha_pago] [date] NULL,
	[observaciones] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_accion_personal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_accion_personal_empleados]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_accion_personal_empleados](
	[id_accion_personal_empleado] [int] IDENTITY(1,1) NOT NULL,
	[fk_empleado] [int] NULL,
	[fk_accion_personal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_accion_personal_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_departamentos]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_departamentos](
	[id_departamento] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [int] NULL,
	[nombre] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_empleados]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_empleados](
	[id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [int] NULL,
	[nombre] [varchar](45) NULL,
	[apellido] [varchar](45) NULL,
	[fecha_nacimiento] [date] NULL,
	[tipo_nombramiento] [varchar](20) NULL,
	[codigo] [varchar](15) NULL,
	[fecha_escala] [date] NULL,
	[fecha_vacaciones] [date] NULL,
	[puesto] [varchar](40) NULL,
	[fk_departamento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_empleados_remuneraciones]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_empleados_remuneraciones](
	[id_empleado_remuneracion] [int] IDENTITY(1,1) NOT NULL,
	[fk_empleado] [int] NULL,
	[fk_remuneracion] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_extraordinario]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_extraordinario](
	[id_extraordinario] [int] IDENTITY(1,1) NOT NULL,
	[fecha_pago] [date] NULL,
	[codigo_plaza] [varchar](20) NULL,
	[cantidad_horas] [int] NULL,
	[monto] [float] NULL,
	[tipo_extraordinario] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_extraordinario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_extraordinario_empleados]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_extraordinario_empleados](
	[id_extraordinario_empleados] [int] IDENTITY(1,1) NOT NULL,
	[fk_extraordinario] [int] NULL,
	[fk_empleado] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_extras_medicas]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_extras_medicas](
	[id_extras] [int] IDENTITY(1,1) NOT NULL,
	[fecha_pago] [date] NULL,
	[codigo_plaza] [varchar](15) NULL,
	[cantidad_horas] [int] NULL,
	[monto_cancelar] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_extras] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_extras_medicas_empleados]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_extras_medicas_empleados](
	[id_extras_empleado] [int] IDENTITY(1,1) NOT NULL,
	[fk_empleado] [int] NULL,
	[fk_extras] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_presupuestos]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_presupuestos](
	[id_presupuesto] [int] IDENTITY(1,1) NOT NULL,
	[tipo_presupuesto] [varchar](50) NULL,
	[monto_presupuesto] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_presupuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_remuneraciones]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_remuneraciones](
	[id_remuneracion] [int] IDENTITY(1,1) NOT NULL,
	[numero_movimiento] [varchar](45) NULL,
	[tipo] [varchar](45) NULL,
	[fecha_pago] [date] NULL,
	[monto] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_remuneracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_usuarios]    Script Date: 27/06/2020 10:16:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](45) NOT NULL,
	[pass] [varchar](45) NULL,
	[cedula] [int] NULL,
	[nombre] [varchar](45) NULL,
	[apellido] [varchar](45) NULL,
	[tipo] [varchar](15) NULL,
	[foto] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_accion_personal_empleados]  WITH CHECK ADD FOREIGN KEY([fk_accion_personal])
REFERENCES [dbo].[tbl_accion_personal] ([id_accion_personal])
GO
ALTER TABLE [dbo].[tbl_accion_personal_empleados]  WITH CHECK ADD FOREIGN KEY([fk_empleado])
REFERENCES [dbo].[tbl_empleados] ([id_empleado])
GO
ALTER TABLE [dbo].[tbl_empleados]  WITH CHECK ADD FOREIGN KEY([fk_departamento])
REFERENCES [dbo].[tbl_departamentos] ([id_departamento])
GO
ALTER TABLE [dbo].[tbl_empleados_remuneraciones]  WITH CHECK ADD FOREIGN KEY([fk_empleado])
REFERENCES [dbo].[tbl_empleados] ([id_empleado])
GO
ALTER TABLE [dbo].[tbl_empleados_remuneraciones]  WITH CHECK ADD FOREIGN KEY([fk_remuneracion])
REFERENCES [dbo].[tbl_remuneraciones] ([id_remuneracion])
GO
ALTER TABLE [dbo].[tbl_extraordinario_empleados]  WITH CHECK ADD FOREIGN KEY([fk_empleado])
REFERENCES [dbo].[tbl_empleados] ([id_empleado])
GO
ALTER TABLE [dbo].[tbl_extraordinario_empleados]  WITH CHECK ADD FOREIGN KEY([fk_extraordinario])
REFERENCES [dbo].[tbl_extraordinario] ([id_extraordinario])
GO
ALTER TABLE [dbo].[tbl_extras_medicas_empleados]  WITH CHECK ADD FOREIGN KEY([fk_empleado])
REFERENCES [dbo].[tbl_empleados] ([id_empleado])
GO
ALTER TABLE [dbo].[tbl_extras_medicas_empleados]  WITH CHECK ADD FOREIGN KEY([fk_extras])
REFERENCES [dbo].[tbl_extras_medicas] ([id_extras])
GO
USE [master]
GO
ALTER DATABASE [bd_RRHH] SET  READ_WRITE 
GO
