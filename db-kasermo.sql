-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Feb 08, 2024 at 02:36 AM
-- Server version: 5.7.33
-- PHP Version: 7.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db-kasermo`
--

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE `log` (
  `id` int(11) NOT NULL,
  `id_user` int(11) NOT NULL,
  `aktivity` text NOT NULL,
  `created_at` timestamp NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `log`
--

INSERT INTO `log` (`id`, `id_user`, `aktivity`, `created_at`) VALUES
(1, 1, 'Login', '2024-01-31 01:56:16'),
(2, 1, 'Login', '2024-01-31 01:59:40'),
(3, 1, 'Login', '2024-01-31 02:10:13'),
(4, 1, 'Login', '2024-01-31 02:10:53'),
(6, 1, 'Login', '2024-01-31 03:03:04'),
(7, 1, 'Login', '2024-01-31 03:05:39'),
(8, 2, 'Login', '2024-01-31 03:08:21'),
(9, 2, 'Kasir Melakukan Transaksi', '2024-01-31 03:09:25'),
(10, 2, 'Login', '2024-01-31 03:09:47'),
(11, 2, 'Login', '2024-01-31 04:11:45'),
(12, 2, 'Kasir Melakukan Transaksi', '2024-01-31 04:12:11'),
(13, 2, 'Login', '2024-01-31 04:12:24'),
(14, 2, 'Login', '2024-01-31 04:35:21'),
(15, 2, 'Login', '2024-01-31 05:59:27'),
(16, 2, 'Kasir Melakukan Transaksi', '2024-01-31 06:00:35'),
(17, 1, 'Login', '2024-01-31 06:03:28'),
(18, 2, 'Login', '2024-01-31 06:03:49'),
(19, 1, 'Login', '2024-01-31 06:07:50'),
(20, 2, 'Login', '2024-01-31 06:14:26'),
(21, 2, 'Login', '2024-01-31 06:26:02'),
(22, 2, 'Login', '2024-01-31 06:27:08'),
(23, 2, 'Login', '2024-01-31 06:43:32'),
(24, 2, 'Login', '2024-01-31 06:43:51'),
(25, 2, 'Kasir Melakukan Transaksi', '2024-01-31 06:44:09'),
(26, 2, 'Login', '2024-01-31 06:46:42'),
(27, 2, 'Login', '2024-01-31 06:48:49'),
(28, 2, 'Login', '2024-01-31 06:49:49'),
(29, 2, 'Login', '2024-01-31 06:51:39'),
(30, 2, 'Login', '2024-01-31 06:53:43'),
(31, 2, 'Login', '2024-01-31 07:07:05'),
(32, 1, 'Login', '2024-01-31 07:08:19'),
(33, 2, 'Login', '2024-01-31 07:08:53'),
(34, 2, 'Login', '2024-01-31 07:13:17'),
(35, 2, 'Login', '2024-01-31 07:14:32'),
(36, 2, 'Login', '2024-01-31 07:16:03'),
(37, 2, 'Login', '2024-01-31 07:21:49'),
(38, 2, 'Login', '2024-01-31 07:25:02'),
(39, 2, 'Login', '2024-01-31 07:28:35'),
(40, 2, 'Login', '2024-01-31 07:29:39'),
(41, 2, 'Login', '2024-01-31 07:30:05'),
(42, 2, 'Login', '2024-01-31 07:31:01'),
(43, 2, 'Login', '2024-01-31 07:33:06'),
(44, 2, 'Login', '2024-01-31 07:35:47'),
(45, 1, 'Login', '2024-01-31 07:38:30'),
(46, 2, 'Login', '2024-01-31 07:40:46'),
(47, 2, 'Login', '2024-01-31 07:43:15'),
(48, 2, 'Login', '2024-01-31 07:43:59'),
(49, 2, 'Login', '2024-01-31 07:45:03'),
(50, 2, 'Login', '2024-01-31 07:46:30'),
(51, 2, 'Login', '2024-01-31 07:46:43'),
(52, 2, 'Login', '2024-01-31 07:47:36'),
(53, 2, 'Login', '2024-01-31 07:48:21'),
(54, 5, 'Login', '2024-01-31 07:50:17'),
(55, 2, 'Login', '2024-01-31 07:50:34'),
(56, 2, 'Login', '2024-01-31 07:52:23'),
(57, 2, 'Login', '2024-01-31 07:58:22'),
(58, 2, 'Login', '2024-01-31 08:00:31'),
(59, 2, 'Login', '2024-01-31 08:01:10'),
(60, 2, 'Login', '2024-01-31 08:02:21'),
(61, 1, 'Login', '2024-01-31 08:05:20'),
(62, 2, 'Login', '2024-01-31 08:05:37'),
(63, 2, 'Login', '2024-01-31 08:08:25'),
(64, 2, 'Login', '2024-01-31 08:09:22'),
(65, 1, 'Login', '2024-01-31 08:09:41'),
(66, 2, 'Login', '2024-01-31 08:10:11'),
(67, 2, 'Login', '2024-01-31 08:10:51'),
(68, 2, 'Kasir Melakukan Transaksi', '2024-01-31 08:11:12'),
(69, 2, 'Login', '2024-01-31 08:14:07'),
(70, 2, 'Kasir Melakukan Transaksi', '2024-01-31 08:14:35'),
(71, 2, 'Login', '2024-01-31 08:16:07'),
(72, 2, 'Kasir Melakukan Transaksi', '2024-01-31 08:16:22'),
(73, 2, 'Login', '2024-01-31 08:21:51'),
(74, 2, 'Login', '2024-01-31 08:22:36'),
(75, 2, 'Login', '2024-01-31 08:23:27'),
(76, 2, 'Login', '2024-01-31 08:23:40'),
(77, 2, 'Kasir Melakukan Transaksi', '2024-01-31 08:23:55'),
(101, 1, 'Login', '2024-02-02 04:28:12'),
(102, 2, 'Login', '2024-02-03 00:43:05'),
(103, 2, 'Kasir Melakukan Transaksi', '2024-02-03 00:43:39'),
(104, 2, 'Kasir Melakukan Transaksi', '2024-02-03 00:44:24'),
(105, 1, 'Login', '2024-02-03 08:46:33'),
(106, 2, 'Login', '2024-02-03 08:46:52'),
(107, 1, 'Login', '2024-02-03 08:48:00'),
(108, 2, 'Login', '2024-02-03 08:48:27'),
(109, 2, 'Login', '2024-02-03 08:49:02'),
(110, 2, 'Login', '2024-02-04 15:28:18'),
(111, 2, 'Login', '2024-02-04 15:31:27'),
(112, 2, 'Login', '2024-02-04 15:31:43'),
(113, 2, 'Login', '2024-02-04 15:34:49'),
(114, 2, 'Login', '2024-02-04 15:36:55'),
(115, 2, 'Login', '2024-02-04 15:37:45'),
(116, 2, 'Login', '2024-02-04 15:40:33'),
(117, 2, 'Login', '2024-02-04 15:41:18'),
(118, 2, 'Login', '2024-02-04 15:41:47'),
(119, 2, 'Login', '2024-02-04 15:42:28'),
(120, 2, 'Login', '2024-02-04 15:45:41'),
(121, 2, 'Login', '2024-02-04 15:46:45'),
(122, 2, 'Login', '2024-02-04 15:52:06'),
(123, 2, 'Login', '2024-02-04 15:53:00'),
(124, 2, 'Login', '2024-02-04 15:53:41'),
(125, 2, 'Login', '2024-02-04 15:54:36'),
(126, 1, 'Login', '2024-02-04 22:23:58'),
(127, 1, 'Admin Melakukan Penambahan Produk', '2024-02-04 22:25:03'),
(128, 1, 'Admin Melakukan Pengeditan Produk', '2024-02-04 22:25:30'),
(129, 1, 'Admin Melakukan Penambahan Produk', '2024-02-04 22:25:43'),
(130, 1, 'Admin Melakukan Penghapusan Produk', '2024-02-04 22:25:49'),
(131, 1, 'Login', '2024-02-04 22:28:23'),
(132, 1, 'Login', '2024-02-04 22:29:36'),
(133, 1, 'Admin Melakukan Penambahan User', '2024-02-04 22:29:54'),
(134, 1, 'Admin Melakukan Pengeditan User', '2024-02-04 22:30:38'),
(135, 1, 'Admin Melakukan Penambahan User', '2024-02-04 22:30:52'),
(136, 1, 'Admin Melakukan Penghapusan/Non-akfifkan User', '2024-02-04 22:30:57'),
(137, 2, 'Login', '2024-02-04 22:31:17'),
(138, 2, 'Login', '2024-02-04 22:34:29'),
(139, 2, 'Login', '2024-02-04 22:35:27'),
(140, 2, 'Login', '2024-02-04 22:35:44'),
(141, 2, 'Login', '2024-02-04 22:36:42'),
(142, 2, 'Login', '2024-02-04 22:38:30'),
(143, 2, 'Kasir Melakukan Transaksi', '2024-02-04 22:39:02'),
(144, 6, 'Login', '2024-02-04 22:41:44'),
(145, 6, 'logout', '2024-02-04 22:41:47'),
(146, 2, 'Login', '2024-02-05 06:04:33'),
(147, 2, 'Kasir Melakukan Transaksi', '2024-02-05 06:05:13'),
(148, 2, 'Login', '2024-02-05 06:08:37'),
(149, 2, 'Kasir Melakukan Transaksi', '2024-02-05 06:09:01'),
(150, 2, 'Login', '2024-02-05 06:10:14'),
(151, 2, 'logout', '2024-02-05 06:11:00'),
(152, 2, 'Login', '2024-02-05 06:11:09'),
(153, 2, 'Kasir Melakukan Transaksi', '2024-02-05 06:11:48'),
(154, 2, 'Login', '2024-02-05 06:13:16'),
(155, 2, 'logout', '2024-02-05 06:13:38'),
(156, 2, 'Login', '2024-02-05 06:13:42'),
(157, 2, 'Kasir Melakukan Transaksi', '2024-02-05 06:14:19'),
(158, 2, 'Login', '2024-02-05 06:21:01'),
(159, 2, 'Kasir Melakukan Transaksi', '2024-02-05 06:21:30'),
(160, 2, 'Login', '2024-02-05 06:22:18'),
(161, 2, 'Kasir Melakukan Transaksi', '2024-02-05 06:22:53'),
(162, 6, 'Login', '2024-02-05 06:24:28'),
(163, 6, 'Kasir Melakukan Transaksi', '2024-02-05 06:24:51'),
(164, 6, 'Login', '2024-02-05 06:28:31'),
(165, 6, 'Kasir Melakukan Transaksi', '2024-02-05 06:29:00'),
(166, 6, 'logout', '2024-02-05 06:29:43'),
(167, 6, 'Login', '2024-02-05 06:32:48'),
(168, 6, 'Kasir Melakukan Transaksi', '2024-02-05 06:33:04'),
(169, 6, 'logout', '2024-02-05 06:33:27'),
(170, 6, 'Login', '2024-02-05 06:37:22'),
(171, 6, 'Login', '2024-02-05 07:09:33'),
(172, 6, 'Kasir Melakukan Transaksi', '2024-02-05 07:09:50'),
(173, 2, 'Login', '2024-02-05 07:13:15'),
(174, 2, 'Kasir Melakukan Transaksi', '2024-02-05 07:13:43'),
(175, 2, 'logout', '2024-02-05 07:14:16'),
(176, 1, 'Login', '2024-02-05 07:36:45'),
(177, 1, 'Logout', '2024-02-05 07:36:55'),
(178, 6, 'Login', '2024-02-05 07:44:17'),
(179, 6, 'logout', '2024-02-05 07:47:55'),
(180, 1, 'Login', '2024-02-05 07:48:26'),
(181, 1, 'Logout', '2024-02-05 07:48:54'),
(182, 2, 'Login', '2024-02-05 07:49:50'),
(183, 2, 'Kasir Melakukan Transaksi', '2024-02-05 07:50:19'),
(184, 2, 'Login', '2024-02-05 07:58:59'),
(185, 2, 'Kasir Melakukan Transaksi', '2024-02-05 07:59:18'),
(186, 2, 'Login', '2024-02-05 08:00:53'),
(187, 2, 'Login', '2024-02-05 08:01:53'),
(188, 2, 'Login', '2024-02-05 08:02:47'),
(189, 2, 'Kasir Melakukan Transaksi', '2024-02-05 08:03:06'),
(190, 2, 'Login', '2024-02-06 00:07:22'),
(191, 2, 'Login', '2024-02-06 00:07:45'),
(192, 2, 'Kasir Melakukan Transaksi', '2024-02-06 00:08:31'),
(193, 2, 'logout', '2024-02-06 00:08:57'),
(194, 6, 'Login', '2024-02-06 00:32:00'),
(195, 6, 'Kasir Melakukan Transaksi', '2024-02-06 00:32:28'),
(196, 2, 'Login', '2024-02-06 00:37:03'),
(197, 2, 'Login', '2024-02-06 00:43:33'),
(198, 2, 'Kasir Melakukan Transaksi', '2024-02-06 00:43:45'),
(199, 1, 'Login', '2024-02-06 00:53:25'),
(200, 1, 'Admin Melakukan Penambahan Produk', '2024-02-06 00:54:10'),
(201, 1, 'Logout', '2024-02-06 00:54:16'),
(202, 2, 'Login', '2024-02-06 00:54:21'),
(203, 2, 'Kasir Melakukan Transaksi', '2024-02-06 00:55:24'),
(204, 2, 'logout', '2024-02-06 00:55:52'),
(205, 1, 'Login', '2024-02-06 00:55:56'),
(206, 1, 'Admin Melakukan Pengeditan Produk', '2024-02-06 00:56:08'),
(207, 1, 'Logout', '2024-02-06 00:56:29'),
(208, 6, 'Login', '2024-02-06 01:04:08'),
(209, 6, 'Login', '2024-02-06 01:06:14'),
(210, 2, 'Login', '2024-02-06 01:10:15'),
(211, 2, 'Login', '2024-02-06 01:17:58'),
(212, 2, 'Kasir Melakukan Transaksi', '2024-02-06 01:18:11'),
(213, 2, 'Login', '2024-02-06 01:21:41'),
(214, 2, 'Kasir Melakukan Transaksi', '2024-02-06 01:22:04'),
(215, 2, 'Login', '2024-02-06 01:27:53'),
(216, 2, 'Kasir Melakukan Transaksi', '2024-02-06 01:28:04'),
(217, 2, 'Login', '2024-02-06 01:34:07'),
(218, 2, 'Kasir Melakukan Transaksi', '2024-02-06 01:34:17'),
(219, 6, 'Login', '2024-02-06 01:37:18'),
(220, 6, 'Kasir Melakukan Transaksi', '2024-02-06 01:37:36'),
(221, 6, 'Kasir Melakukan Transaksi', '2024-02-06 01:40:00'),
(222, 6, 'Kasir Melakukan Transaksi', '2024-02-06 01:40:06'),
(223, 2, 'Login', '2024-02-06 01:44:15'),
(224, 2, 'Kasir Melakukan Transaksi', '2024-02-06 01:45:17'),
(225, 2, 'logout', '2024-02-06 01:46:00'),
(226, 2, 'Login', '2024-02-06 01:48:28'),
(227, 2, 'Kasir Melakukan Transaksi', '2024-02-06 01:49:36'),
(228, 2, 'logout', '2024-02-06 01:49:55'),
(229, 2, 'Login', '2024-02-07 01:49:25'),
(230, 2, 'Kasir Melakukan Transaksi', '2024-02-07 01:50:39'),
(231, 2, 'logout', '2024-02-07 01:53:42'),
(232, 2, 'Login', '2024-02-07 01:53:46'),
(233, 2, 'Login', '2024-02-07 01:55:41'),
(234, 2, 'Kasir Melakukan Transaksi', '2024-02-07 01:55:58'),
(235, 2, 'Login', '2024-02-07 01:58:11'),
(236, 2, 'logout', '2024-02-07 01:58:28'),
(237, 2, 'Login', '2024-02-07 02:35:16'),
(238, 2, 'Kasir Melakukan Transaksi', '2024-02-07 02:37:29'),
(239, 2, 'logout', '2024-02-07 02:37:44'),
(240, 1, 'Login', '2024-02-07 04:13:40'),
(241, 1, 'Admin Melakukan Penghapusan Produk', '2024-02-07 04:13:56'),
(242, 1, 'Admin Melakukan Pengeditan Produk', '2024-02-07 04:14:05'),
(243, 1, 'Admin Melakukan Pengeditan Produk', '2024-02-07 04:14:31'),
(244, 1, 'Admin Melakukan Penambahan Produk', '2024-02-07 04:15:24'),
(245, 1, 'Login', '2024-02-07 04:18:09'),
(246, 2, 'Login', '2024-02-07 04:18:35'),
(247, 2, 'Kasir Melakukan Transaksi', '2024-02-07 04:19:13'),
(248, 2, 'Kasir Melakukan Transaksi', '2024-02-07 04:19:23'),
(249, 2, 'Login', '2024-02-07 06:43:53'),
(250, 2, 'Kasir Melakukan Transaksi', '2024-02-07 06:44:59'),
(251, 2, 'Login', '2024-02-07 06:49:33'),
(252, 2, 'logout', '2024-02-07 06:51:06'),
(253, 2, 'Login', '2024-02-07 07:42:16'),
(254, 2, 'Login', '2024-02-07 07:45:17'),
(255, 2, 'Login', '2024-02-07 07:49:09'),
(256, 2, 'Login', '2024-02-07 07:50:46'),
(257, 2, 'Login', '2024-02-07 07:54:46'),
(258, 2, 'Kasir Melakukan Transaksi', '2024-02-07 07:56:25'),
(259, 2, 'logout', '2024-02-07 07:56:38'),
(260, 2, 'Login', '2024-02-07 08:04:13'),
(261, 2, 'Kasir Melakukan Transaksi', '2024-02-07 08:05:15'),
(262, 2, 'Login', '2024-02-07 08:11:18'),
(263, 2, 'Kasir Melakukan Transaksi', '2024-02-07 08:11:36'),
(264, 2, 'Login', '2024-02-07 08:14:36'),
(265, 2, 'Kasir Melakukan Transaksi', '2024-02-07 08:14:55'),
(266, 2, 'Login', '2024-02-07 08:18:32'),
(267, 2, 'Kasir Melakukan Transaksi', '2024-02-07 08:19:01'),
(268, 2, 'Login', '2024-02-07 08:20:50'),
(269, 2, 'Kasir Melakukan Transaksi', '2024-02-07 08:21:23');

-- --------------------------------------------------------

--
-- Table structure for table `produk`
--

CREATE TABLE `produk` (
  `id` int(11) NOT NULL,
  `nama_produk` varchar(45) NOT NULL,
  `stok` int(11) NOT NULL,
  `harga_produk` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `update_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `produk`
