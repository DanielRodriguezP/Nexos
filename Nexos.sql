--Create Database Nexos
GO

-- Crear tablas ---------

CREATE TABLE CIUDAD(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Nombre VARCHAR(30) NOT NULL
)
GO


CREATE TABLE GENERO(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Nombre VARCHAR(60)
)
GO


CREATE TABLE AUTOR(
Id INT IDENTITY PRIMARY KEY NOT NULL,
NombreCompleto VARCHAR(100),
FechaNacimiento DATE NOT NULL,
CiudadId INT NOT NULL,
Correo VARCHAR(60) NOT NULL,
FOREIGN KEY (CiudadId) REFERENCES CIUDAD(Id)
)
GO

CREATE TABLE LIBRO(
Id INT IDENTITY PRIMARY KEY,
Titulo VARCHAR(60) NOT NULL,
Año INT NOT NULL,
GeneroId INT NOT NULL,
NumPag INT NOT NULL,
AutorId INT NOT NULL,
FOREIGN KEY (AutorId) REFERENCES AUTOR(Id),
FOREIGN KEY (GeneroId) REFERENCES GENERO(Id)
)
GO

-- Insertar tuplas ---------

INSERT INTO CIUDAD VALUES ('Medellin'), ('Cali'), ('Bogota')

INSERT INTO GENERO VALUES ('Novela'),('Literatura'),('Poesia')

INSERT INTO AUTOR VALUES ('Daniel Rodriguez', '07/08/1998', 1, 'daniel@gmail.com'), ('Juan Perez', '07/08/2000', 2, 'juan@gmail.com'),('Shirly Rodriguez', '07/08/2001', 3, 'shirly@gmail.com')

INSERT INTO LIBRO VALUES ('Harry Potter', 1998, 1, 4, 1),('Harry Potter', 1780, 2, 3, 2),('Padre Pio', 1976, 3, 4, 3)


-- Crear procedimientos almacenados -------

CREATE PROCEDURE SP_ListarGenero
AS
BEGIN
   SELECT g.Id, g.Nombre FROM GENERO g
END


CREATE PROCEDURE SP_InsertarAutor
@NombreCompleto varchar(100),
@FechaNacimiento Date,
@CiudadId int,
@Correo varchar(60)
AS
BEGIN

IF NOT EXISTS(select top 1 * from AUTOR WITH(NOLOCK) where NombreCompleto = @NombreCompleto and Correo = @Correo)
	BEGIN
	  INSERT INTO AUTOR VALUES (@NombreCompleto, @FechaNacimiento, @CiudadId, @Correo)
	END
END


CREATE PROCEDURE SP_ListarAutores
AS
BEGIN
  SELECT a.Id, a.NombreCompleto, a.Correo, a.FechaNacimiento, c.Nombre as 'Ciudad'
  FROM AUTOR a WITH(NOLOCK)
  INNER JOIN CIUDAD c WITH(NOLOCK) on a.CiudadId = c.Id
  GROUP BY  a.Id, a.NombreCompleto, a.Correo, a.FechaNacimiento, c.Nombre
END

CREATE PROCEDURE SP_ListarAutor
AS
BEGIN
  SELECT a.Id, a.NombreCompleto 
  FROM AUTOR a WITH(NOLOCK)
  INNER JOIN CIUDAD c WITH(NOLOCK) on a.CiudadId = c.Id
  GROUP BY a.Id, a.NombreCompleto
END


CREATE PROCEDURE SP_ListarCiudad
AS
BEGIN
  SELECT a.Id, a.Nombre
  FROM CIUDAD a WITH(NOLOCK)
  GROUP BY a.Id, a.Nombre
END


CREATE PROCEDURE SP_ListarLibros
AS
BEGIN
  SELECT  l.Id, l.Titulo, l.Año, l.NumPag, a.NombreCompleto, g.Nombre AS 'Genero'
  FROM LIBRO l WITH(NOLOCK)
  INNER JOIN AUTOR a WITH(NOLOCK) ON l.AutorId = a.Id 
  INNER JOIN GENERO g WITH(NOLOCK) on g.Id = l.GeneroId
  GROUP BY  l.Id, l.Titulo, l.Año, l.NumPag, a.NombreCompleto, g.Nombre 
END


CREATE PROCEDURE SP_InsertarLibro
@Titulo varchar(60),
@Año int,
@Genero int,
@NumPag int,
@AutorId int 
AS
BEGIN

DECLARE @CantidadLibros INT = 4

IF NOT EXISTS(select top 1 * from LIBRO l  WITH(NOLOCK) where l.Titulo = @Titulo and l.AutorId = @AutorId)
BEGIN
   IF (@CantidadLibros > (SELECT COUNT(L.Titulo) FROM LIBRO l WHERE AutorId = @AutorId))
   BEGIN
      INSERT INTO LIBRO VALUES (@Titulo, @Año, @Genero, @NumPag, @AutorId)
   END
   ELSE
	   BEGIN
		  SELECT -1 
	   END
END
  ELSE
  BEGIN
     SELECT -2 
  END
END
