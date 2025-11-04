DELIMITER //

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

DELIMITER ;
DELIMITER //

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

DELIMITER ;
DELIMITER //

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

DELIMITER ;
DELIMITER //

CREATE PROCEDURE altaRol(
    IN UnDescripcion VARCHAR(45), 
    OUT AIidRol INT
)
BEGIN
    INSERT INTO Gran_DT.Rol (descrpcion) 
    VALUES (UnDescripcion);
    SET AIidRol = LAST_INSERT_ID();
END;
//

DELIMITER ;
DELIMITER //

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
    INSERT INTO Gran_DT.Usuario (nombre, apellido, email, fecha_nacimiento, password, id_rol) 
    VALUES (UnNombre, UnApellido, UnEmail, UnFechaNacimiento, UnContrasena, UnidRol);
    SET AIidUsuario = LAST_INSERT_ID();
END;
//

DELIMITER ;
DELIMITER //

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

DELIMITER ;
DELIMITER //

CREATE PROCEDURE altaPlantilla(
    IN UnPresupuesto DECIMAL(10,2),
    IN UnidUsuario INT,
    IN UnFechaCreacion DATE,
    OUT AIidPlantilla INT
)
BEGIN
    INSERT INTO Gran_DT.Plantilla (presupuesto_max, id_usuario, fecha_creacion) 
    VALUES (UnPresupuesto, UnidUsuario, UnFechaCreacion);
    SET AIidPlantilla = LAST_INSERT_ID();
END;
//

DELIMITER ;
DELIMITER //

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

DELIMITER ;
