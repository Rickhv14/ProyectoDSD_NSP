USE [master]
GO
/****** Object:  Database [NSP]    Script Date: 7/07/2020 21:18:15 ******/
CREATE DATABASE [NSP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NSP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\NSP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NSP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\NSP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NSP] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NSP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NSP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NSP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NSP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NSP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NSP] SET ARITHABORT OFF 
GO
ALTER DATABASE [NSP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NSP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NSP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NSP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NSP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NSP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NSP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NSP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NSP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NSP] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NSP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NSP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NSP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NSP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NSP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NSP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NSP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NSP] SET RECOVERY FULL 
GO
ALTER DATABASE [NSP] SET  MULTI_USER 
GO
ALTER DATABASE [NSP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NSP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NSP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NSP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NSP] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NSP', N'ON'
GO
ALTER DATABASE [NSP] SET QUERY_STORE = OFF
GO
USE [NSP]
GO
/****** Object:  Table [dbo].[ALUMNO]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALUMNO](
	[CodigoAlumno] [varchar](50) NOT NULL,
	[DNIAlumno] [varchar](50) NOT NULL,
	[NombreAlumno] [varchar](50) NOT NULL,
	[ApellidoAlumno] [varchar](100) NOT NULL,
	[DireccionAlumno] [varchar](100) NOT NULL,
	[CorreoAlumno] [varchar](100) NOT NULL,
	[TelefonoAlumno] [varchar](20) NOT NULL,
	[EdadAlumno] [varchar](3) NOT NULL,
	[FechaNacimiento] [varchar](10) NOT NULL,
	[Usuario] [varchar](10) NULL,
 CONSTRAINT [PK__ALUMNO__E6BDA4287353DA36] PRIMARY KEY CLUSTERED 
(
	[CodigoAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[APODERADO]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[APODERADO](
	[DNIApoderado] [char](8) NOT NULL,
	[NombreApoderado] [varchar](50) NOT NULL,
	[ApellidoApoderado] [varchar](50) NOT NULL,
	[CorreoApoderado] [varchar](100) NOT NULL,
	[TelefonoApoderado] [varchar](10) NOT NULL,
	[TelefonoReferencia] [varchar](10) NOT NULL,
	[FechaNacimientoApoderado] [date] NOT NULL,
	[CodigoAlumno] [varchar](50) NULL,
 CONSTRAINT [PK__APODERAD__898961A2475DE6CD] PRIMARY KEY CLUSTERED 
(
	[DNIApoderado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CURSOS]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CURSOS](
	[IDCurso] [char](5) NOT NULL,
	[NOmbreCurso] [varchar](30) NOT NULL,
	[EstadoCurso] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLE_ALUMNO_NOTA_CURSO_GRADO]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_ALUMNO_NOTA_CURSO_GRADO](
	[IDDETALLE] [char](9) NOT NULL,
	[CodigoAlumno] [varchar](50) NULL,
	[IDCurso] [char](5) NULL,
 CONSTRAINT [PK__DETALLE___A1AC0F6467040EB9] PRIMARY KEY CLUSTERED 
(
	[IDDETALLE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLE_CURSO_DOCENTE_ALUMNO]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_CURSO_DOCENTE_ALUMNO](
	[CodigoAlumno] [varchar](50) NULL,
	[IDDOCENTE] [char](9) NULL,
	[IDCurso] [char](5) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOCENTE]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOCENTE](
	[IDDOCENTE] [char](9) NOT NULL,
	[DNIDocente] [char](8) NOT NULL,
	[NombreDocente] [varchar](50) NOT NULL,
	[ApellidoDocente] [varchar](50) NOT NULL,
	[TelefonoDocente] [varchar](10) NOT NULL,
	[CorreoDocente] [varchar](50) NOT NULL,
	[CursosACargo] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDDOCENTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FACTURA]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FACTURA](
	[Nro_Factura] [char](10) NOT NULL,
	[Total_Pagar] [int] NOT NULL,
	[FechaInicioFactruracion] [date] NULL,
	[FechaFinFacturacion] [date] NULL,
	[EstadoFacrtura] [varchar](20) NOT NULL,
	[CodigoAlumno] [varchar](50) NULL,
 CONSTRAINT [PK__FACTURA__64916D2BDB4C8E2E] PRIMARY KEY CLUSTERED 
(
	[Nro_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GRADO]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GRADO](
	[IDGrado] [char](9) NOT NULL,
	[NroGrado] [int] NOT NULL,
	[Turno] [varchar](20) NOT NULL,
	[CodigoAlumno] [varchar](50) NULL,
	[IDDOCENTE] [char](9) NULL,
	[IDCurso] [char](5) NULL,
	[IDLIBRO] [char](9) NULL,
 CONSTRAINT [PK__GRADO__CEDFC9F7BC36CEC1] PRIMARY KEY CLUSTERED 
(
	[IDGrado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[idMatricula] [int] IDENTITY(1,1) NOT NULL,
	[CodigoAlumno] [varchar](50) NULL,
	[Comentario] [varchar](500) NULL,
	[FechaRegistro] [datetime] NULL,
	[Turno] [varchar](20) NULL,
	[EstadoMatricula] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[idMatricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NOTA]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NOTA](
	[IDNotas] [char](9) NOT NULL,
	[Nota] [int] NOT NULL,
	[IDCurso] [char](5) NULL,
	[CodigoAlumno] [varchar](50) NULL,
 CONSTRAINT [PK__NOTA__63BF768A51CAD729] PRIMARY KEY CLUSTERED 
(
	[IDNotas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRESTAMO_LIBRO]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRESTAMO_LIBRO](
	[IDLIBRO] [char](9) NOT NULL,
	[NOMBRELIBRO] [varchar](50) NOT NULL,
	[FECHA_INICIO_PRESTAMO] [date] NOT NULL,
	[FECHA_FIN_PRESTAMO] [date] NOT NULL,
	[ESTADO_PRESTAMO] [varchar](30) NOT NULL,
	[CodigoAlumno] [varchar](50) NULL,
 CONSTRAINT [PK__PRESTAMO__CF77DC6D536F3A69] PRIMARY KEY CLUSTERED 
(
	[IDLIBRO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Usuario] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Estado] [char](1) NULL,
	[DNIApoderado] [varchar](10) NULL,
	[Nombre] [varchar](100) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[APODERADO]  WITH CHECK ADD  CONSTRAINT [FK__APODERADO__Codig__5629CD9C] FOREIGN KEY([CodigoAlumno])
REFERENCES [dbo].[ALUMNO] ([CodigoAlumno])
GO
ALTER TABLE [dbo].[APODERADO] CHECK CONSTRAINT [FK__APODERADO__Codig__5629CD9C]
GO
ALTER TABLE [dbo].[DETALLE_ALUMNO_NOTA_CURSO_GRADO]  WITH CHECK ADD  CONSTRAINT [FK__DETALLE_A__Codig__7C4F7684] FOREIGN KEY([CodigoAlumno])
REFERENCES [dbo].[ALUMNO] ([CodigoAlumno])
GO
ALTER TABLE [dbo].[DETALLE_ALUMNO_NOTA_CURSO_GRADO] CHECK CONSTRAINT [FK__DETALLE_A__Codig__7C4F7684]
GO
ALTER TABLE [dbo].[DETALLE_ALUMNO_NOTA_CURSO_GRADO]  WITH CHECK ADD  CONSTRAINT [FK__DETALLE_A__IDCur__7D439ABD] FOREIGN KEY([IDCurso])
REFERENCES [dbo].[CURSOS] ([IDCurso])
GO
ALTER TABLE [dbo].[DETALLE_ALUMNO_NOTA_CURSO_GRADO] CHECK CONSTRAINT [FK__DETALLE_A__IDCur__7D439ABD]
GO
ALTER TABLE [dbo].[DETALLE_CURSO_DOCENTE_ALUMNO]  WITH CHECK ADD  CONSTRAINT [FK__DETALLE_C__Codig__5EBF139D] FOREIGN KEY([CodigoAlumno])
REFERENCES [dbo].[ALUMNO] ([CodigoAlumno])
GO
ALTER TABLE [dbo].[DETALLE_CURSO_DOCENTE_ALUMNO] CHECK CONSTRAINT [FK__DETALLE_C__Codig__5EBF139D]
GO
ALTER TABLE [dbo].[DETALLE_CURSO_DOCENTE_ALUMNO]  WITH CHECK ADD  CONSTRAINT [FK__DETALLE_C__IDCur__60A75C0F] FOREIGN KEY([IDCurso])
REFERENCES [dbo].[CURSOS] ([IDCurso])
GO
ALTER TABLE [dbo].[DETALLE_CURSO_DOCENTE_ALUMNO] CHECK CONSTRAINT [FK__DETALLE_C__IDCur__60A75C0F]
GO
ALTER TABLE [dbo].[DETALLE_CURSO_DOCENTE_ALUMNO]  WITH CHECK ADD  CONSTRAINT [FK__DETALLE_C__IDDOC__5FB337D6] FOREIGN KEY([IDDOCENTE])
REFERENCES [dbo].[DOCENTE] ([IDDOCENTE])
GO
ALTER TABLE [dbo].[DETALLE_CURSO_DOCENTE_ALUMNO] CHECK CONSTRAINT [FK__DETALLE_C__IDDOC__5FB337D6]
GO
ALTER TABLE [dbo].[FACTURA]  WITH CHECK ADD  CONSTRAINT [FK__FACTURA__CodigoA__59063A47] FOREIGN KEY([CodigoAlumno])
REFERENCES [dbo].[ALUMNO] ([CodigoAlumno])
GO
ALTER TABLE [dbo].[FACTURA] CHECK CONSTRAINT [FK__FACTURA__CodigoA__59063A47]
GO
ALTER TABLE [dbo].[GRADO]  WITH CHECK ADD  CONSTRAINT [FK__GRADO__CodigoAlu__72C60C4A] FOREIGN KEY([CodigoAlumno])
REFERENCES [dbo].[ALUMNO] ([CodigoAlumno])
GO
ALTER TABLE [dbo].[GRADO] CHECK CONSTRAINT [FK__GRADO__CodigoAlu__72C60C4A]
GO
ALTER TABLE [dbo].[GRADO]  WITH CHECK ADD  CONSTRAINT [FK__GRADO__IDCurso__74AE54BC] FOREIGN KEY([IDCurso])
REFERENCES [dbo].[CURSOS] ([IDCurso])
GO
ALTER TABLE [dbo].[GRADO] CHECK CONSTRAINT [FK__GRADO__IDCurso__74AE54BC]
GO
ALTER TABLE [dbo].[GRADO]  WITH CHECK ADD  CONSTRAINT [FK__GRADO__IDDOCENTE__73BA3083] FOREIGN KEY([IDDOCENTE])
REFERENCES [dbo].[DOCENTE] ([IDDOCENTE])
GO
ALTER TABLE [dbo].[GRADO] CHECK CONSTRAINT [FK__GRADO__IDDOCENTE__73BA3083]
GO
ALTER TABLE [dbo].[GRADO]  WITH CHECK ADD  CONSTRAINT [FK__GRADO__IDLIBRO__75A278F5] FOREIGN KEY([IDLIBRO])
REFERENCES [dbo].[PRESTAMO_LIBRO] ([IDLIBRO])
GO
ALTER TABLE [dbo].[GRADO] CHECK CONSTRAINT [FK__GRADO__IDLIBRO__75A278F5]
GO
ALTER TABLE [dbo].[NOTA]  WITH CHECK ADD  CONSTRAINT [FK__NOTA__CodigoAlum__797309D9] FOREIGN KEY([CodigoAlumno])
REFERENCES [dbo].[ALUMNO] ([CodigoAlumno])
GO
ALTER TABLE [dbo].[NOTA] CHECK CONSTRAINT [FK__NOTA__CodigoAlum__797309D9]
GO
ALTER TABLE [dbo].[NOTA]  WITH CHECK ADD  CONSTRAINT [FK__NOTA__IDCurso__787EE5A0] FOREIGN KEY([IDCurso])
REFERENCES [dbo].[CURSOS] ([IDCurso])
GO
ALTER TABLE [dbo].[NOTA] CHECK CONSTRAINT [FK__NOTA__IDCurso__787EE5A0]
GO
ALTER TABLE [dbo].[PRESTAMO_LIBRO]  WITH CHECK ADD  CONSTRAINT [FK__PRESTAMO___Codig__6FE99F9F] FOREIGN KEY([CodigoAlumno])
REFERENCES [dbo].[ALUMNO] ([CodigoAlumno])
GO
ALTER TABLE [dbo].[PRESTAMO_LIBRO] CHECK CONSTRAINT [FK__PRESTAMO___Codig__6FE99F9F]
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Login]
@user varchar(100),
@password varchar(100)
as
select Nombre from Usuario where Usuario = @user and [Password] = @password
GO
/****** Object:  StoredProcedure [dbo].[uspAlumnoObtenerNombreCompleto]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[uspAlumnoObtenerNombreCompleto]
@Usuario varchar(10),
@DNI varchar(50)
as
select CodigoAlumno,NombreAlumno + ' ' + ApellidoAlumno,TelefonoAlumno from ALUMNO where DNIAlumno = @DNI and Usuario = @Usuario
GO
/****** Object:  StoredProcedure [dbo].[uspConsultarNotaAlumno]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[uspConsultarNotaAlumno]
  @DNIAlumno varchar(10),
  @CodigoAlumno varchar(20)
  as
  select A.CodigoAlumno as CodigoAlumno,DNIAlumno as DNIAlumno,NombreAlumno as NombreAlumno
  ,ApellidoAlumno as ApellidoAlumno,NombreCurso as NombreCurso,EstadoCurso as EstadoCurso,Nota as Nota 
  into #temp
  from NOTA N
  inner join Alumno A on (A.CodigoAlumno = N.CodigoAlumno)
  inner join Cursos C on(C.IDCurso = N.IDCurso)
  where (A.CodigoAlumno = @CodigoAlumno) --or (A.DNIAlumno = @DNIAlumno) -- and (@CodigoAlumno = '' or A.CodigoAlumno = @CodigoAlumno)
		 select * from #temp for json auto
GO
/****** Object:  StoredProcedure [dbo].[uspFacturaPendienteAlumno]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspFacturaPendienteAlumno]
@CodigoAlumno varchar(50)
as
select Nro_Factura from FACTURA where CodigoAlumno = @CodigoAlumno and EstadoFacrtura = 'Pendiente'
GO
/****** Object:  StoredProcedure [dbo].[uspMatriculaBuscar]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspMatriculaBuscar]
@Usuario varchar(10)
as
select idMatricula,A.CodigoAlumno,DNIAlumno,NombreAlumno + ' ' + ApellidoAlumno as Nombre
,EstadoMatricula,Comentario ,CONVERT(varchar(10),FechaRegistro,103) as FechaMatricula
from Matricula M inner join ALUMNO A on(M.CodigoAlumno = A.CodigoAlumno) where Usuario = @Usuario
GO
/****** Object:  StoredProcedure [dbo].[uspMatriculaInsert]    Script Date: 7/07/2020 21:18:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspMatriculaInsert]
@CodigoAlumno varchar(50),
@Comentario varchar(500),
@Turno varchar(20),
@EstadoMatricula varchar(20)
as
insert Matricula values(@CodigoAlumno,@Comentario,GETDATE(),@Turno,@EstadoMatricula)
GO
USE [master]
GO
ALTER DATABASE [NSP] SET  READ_WRITE 
GO
