-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Ápr 11. 13:41
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 8.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `kuldes`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `csapatok`
--

CREATE TABLE `csapatok` (
  `idCsapat` int(11) NOT NULL,
  `csapatNev` varchar(45) NOT NULL,
  `elerhetosegKod` int(11) NOT NULL,
  `csapatVezeto` varchar(45) NOT NULL,
  `idOsztaly` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `csapatok`
--

INSERT INTO `csapatok` (`idCsapat`, `csapatNev`, `elerhetosegKod`, `csapatVezeto`, `idOsztaly`) VALUES
(1, 'Kispest', 60, 'Nap Pali', 11),
(2, 'Heves', 1, 'Hevesi József', 11),
(3, 'Gyöngyös', 3, 'Nagy Gábor', 11),
(5, 'Kömlő', 2, 'Suha József', 13),
(6, 'Érd', 11, 'Érdi Pál', 34),
(7, 'Kukutyin', 52, 'Gál Éva', 14),
(8, 'Bélapátfalva', 6, 'Bal Kéz', 34),
(9, 'Kápolna', 7, 'Füle Müle', 13),
(10, 'Hatvan', 6, 'Józan Ész', 1),
(11, 'Parád', 33, 'Parádi János', 14),
(12, 'Eger', 10, 'Bal Láb', 1),
(13, 'Mucsaröcsöge', 43, 'Makk Marci', 1),
(14, 'Gyöngyöspata', 44, 'Gyöngy Vér', 3),
(23, 'Honvéd', 13, 'Kis Piroska', 1),
(25, 'Eger U19', 10, 'Pápai Zoltán', 32),
(31, 'Egerszalók', 10, 'sahdgsfd', 2),
(35, 'Füzesabony', 12, 'Szabó András', 11),
(42, 'Besenyőtelek', 10, 'Nagy Endre', 11),
(44, 'Kispest U19', 31, 'Nagy Éva', 32),
(55, 'Kál', 23, '', 14);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `elerhetoseg`
--

CREATE TABLE `elerhetoseg` (
  `elerhetosegKod` int(11) NOT NULL,
  `email` varchar(45) NOT NULL,
  `telefon` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `elerhetoseg`
--

INSERT INTO `elerhetoseg` (`elerhetosegKod`, `email`, `telefon`) VALUES
(1, 'cszs@gmail.com', 601234567),
(2, 'ezfdshgfsd@shfffghjja.hu', 1545154),
(3, 'ydgfhbgdfb@email', 3412143),
(6, 'sssss@bnh.hu', 1234567),
(10, 'dfzerth@jfkfl.nb', 1255146),
(11, 'cszs@gmail.coms', 2147483647),
(12, 'asdfg@shddjja.com', 515155),
(13, 'asdreew@bbb.hu', 670111111),
(16, 'sths@aergaerg.hz', 4014034),
(23, 'ezsd@shghjja.hu', 1243523),
(31, 'dfgh@bgt.nb', 20140141),
(33, 'aaaa@bbbb.cc', 2147483647),
(34, 'tgfegr@rrgf.nj', 1323543),
(43, 'etgfrwefg@gghz.ji', 1401401),
(44, 'gipsz@gipsz.com', 301233210),
(45, 'peter@gmail.com', 31564543),
(46, 'asdf@kkkk.lll', 524543),
(52, 'aaaa@aaa.aa', 111112222),
(54, 'bbbbb@bbb.bb', 234234),
(55, 'gyongyos@gy.hu', 12312356),
(56, 'dfwq@fdgardeg.hg', 5125),
(57, 'asfdasfd', 234),
(58, 'AAAAA@AAA.HU', 1),
(59, 'abcd@efg,h', 11111111),
(60, 'qwqw@vv.h', 88888),
(61, 'lllllll@ll.lu', 444444),
(62, 'szalok@szalok.hu', 1231230);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalo`
--

CREATE TABLE `felhasznalo` (
  `felhKod` int(10) NOT NULL,
  `felhNev` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `jelszo` varchar(255) NOT NULL,
  `admin` tinyint(1) DEFAULT NULL,
  `aszf` tinyint(1) DEFAULT NULL,
  `torolt` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `felhasznalo`
--

INSERT INTO `felhasznalo` (`felhKod`, `felhNev`, `email`, `jelszo`, `admin`, `aszf`, `torolt`) VALUES
(1, 'admin', 'admin@admin.hu', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 1, 1, 0),
(2, 'csatesz', 'csatho.zsolt@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0, 1, 0),
(4, 'Csatesz', 'csatesz@gmail.com', 'd17f25ecfbcc7857f7bebea469308be0b2580943e96d13a3ad98a13675c4bfc2', 0, 1, 0),
(5, 'Baba', 'bbbbbb@reg.hu', '2558a34d4d20964ca1d272ab26ccce9511d880579593cd4c9e01ab91ed00f325', 0, 1, 0),
(6, 'karak', 'fgaa@gfsadg,gr', '0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c', 0, 1, 0),
(7, 'blabla', 'blalbla@aergrea.de', 'b6197fe0d62a4e463edd2925382d4d268c4fce0859378682608efa4fda326f26', 0, 1, 0),
(8, 'lalalala', 'lalala@lalala.com', '91b4d142823f7d20c5f08df69122de43f35f057a988d9619f6d3138485c9a203', 0, 1, 0),
(9, 'valakik', 'xy@dft.hu', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 0, 1, 1),
(10, 'arhgaestg', 'xgfsjdgf@gsd.h', 'd17f25ecfbcc7857f7bebea469308be0b2580943e96d13a3ad98a13675c4bfc2', 0, 1, NULL),
(11, 'ajnika', 'asdfs@gfd.hz', 'd17f25ecfbcc7857f7bebea469308be0b2580943e96d13a3ad98a13675c4bfc2', 0, 0, 1),
(12, 'krumpli', 'krumpli@gh.hu', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 0, 1, NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `jatekvezetok`
--

CREATE TABLE `jatekvezetok` (
  `jvKod` int(10) NOT NULL,
  `nev` varchar(45) NOT NULL,
  `elerhetosegKod` int(11) NOT NULL,
  `idTelepules` int(11) NOT NULL,
  `minosites` varchar(10) DEFAULT NULL,
  `keret` varchar(30) NOT NULL,
  `feladatkor` varchar(15) NOT NULL DEFAULT 'asszisztens',
  `torolt` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `jatekvezetok`
--

INSERT INTO `jatekvezetok` (`jvKod`, `nev`, `elerhetosegKod`, `idTelepules`, `minosites`, `keret`, `feladatkor`, `torolt`) VALUES
(212, 'Remek Elek', 61, 41, 'A', 'megye 1', 'játékvezető', 0),
(222, 'Nap Óra', 52, 10, 'A', 'megye 3', 'játékvezető', 0),
(235, 'Kakuk Óra', 59, 2, 'B', 'NB 2', 'asszisztens', 0),
(333, 'Farkas Bertalan', 13, 23, 'A', 'NB 2', 'játékvezető', 0),
(343, 'Nagy Egon', 62, 2, 'A', 'megye 1', 'játékvezető', 0),
(444, 'Kovács József', 3, 10, 'B', 'megye 1', 'játékvezető', 0),
(555, 'Bak Endre', 34, 34, 'C', 'megye 1', 'asszisztens', 0),
(666, 'Szabó Pál', 16, 32, 'A', 'megye 1', 'játékvezető', 0),
(777, 'Fodor Pál', 6, 22, 'A', 'megye 1', 'asszisztens', 0),
(888, 'Pozsik Péter', 45, 40, 'A', 'megye 1', 'játékvezető', 0),
(999, 'Sós Tamás', 54, 23, 'B', 'megye 1', 'játékvezető', 0),
(1031, 'Csathó Zsolt', 1, 10, 'B', 'megye 1', 'asszisztens', 0),
(1212, 'Comp Uter', 10, 21, 'A', 'megye 3', 'asszisztens', 0),
(2134, 'Kis Pál', 33, 10, 'B', 'NB 3', 'játékvezető', 0),
(4324, 'Nagy Éva', 13, 21, 'A', 'megye 2', 'asszisztens', 0),
(6623, 'Holló Lajos', 2, 10, 'A', 'megye 3', 'asszisztens', 0),
(12345, 'Nagy Péter', 45, 10, 'C', 'megye 3', 'asszisztens', 0),
(123013, 'Kis Péter', 12, 32, 'A', 'NB 3', 'játékvezető', 0),
(123456, 'Trinity', 52, 10, 'A', 'NB 1', 'játékvezető', 0),
(266263, 'Gipsz Jakab', 44, 25, 'C', 'megye 3', 'asszisztens', 0),
(402341, 'Buga Jakab', 23, 32, 'A', 'megye 3', 'játékvezető', 0),
(453512, 'Kovács Péter', 11, 10, 'A', 'megye 3', 'asszisztens', 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kuldes`
--

CREATE TABLE `kuldes` (
  `kuldKod` int(20) NOT NULL,
  `merkozesKod` int(11) NOT NULL,
  `jvKod` int(11) NOT NULL,
  `assz1Kod` int(11) DEFAULT NULL,
  `assz2Kod` int(11) DEFAULT NULL,
  `assz3Kod` int(11) DEFAULT NULL,
  `assz4Kod` int(11) DEFAULT NULL,
  `torolt` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `kuldes`
--

INSERT INTO `kuldes` (`kuldKod`, `merkozesKod`, `jvKod`, `assz1Kod`, `assz2Kod`, `assz3Kod`, `assz4Kod`, `torolt`) VALUES
(1, 13414, 123456, 266263, 1212, NULL, NULL, 0),
(2, 123456, 212, 1031, 235, NULL, NULL, 0),
(3, 234125, 212, 0, 0, NULL, NULL, 0),
(4, 21545521, 212, 222, 0, NULL, NULL, 0),
(5, 215455, 343, 123013, 453512, NULL, NULL, 0),
(6, 3414, 402341, 453512, NULL, NULL, NULL, 0),
(7, 55, 2134, 1031, 0, NULL, NULL, 0),
(8, 123, 123013, 4324, 402341, NULL, NULL, 0),
(9, 1513, 123456, 6623, 266263, NULL, NULL, 0),
(10, 6235634, 402341, NULL, NULL, NULL, NULL, 0),
(11, 111, 212, 235, 12345, NULL, NULL, 0),
(12, 222, 123013, 6623, NULL, NULL, NULL, NULL),
(13, 333, 343, 4324, 6623, NULL, NULL, 0),
(14, 4021, 2134, 555, 235, NULL, NULL, 0),
(78, 444, 2134, 6623, 777, NULL, NULL, 0),
(79, 555, 123013, 402341, 1212, NULL, NULL, NULL),
(80, 666, 444, 4324, NULL, NULL, NULL, NULL),
(81, 777, 123456, 453512, 555, NULL, NULL, 0),
(82, 888, 666, 1031, 333, NULL, NULL, 0),
(83, 1, 123456, 6623, 1031, NULL, NULL, 0),
(84, 2, 123013, 12345, 12345, NULL, NULL, NULL),
(85, 3, 222, 235, NULL, NULL, NULL, NULL),
(86, 4, 222, NULL, NULL, NULL, NULL, NULL),
(87, 6251, 343, 1031, NULL, NULL, NULL, NULL),
(88, 12412, 999, 6623, 12345, NULL, NULL, 0),
(89, 451213, 444, 555, NULL, NULL, NULL, NULL),
(90, 452312, 402341, 453512, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `merkozes`
--

CREATE TABLE `merkozes` (
  `merkozesKod` int(11) NOT NULL,
  `HazaiCsapatId` int(11) NOT NULL,
  `vendegCsapatId` int(11) NOT NULL,
  `JvSzam` int(11) NOT NULL,
  `merkozesDatum` datetime NOT NULL,
  `idTelepules` int(11) NOT NULL,
  `idOsztaly` int(11) NOT NULL,
  `fordulo` int(11) NOT NULL,
  `torolt` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `merkozes`
--

INSERT INTO `merkozes` (`merkozesKod`, `HazaiCsapatId`, `vendegCsapatId`, `JvSzam`, `merkozesDatum`, `idTelepules`, `idOsztaly`, `fordulo`, `torolt`) VALUES
(1, 12, 23, 3, '2022-05-11 19:00:22', 10, 1, 11, 0),
(2, 23, 42, 3, '2022-05-04 17:00:32', 1, 100, 0, 0),
(3, 13, 12, 2, '2022-06-05 19:00:38', 25, 100, 0, 0),
(4, 12, 25, 1, '2022-04-28 15:30:00', 10, 100, 0, 0),
(55, 42, 12, 2, '2022-04-10 19:30:00', 1, 11, 4, NULL),
(111, 11, 8, 3, '2022-04-10 15:00:00', 10, 13, 6, 0),
(123, 12, 25, 3, '2022-04-30 16:00:00', 5, 100, 12, 0),
(222, 31, 8, 2, '2022-04-10 16:30:00', 33, 13, 6, 0),
(333, 3, 42, 3, '2022-04-10 16:00:00', 23, 11, 6, 0),
(444, 42, 35, 3, '2022-04-16 15:30:00', 10, 11, 10, 0),
(555, 2, 3, 3, '2022-04-16 15:00:00', 30, 11, 10, 0),
(666, 9, 5, 2, '2022-04-16 16:00:43', 22, 13, 10, 0),
(777, 12, 13, 3, '2022-04-16 18:00:54', 10, 1, 10, 0),
(888, 10, 23, 3, '2022-04-16 18:30:36', 1, 12, 10, 0),
(1513, 1, 2, 3, '2022-04-23 15:00:00', 5, 42, 6, NULL),
(3414, 55, 35, 2, '2022-04-10 11:00:00', 32, 13, 3, NULL),
(4021, 11, 9, 3, '2022-04-29 16:00:00', 10, 13, 4, 0),
(6251, 25, 44, 2, '2022-04-30 17:00:44', 10, 100, 0, 0),
(12412, 3, 1, 3, '2022-04-16 19:00:46', 23, 11, 10, 0),
(13414, 25, 44, 3, '2022-04-10 16:30:00', 1, 32, 1, NULL),
(123456, 42, 35, 3, '2022-03-31 10:00:00', 10, 11, 1, NULL),
(215455, 12, 44, 3, '2022-05-07 13:00:00', 10, 11, 3, NULL),
(234125, 23, 12, 1, '2022-04-28 14:00:00', 21, 1, 2, 0),
(451213, 9, 5, 2, '2022-04-10 16:30:00', 40, 13, 10, 0),
(452312, 7, 11, 2, '2022-04-10 18:00:00', 10, 14, 8, 0),
(6235634, 55, 7, 1, '2022-05-06 14:00:00', 22, 14, 5, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `osztaly`
--

CREATE TABLE `osztaly` (
  `idOsztaly` int(3) NOT NULL,
  `osztalyMegnevezes` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `osztaly`
--

INSERT INTO `osztaly` (`idOsztaly`, `osztalyMegnevezes`) VALUES
(1, 'NB 1'),
(2, 'NB 2'),
(3, 'NB 3'),
(11, 'megye 1'),
(12, 'megye 2'),
(13, 'megye 3'),
(14, 'megye 4'),
(21, 'megye 1 U17'),
(32, 'U 19'),
(34, 'U 17'),
(41, 'megye 1 U19'),
(42, 'megye 2 U19'),
(43, 'női'),
(44, 'NB 2 női'),
(50, 'öregfiúk'),
(77, 'női U 16'),
(100, 'barátságos');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `telepules`
--

CREATE TABLE `telepules` (
  `idTelepules` int(11) NOT NULL,
  `Telepules` varchar(45) NOT NULL,
  `iranyitoszam` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `telepules`
--

INSERT INTO `telepules` (`idTelepules`, `Telepules`, `iranyitoszam`) VALUES
(1, 'Budapest', 1112),
(2, 'Debrecen', 4000),
(3, 'Szolnok', 5000),
(5, 'Nyíregyháza', 4400),
(9, 'Hatvan', 3000),
(10, 'Eger', 3300),
(21, 'Füzesabony', 3390),
(22, 'Kál', 3343),
(23, 'Gyöngyös', 3200),
(25, 'Mucsaröcsöge', 2222),
(28, 'Bélapátfalva', 3345),
(30, 'Heves', 3000),
(32, 'Besenyőtelek', 3373),
(33, 'Tard', 1450),
(34, 'Dormánd', 3334),
(35, 'Detk', 2145),
(40, 'Kompolt', 3333),
(41, 'Alatka', 2432),
(44, 'Balaton', 3332),
(51, 'Szalók', 3344);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `csapatok`
--
ALTER TABLE `csapatok`
  ADD PRIMARY KEY (`idCsapat`);

--
-- A tábla indexei `elerhetoseg`
--
ALTER TABLE `elerhetoseg`
  ADD PRIMARY KEY (`elerhetosegKod`);

--
-- A tábla indexei `felhasznalo`
--
ALTER TABLE `felhasznalo`
  ADD PRIMARY KEY (`felhKod`);

--
-- A tábla indexei `jatekvezetok`
--
ALTER TABLE `jatekvezetok`
  ADD PRIMARY KEY (`jvKod`);

--
-- A tábla indexei `kuldes`
--
ALTER TABLE `kuldes`
  ADD PRIMARY KEY (`kuldKod`),
  ADD KEY `mrkozesKod` (`merkozesKod`);

--
-- A tábla indexei `merkozes`
--
ALTER TABLE `merkozes`
  ADD PRIMARY KEY (`merkozesKod`);

--
-- A tábla indexei `osztaly`
--
ALTER TABLE `osztaly`
  ADD PRIMARY KEY (`idOsztaly`);

--
-- A tábla indexei `telepules`
--
ALTER TABLE `telepules`
  ADD PRIMARY KEY (`idTelepules`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `elerhetoseg`
--
ALTER TABLE `elerhetoseg`
  MODIFY `elerhetosegKod` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;

--
-- AUTO_INCREMENT a táblához `felhasznalo`
--
ALTER TABLE `felhasznalo`
  MODIFY `felhKod` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=135;

--
-- AUTO_INCREMENT a táblához `kuldes`
--
ALTER TABLE `kuldes`
  MODIFY `kuldKod` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=91;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
