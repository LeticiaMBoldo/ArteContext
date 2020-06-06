-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 26-Maio-2020 às 23:05
-- Versão do servidor: 10.1.39-MariaDB
-- versão do PHP: 7.3.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `artes`
--
CREATE DATABASE IF NOT EXISTS `artes` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `artes`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `artista`
--

CREATE TABLE `artista` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
  `Endereco` varchar(60) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Bairro` varchar(50) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Fone` varchar(20) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Rg` varchar(20) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Email` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
  `CidadeId` int(11) NOT NULL,
  `Foto` varchar(500) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `cidade`
--

CREATE TABLE `cidade` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `Estado` varchar(2) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `cidade`
--

INSERT INTO `cidade` (`Id`, `Nome`, `Estado`) VALUES
(1, 'Barra Bonita', 'SP'),
(2, 'Igaraçu do Tietê', 'SP'),
(3, 'Bauru', 'SP'),
(4, 'Macatuba', 'SP'),
(5, 'Pederneiras', 'SP'),
(6, 'Lençois Paulista', 'SP');

-- --------------------------------------------------------

--
-- Estrutura da tabela `obra`
--

CREATE TABLE `obra` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(1000) CHARACTER SET utf8mb4 NOT NULL,
  `TipoObraId` int(11) NOT NULL,
  `ArtistaId` int(11) NOT NULL,
  `InspiradaEm` varchar(2000) CHARACTER SET utf8mb4 NOT NULL,
  `Representa` varchar(2000) CHARACTER SET utf8mb4 NOT NULL,
  `FotoArte` varchar(500) CHARACTER SET utf8mb4 NOT NULL,
  `DataInscricao` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipoobra`
--

CREATE TABLE `tipoobra` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(50) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tipoobra`
--

INSERT INTO `tipoobra` (`Id`, `Nome`) VALUES
(1, 'Fotografia'),
(2, 'Artes Plásticas'),
(3, 'Escultura'),
(4, 'Pintura'),
(5, 'Modelagem 3D');

-- --------------------------------------------------------

--
-- Estrutura da tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200526210433_criacao-banco', '3.1.2');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `artista`
--
ALTER TABLE `artista`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Artista_CidadeId` (`CidadeId`);

--
-- Indexes for table `cidade`
--
ALTER TABLE `cidade`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `obra`
--
ALTER TABLE `obra`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Obra_ArtistaId` (`ArtistaId`),
  ADD KEY `IX_Obra_TipoObraId` (`TipoObraId`);

--
-- Indexes for table `tipoobra`
--
ALTER TABLE `tipoobra`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `artista`
--
ALTER TABLE `artista`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cidade`
--
ALTER TABLE `cidade`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `obra`
--
ALTER TABLE `obra`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tipoobra`
--
ALTER TABLE `tipoobra`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `artista`
--
ALTER TABLE `artista`
  ADD CONSTRAINT `FK_Artista_Cidade_CidadeId` FOREIGN KEY (`CidadeId`) REFERENCES `cidade` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `obra`
--
ALTER TABLE `obra`
  ADD CONSTRAINT `FK_Obra_Artista_ArtistaId` FOREIGN KEY (`ArtistaId`) REFERENCES `artista` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Obra_TipoObra_TipoObraId` FOREIGN KEY (`TipoObraId`) REFERENCES `tipoobra` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
