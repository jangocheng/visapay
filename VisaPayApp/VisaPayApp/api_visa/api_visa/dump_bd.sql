CREATE DATABASE  IF NOT EXISTS `visa_teste` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `visa_teste`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: visa_teste
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.30-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cartao`
--

DROP TABLE IF EXISTS `cartao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cartao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Numero` varchar(16) CHARACTER SET ujis NOT NULL,
  `MesVencimanto` int(2) NOT NULL,
  `AnoVencimento` int(4) NOT NULL,
  `Nome` varchar(255) CHARACTER SET ujis NOT NULL,
  `Descricao` varchar(180) CHARACTER SET ujis NOT NULL,
  `CodigoSeguranca` int(3) NOT NULL,
  `PessoaId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `PessoaId_UNIQUE` (`PessoaId`,`Numero`),
  KEY `fk_cartao_pessoa_idx` (`PessoaId`),
  CONSTRAINT `fk_cartao_pessoa` FOREIGN KEY (`PessoaId`) REFERENCES `pessoa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `dispositivo`
--

DROP TABLE IF EXISTS `dispositivo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dispositivo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `RefId` varchar(45) NOT NULL,
  `Descricao` varchar(180) NOT NULL,
  `PessoaId` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `PessoaId_UNIQUE` (`PessoaId`,`RefId`),
  CONSTRAINT `fk_dispositivo_pessoa` FOREIGN KEY (`PessoaId`) REFERENCES `pessoa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pessoa` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(255) CHARACTER SET ujis NOT NULL,
  `Email` varchar(255) CHARACTER SET ujis NOT NULL,
  `Telefone` varchar(45) CHARACTER SET ujis NOT NULL,
  `Senha` varchar(255) CHARACTER SET ujis NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'visa_teste'
--

--
-- Dumping routines for database 'visa_teste'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-02-02 10:53:20
