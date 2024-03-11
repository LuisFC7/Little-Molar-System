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
  `id` smallint NOT NULL AUTO_INCREMENT,
  `patientId` smallint NOT NULL DEFAULT '0',
  `patientIllness` text NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK__patient` (`patientId`),
  CONSTRAINT `FK__patient` FOREIGN KEY (`patientId`) REFERENCES `patient` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla littlemolardb.clinicalhistory: ~0 rows (aproximadamente)
DELETE FROM `clinicalhistory`;

-- Volcando estructura para tabla littlemolardb.dentist
CREATE TABLE IF NOT EXISTS `dentist` (
  `id` tinyint NOT NULL DEFAULT '0',
  `dentistName` varchar(50) NOT NULL DEFAULT '0',
  `dentistLastName` varchar(50) NOT NULL DEFAULT '0',
  `dentistUser` varchar(50) NOT NULL DEFAULT '0',
  `dentistPassword` varchar(50) NOT NULL DEFAULT '0',
  `dentistEmail` varchar(50) NOT NULL DEFAULT '0',
  `dentistAge` tinyint NOT NULL DEFAULT '0',
  `dentistId` varchar(50) NOT NULL DEFAULT '0',
  `dentistPhone` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla littlemolardb.dentist: ~0 rows (aproximadamente)
DELETE FROM `dentist`;
INSERT INTO `dentist` (`id`, `dentistName`, `dentistLastName`, `dentistUser`, `dentistPassword`, `dentistEmail`, `dentistAge`, `dentistId`, `dentistPhone`) VALUES
	(0, 'User', 'LastName', 'userdentist', 'userdentist', 'user@user.com', 29, '929292921', '55-22-33-22');

-- Volcando estructura para tabla littlemolardb.patient
CREATE TABLE IF NOT EXISTS `patient` (
  `id` smallint NOT NULL AUTO_INCREMENT,
  `patientName` varchar(50) NOT NULL DEFAULT '0',
  `patientLastName` varchar(50) NOT NULL DEFAULT '0',
  `patientPhone` varchar(50) NOT NULL DEFAULT '0',
  `dentistId` tinyint NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK__dentist` (`dentistId`),
  CONSTRAINT `FK__dentist` FOREIGN KEY (`dentistId`) REFERENCES `dentist` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla littlemolardb.patient: ~0 rows (aproximadamente)
DELETE FROM `patient`;

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
DELETE FROM `receipt`;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
