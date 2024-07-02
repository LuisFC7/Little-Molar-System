-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.29 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.0.0.6468
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para littlemolardb
CREATE DATABASE IF NOT EXISTS `littlemolardb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `littlemolardb`;

-- Volcando estructura para tabla littlemolardb.clinicalhistory
CREATE TABLE IF NOT EXISTS `clinicalhistory` (
  `id` int NOT NULL DEFAULT '0',
  `patientId` smallint NOT NULL DEFAULT '0',
  `patientIllness` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK__patient` (`patientId`),
  CONSTRAINT `FK__patient` FOREIGN KEY (`patientId`) REFERENCES `patient` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla littlemolardb.clinicalhistory: ~0 rows (aproximadamente)

-- Volcando estructura para tabla littlemolardb.dentist
CREATE TABLE IF NOT EXISTS `dentist` (
  `id` tinyint NOT NULL AUTO_INCREMENT,
  `dentistName` varchar(50) NOT NULL DEFAULT '0',
  `dentistLastName` varchar(50) NOT NULL DEFAULT '0',
  `dentistUser` varchar(50) NOT NULL DEFAULT '0',
  `dentistPassword` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '0',
  `dentistEmail` varchar(50) NOT NULL DEFAULT '0',
  `dentistAge` tinyint NOT NULL DEFAULT '0',
  `dentistId` varchar(50) NOT NULL DEFAULT '0',
  `dentistPhone` varchar(50) NOT NULL DEFAULT '0',
  `dentistImage` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla littlemolardb.dentist: ~8 rows (aproximadamente)
INSERT IGNORE INTO `dentist` (`id`, `dentistName`, `dentistLastName`, `dentistUser`, `dentistPassword`, `dentistEmail`, `dentistAge`, `dentistId`, `dentistPhone`, `dentistImage`) VALUES
	(1, 'Pablo', 'Arquimedes', 'pabloarquimedes1', 'Pabloarquimedes1&', 'pabloarquimedes1@gmail.com', 45, '29567890', '3344556677', '0'),
	(2, 'Gonzalo', 'Martinez', 'gonzaMarti1', 'gonzaMarti1&', 'gonzamarti1@gmail.com', 29, '928746', '5590876342', '0'),
	(3, 'Luis', 'Castro', 'luiscastro1', 'Luiscastro1&', 'luiscastro1@gmail.com', 24, '345678', '1234567890', '0'),
	(4, 'Prueba', 'Hash', 'pruebahash1', 'dd4663abb263344bbf56008df660dffcc8772a6aba434a071c02b6d1809092ea', 'pruebahash1@gmail.com', 41, '12345678', '4400998877', '0'),
	(5, 'User', 'UserLast', 'Userlast1', 'UserLast1&', 'userlast1@gmail.com', 34, '123456', '12213123123123', '0'),
	(6, 'Dentista', 'Muelas', 'Dentista1', 'Upnh0Xt/g+S4fCA0uTiRf4Dys9B/2Cf+f03r+3AkBXOoEp49', 'dentista1@gmail.com', 24, '54321234', '9087654332', '0'),
	(7, 'Prueba', 'PruebaLastName', 'Prueba11', 'eOV1Cha/KB9klNz7ZGqjkdsQAT2Aqtt4sXqOHfZPXtpePIoL', 'prueba1@gmail.com', 45, '90876544', '5500998877', '0'),
	(8, 'PruebaD', 'LastNameD', 'PruebaDU', 'WllozzVwJ53RCez47LE8xCWHjl+1Pt/LnTcVmqNL+YDvmAwN', 'pruebad12@gmail.com', 25, '12345678', '5566778899', '0');

-- Volcando estructura para tabla littlemolardb.patient
CREATE TABLE IF NOT EXISTS `patient` (
  `id` smallint NOT NULL AUTO_INCREMENT,
  `patientName` varchar(50) NOT NULL DEFAULT '0',
  `patientLastName` varchar(50) NOT NULL DEFAULT '0',
  `patientAge` tinyint NOT NULL DEFAULT '0',
  `patientPhone` varchar(50) NOT NULL DEFAULT '0',
  `dentistId` tinyint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK__dentist` (`dentistId`),
  CONSTRAINT `FK__dentist` FOREIGN KEY (`dentistId`) REFERENCES `dentist` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla littlemolardb.patient: ~0 rows (aproximadamente)
INSERT IGNORE INTO `patient` (`id`, `patientName`, `patientLastName`, `patientAge`, `patientPhone`, `dentistId`) VALUES
	(1, 'Paciente', 'Prueba', 34, '5588990077', 1);

-- Volcando estructura para tabla littlemolardb.receipt
CREATE TABLE IF NOT EXISTS `receipt` (
  `id` int NOT NULL,
  `patientId` smallint DEFAULT NULL,
  `dentistId` tinyint DEFAULT NULL,
  `receiptTreatment` int DEFAULT NULL,
  `receiptDate` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_receipt_patient` (`patientId`),
  KEY `FK_receipt_dentist` (`dentistId`),
  CONSTRAINT `FK_receipt_dentist` FOREIGN KEY (`dentistId`) REFERENCES `dentist` (`id`),
  CONSTRAINT `FK_receipt_patient` FOREIGN KEY (`patientId`) REFERENCES `patient` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla littlemolardb.receipt: ~0 rows (aproximadamente)

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
