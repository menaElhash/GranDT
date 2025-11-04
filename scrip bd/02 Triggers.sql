-- Limite de jugadores totales
delimiter //
CREATE TRIGGER trg_max_jugadores
BEFORE INSERT ON Jugador
FOR EACH ROW
BEGIN
    DECLARE total INT;
    SELECT COUNT(*) INTO total FROM Jugador;
    IF total >= 1500 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'No se pueden registrar más de 1500 jugadores.';
    END IF;
END;
//
delimiter ;
delimiter //
-- Limite de cotización
CREATE TRIGGER trg_valida_cotizacion
BEFORE INSERT ON Jugador
FOR EACH ROW
BEGIN
    IF NEW.cotizacion > 99999999.99 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La cotización no puede superar 99.999.999,99.';
    END IF;
END;
//
delimiter ;
delimiter //
-- Fecha de nacimiento valida
CREATE TRIGGER trg_fecha_jugador
BEFORE INSERT ON Jugador
FOR EACH ROW
BEGIN
    IF NEW.fecha_nacimiento > CURDATE() THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La fecha de nacimiento no puede ser futura.';
    END IF;
END;

//
delimiter ;
delimiter //

-- Máximo de jugadores en plantilla
CREATE TRIGGER trg_max_jugadores_plantilla
BEFORE INSERT ON PlantillaJugador
FOR EACH ROW
BEGIN
    DECLARE total INT;
    SELECT COUNT(*) INTO total 
    FROM PlantillaJugador 
    WHERE id_plantilla = NEW.id_plantilla;
    
    IF total >= 20 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'No se pueden agregar más de 20 jugadores a la plantilla.';
    END IF;
END;
//
delimiter ;
delimiter //
-- Nota valida
CREATE TRIGGER trg_valida_nota
BEFORE INSERT ON Puntuacion
FOR EACH ROW
BEGIN
    IF NEW.nota < 1 OR NEW.nota > 10 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La nota debe estar entre 1 y 10.';
    END IF;
END;
//
delimiter ;
delimiter //
-- Fecha valida
CREATE TRIGGER trg_valida_fecha_puntuacion
BEFORE INSERT ON Puntuacion
FOR EACH ROW
BEGIN
    IF NEW.fecha_numero > 49 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La fecha no puede ser mayor o igual a 50.';
    END IF;
END;
//
delimiter ;

