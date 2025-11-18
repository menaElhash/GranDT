DELIMITER //

-- ===================================
-- PROCEDIMIENTOS DE ALTA
-- ===================================

-- 1. ALTA TIPO JUGADOR
CREATE PROCEDURE altaTipo(
    IN UnDescripcion VARCHAR(45), 
    OUT AIidTipo INT
)
BEGIN
    INSERT INTO Gran_DT.TipoJugador (descripcion) 
    VALUES (UnDescripcion);
    SET AIidTipo = LAST_INSERT_ID();
END;
//

-- 2. ALTA EQUIPO
CREATE PROCEDURE altaEquipo(
    IN UnNombre VARCHAR(45), 
    OUT AIidEquipo INT
)
BEGIN
    INSERT INTO Gran_DT.Equipo (nombre) 
    VALUES (UnNombre);
    SET AIidEquipo = LAST_INSERT_ID();
END;
//

-- 3. ALTA ROL
CREATE PROCEDURE altaRol(
    IN UnDescripcion VARCHAR(45), 
    OUT AIidRol INT
)
BEGIN
    INSERT INTO Gran_DT.Rol (descrpcion) -- La columna es 'descrpcion' en el DDL
    VALUES (UnDescripcion);
    SET AIidRol = LAST_INSERT_ID();
END;
//

-- 4. ALTA JUGADOR (FUTBOLISTA)
CREATE PROCEDURE altaJugador(
    IN UnNombre VARCHAR(45), 
    IN UnApellido VARCHAR(45),
    IN UnApodo VARCHAR(45), 
    IN UnFechaNacimiento DATE,
    IN UnCotizacion DECIMAL(10,2),
    IN UnidTipo INT,
    IN UnidEquipo INT,
    OUT AIidJugador INT
)
BEGIN
    INSERT INTO Gran_DT.Jugador (nombre, apellido, apodo, fecha_nacimiento, cotizacion, id_tipo, id_equipo) 
    VALUES (UnNombre, UnApellido, UnApodo, UnFechaNacimiento, UnCotizacion, UnidTipo, UnidEquipo);
    SET AIidJugador = LAST_INSERT_ID();
END;
//

-- 5. ALTA USUARIO
CREATE PROCEDURE altaUsuario(
    IN UnNombre VARCHAR(45),
    IN UnApellido VARCHAR(45),
    IN UnEmail VARCHAR(100),
    IN UnFechaNacimiento DATE,
    IN UnContrasena CHAR(64),
    IN UnidRol INT,
    OUT AIidUsuario INT
)
BEGIN
    -- Se asume que el hash de la contraseña se genera ANTES de llamar al SP
    INSERT INTO Gran_DT.Usuario (nombre, apellido, email, fecha_nacimiento, password, id_rol) 
    VALUES (UnNombre, UnApellido, UnEmail, UnFechaNacimiento, UnContrasena, UnidRol);
    SET AIidUsuario = LAST_INSERT_ID();
END;
//

-- 6. ALTA PLANTILLA
CREATE PROCEDURE altaPlantilla(
    IN UnPresupuesto DECIMAL(10,2),
    IN UnidUsuario INT,
    IN UnidEquipo INT,
    IN UnFechaCreacion DATE,
    OUT AIidPlantilla INT
)
BEGIN
    INSERT INTO Gran_DT.Plantilla (presupuesto_max, id_usuario, id_equipo, fecha_creacion) 
    VALUES (UnPresupuesto, UnidUsuario, UnidEquipo, UnFechaCreacion);
    SET AIidPlantilla = LAST_INSERT_ID();
END;
//

-- 7. ALTA PLANTILLAJUGADOR
CREATE PROCEDURE altaPlantillaJugador(
    IN UnidJugador INT,
    IN UnidPlantilla INT,
    IN UnesTitular TINYINT
)
BEGIN
    INSERT INTO Gran_DT.PlantillaJugador (id_jugador, id_plantilla, es_titular) 
    VALUES (UnidJugador, UnidPlantilla, UnesTitular);
END;
//

-- 8. ALTA PUNTUACION
CREATE PROCEDURE altaPuntuacion(
    IN UnidJugador INT,
    IN UnNota DECIMAL(3,1),
    IN UnFechaNumero DATE,
    OUT AIidPuntuacion INT
)
BEGIN
    INSERT INTO Gran_DT.Puntuacion (id_jugador, nota, fecha_numero) 
    VALUES (UnidJugador, UnNota, UnFechaNumero);
    SET AIidPuntuacion = LAST_INSERT_ID();
END;
//


-- ===================================
-- PROCEDIMIENTOS DE CONSULTA Y LÓGICA (FALTANTES)
-- ===================================

-- 9. LOGIN USUARIO (Autenticación)
CREATE PROCEDURE loginUsuario(
    IN UnEmail VARCHAR(100),
    IN UnContrasena VARCHAR(64)
)
BEGIN
    -- Se asume que la aplicación envía el hash SHA256 (64 caracteres)
    SELECT 
        id_usuario, nombre, apellido, email, id_rol
    FROM Gran_DT.Usuario
    WHERE email = UnEmail
      AND password = UnContrasena;
END;
//

-- 10. TRAER EQUIPOS (Listado para combobox/select)
CREATE PROCEDURE traerEquipo() 
BEGIN
    SELECT  *
    FROM Gran_DT.Equipo
    ORDER BY nombre;
END;
//

-- 11. TRAER FUTBOLISTAS FILTRADOS (Búsqueda en el mercado de pases)
CREATE PROCEDURE traerJugadoresBasicoXTipoXEquipo(
    IN UnIdTipo INT,
    IN UnIdEquipo INT
)
BEGIN
    SELECT 
        id_jugador,
        nombre,
        apellido,
        apodo,
        fecha_nacimiento,
        cotizacion
    FROM Gran_DT.Jugador
    WHERE id_tipo = UnIdTipo
      AND id_equipo = UnIdEquipo
    ORDER BY apellido;
END;
//

-- 12. TRAER PLANTILLAS POR USUARIO
CREATE PROCEDURE PlantillasPorIdUsuario(
    IN UnidUsuario INT
)
BEGIN
    SELECT *
    FROM Gran_DT.Plantilla p
    WHERE id_usuario = UnidUsuario;
END;
//

-- 13. ACTUALIZAR PLANTILLA JUGADOR (Cambiar Titularidad)
CREATE PROCEDURE actualizarPlantillaJugador(
    IN UnidJugador INT,
    IN UnidPlantilla INT,
    IN UnesTitular TINYINT
)
BEGIN
    UPDATE Gran_DT.PlantillaJugador
    SET es_titular = UnesTitular
    WHERE id_jugador = UnidJugador AND id_plantilla = UnidPlantilla;
END;
//

DELIMITER ;