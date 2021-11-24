-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 13. Aug 2021 um 14:23
-- Server-Version: 10.4.20-MariaDB
-- PHP-Version: 8.0.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `gangwar`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `accounts`
--

CREATE TABLE `accounts` (
  `id` int(11) NOT NULL,
  `username` varchar(128) NOT NULL,
  `socialClub` varchar(128) NOT NULL,
  `hwId` varchar(512) NOT NULL,
  `ban` tinyint(1) NOT NULL DEFAULT 0,
  `isTimeban` tinyint(1) NOT NULL DEFAULT 0,
  `timebanHours` int(11) NOT NULL,
  `banTimestamp` timestamp NOT NULL DEFAULT current_timestamp(),
  `warns` int(11) NOT NULL DEFAULT 0,
  `adminrank` int(11) NOT NULL DEFAULT 0,
  `level` int(11) NOT NULL DEFAULT 1,
  `exp` int(11) NOT NULL DEFAULT 0,
  `prestigeLevel` int(11) NOT NULL DEFAULT 0,
  `kills` int(11) NOT NULL DEFAULT 0,
  `deaths` int(11) NOT NULL DEFAULT 0,
  `faction` int(11) NOT NULL DEFAULT 0,
  `factionrank` int(11) NOT NULL DEFAULT 0,
  `lastGift` timestamp NOT NULL DEFAULT current_timestamp(),
  `lockState` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `accounts`
--

INSERT INTO `accounts` (`id`, `username`, `socialClub`, `hwId`, `ban`, `isTimeban`, `timebanHours`, `banTimestamp`, `warns`, `adminrank`, `level`, `exp`, `prestigeLevel`, `kills`, `deaths`, `faction`, `factionrank`, `lastGift`, `lockState`) VALUES
(1, 'Nicergrossa', 'Nicergrossa', 'D8903A045B3A2028C5002CA8EAC44910B9D0F884DB209BF03EF018C8DD220100855A009006AC2218D9BAB8E0E972D070EA7C08A056B6E9C8E0E2EF00F4AAC540', 0, 0, 0, '2021-08-10 14:21:13', 0, 10, 8, 20, 0, 15, 46, 0, 0, '2021-08-10 14:21:13', 0),
(2, 'Jeff', 'xJxnas', 'D8903A045B0046B06C5AE7D449842A10B9F4F85CF07825B0BBF018C8DD220040D6983BF4A3AE0270D9BA0EE08FA08C90727608A056B6E9003AFCC41C0116B980', 0, 0, 0, '2021-08-10 21:30:07', 0, 0, 1, 0, 0, 0, 0, 0, 0, '2021-08-10 21:30:07', 0),
(3, 'Purity', 'DXtery97', 'D8903A045BDCA510E53824ACA58C85C075E231209CF49B5070F018C8DD224660429A4430FDF686B80C12E36408E87270AEE008A056B6E9B01B744F503C6EAA40', 0, 0, 0, '2021-08-10 21:47:38', 0, 0, 2, 25, 0, 8, 9, 0, 0, '2021-08-10 21:47:38', 0),
(4, 'Pain', 'NEPTUNEGIANT', 'DAD015ACC3145EB013084AB8B7EC9870DBBE6AE86E12ACD06A6EFE60CB0AB9C0722C1150561C2510282639B416FCEA10F4DCCEDC22F08168AF6C86A80F34BDC0', 0, 0, 0, '2021-08-11 15:42:37', 0, 0, 1, 0, 0, 0, 0, 0, 0, '2021-08-11 15:42:37', 0),
(5, 'Moin', '--J_u_l_i_a_n--', 'D8903A045B8851F8A1700328D0EA1B10B90631E82F62E00870F018C8DD2294E0DFD288C466605548D9BA3964CA2A5D001BE008A056B6E9A06FC603A08586D500', 0, 0, 0, '2021-08-11 17:46:30', 0, 0, 1, 0, 0, 0, 0, 0, 0, '2021-08-11 17:46:30', 0),
(6, 'alan_', 'LilAlanPL', 'D8903A045BFAD2D8EA18EA046846FE10B9F499E4335A6D0857F018C8DD22E1C09B74D4B8F730C350D9BA0E04810229101BAE08A056B6E9C8AE5EFE9086668A40', 0, 0, 0, '2021-08-11 18:27:23', 0, 0, 1, 0, 0, 0, 0, 0, 0, '2021-08-11 18:27:23', 0),
(7, 'Moe_XyX', 'Bigfhr', 'D8903A045B887BD87DE82FF4ADF848001F4E3184C6B28438F3F018C8DD2294A05B4A2C54DBE67CC0B0B6E564E944E5407DE608A056B6E9A0C5DE177079EA4780', 1, 0, 0, '2021-08-11 21:33:53', 0, 0, 10, 130, 0, 161, 108, 0, 0, '2021-08-11 19:26:13', 0),
(8, 'Nico_XyX', 'KlatschAlleWeg', 'D8903A045B7CACC867882F30825E0C10B9D0E5E487B23F3825F018C8DD22568019BE5C54947CCF20D9BAB8B481BAE5B07D4A08A056B6E930546A153079189AC0', 0, 0, 0, '2021-08-11 19:27:30', 0, 0, 10, 25, 0, 140, 131, 0, 0, '2021-08-11 19:27:30', 0),
(9, 'Andreww', 'GrisiBierchen', 'D8903A045BDC2318AA20C18C41D2A5B0750644709C7028A80CF018C8DD2246A063F470EC85BE49B8E3123990BCE85880571808A056B6E9B01DAE3EC0175E7E80', 1, 0, 0, '2021-08-11 21:06:14', 0, 0, 5, 25, 0, 35, 34, 0, 0, '2021-08-11 19:50:43', 0),
(10, 'Norwin1234', 'YourGirlDateMeli', 'D8903A045BEE93806886EF1C7DAE67C0A83C7DACA008A740884C5B64A976D00007FA27E41516B4405EB6E5801C4EA8805EB26D645920988805324B7CC54C7A80', 0, 0, 0, '2021-08-11 19:53:16', 0, 0, 4, 40, 0, 26, 21, 0, 0, '2021-08-11 19:53:16', 0),
(11, 'Felix_Skyline', 'WarmishApollo28', 'D8903A045B06D6B8EEF2D784532E0EB075E2578405A425B0BBF018C8DD221F40F7BC4F34571AB7D0E312E3BCE9CEEA90727608A056B6E938AA368AAC91586B40', 0, 0, 0, '2021-08-11 19:53:28', 0, 0, 3, 30, 0, 15, 23, 0, 0, '2021-08-11 19:53:28', 0),
(12, 'Vorek', 'BorekChef', 'CD9431348824038871C2E410B13469909D34E104088453980192A4D00194D9206DD491D488E4A3A89162649051F449B03D7441A40844F3B821322450A154B940', 0, 0, 0, '2021-08-11 20:18:38', 0, 0, 1, 0, 0, 0, 0, 0, 0, '2021-08-11 20:18:38', 0),
(13, 'samm', 'sammy246963', '2F5C99D80920186068A4E4BCE10649F0A714B6ACC662DAF8B010A460C2287BA0C52E6DBC626C29302BDCE74008E858E06C3A5F8413EAD1B022A69AF4DECE0740', 0, 0, 0, '2021-08-11 20:36:26', 0, 0, 1, 0, 0, 0, 0, 0, 0, '2021-08-11 20:36:26', 0),
(14, 'aminagoyar', 'Olek1947', 'D8903A045BFA2320705CB938D5E4B3B075066A701A8E25E0BBF018C8DD22E1A084E0428C8296B288E31239E8BCFCBB90D47608A056B6E9C81DE850285F502CC0', 0, 0, 0, '2021-08-11 21:08:21', 0, 0, 2, 25, 0, 8, 7, 0, 0, '2021-08-11 21:08:21', 0),
(15, 'Steve', 'stephen659', 'D8903A045B4058B88BDCE7545B1C7710B9E273E409446DD857F018C8DD222000D74602F4030A4EE8D9BAE3AC81A6FA10B9AE08A056B6E900A8F60128015C82C0', 0, 0, 0, '2021-08-11 23:49:45', 0, 0, 1, 0, 0, 0, 0, 0, 0, '2021-08-11 23:49:45', 0),
(16, 'Tyron', 'Lehmannderkleine', 'D8903A045B2E12D8AEDEC1709C38B3C075D00B2072863FC00CF018C8DD22C3C03B3C09EC44C89C880C12B80C088C87B0881808A056B6E9586E9ECA34179CC940', 0, 0, 0, '2021-08-12 03:49:58', 0, 0, 1, 5, 0, 1, 3, 0, 0, '2021-08-12 03:49:58', 0),
(17, 'MisterX', 'Mister-X-51', 'D8903A045BE8F24882E8AB5834E085B075187D48C68611080CF018C8DD2284C029242CA4FA9870B8E3126414624487501B1808A056B6E9208E0AC6709DBC5FC0', 0, 0, 0, '2021-08-12 07:30:50', 0, 0, 4, 30, 0, 24, 17, 0, 0, '2021-08-12 07:30:50', 0),
(18, 'Jorden_Gambo', 'itzz_lara', 'D8903A045BDCEBB8432AD770BF2668C0752A44209C5A3F0825F018C8DD2246A0D7369334444233C00C128F9008E829B01B4A08A056B6E9B055F629FC91D2D5C0', 0, 0, 0, '2021-08-12 07:31:10', 0, 0, 3, 40, 0, 17, 19, 0, 0, '2021-08-12 07:31:10', 0),
(19, 'Drapzz', 'Pad_r08', 'EFFCC7200BCEDAB036C8E4D456CAC160635685C89BD44BC037D292E8AE5854E0EEC66D985FD2119047ACCF6063D64A2026E8C4EC86C219D05B4E9D58F3E2D1C0', 0, 0, 0, '2021-08-12 07:42:24', 0, 0, 2, 0, 0, 3, 8, 0, 0, '2021-08-12 07:42:24', 0),
(20, 'Gino', 'Hyp3r_Gxn0', 'D8903A045B7CA598AFC419C0C89EB310B9183134C6B23F383EF018C8DD22566073CE2E0C1070EF88D9BA64643544E5B07D7C08A056B6E9301B4EED98FF12E580', 0, 0, 0, '2021-08-12 16:16:05', 0, 0, 3, 40, 0, 17, 17, 0, 0, '2021-08-12 16:16:05', 0),
(21, 'Maison', 'YZBY_GTA', 'D8903A045B9A3860515AB3A08B549510B9D0AC20DB20F7683EF018C8DD22F1008C323B04D8AAEA38D9BAB8300872D030DF7C08A056B6E948C8B8131C553E1440', 0, 0, 0, '2021-08-12 16:16:57', 0, 0, 3, 30, 0, 15, 5, 0, 0, '2021-08-12 16:16:57', 0),
(22, 'Manu', 'CxllMeMxlone', 'BF6A1C58838EA580AE3A4BF4871C4A001F181EE8DB68BBD0A762FC682BC66D007E9263DCCF4C5A8087380E98430873A08F5ADC78D3FE35804EEA7BC41728E180', 0, 0, 0, '2021-08-12 16:30:58', 0, 0, 2, 5, 0, 4, 15, 0, 0, '2021-08-12 16:30:58', 0),
(23, 'KinderBueno', 'TITENGIRL', 'D8903A045B3AB3A0F70E42ECB2D686001F845784725A3F203EF018C8DD2201A094DEB1D8AD1C8B10B0B666BCE98C29B04C7C08A056B6E9C88D88C5546EDA1040', 0, 0, 0, '2021-08-12 16:45:48', 0, 0, 2, 25, 0, 8, 17, 0, 0, '2021-08-12 16:45:48', 0),
(24, 'Luca_Drake', 'Lucaderbot', 'D8903A045B06BDC8B8E8ED48C7D81B10B918D24872C8C938BBF018C8DD221F6039F02C7CDE32EC48D9BA6488628C14D07D7608A056B6E93803AA28700B568240', 0, 0, 0, '2021-08-12 16:46:24', 0, 0, 4, 10, 0, 20, 9, 0, 0, '2021-08-12 16:46:24', 0),
(25, 'Merlin', 'MerelinQWER', 'D8903A045B5E1550123C3708454C49C075E2310C870AB280A2F018C8DD22BB604A44D2B42EB666180C12E364DBBAA1A0104408A056B6E918AB447668316C8640', 0, 0, 0, '2021-08-12 21:37:00', 0, 0, 3, 5, 0, 10, 7, 0, 0, '2021-08-12 21:37:00', 0),
(26, 'Daniel_Travolta', 'GIn_MG13', 'D8903A045B6A357804CE580C5B2A2CB075F4440C1E18B5A825F018C8DD22F960CF485120250A7520E3120E90DBD49C90574A08A056B6E9888B268CD4E8F0C540', 0, 0, 0, '2021-08-12 21:41:47', 0, 0, 1, 5, 0, 1, 3, 0, 0, '2021-08-12 21:41:47', 0),
(27, 'Sekko_Diaz', 'Yassinausoff', 'D8903A045B12E06048243DC84EB2FD10B9F431AC2FA40E80A2F018C8DD225D00AC10FE3C3EE4B9F8D9BA0E64432AEA60104408A056B6E9A820F8D8D83B12DD80', 0, 0, 0, '2021-08-13 02:05:09', 0, 0, 2, 15, 0, 6, 3, 0, 0, '2021-08-13 02:05:09', 0),
(28, 'Ryan_Lansky', 'Alman_Toxic3224', 'D8903A045B64A508E91AF880BF623BB0752A1EE49C182820DAF018C8DD22DA6021E2DBA060421148E3128F3881E89C804CB408A056B6E9501B3ADB9C48B49200', 0, 0, 0, '2021-08-13 02:06:57', 0, 0, 2, 0, 0, 3, 6, 0, 0, '2021-08-13 02:06:57', 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `admin_logs`
--

CREATE TABLE `admin_logs` (
  `id` int(11) NOT NULL,
  `accountId` int(11) NOT NULL,
  `targetId` int(11) NOT NULL,
  `action` varchar(128) NOT NULL,
  `description` varchar(128) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `admin_logs`
--

INSERT INTO `admin_logs` (`id`, `accountId`, `targetId`, `action`, `description`, `timestamp`) VALUES
(1, 1, 7, 'ban', 'Nicergrossa hat Moe_XyX gebannt. Grund: hs kind', '2021-08-11 21:33:53');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `server_blips`
--

CREATE TABLE `server_blips` (
  `id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL,
  `sprite` int(11) NOT NULL,
  `color` int(11) NOT NULL,
  `scale` float NOT NULL,
  `shortRange` tinyint(1) NOT NULL,
  `alpha` int(11) NOT NULL,
  `posX` float NOT NULL,
  `posY` float NOT NULL,
  `posZ` float NOT NULL,
  `isActive` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `server_blips`
--

INSERT INTO `server_blips` (`id`, `name`, `sprite`, `color`, `scale`, `shortRange`, `alpha`, `posX`, `posY`, `posZ`, `isActive`) VALUES
(1, 'Grove Family', 475, 25, 1, 1, 255, 468.624, -1803.23, 28.5925, 1),
(2, 'La Cosa Nostra', 475, 40, 1, 1, 255, -1535.58, 97.4416, 56.7706, 1),
(3, 'Front Yard Ballas', 475, 27, 1, 1, 255, 85.0863, -1957.54, 21.1254, 1),
(4, 'Marabunta Grande 13', 475, 3, 1, 1, 255, 1192.99, -1655.59, 43.0265, 1),
(5, 'Bruderschaft', 475, 0, 1, 1, 255, 792.236, 1277.17, 359.872, 1),
(6, 'Triaden', 475, 38, 1, 1, 255, 1380.26, 1147.29, 114.334, 1),
(7, 'Los Santos Vagos', 475, 46, 1, 1, 255, -1117.4, -1608.77, 4.23845, 1),
(8, 'YakuZa', 475, 49, 1, 1, 255, -1516.77, 851.591, 181.594, 1),
(11, 'Aztecas', 475, 3, 1, 1, 255, 1385.04, -592.398, 74.4855, 1),
(12, '45 Crips', 475, 38, 1, 1, 255, 336.437, -2040.95, 21.1409, 1),
(13, 'El Mando', 475, 47, 1, 1, 255, -1236.37, -1224.25, 6.45432, 1),
(14, 'Secret Service', 475, 39, 1, 1, 255, -535.55, -220.613, 37.6498, 1),
(15, 'Organisatzija', 475, 62, 1, 1, 255, -698.735, 47.139, 44.0338, 1),
(17, '187', 475, 37, 1, 0, 255, -1581.81, -59.1878, 56.0666, 1),
(18, 'Gerados Elite', 475, 83, 1, 1, 255, -406.535, 6148.93, 31.6783, 1),
(19, 'KFC Bigness', 475, 50, 1, 1, 255, -51.3351, 6515.82, 31.4908, 1),
(21, 'FIB', 475, 40, 1, 1, 255, 134.317, -719.017, 33.1333, 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `server_factions`
--

CREATE TABLE `server_factions` (
  `id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL,
  `spawnX` float NOT NULL,
  `spawnY` float NOT NULL,
  `spawnZ` float NOT NULL,
  `private` tinyint(1) NOT NULL,
  `color` int(11) NOT NULL,
  `blipColor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `server_factions`
--

INSERT INTO `server_factions` (`id`, `name`, `spawnX`, `spawnY`, `spawnZ`, `private`, `color`, `blipColor`) VALUES
(1, 'Ballas', 84.6384, -1958.1, 21.1217, 0, 145, 0),
(2, 'fib', 110.374, -736.147, 33.1332, 1, 0, 0),
(3, 'Grove', 469.5, -1803.61, 28.4652, 0, 53, 0),
(4, 'LCN', -1535.58, 97.4416, 56.7706, 0, 0, 0),
(5, 'MG13', 1192.99, -1655.59, 43.0265, 0, 70, 0),
(6, 'Bruderschaft', 781.107, 1296.77, 361.362, 0, 22, 0),
(7, 'Triaden', 1380.35, 1147.3, 114.334, 0, 82, 0),
(8, 'Vagos', -1114.81, -1621.81, 4.39843, 0, 89, 0),
(9, 'Yakuza', -1516.9, 851.925, 181.595, 0, 43, 0),
(10, 'El Mando', -1243.9, -1240.55, 11.0277, 0, 41, 0),
(11, 'Aztecas', 1385.08, -592.365, 74.4855, 1, 140, 0),
(12, '45 Crips', 325.242, -2050.18, 20.9364, 1, 83, 0),
(14, 'Secret Service', -535.55, -220.613, 37.6498, 1, 156, 0),
(15, 'Organisazija', -698.735, 47.139, 44.0338, 0, 14, 0),
(17, '187', -1579.94, -34.0914, 57.5652, 1, 120, 0),
(18, 'Gerardos Elite', -406.535, 6148.93, 31.6783, 1, 148, 0),
(19, 'KFC Bigness', -57.0049, 6523.91, 31.4908, 1, 145, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `server_factions_clothes`
--

CREATE TABLE `server_factions_clothes` (
  `id` int(11) NOT NULL,
  `factionId` int(11) NOT NULL,
  `hat` int(11) NOT NULL,
  `hatTex` int(11) NOT NULL,
  `mask` int(11) NOT NULL,
  `maskTex` int(11) NOT NULL,
  `top` int(11) NOT NULL,
  `topTex` int(11) NOT NULL,
  `undershirt` int(11) NOT NULL,
  `undershirtTex` int(11) NOT NULL,
  `leg` int(11) NOT NULL,
  `legTex` int(11) NOT NULL,
  `shoes` int(11) NOT NULL,
  `shoesTex` int(11) NOT NULL,
  `bag` int(11) NOT NULL,
  `bagTex` int(11) NOT NULL,
  `glasses` int(11) NOT NULL,
  `glassesTex` int(11) NOT NULL,
  `accessories` int(11) NOT NULL,
  `accessoriesTex` int(11) NOT NULL,
  `torso` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `server_factions_clothes`
--

INSERT INTO `server_factions_clothes` (`id`, `factionId`, `hat`, `hatTex`, `mask`, `maskTex`, `top`, `topTex`, `undershirt`, `undershirtTex`, `leg`, `legTex`, `shoes`, `shoesTex`, `bag`, `bagTex`, `glasses`, `glassesTex`, `accessories`, `accessoriesTex`, `torso`) VALUES
(1, 5, 8, 0, 95, 0, 96, 0, 0, 30, 5, 3, 7, 0, 0, 0, 0, 0, 0, 0, 14),
(2, 9, 30, 0, 111, 5, 139, 1, 0, 30, 24, 4, 10, 0, 0, 0, 0, 0, 0, 0, 17),
(3, 3, 77, 9, 51, 5, 82, 4, 15, 0, 42, 6, 7, 0, 0, 0, 0, 0, 0, 0, 0),
(4, 1, 8, 0, 51, 6, 203, 2, 15, 0, 5, 9, 7, 0, 0, 0, 0, 0, 0, 0, 0),
(5, 7, 7, 3, 95, 0, 111, 3, 0, 30, 28, 11, 42, 2, 0, 0, 0, 0, 77, 2, 1),
(6, 6, 5, 0, 95, 0, 163, 0, 75, 3, 4, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0),
(7, 4, 61, 6, 111, 17, 76, 1, 3, 0, 24, 0, 36, 3, 0, 0, 0, 0, 0, 0, 6),
(8, 2, 66, 0, 54, 0, 234, 0, 15, 0, 24, 0, 10, 0, 0, 0, 25, 4, 125, 0, 30),
(9, 8, 8, 0, 129, 12, 253, 1, 0, 30, 5, 8, 7, 0, 0, 0, 0, 0, 0, 0, 4),
(10, 10, 77, 9, 111, 16, 134, 0, 15, 0, 5, 7, 7, 0, 0, 0, 0, 0, 0, 0, 14),
(11, 11, 3, 1, 111, 4, 251, 9, 0, 0, 97, 9, 7, 0, 0, 0, 0, 0, 0, 0, 0),
(12, 12, 20, 4, 8, 0, 243, 20, 15, 0, 16, 8, 7, 0, 0, 0, 0, 0, 0, 0, 0),
(14, 14, 8, 0, 54, 1, 13, 0, 130, 0, 24, 0, 10, 0, 0, 0, 0, 0, 128, 0, 0),
(15, 15, 12, 0, 110, 0, 111, 0, 15, 0, 28, 0, 10, 0, 0, 0, 0, 0, 0, 0, 4),
(17, 17, 0, 0, 54, 0, 135, 0, 15, 0, 33, 0, 6, 0, 0, 0, 0, 0, 11, 0, 84),
(18, 18, 4, 0, 51, 6, 80, 0, 15, 0, 5, 9, 7, 0, 0, 0, 0, 0, 0, 0, 15),
(19, 19, 4, 0, 51, 6, 81, 0, 15, 0, 5, 9, 7, 0, 0, 0, 0, 0, 0, 0, 15);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `server_factions_garage`
--

CREATE TABLE `server_factions_garage` (
  `id` int(11) NOT NULL,
  `factionId` int(11) NOT NULL,
  `pedModel` varchar(64) NOT NULL,
  `pedX` float NOT NULL,
  `pedY` float NOT NULL,
  `pedZ` float NOT NULL,
  `pedRot` float NOT NULL,
  `spawnX` float NOT NULL,
  `spawnY` float NOT NULL,
  `spawnZ` float NOT NULL,
  `spawnRot` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `server_factions_garage`
--

INSERT INTO `server_factions_garage` (`id`, `factionId`, `pedModel`, `pedX`, `pedY`, `pedZ`, `pedRot`, `spawnX`, `spawnY`, `spawnZ`, `spawnRot`) VALUES
(1, 5, 'a_m_m_soucent_03', 1166.6, -1641.56, 36.9528, 0, 1160.99, -1647.44, 36.5073, 180.234),
(2, 9, 'g_m_y_korlieut_01', -1520.32, 848.974, 181.595, 36.1076, -1529.68, 858.641, 181.588, 299.009),
(3, 1, 'g_m_y_ballaorig_01', 102.974, -1958.63, 20.784, 354.349, 95.184, -1959.9, 20.2503, 317.319),
(4, 7, 'ig_milton', 1400.34, 1123.94, 114.828, 190, 1405.77, 1118.06, 114.124, 87.8782),
(5, 6, 'a_m_y_surfer_01', 781.316, 1280.63, 360.296, 143.561, 792.236, 1277.17, 359.872, 64.207),
(6, 4, 'a_m_y_hasjew_01', -1531.72, 79.2878, 56.7491, 321.473, -1531.72, 83.9317, 56.049, 313.154),
(7, 3, 'mp_m_famdd_01', 479.314, -1792.55, 28.5495, 243.561, 484.304, -1796.18, 28.395, 243.561),
(8, 2, 's_m_m_ciasec_01', 135.134, -718.669, 33.1333, 0, 132.384, -724.046, 33.1333, 0),
(9, 8, 'g_m_y_mexgoon_01', -1121.37, -1614.66, 4.39843, 0, -1119.04, -1605.99, 4.35141, 0),
(10, 10, 'a_m_m_stlat_02', -1244.14, -1232.73, 6.96911, 243.561, -1236.37, -1224.25, 6.45432, 143.561),
(11, 11, 'a_m_m_soucent_03', 1375.05, -597.682, 74.4342, 0, 1367.44, -580.253, 74.3803, 0),
(12, 12, 'ig_tracydisanto', 336.437, -2040.95, 21.1409, 0, 326.823, -2033.48, 20.9374, 0),
(14, 14, 'u_m_m_fibarchitect', -517.543, -251.499, 35.6723, 0, -514.052, -263.422, 35.4226, 0),
(15, 15, 'csb_reporter', -674.225, 50.7146, 42.8149, 0, -670.508, 46.2044, 41.6168, 260.561),
(17, 17, 'a_f_m_beach_01', -1575.91, -55.4513, 56.492, 0, -1581.81, -59.1878, 56.0666, 0),
(18, 18, 'ig_ballasog', -434.212, 6143.9, 31.4783, 0, -442.654, 6144.26, 31.4783, 0),
(19, 19, 'g_m_y_ballaeast_01', -51.3351, 6515.82, 31.4908, 0, -51.5417, 6529.33, 31.4908, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `server_factions_vehicles`
--

CREATE TABLE `server_factions_vehicles` (
  `id` int(11) NOT NULL,
  `hash` int(10) UNSIGNED NOT NULL,
  `displayName` varchar(128) NOT NULL,
  `type` varchar(64) NOT NULL COMMENT 'bike // car',
  `neededLevel` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `server_factions_vehicles`
--

INSERT INTO `server_factions_vehicles` (`id`, `hash`, `displayName`, `type`, `neededLevel`) VALUES
(1, 1873600305, 'Ratbike', 'bike', 1),
(2, 86520421, 'bf400', 'bike', 5),
(3, 3403504941, 'Bati2', 'bike', 20),
(4, 4039289119, 'Hakuchou2', 'bike', 30),
(7, 3057713523, 'Dubsta3', 'car', 1),
(9, 970598228, 'Sultan', 'car', 2),
(10, 3670438162, 'Jackal', 'car', 2),
(11, 3379262425, 'Dominator2', 'car', 5),
(12, 108773431, 'Coquette', 'car', 10),
(13, 2809443750, 'Schafter3', 'car', 1),
(14, 867799010, 'Pariah', 'car', 20),
(15, 3884762073, 'Revolter', 'car', 25),
(16, 2765724541, 'Raiden', 'car', 30),
(17, 2922118804, 'Kuruma', 'car', 35),
(18, 3003014393, 'EntityXF', 'car', 40),
(19, 3862958888, 'Xls2', 'car', 45),
(20, 2445973230, 'Neon', 'car', 50),
(21, 3296789504, 'Visione', 'car', 55),
(22, 408192225, 'Turismo2', 'car', 60),
(23, 1939284556, 'Vagner', 'car', 65),
(24, 2123327359, 'Prototipo', 'car', 70),
(25, 2891838741, 'Zentorno', 'car', 80),
(26, 1987142870, 'Osiris', 'car', 90),
(27, 1753414259, 'Enduro', 'bike', 15),
(28, 3889340782, 'Shotaro', 'bike', 10),
(29, 3285698347, 'ZombieA', 'bike', 40);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `server_ffa`
--

CREATE TABLE `server_ffa` (
  `id` int(11) NOT NULL,
  `name` varchar(128) NOT NULL,
  `posX` float NOT NULL,
  `posY` float NOT NULL,
  `posZ` float NOT NULL,
  `dimension` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `server_ffa`
--

INSERT INTO `server_ffa` (`id`, `name`, `posX`, `posY`, `posZ`, `dimension`) VALUES
(1, '1', 160.857, -1004.98, 28.4021, 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `server_ffa_spawns`
--

CREATE TABLE `server_ffa_spawns` (
  `id` int(11) NOT NULL,
  `zoneId` int(11) NOT NULL,
  `posX` float NOT NULL,
  `posY` float NOT NULL,
  `posZ` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `server_ffa_spawns`
--

INSERT INTO `server_ffa_spawns` (`id`, `zoneId`, `posX`, `posY`, `posZ`) VALUES
(1, 1, 206.494, -878.083, 31.4983),
(2, 1, 249.712, -896.04, 29.1415),
(3, 1, 200.702, -1003.49, 29.2918),
(4, 1, 139.705, -978.801, 29.4082),
(5, 1, 158.894, -911.684, 30.1863),
(6, 1, 186.913, -843.567, 31.0293),
(7, 1, 240.852, -876.465, 30.4921),
(8, 1, 229.314, -960.097, 29.3557),
(9, 1, 198.499, -899.619, 31.1168),
(10, 1, 210.603, -983.268, 29.1323);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `server_gangwarflags`
--

CREATE TABLE `server_gangwarflags` (
  `id` int(11) NOT NULL,
  `zoneId` int(11) NOT NULL,
  `flagX` float NOT NULL,
  `flagY` float NOT NULL,
  `flagZ` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `server_gangwarflags`
--

INSERT INTO `server_gangwarflags` (`id`, `zoneId`, `flagX`, `flagY`, `flagZ`) VALUES
(6, 1, -602.798, 5311.51, 70.3277),
(7, 1, -510.022, 5240.92, 80.3026),
(8, 1, -477.635, 5359.29, 80.7589),
(9, 1, -55.672, 5319.19, 73.6013),
(10, 2, 3626.17, 3752.03, 28.5157),
(11, 2, 3556.66, 3723.91, 37.3527),
(12, 2, 3469.61, 3656.94, 42.5962),
(13, 3, 142.662, -358.746, 43.2556),
(14, 3, 28.3531, -361.183, 39.3147),
(15, 3, 39.6186, -457.113, 39.9197);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `server_gangwarzones`
--

CREATE TABLE `server_gangwarzones` (
  `id` int(11) NOT NULL,
  `zoneName` varchar(128) NOT NULL,
  `currentOwner` int(11) NOT NULL,
  `attackPosX` float NOT NULL,
  `attackPosY` float NOT NULL,
  `attackPosZ` float NOT NULL,
  `isPrivate` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `server_gangwarzones`
--

INSERT INTO `server_gangwarzones` (`id`, `zoneName`, `currentOwner`, `attackPosX`, `attackPosY`, `attackPosZ`, `isPrivate`) VALUES
(1, 'Sägewerk', 3, -616.539, 5262.35, 72.8321, 0),
(2, 'Humane Labs', 3, 3420, 3759.37, 30.5556, 0),
(3, 'Baustelle', 3, 68.544, -405.424, 39.919, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `server_prestige_vehicles`
--

CREATE TABLE `server_prestige_vehicles` (
  `id` int(11) NOT NULL,
  `hash` int(10) UNSIGNED NOT NULL,
  `displayName` varchar(64) NOT NULL,
  `neededLevel` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `server_prestige_vehicles`
--

INSERT INTO `server_prestige_vehicles` (`id`, `hash`, `displayName`, `neededLevel`) VALUES
(1, 470404958, 'Baller5', 1),
(2, 37348240, 'Hotknife', 0),
(3, 1093792632, 'Nero2', 2),
(4, 1922255844, 'Schafter6', 3);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `server_private_vehicles`
--

CREATE TABLE `server_private_vehicles` (
  `id` int(11) NOT NULL,
  `accountId` int(11) NOT NULL,
  `hash` int(10) UNSIGNED NOT NULL,
  `displayName` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `server_private_vehicles`
--

INSERT INTO `server_private_vehicles` (`id`, `accountId`, `hash`, `displayName`) VALUES
(1, 1, 1, '1');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `admin_logs`
--
ALTER TABLE `admin_logs`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `server_blips`
--
ALTER TABLE `server_blips`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `server_factions`
--
ALTER TABLE `server_factions`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `server_factions_clothes`
--
ALTER TABLE `server_factions_clothes`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `server_factions_garage`
--
ALTER TABLE `server_factions_garage`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `server_factions_vehicles`
--
ALTER TABLE `server_factions_vehicles`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `server_ffa`
--
ALTER TABLE `server_ffa`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `server_ffa_spawns`
--
ALTER TABLE `server_ffa_spawns`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `server_gangwarflags`
--
ALTER TABLE `server_gangwarflags`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `server_gangwarzones`
--
ALTER TABLE `server_gangwarzones`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `server_prestige_vehicles`
--
ALTER TABLE `server_prestige_vehicles`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `server_private_vehicles`
--
ALTER TABLE `server_private_vehicles`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `accounts`
--
ALTER TABLE `accounts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT für Tabelle `admin_logs`
--
ALTER TABLE `admin_logs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT für Tabelle `server_blips`
--
ALTER TABLE `server_blips`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT für Tabelle `server_factions`
--
ALTER TABLE `server_factions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT für Tabelle `server_factions_clothes`
--
ALTER TABLE `server_factions_clothes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT für Tabelle `server_factions_garage`
--
ALTER TABLE `server_factions_garage`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT für Tabelle `server_factions_vehicles`
--
ALTER TABLE `server_factions_vehicles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT für Tabelle `server_ffa`
--
ALTER TABLE `server_ffa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT für Tabelle `server_ffa_spawns`
--
ALTER TABLE `server_ffa_spawns`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;

--
-- AUTO_INCREMENT für Tabelle `server_gangwarflags`
--
ALTER TABLE `server_gangwarflags`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT für Tabelle `server_gangwarzones`
--
ALTER TABLE `server_gangwarzones`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT für Tabelle `server_prestige_vehicles`
--
ALTER TABLE `server_prestige_vehicles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT für Tabelle `server_private_vehicles`
--
ALTER TABLE `server_private_vehicles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