--

INSERT INTO `produk` (`id`, `nama_produk`, `stok`, `harga_produk`, `created_at`, `update_at`) VALUES
(2, 'ganti oli', 0, 1000, '2024-01-31 08:10:02', NULL),
(3, 'spion', 5, 10, '2024-02-03 08:48:18', NULL),
(4, 'lampu sen', 0, 100000, '2024-02-04 22:25:03', '2024-02-07 04:14:28'),
(6, 'jok motor', 4, 30000, '2024-02-06 00:54:10', '2024-02-06 00:56:07'),
(7, 'jari-jari', 7, 100000, '2024-02-07 04:15:24', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `transaksi`
--

CREATE TABLE `transaksi` (
  `id` int(11) NOT NULL,
  `id_produk` int(11) NOT NULL,
  `qty` int(11) NOT NULL,
  `nama_pelanggan` varchar(45) NOT NULL,
  `nomor_unik` varchar(45) NOT NULL,
  `uang_bayar` int(11) DEFAULT NULL,
  `uang_kembali` int(11) DEFAULT NULL,
  `total_harga` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `update_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transaksi`
--

INSERT INTO `transaksi` (`id`, `id_produk`, `qty`, `nama_pelanggan`, `nomor_unik`, `uang_bayar`, `uang_kembali`, `total_harga`, `created_at`, `update_at`) VALUES
(6, 2, 2, 'd', '93453', 4000, 2000, 2000, '2024-01-31 08:23:55', NULL),
(8, 2, 1, 'j', '77935', 7000, 1000, 6000, '2024-02-04 22:39:02', NULL),
(9, 4, 1, 'dian', '37585', 300000, 200000, 100000, '2024-02-05 06:05:13', NULL),
(10, 4, 2, 'ian', '53591', 230000, 30000, 200000, '2024-02-05 06:09:01', NULL),
(12, 3, 1, 'AWP', '76752', 11, 1, 10, '2024-02-05 06:14:19', NULL),
(13, 3, 2, 'Din', '27066', 33, 13, 20, '2024-02-05 06:21:30', NULL),
(14, 4, 3, 'india', '16465', 1231231, 931231, 300000, '2024-02-05 06:22:53', NULL),
(15, 3, 4, 'dian', '51482', 50, 10, 40, '2024-02-05 06:24:51', NULL),
(17, 3, 3, '', '92648', 50, 20, 30, '2024-02-05 06:33:04', NULL),
(18, 2, 2, 'dian', '82829', 5000, 3000, 2000, '2024-02-05 07:09:50', NULL),
(20, 3, 2, '', '56988', 30, 10, 20, '2024-02-05 07:50:19', NULL),
(22, 4, 10, '', '94033', 23123123, 22123123, 1000000, '2024-02-06 00:32:28', NULL),
(24, 6, 5, 'asdf', '21381', 123123123, 122973123, 150000, '2024-02-06 00:55:24', NULL),
(25, 2, 2, '', '21415', 20, -1980, 2000, '2024-02-06 01:18:11', NULL),
(26, 6, 1, '', '90120', 9, -29991, 30000, '2024-02-06 01:22:06', NULL),
(29, 4, 2, '', '55709', 200002, 2, 200000, '2024-02-06 01:45:17', NULL),
(30, 6, 1, 'dian', '45339', 40002, 2, 40000, '2024-02-06 01:49:36', NULL),
(32, 2, 1, '', '39992', 12000, 1000, 11000, '2024-02-07 02:37:29', NULL),
(33, 6, 1, '', '50506', 20000000, 19970000, 30000, '2024-02-07 04:19:23', NULL),
(34, 3, 2, '', '37116', 200, 180, 20, '2024-02-07 06:44:59', NULL),
(35, 6, 1, '', '69525', 234234, 171234, 63000, '2024-02-07 07:56:25', NULL),
(36, 7, 3, '', '42427', 2342342, 2012312, 330030, '2024-02-07 08:05:15', NULL),
(37, 3, 3, '', '91599', 1233, 203, 1030, '2024-02-07 08:11:36', NULL),
(38, 2, 1, '', '23546', 1211, 201, 1010, '2024-02-07 08:14:55', NULL),
(39, 6, 1, '', '75588', 300000, 269990, 30010, '2024-02-07 08:19:01', NULL),
(40, 6, 1, '', '35236', 232323, 202323, 30000, '2024-02-07 08:21:23', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `nama` varchar(45) NOT NULL,
  `role` enum('admin','kasir','owner') NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `update_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `username`, `password`, `nama`, `role`, `created_at`, `update_at`) VALUES
(1, 'admin', '123', 'dian', 'admin', '2024-01-31 01:55:41', '2024-01-31 02:00:19'),
(2, 'kasir', '123', 'dian', 'kasir', '2024-01-31 01:57:09', NULL),
(5, 'owner', '123', 'indra', 'owner', '2024-01-31 02:21:11', '2024-01-31 03:07:47'),
(6, 'naufal', '123', 'naufal', 'kasir', '2024-02-04 22:29:54', '2024-02-04 22:30:38');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_user` (`id_user`);

--
-- Indexes for table `produk`
--
ALTER TABLE `produk`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`id`) USING BTREE,
  ADD KEY `id_produk` (`id_produk`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `log`
--
ALTER TABLE `log`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=270;

--
-- AUTO_INCREMENT for table `produk`
--
ALTER TABLE `produk`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `transaksi`
--
ALTER TABLE `transaksi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `log`
--
ALTER TABLE `log`
  ADD CONSTRAINT `log_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `transaksi`
--
ALTER TABLE `transaksi`
  ADD CONSTRAINT `transaksi_ibfk_1` FOREIGN KEY (`id_produk`) REFERENCES `produk` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
