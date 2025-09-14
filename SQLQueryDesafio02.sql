-- Crear la base de datos
CREATE DATABASE CursosOnline;

USE CursosOnline;

-- =========================
-- TABLA: Instructor
-- =========================
CREATE TABLE Instructor (
    IdInstructor INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Especialidad VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE
);

-- =========================
-- TABLA: Curso
-- =========================
CREATE TABLE Curso (
    IdCurso INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(150) NOT NULL,
    Descripcion VARCHAR(300),
    Nivel VARCHAR(50) NOT NULL CHECK (Nivel IN ('Basico','Intermedio','Avanzado')),
    IdInstructor INT NOT NULL,
    CONSTRAINT FK_Curso_Instructor FOREIGN KEY (IdInstructor) REFERENCES Instructor(IdInstructor)
);


-- =========================
-- TABLA: Estudiante
-- =========================
CREATE TABLE Estudiante (
    IdEstudiante INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    FechaNacimiento DATE NOT NULL CHECK (FechaNacimiento <= GETDATE()) -- No se permite fecha futura
);

-- =========================
-- TABLA: Inscripción
-- =========================
CREATE TABLE Inscripcion (
    IdInscripcion INT IDENTITY(1,1) PRIMARY KEY,
    FechaInscripcion DATE NOT NULL DEFAULT GETDATE(),
    IdEstudiante INT NOT NULL,
    IdCurso INT NOT NULL,
    CONSTRAINT FK_Inscripcion_Estudiante FOREIGN KEY (IdEstudiante) REFERENCES Estudiante(IdEstudiante),
    CONSTRAINT FK_Inscripcion_Curso FOREIGN KEY (IdCurso) REFERENCES Curso(IdCurso),
    CONSTRAINT UQ_Inscripcion UNIQUE (IdEstudiante, IdCurso) -- Evita que un estudiante se inscriba 2 veces al mismo curso
);

-- =========================
-- EJEMPLOS DE INSERCIÓN
-- =========================
select * from Estudiante
-- Insertar instructores
INSERT INTO Instructor (Nombre, Especialidad, Email)
VALUES 
('Ana López', 'Matemáticas', 'ana.lopez@academia.com'),
('Carlos Pérez', 'Programación', 'carlos.perez@academia.com');

-- Insertar cursos
INSERT INTO Curso (Titulo, Descripcion, Nivel, IdInstructor)
VALUES
('Álgebra Básica', 'Curso introductorio de álgebra', 'Básico', 1),
('Programación en C#', 'Curso intermedio de C# con proyectos prácticos', 'Intermedio', 2);

-- Insertar estudiantes
INSERT INTO Estudiante (Nombre, Email, FechaNacimiento)
VALUES
('María González', 'maria.gonzalez@correo.com', '2000-05-10'),
('Juan Torres', 'juan.torres@correo.com', '1998-09-23');

-- Insertar inscripciones
INSERT INTO Inscripcion (FechaInscripcion, IdEstudiante, IdCurso)
VALUES
(GETDATE(), 1, 1),
(GETDATE(), 2, 2);

-- =========================
-- VALIDACIONES A PROBAR
-- =========================

-- ❌ Error: Email duplicado en Instructor
-- INSERT INTO Instructor (Nombre, Especialidad, Email) VALUES ('Pedro Ruiz', 'Historia', 'ana.lopez@academia.com');

-- ❌ Error: Nivel incorrecto en Curso
-- INSERT INTO Curso (Titulo, Descripcion, Nivel, IdInstructor) VALUES ('Curso Avanzado X', 'Contenido avanzado', 'Experto', 1);

-- ❌ Error: Fecha de nacimiento en el futuro
-- INSERT INTO Estudiante (Nombre, Email, FechaNacimiento) VALUES ('Luis Mejía', 'luis.mejia@correo.com', '2030-01-01');

-- ❌ Error: Estudiante ya inscrito en el mismo curso
-- INSERT INTO Inscripcion (FechaInscripcion, IdEstudiante, IdCurso) VALUES (GETDATE(), 1, 1);

SELECT * FROM Estudiante