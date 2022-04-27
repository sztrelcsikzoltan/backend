-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Ápr 27. 10:04
-- Kiszolgáló verziója: 10.4.22-MariaDB
-- PHP verzió: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `company`
--

CREATE database company
DEFAULT CHARACTER SET UTF8
COLLATE utf8_hungarian_ci;
USE company;
-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `coworker`
--

CREATE TABLE `coworker` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `email` varchar(100) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `coworker`
--

INSERT INTO `coworker` (`id`, `name`, `email`) VALUES
(1, 'Coworker 1', 'coworker1@company.com'),
(2, 'Coworker 2', 'coworker2@company.com'),
(3, 'Coworker 3', 'coworker3@company.com'),
(4, 'Coworker 4', 'coworker4@company.com'),
(5, 'Coworker 5', 'coworker5@company.com'),
(6, 'Coworker 6', 'coworker6@company.com');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `notebook`
--

CREATE TABLE `notebook` (
  `id` int(11) NOT NULL,
  `brand` varchar(150) COLLATE utf8_hungarian_ci NOT NULL,
  `type` varchar(150) COLLATE utf8_hungarian_ci NOT NULL,
  `coworkerId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `notebook`
--

INSERT INTO `notebook` (`id`, `brand`, `type`, `coworkerId`) VALUES
(3, 'Notebook1 brand1', 'type1', 1),
(4, 'Notebook2 brand2', 'type2', 1),
(5, 'Notebook3 brand3', 'type3', 1),
(6, 'Notebook4 brand4', 'type4', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `phone`
--

CREATE TABLE `phone` (
  `id` int(11) NOT NULL,
  `brand` varchar(150) COLLATE utf8_hungarian_ci NOT NULL,
  `type` varchar(150) COLLATE utf8_hungarian_ci NOT NULL,
  `coworkerId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `phone`
--

INSERT INTO `phone` (`id`, `brand`, `type`, `coworkerId`) VALUES
(3, 'Huwaei', 'type1', 1),
(4, 'Samsung', 'type2', 1),
(5, 'Nokia', 'type3', 1),
(6, 'Siemens', 'type4', 1),
(8, 'LG', 'type5', 1),
(35, 'Test1', 'test1', 1);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `coworker`
--
ALTER TABLE `coworker`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- A tábla indexei `notebook`
--
ALTER TABLE `notebook`
  ADD PRIMARY KEY (`id`),
  ADD KEY `notebook_coworkerId_fk` (`coworkerId`);

--
-- A tábla indexei `phone`
--
ALTER TABLE `phone`
  ADD PRIMARY KEY (`id`),
  ADD KEY `phone_coworkerId_fk` (`coworkerId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `coworker`
--
ALTER TABLE `coworker`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT a táblához `notebook`
--
ALTER TABLE `notebook`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT a táblához `phone`
--
ALTER TABLE `phone`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `notebook`
--
ALTER TABLE `notebook`
  ADD CONSTRAINT `notebook_coworkerId_fk` FOREIGN KEY (`coworkerId`) REFERENCES `coworker` (`id`);

--
-- Megkötések a táblához `phone`
--
ALTER TABLE `phone`
  ADD CONSTRAINT `phone_coworkerId_fk` FOREIGN KEY (`coworkerId`) REFERENCES `coworker` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
