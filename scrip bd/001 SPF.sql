-- AGREGAR USUARIO
DELIMITER //
CREATE PROCEDURE sp_AgregarUsuario(
    IN p_nombre VARCHAR(45),
    IN p_apellido VARCHAR(45),
    IN p_email VARCHAR(100),
    IN p_password CHAR(64),
    IN p_fecha DATE,
    IN p_idRol INT
)
BEGIN
    INSERT INTO Usuario(nombre, apellido, email, password, fecha_nacimiento, id_rol)
    VALUES (p_nombre, p_apellido, p_email, p_password, p_fecha, p_idRol);
END //
DELIMITER ;

-- ELIMINAR USUARIO
DELIMITER //
CREATE PROCEDURE sp_EliminarUsuario(
    IN p_idUsuario INT
)
BEGIN
    DELETE FROM Usuario WHERE id_usuario = p_idUsuario;
END //
DELIMITER ;

-- ACTUALIZAR USUARIO
DELIMITER //
CREATE PROCEDURE sp_ActualizarUsuario(
    IN p_idUsuario INT,
    IN p_nombre VARCHAR(45),
    IN p_apellido VARCHAR(45),
    IN p_email VARCHAR(100),
    IN p_password CHAR(64),
    IN p_fecha DATE,
    IN p_idRol INT
)
BEGIN
    UPDATE Usuario
    SET nombre = p_nombre,
        apellido = p_apellido,
        email = p_email,
        password = p_password,
        fecha_nacimiento = p_fecha,
        id_rol = p_idRol
    WHERE id_usuario = p_idUsuario;
END //
DELIMITER ;

-- AGREGAR JUGADOR
DELIMITER //
CREATE PROCEDURE sp_AgregarJugador(
    IN p_nombre VARCHAR(45),
    IN p_apellido VARCHAR(45),
    IN p_apodo VARCHAR(45),
    IN p_fechaNacimiento DATE,
    IN p_cotizacion DECIMAL(10,2),
    IN p_idTipo INT,
    IN p_idEquipo INT
)
BEGIN
    INSERT INTO Jugador(nombre, apellido, apodo, fecha_nacimiento, cotizacion, id_tipo, id_equipo)
    VALUES (p_nombre, p_apellido, p_apodo, p_fechaNacimiento, p_cotizacion, p_idTipo, p_idEquipo);
END //
DELIMITER ;

-- ELIMINAR JUGADOR
DELIMITER //
CREATE PROCEDURE sp_EliminarJugador(
    IN p_idJugador INT
)
BEGIN
    DELETE FROM Jugador WHERE id_jugador = p_idJugador;
END //
DELIMITER ;

-- ACTUALIZAR JUGADOR
DELIMITER //
CREATE PROCEDURE sp_ActualizarJugador(
    IN p_idJugador INT,
    IN p_nombre VARCHAR(45),
    IN p_apellido VARCHAR(45),
    IN p_apodo VARCHAR(45),
    IN p_fechaNacimiento DATE,
    IN p_cotizacion DECIMAL(10,2),
    IN p_idTipo INT,
    IN p_idEquipo INT
)
BEGIN
    UPDATE Jugador
    SET nombre = p_nombre,
        apellido = p_apellido,
        apodo = p_apodo,
        fecha_nacimiento = p_fechaNacimiento,
        cotizacion = p_cotizacion,
        id_tipo = p_idTipo,
        id_equipo = p_idEquipo
    WHERE id_jugador = p_idJugador;
END //
DELIMITER ;

-- AGREGAR PLANTILLA
DELIMITER //
CREATE PROCEDURE sp_AgregarPlantilla(
    IN p_idUsuario INT,
    IN p_presupuesto DECIMAL(10,2)
)
BEGIN
    INSERT INTO Plantilla(id_usuario, presupuesto_max, fecha_creacion)
    VALUES (p_idUsuario, p_presupuesto, CURDATE());
END //
DELIMITER ;

-- ELIMINAR PLANTILLA
DELIMITER //
CREATE PROCEDURE sp_EliminarPlantilla(
    IN p_idPlantilla INT
)
BEGIN
    DELETE FROM Plantilla WHERE id_plantilla = p_idPlantilla;
END //
DELIMITER ;

-- ACTUALIZAR PLANTILLA
DELIMITER //
CREATE PROCEDURE sp_ActualizarPlantilla(
    IN p_idPlantilla INT,
    IN p_presupuesto DECIMAL(10,2)
)
BEGIN
    UPDATE Plantilla
    SET presupuesto_max = p_presupuesto
    WHERE id_plantilla = p_idPlantilla;
END //
DELIMITER ;

-- =========================
-- EQUIPO
-- =========================
DELIMITER //
CREATE PROCEDURE sp_AgregarEquipo(IN p_nombre VARCHAR(45))
BEGIN
    IF EXISTS (SELECT 1 FROM Equipo WHERE nombre = p_nombre) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Nombre de equipo ya existe';
    END IF;
    INSERT INTO Equipo(nombre) VALUES (p_nombre);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_EliminarEquipo(IN p_idEquipo INT)
