-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Jan 24. 08:05
-- Kiszolgáló verziója: 10.4.17-MariaDB
-- PHP verzió: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `backend`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `auto`
--

CREATE TABLE `auto` (
  `id` int(11) NOT NULL,
  `szoveg` varchar(255) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `linkkep` varchar(255) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `ar` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `auto`
--

INSERT INTO `auto` (`id`, `szoveg`, `linkkep`, `ar`) VALUES
(1, 'Fiat Punto', '/img/punto.jpg', 300000),
(2, 'Skoda 105S', '/img/skoda105S.jpg', 250000),
(3, 'Shelby Cobra', '/img/ford-shelby.jpg', 5600000),
(4, 'Ford Mustang', '/img/ford-mustang.jpg', 8700000),
(5, 'Trabant', '/img/trabant.jpg', 120000),
(6, 'Ferrari', '/img/ferrari.jpg', 4500000),
(7, 'Opel', '/img/opel.jpg', 123456),
(8, 'string', 'string', 0),
(9, 'lada', 'img/lada.jpg', 350000),
(10, 'renault', 'img/clio.jpg', 100);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `auto`
--
ALTER TABLE `auto`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `auto`
--
ALTER TABLE `auto`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
