-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 02, 2020 at 01:22 PM
-- Server version: 10.4.10-MariaDB
-- PHP Version: 7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `koperasi`
--

-- --------------------------------------------------------

--
-- Table structure for table `anggota`
--

CREATE TABLE `anggota` (
  `id` int(10) NOT NULL,
  `nama` varchar(45) NOT NULL,
  `alamat` text NOT NULL,
  `no_hp` varchar(15) NOT NULL,
  `email` varchar(65) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `anggota`
--

INSERT INTO `anggota` (`id`, `nama`, `alamat`, `no_hp`, `email`) VALUES
(1, 'Fachru Wildan Afdinal', 'Sarpon', '08987656543213', 'fachruwildan@gmail.com'),
(2, 'Defri Indra Mahardika', 'Pulung', '089786565432', 'defrindr@gmail.com'),
(3, 'Fachru Wildan', 'Sarpon Kota', '08987656543213', 'fachruwildan@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `anggota_has_simpanan`
--

CREATE TABLE `anggota_has_simpanan` (
  `id` int(11) NOT NULL,
  `anggota_id` int(10) NOT NULL,
  `simpanan_id` int(11) NOT NULL,
  `jml_ambil` bigint(50) NOT NULL DEFAULT 0,
  `jml_simpan` bigint(50) NOT NULL DEFAULT 0,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `updated_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `anggota_has_simpanan`
--

INSERT INTO `anggota_has_simpanan` (`id`, `anggota_id`, `simpanan_id`, `jml_ambil`, `jml_simpan`, `created_at`, `updated_at`) VALUES
(1, 1, 1, 0, 10000, '2020-04-02 00:00:00', '2020-04-02 00:00:00'),
(2, 1, 1, 10000, 0, '2020-04-02 00:00:00', '2020-04-02 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `angsuran`
--

CREATE TABLE `angsuran` (
  `id` int(11) NOT NULL,
  `bulan` varchar(45) NOT NULL,
  `tahun` varchar(45) NOT NULL,
  `jml_angsur` varchar(45) DEFAULT NULL,
  `peminjaman_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `angsuran`
--

INSERT INTO `angsuran` (`id`, `bulan`, `tahun`, `jml_angsur`, `peminjaman_id`) VALUES
(2, 'March', '2020', '100000', 5),
(3, 'March', '2020', '100000', 5),
(4, 'March', '2020', '100000', 5);

-- --------------------------------------------------------

--
-- Table structure for table `peminjaman`
--

CREATE TABLE `peminjaman` (
  `id` int(11) NOT NULL,
  `jumlah_pinjaman` bigint(50) NOT NULL,
  `anggota_id` int(10) NOT NULL,
  `ansur_perbulan` varchar(45) DEFAULT NULL,
  `jumlah_bulan` int(11) NOT NULL,
  `bunga` varchar(45) DEFAULT NULL,
  `status` varchar(50) NOT NULL,
  `tanggal_pinjam` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `peminjaman`
--

INSERT INTO `peminjaman` (`id`, `jumlah_pinjaman`, `anggota_id`, `ansur_perbulan`, `jumlah_bulan`, `bunga`, `status`, `tanggal_pinjam`) VALUES
(5, 300000, 3, '100000', 1, '5%', 'lunas', '2020-03-18');

-- --------------------------------------------------------

--
-- Table structure for table `simpanan`
--

CREATE TABLE `simpanan` (
  `id` int(11) NOT NULL,
  `no_rekening` varchar(45) NOT NULL,
  `saldo` bigint(50) NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `simpanan`
--

INSERT INTO `simpanan` (`id`, `no_rekening`, `saldo`, `created_at`, `updated_at`) VALUES
(1, '12345678', 5000, '2020-04-02 00:00:00', '2020-04-02 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `tbuser`
--

CREATE TABLE `tbuser` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `nama` varchar(255) NOT NULL,
  `role` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbuser`
--

INSERT INTO `tbuser` (`id`, `username`, `password`, `nama`, `role`) VALUES
(1, 'admin', '1234', 'adminkece', 'admin'),
(2, 'operator', '1234', 'operator', 'operator'),
(3, 'test', '222', 'tesss', 'operator'),
(5, 'admin', '1234', 'administrator', 'admin');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `anggota`
--
ALTER TABLE `anggota`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `anggota_has_simpanan`
--
ALTER TABLE `anggota_has_simpanan`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_anggota_has_simpanan_simpanan1_idx` (`simpanan_id`),
  ADD KEY `fk_anggota_has_simpanan_anggota_idx` (`anggota_id`);

--
-- Indexes for table `angsuran`
--
ALTER TABLE `angsuran`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_angsuran_peminjaman1_idx` (`peminjaman_id`);

--
-- Indexes for table `peminjaman`
--
ALTER TABLE `peminjaman`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_peminjaman_anggota1_idx` (`anggota_id`);

--
-- Indexes for table `simpanan`
--
ALTER TABLE `simpanan`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbuser`
--
ALTER TABLE `tbuser`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `anggota`
--
ALTER TABLE `anggota`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `anggota_has_simpanan`
--
ALTER TABLE `anggota_has_simpanan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `angsuran`
--
ALTER TABLE `angsuran`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `peminjaman`
--
ALTER TABLE `peminjaman`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `simpanan`
--
ALTER TABLE `simpanan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tbuser`
--
ALTER TABLE `tbuser`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `anggota_has_simpanan`
--
ALTER TABLE `anggota_has_simpanan`
  ADD CONSTRAINT `fk_anggota_has_peminjaman_anggota` FOREIGN KEY (`anggota_id`) REFERENCES `anggota` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_anggota_has_peminjaman_peminjaman1` FOREIGN KEY (`simpanan_id`) REFERENCES `simpanan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `angsuran`
--
ALTER TABLE `angsuran`
  ADD CONSTRAINT `fk_angsuran_peminjaman1` FOREIGN KEY (`peminjaman_id`) REFERENCES `peminjaman` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `peminjaman`
--
ALTER TABLE `peminjaman`
  ADD CONSTRAINT `fk_peminjaman_anggota1` FOREIGN KEY (`anggota_id`) REFERENCES `anggota` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