BEGIN
    DELETE FROM Equipo WHERE id_equipo = p_idEquipo;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_ActualizarEquipo(IN p_idEquipo INT, IN p_nombre VARCHAR(45))
BEGIN
    IF EXISTS (SELECT 1 FROM Equipo WHERE nombre = p_nombre AND id_equipo <> p_idEquipo) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Otro equipo ya tiene ese nombre';
    END IF;
    UPDATE Equipo
    SET nombre = p_nombre
    WHERE id_equipo = p_idEquipo;
END //
DELIMITER ;

-- =========================
-- TIPOJUGADOR
-- =========================
DELIMITER //
CREATE PROCEDURE sp_AgregarTipoJugador(IN p_descripcion VARCHAR(45))
BEGIN
    IF EXISTS (SELECT 1 FROM TipoJugador WHERE descripcion = p_descripcion) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Tipo de jugador ya existe';
    END IF;
    INSERT INTO TipoJugador(descripcion) VALUES (p_descripcion);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_EliminarTipoJugador(IN p_idTipo INT)
BEGIN
    IF EXISTS (SELECT 1 FROM Jugador WHERE id_tipo = p_idTipo) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se puede eliminar: hay jugadores con ese tipo';
    END IF;
    DELETE FROM TipoJugador WHERE id_tipo = p_idTipo;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_ActualizarTipoJugador(IN p_idTipo INT, IN p_descripcion VARCHAR(45))
BEGIN
    IF EXISTS (SELECT 1 FROM TipoJugador WHERE descripcion = p_descripcion AND id_tipo <> p_idTipo) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Otro tipo ya tiene esa descripción';
    END IF;
    UPDATE TipoJugador
    SET descripcion = p_descripcion
    WHERE id_tipo = p_idTipo;
END //
DELIMITER ;

-- =========================
-- ROL
-- =========================
DELIMITER //
CREATE PROCEDURE sp_AgregarRol(IN p_descripcion VARCHAR(45))
BEGIN
    IF EXISTS (SELECT 1 FROM Rol WHERE descripcion = p_descripcion) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Rol ya existe';
    END IF;
    INSERT INTO Rol(descripcion) VALUES (p_descripcion);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_EliminarRol(IN p_idRol INT)
BEGIN
    IF EXISTS (SELECT 1 FROM Usuario WHERE id_rol = p_idRol) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se puede eliminar: hay usuarios con ese rol';
    END IF;
    DELETE FROM Rol WHERE id_rol = p_idRol;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_ActualizarRol(IN p_idRol INT, IN p_descripcion VARCHAR(45))
BEGIN
    IF EXISTS (SELECT 1 FROM Rol WHERE descripcion = p_descripcion AND id_rol <> p_idRol) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Otra rol ya tiene esa descripción';
    END IF;
    UPDATE Rol
    SET descripcion = p_descripcion
    WHERE id_rol = p_idRol;
END //
DELIMITER ;

-- =========================
-- PUNTUACION
-- =========================
-- Supuesto esquema: Puntuacion(id_puntuacion AUTO_INCREMENT PK, id_jugador INT, nota DECIMAL(3,1), fecha_numero INT)
DELIMITER //
CREATE PROCEDURE sp_AgregarPuntuacion(
    IN p_idJugador INT,
    IN p_nota DECIMAL(3,1),
    IN p_fechaNumero INT
)
BEGIN
    -- Validaciones
    IF p_fechaNumero < 1 OR p_fechaNumero > 49 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'fecha_numero fuera de rango (1-49)';
    END IF;
    IF p_nota < 0 OR p_nota > 10 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'nota fuera de rango (0.0 - 10.0)';
    END IF;
    IF NOT EXISTS (SELECT 1 FROM Jugador WHERE id_jugador = p_idJugador) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El jugador no existe';
    END IF;
    -- Un jugador no puede tener 2 puntuaciones para la misma fecha
    IF EXISTS (SELECT 1 FROM Puntuacion WHERE id_jugador = p_idJugador AND fecha_numero = p_fechaNumero) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El jugador ya tiene puntuacion para esa fecha';
    END IF;

    INSERT INTO Puntuacion(id_jugador, nota, fecha_numero)
    VALUES (p_idJugador, p_nota, p_fechaNumero);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_EliminarPuntuacion(IN p_idPuntuacion INT)
BEGIN
    DELETE FROM Puntuacion WHERE id_puntuacion = p_idPuntuacion;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_ActualizarPuntuacion(
    IN p_idPuntuacion INT,
    IN p_nota DECIMAL(3,1)
)
BEGIN
    IF p_nota < 0 OR p_nota > 10 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'nota fuera de rango (0.0 - 10.0)';
    END IF;
    UPDATE Puntuacion
    SET nota = p_nota
    WHERE id_puntuacion = p_idPuntuacion;
END //
DELIMITER ;
