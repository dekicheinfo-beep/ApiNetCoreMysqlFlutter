-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  sam. 22 nov. 2025 à 17:29
-- Version du serveur :  5.7.21
-- Version de PHP :  5.6.35

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `db_atelier`
--

-- --------------------------------------------------------

--
-- Structure de la table `agence`
--

DROP TABLE IF EXISTS `agence`;
CREATE TABLE IF NOT EXISTS `agence` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) CHARACTER SET utf8 NOT NULL,
  `logo` varchar(200) CHARACTER SET utf8 NOT NULL,
  `adresse` varchar(200) CHARACTER SET utf8 NOT NULL,
  `email` varchar(100) CHARACTER SET utf8 NOT NULL,
  `telephone` varchar(100) CHARACTER SET utf8 NOT NULL,
  `horaire` varchar(100) CHARACTER SET utf8 NOT NULL,
  `proprietaire` varchar(255) CHARACTER SET utf8 NOT NULL,
  `banque` varchar(255) CHARACTER SET utf8 NOT NULL,
  `rib` varchar(255) CHARACTER SET utf8 NOT NULL,
  `presentation` text CHARACTER SET utf8 NOT NULL,
  `Rcommerce` varchar(100) CHARACTER SET utf8 NOT NULL,
  `Aimposition` varchar(100) CHARACTER SET utf8 NOT NULL,
  `Fimposition` varchar(100) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `agence`
--

INSERT INTO `agence` (`id`, `nom`, `logo`, `adresse`, `email`, `telephone`, `horaire`, `proprietaire`, `banque`, `rib`, `presentation`, `Rcommerce`, `Aimposition`, `Fimposition`) VALUES
(1, 'RENTAL CAR MK', 'exception log in.PNG', 'rouiba issat ider', 'kouidermsdr@gmail.com', '0770525240', '7/7 24/24', 'ZEMMACHE LYES', 'bna', '44444', '', '11111111111', '2222222222', '33333333333');

-- --------------------------------------------------------

--
-- Structure de la table `ent_client`
--

DROP TABLE IF EXISTS `ent_client`;
CREATE TABLE IF NOT EXISTS `ent_client` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(50) NOT NULL,
  `passe` varchar(100) NOT NULL,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `date_naiss` varchar(10) NOT NULL,
  `telephone` varchar(20) NOT NULL,
  `raison` varchar(50) NOT NULL,
  `adresse` varchar(100) NOT NULL,
  `type` varchar(50) NOT NULL,
  `rcommerce` varchar(50) NOT NULL,
  `nif` varchar(50) NOT NULL,
  `narticle` varchar(50) NOT NULL,
  `nature` varchar(50) NOT NULL,
  `nis` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_client`
--

INSERT INTO `ent_client` (`id`, `email`, `passe`, `nom`, `prenom`, `date_naiss`, `telephone`, `raison`, `adresse`, `type`, `rcommerce`, `nif`, `narticle`, `nature`, `nis`) VALUES
(1, '', '', 'tikalane', 'rachida', '1992-01-21', '055042564', '', '', 'Particulier', '', '', '', 'Normal', ''),
(2, '', '', 'fares ', 'ali', '1984-12-27', '0551240831', '', '', 'Particulier', '', '16122/2017/7087', '2017/12/20', 'Conventionner', ''),
(3, '', '', 'dekiche', 'iyad', '2021-09-20', '066666666', 'raison', 'reghaia', 'Particulier', 'rc', 'nif', 'nart', 'Normal', 'nis'),
(4, '', '', 'kellal', '', '', '0003', '', '', '', '', '', '', 'Normal', ''),
(5, '', '', 'habib', '', '', '078895421', '', '', '', '', '', '', 'Conventionner', ''),
(6, '', '', 'dekiche moumen', '', '', '045226873', '', '', '', '', '', '', 'Normal', ''),
(14, '', '', 'a', '', '', '0552223456', '', '', '', '', '', '', 'Normal', ''),
(15, '', '', 'YAKOUB', '', '', '00004-16', '', '', '', '', '', '', 'Normal', '');

-- --------------------------------------------------------

--
-- Structure de la table `ent_condition`
--

DROP TABLE IF EXISTS `ent_condition`;
CREATE TABLE IF NOT EXISTS `ent_condition` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cond` text CHARACTER SET utf8 NOT NULL,
  `type` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `ent_condition`
--

INSERT INTO `ent_condition` (`id`, `cond`, `type`) VALUES
(2, '1-1. Age requis : L\'Age minimum pour les locataires et les conducteurs est de 25 ans.', 'Français'),
(3, '1-2. La durée de validité du permis de course : La personne qui conduit le véhicule doit être titulaire d\'un permis de conduire en cours de validité délivré depuis deux ans.', 'Français'),
(4, '1-3. Le conducteur licencié : Le véhicule loué est conduit uniquement par la ou les personnes qui en ont la charge et qui sont licenciées par le loueur, et le signataire du contrat reste seul responsable vis-à-vis du loueur.', 'Français'),
(5, '1-4. Dépôt du montant de la garantie garantie : Un montant de garantie est déposé lors de la signature du contrat de location, et il est restitué à la fin du contrat, sauf en cas d\'accident du véhicule.', 'Français'),
(6, '1-5. En cas d\'accident : En cas d\'accident du véhicule, en plus de ne pas récupérer le montant de la garantie, le locataire est tenu de payer 40% du prix du véhicule.', 'Français'),
(7, '1-6. Paiement du montant de la location : le montant de la location du véhicule est payé d\'avance.', 'Français'),
(9, 'Etat du véhicule : Le véhicule est présenté au locataire en bon état de fonctionnement. Dans un premier temps, les deux parties signent un document descriptif établi pour l\'état du véhicule. Le locataire doit restituer le véhicule dans le même état qu\'il l\'a pris, et dans le cas contraire, le locataire est tenu de régler les charges et frais de remise en état et de le remettre dans son état. .', 'Français'),
(10, 'Utilisation du véhicule : Le locataire est tenu de :\r\nUtilisation du véhicule en famille et Dhab.\r\nLe véhicule ne doit pas être utilisé par d\'autres personnes que celles autorisées par l\'agence de location.\r\nIl ne participe pas à des rallyes ou à des compétitions, ou quelque chose comme ça.\r\nNe pas utiliser le véhicule à des fins illégales.\r\nIl ne doit pas être chargé par des personnes ou d\'autres charges utiles utilitaires.\r\nIl ne se connecte pas à une remorque ou à un véhicule similaire.\r\nLe véhicule est utilisé uniquement sur le territoire national.\r\nLe véhicule est loué pour une distance ne dépassant pas 400 kilomètres par jour, et le locataire paie également 20 dinars par kilomètre pour une personne au-delà de la limite autorisée.\r\n', 'Français'),
(11, 'Restitution du véhicule : le locataire doit restituer le véhicule au jour et lieu précisés dans le contrat, et restituer le véhicule dans l\'heure d\'ouverture de l\'agence, et tout retard qui en est la cause fait l\'objet d\'une majoration basée sur 50% du prix applicable, et en cas de non restitution du véhicule dans les délais impartis, Le loueur se réserve le droit de prendre les mesures nécessaires à la préservation de ses intérêts.', 'Français'),
(12, 'Restitution du véhicule : le locataire doit restituer le véhicule au jour et lieu précisés dans le contrat, et restituer le véhicule dans l\'heure d\'ouverture de l\'agence, et tout retard qui en est la cause fait l\'objet d\'une majoration basée sur 50% du prix applicable, et en cas de non restitution du véhicule dans les délais impartis, Le loueur se réserve le droit de prendre les mesures nécessaires à la préservation de ses intérêts.', 'Français'),
(13, 'Prolongation de la période de location : La prolongation du contrat de location ne peut se faire qu\'avec l\'accord du propriétaire, et une demande doit être soumise dans les 4 heures avant la fin du contrat de location avec le paiement des dépenses pour la période requise.', 'Français'),
(14, 'Carburant / Fioul : Le véhicule est livré avec son carburant et doit restituer la même quantité de carburant.A chaque infraction à cette règle, le locataire fait l\'objet d\'une facture selon les tarifs de l\'agence de location, et le locataire doit toujours consulter le le niveau d\'huile ainsi que l\'eau.', 'Français'),
(15, 'Entretien et réparation : Toute panne mécanique normale est à la charge du loueur.Toute réparation mécanique est causée par un dommage anormal, ou une négligence émanant du locataire.Elle est à la charge de ce dernier, et en cas d\'immobilisation du véhicule. , sa remise en état ne pourra être effectuée qu\'avec un accord écrit selon les ordres de l\'agence de location, et en aucun cas le locataire ne pourra prétendre à une indemnité pour retard de livraison du véhicule, résiliation du contrat de location ou inversion de trajet en cas de les réparations effectuées pendant la durée de validité du contrat de location.', 'Français'),
(16, 'Assurances :\r\n8-1. Qualité d\'assurance : Nos véhicules sont assurés avec des contrats d\'assurance tous risques en Algérie uniquement.\r\n8-2. Bénéficiaires : Seuls les conducteurs licenciés par l\'agence de location ont le droit de bénéficier du statut d\'assuré.\r\n8-3. Déclaration : Sous peine de nullité du contrat d\'assurance, le locataire est tenu de déclarer dans les 24 heures à l\'agence et aux autorités de sécurité pour chaque vol ou incendie même partiel.\r\n8-4. Exceptions : L\'agence de location n\'est pas responsable de tous les accidents causant des pertes à autrui pour leurs véhicules que le locataire peut causer pendant la période de location du véhicule si ce dernier fournit délibérément à l\'agence des informations erronées, et en cas de vol, un des suites judiciaires sont levées, en cas d\'événement ayant entraîné des pertes dans le véhicule ou une suspension, les frais de réparations et de suspension sont à la charge du locataire, et l\'agence de location dans les deux cas se réserve le droit de résilier le contrat de bail sans restituer le montant du loyer ou une indemnité.\r\n', 'Français'),
(17, 'Responsabilité:\r\n9-1. Vis-à-vis du locataire : le locataire reste seul responsable du paiement des amendes, contraventions, et procès-verbaux dressés à son encontre.\r\n9-2. Pour le loueur : La responsabilité du loueur ne peut être en dehors des garanties accordées par l\'assurance « tous risques ».\r\n', 'Français'),
(18, 'Conditions d\'attribution de juridiction : Tout litige né du présent contrat n\'ayant pas abouti à un règlement amiable, dans les limites permises par la loi, il est possible de saisir le tribunal compétent du lieu du siège social du bailleur.', 'Français');

-- --------------------------------------------------------

--
-- Structure de la table `ent_facture`
--

DROP TABLE IF EXISTS `ent_facture`;
CREATE TABLE IF NOT EXISTS `ent_facture` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `num` varchar(10) NOT NULL,
  `date` varchar(10) NOT NULL,
  `etat` varchar(20) NOT NULL,
  `total` varchar(20) NOT NULL,
  `versement` varchar(20) NOT NULL,
  `reste` varchar(20) NOT NULL,
  `id_client` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_facture`
--

INSERT INTO `ent_facture` (`id`, `num`, `date`, `etat`, `total`, `versement`, `reste`, `id_client`) VALUES
(1, '000001', '2024-05-06', 'En cours', '36500', '36500', '0', 3);

-- --------------------------------------------------------

--
-- Structure de la table `ent_ligne_proforma`
--

DROP TABLE IF EXISTS `ent_ligne_proforma`;
CREATE TABLE IF NOT EXISTS `ent_ligne_proforma` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_proforma` int(11) NOT NULL,
  `type` varchar(50) NOT NULL,
  `designation` varchar(255) NOT NULL,
  `qtt` varchar(20) NOT NULL,
  `unite` varchar(10) NOT NULL,
  `pu` varchar(10) NOT NULL,
  `total` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_ligne_proforma`
--

INSERT INTO `ent_ligne_proforma` (`id`, `id_proforma`, `type`, `designation`, `qtt`, `unite`, `pu`, `total`) VALUES
(1, 1, 'Reparation', 'kkkkkk', '4', 'U', '1200', '4800'),
(2, 1, 'fabrication', 'eeeeeeeeeeee', '7', 'U', '400', '2800'),
(3, 1, 'tournage', 'rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr', '1', 'U', '2500', '2500'),
(4, 1, 'fabrication', 'hhhhhhhhhhh', '3', 'U', '900', '2700');

-- --------------------------------------------------------

--
-- Structure de la table `ent_ligne_travail`
--

DROP TABLE IF EXISTS `ent_ligne_travail`;
CREATE TABLE IF NOT EXISTS `ent_ligne_travail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_travail` int(11) NOT NULL,
  `type` varchar(50) NOT NULL,
  `designation` varchar(255) NOT NULL,
  `qtt` varchar(20) NOT NULL,
  `unite` varchar(10) NOT NULL,
  `pu` varchar(10) NOT NULL,
  `total` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_ligne_travail`
--

INSERT INTO `ent_ligne_travail` (`id`, `id_travail`, `type`, `designation`, `qtt`, `unite`, `pu`, `total`) VALUES
(1, 1, 'Reparation', 'reparation mmmmmmmm', '1', 'U', '6000', '6000'),
(2, 2, 'fabrication', '', '1', '', '5000', ''),
(3, 3, 'Reparation', '', '1', '', '5000', '5000'),
(4, 4, 'Reparation', 'ddddddd', '1', '', '5000', '5000'),
(5, 5, 'Reparation', 'rrrrr', '1', '', '5000', '5000'),
(6, 5, 'Reparation', 'rrrrr', '1', '', '5000', '5000'),
(7, 6, 'Reparation', 'jjjjjjjjjjjj', '1', '', '5000', '5000'),
(8, 6, 'fabrication', 'ooooooooo', '1', '', '6000', '6000'),
(9, 6, 'tournage', 'AAAAAAAA', '1', '', '8000', '8000'),
(11, 1, 'fabrication', 'fabrication gggggggg', '1', 'U', '8000', '8000'),
(12, 1, 'tournage', 'tournage yyyyy', '1', 'U', '5000', '5000'),
(13, 7, 'Reparation', 'kkkkkk', '2', '', '1500', '3000'),
(18, 1, 'fabrication', 'fabrication rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr', '5', 'U', '3500', '17500'),
(19, 8, 'Reparation', 'kkkkkk', '4', 'U', '1200', '4800'),
(20, 8, 'fabrication', 'eeeeeeeeeeee', '7', 'U', '400', '2800'),
(21, 8, 'tournage', 'rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr', '1', 'U', '2500', '2500'),
(22, 8, 'fabrication', 'hhhhhhhhhhh', '3', 'U', '900', '2700'),
(23, 8, 'Reparation', 'kkkkkk', '4', 'U', '1200', '4800'),
(24, 8, 'fabrication', 'eeeeeeeeeeee', '7', 'U', '400', '2800'),
(25, 8, 'tournage', 'rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr', '1', 'U', '2500', '2500'),
(26, 8, 'fabrication', 'hhhhhhhhhhh', '3', 'U', '900', '2700'),
(27, 9, 'Reparation', 'kkkkkk', '4', 'U', '1200', '4800'),
(28, 9, 'fabrication', 'eeeeeeeeeeee', '7', 'U', '400', '2800'),
(29, 9, 'tournage', 'rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr', '1', 'U', '2500', '2500'),
(30, 9, 'fabrication', 'hhhhhhhhhhh', '3', 'U', '900', '2700'),
(31, 11, '', 'reparation hhhhh', '1', 'U', '2000', '2000'),
(33, 12, '', 'TVC', '20', 'U', '500', '10000'),
(34, 12, '', '040', '50', 'U', '1000', '50000');

-- --------------------------------------------------------

--
-- Structure de la table `ent_location`
--

DROP TABLE IF EXISTS `ent_location`;
CREATE TABLE IF NOT EXISTS `ent_location` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `num` varchar(20) NOT NULL,
  `etat` varchar(20) NOT NULL,
  `date_deb` varchar(10) NOT NULL,
  `date_fin` varchar(10) NOT NULL,
  `client` int(11) NOT NULL,
  `conducteur` int(11) NOT NULL,
  `vehicule` int(11) NOT NULL,
  `prixu` varchar(20) NOT NULL,
  `montant` varchar(20) NOT NULL,
  `montant_verse` varchar(20) NOT NULL,
  `montant_reste` varchar(20) NOT NULL,
  `mode_paiement` varchar(20) NOT NULL,
  `km_jour` varchar(20) NOT NULL,
  `km_depart` varchar(20) NOT NULL,
  `km_retour` varchar(20) NOT NULL,
  `cautionnement` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_location`
--

INSERT INTO `ent_location` (`id`, `num`, `etat`, `date_deb`, `date_fin`, `client`, `conducteur`, `vehicule`, `prixu`, `montant`, `montant_verse`, `montant_reste`, `mode_paiement`, `km_jour`, `km_depart`, `km_retour`, `cautionnement`) VALUES
(1, '000001', 'En cours', '2024-05-13', '2024-05-20', 1, 0, 1, '8000', '56000', '56000', '', 'Espece', '350', '5000', '7450', '50000'),
(2, '000002', 'En cours', '2024-04-24', '2024-04-25', 2, 0, 7, '10000', '10000', '10000', '', 'Espece', '300', '0', '300', '');

-- --------------------------------------------------------

--
-- Structure de la table `ent_marque`
--

DROP TABLE IF EXISTS `ent_marque`;
CREATE TABLE IF NOT EXISTS `ent_marque` (
  `id_marque` int(9) NOT NULL AUTO_INCREMENT,
  `marque` varchar(50) NOT NULL,
  PRIMARY KEY (`id_marque`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_marque`
--

INSERT INTO `ent_marque` (`id_marque`, `marque`) VALUES
(1, 'Dacia'),
(2, 'Peugeot'),
(3, 'Renault'),
(4, 'Fiat'),
(5, 'Seat'),
(6, 'Hyundai'),
(7, 'SKODA'),
(8, 'Volkswagen'),
(9, 'Kia');

-- --------------------------------------------------------

--
-- Structure de la table `ent_modele`
--

DROP TABLE IF EXISTS `ent_modele`;
CREATE TABLE IF NOT EXISTS `ent_modele` (
  `id_modele` int(11) NOT NULL AUTO_INCREMENT,
  `id_marque` int(11) NOT NULL,
  `modele` varchar(50) NOT NULL,
  PRIMARY KEY (`id_modele`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_modele`
--

INSERT INTO `ent_modele` (`id_modele`, `id_marque`, `modele`) VALUES
(17, 8, 'Golf 8'),
(5, 2, '308'),
(16, 7, 'Octavai'),
(7, 5, 'Ibiza'),
(15, 6, 'CRETA'),
(9, 2, '206'),
(18, 9, 'Rio'),
(11, 3, 'Symbole'),
(12, 5, 'Ibiza fr+'),
(14, 4, 'Tipo');

-- --------------------------------------------------------

--
-- Structure de la table `ent_proforma`
--

DROP TABLE IF EXISTS `ent_proforma`;
CREATE TABLE IF NOT EXISTS `ent_proforma` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `num` varchar(10) NOT NULL,
  `date` varchar(10) NOT NULL,
  `total` varchar(20) NOT NULL,
  `versement` varchar(20) NOT NULL,
  `reste` varchar(20) NOT NULL,
  `etat` varchar(20) NOT NULL,
  `id_client` int(11) NOT NULL,
  `id_travail` int(11) NOT NULL,
  `validite` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_proforma`
--

INSERT INTO `ent_proforma` (`id`, `num`, `date`, `total`, `versement`, `reste`, `etat`, `id_client`, `id_travail`, `validite`) VALUES
(1, '000001', '2024-05-08', '12800', '0', '0', 'Valide', 6, 0, '2 mois');

-- --------------------------------------------------------

--
-- Structure de la table `ent_reservation`
--

DROP TABLE IF EXISTS `ent_reservation`;
CREATE TABLE IF NOT EXISTS `ent_reservation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date_depart` varchar(10) NOT NULL,
  `date_retour` varchar(10) NOT NULL,
  `nb_jour` varchar(10) NOT NULL,
  `type_paiement` varchar(50) NOT NULL,
  `somme` varchar(20) NOT NULL,
  `id_client` int(11) NOT NULL,
  `id_vehicule` int(11) NOT NULL,
  `nom_vehicule` varchar(100) NOT NULL,
  `valider` varchar(10) NOT NULL,
  `nom_client` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `ent_travail`
--

DROP TABLE IF EXISTS `ent_travail`;
CREATE TABLE IF NOT EXISTS `ent_travail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `num` varchar(10) NOT NULL,
  `date` varchar(10) NOT NULL,
  `total` varchar(20) NOT NULL,
  `versement` varchar(20) NOT NULL,
  `reste` varchar(20) NOT NULL,
  `etat` varchar(20) NOT NULL,
  `id_client` int(11) NOT NULL,
  `id_facture` int(11) NOT NULL,
  `id_proforma` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_travail`
--

INSERT INTO `ent_travail` (`id`, `num`, `date`, `total`, `versement`, `reste`, `etat`, `id_client`, `id_facture`, `id_proforma`) VALUES
(1, '000001', '2024-05-01', '36500', '30000', '6500', 'En cours', 3, 1, 0),
(2, '000002', '2024-05-01', '', '', '', 'En cours', 4, 0, 0),
(3, '000003', '2024-05-01', '5000', '', '', 'En cours', 4, 0, 0),
(4, '000004', '2024-05-01', '5000', '', '', 'En cours', 2, 0, 0),
(5, '000005', '2024-05-01', '10000', '', '', 'En cours', 1, 0, 0),
(6, '000006', '2024-05-01', '19000', '', '', 'En cours', 1, 0, 0),
(7, '000007', '2024-05-02', '3000', '', '', 'En cours', 5, 0, 0),
(8, '000009', '2024-05-07', '25600', '0', '0', 'En cours', 3, 0, 0),
(9, '000010', '2024-05-08', '12800', '0', '0', 'Valide', 6, 0, 1),
(10, '000011', '2024-05-10', '0', '0', '0', 'En cours', 3, 0, 0),
(11, '000012', '2024-05-11', '2000', '1000', '1000', 'En cours', 14, 0, 0),
(12, '000013', '2025-05-01', '60000', '0', '0', 'En cours', 15, 0, 0);

-- --------------------------------------------------------

--
-- Structure de la table `ent_user`
--

DROP TABLE IF EXISTS `ent_user`;
CREATE TABLE IF NOT EXISTS `ent_user` (
  `user` varchar(200) NOT NULL,
  `password` varchar(200) NOT NULL,
  `profile` varchar(100) NOT NULL,
  `etat` varchar(100) NOT NULL,
  PRIMARY KEY (`user`),
  UNIQUE KEY `user` (`user`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `ent_user`
--

INSERT INTO `ent_user` (`user`, `password`, `profile`, `etat`) VALUES
('admin', '2010', 'Administrateur', 'marche'),
('habib', '2021', 'Utilisateur', 'marche');

-- --------------------------------------------------------

--
-- Structure de la table `ent_user2`
--

DROP TABLE IF EXISTS `ent_user2`;
CREATE TABLE IF NOT EXISTS `ent_user2` (
  `User` varchar(50) NOT NULL,
  `Nom` varchar(50) NOT NULL,
  `Prenom` varchar(50) NOT NULL,
  `Passe` varchar(50) NOT NULL,
  `Role` varchar(50) NOT NULL,
  PRIMARY KEY (`User`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_user2`
--

INSERT INTO `ent_user2` (`User`, `Nom`, `Prenom`, `Passe`, `Role`) VALUES
('admin', 'dekiche', 'amine', '2010', 'admin');

-- --------------------------------------------------------

--
-- Structure de la table `ent_vehicule`
--

DROP TABLE IF EXISTS `ent_vehicule`;
CREATE TABLE IF NOT EXISTS `ent_vehicule` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Modele` int(11) NOT NULL,
  `Marque` int(11) DEFAULT NULL,
  `Apercu` longtext CHARACTER SET latin1,
  `PrixParJour` int(11) DEFAULT NULL,
  `Energie` varchar(100) CHARACTER SET latin1 DEFAULT NULL,
  `ModelAnnee` varchar(10) DEFAULT NULL,
  `NombrePlace` varchar(10) DEFAULT NULL,
  `Matricule` varchar(100) NOT NULL,
  `Chassis` varchar(100) NOT NULL,
  `Couleur` varchar(100) NOT NULL,
  `Kilometrage` int(11) NOT NULL,
  `Etat` varchar(255) NOT NULL,
  `Transmission` varchar(100) NOT NULL,
  `DEB_ASSURANCE` varchar(10) DEFAULT NULL,
  `FIN_ASSURANCE` varchar(10) DEFAULT NULL,
  `AGENCE_ASSURANCE` varchar(100) NOT NULL,
  `DEB_CONTROL` varchar(10) DEFAULT NULL,
  `FIN_CONTROL` varchar(10) DEFAULT NULL,
  `AGENCE_CONTROL` varchar(100) NOT NULL,
  `DATE_VIDANGE` varchar(10) DEFAULT NULL,
  `KM_VIDANGE` int(11) NOT NULL,
  `KM_RETOUR_VIDANGE` int(11) NOT NULL,
  `Vimage1` varchar(120) CHARACTER SET latin1 DEFAULT NULL,
  `Vimage2` varchar(120) CHARACTER SET latin1 DEFAULT NULL,
  `Vimage3` varchar(120) CHARACTER SET latin1 DEFAULT NULL,
  `Vimage4` varchar(120) CHARACTER SET latin1 DEFAULT NULL,
  `Vimage5` varchar(120) CHARACTER SET latin1 DEFAULT NULL,
  `Climatiseur` tinyint(1) DEFAULT NULL,
  `TriangeSignalisation` tinyint(1) DEFAULT NULL,
  `ABS` tinyint(1) DEFAULT NULL,
  `SiegeAuto` tinyint(1) DEFAULT NULL,
  `DirectionAssiste` tinyint(1) DEFAULT NULL,
  `AirbagConducteur` tinyint(1) DEFAULT NULL,
  `AirbagPassager` tinyint(1) DEFAULT NULL,
  `VitresElectriques` tinyint(1) DEFAULT NULL,
  `LecteurCd` tinyint(1) DEFAULT NULL,
  `VerouillageCentralise` tinyint(1) DEFAULT NULL,
  `CapteurCollision` tinyint(1) DEFAULT NULL,
  `SiegesEnCuir` tinyint(1) DEFAULT NULL,
  `RoueSecours` tinyint(1) NOT NULL,
  `CableRemorquage` tinyint(1) NOT NULL,
  `AntiVol` tinyint(1) NOT NULL,
  `Alarme` tinyint(1) NOT NULL,
  `CricManivelle` tinyint(1) NOT NULL,
  `CameraRecul` tinyint(1) NOT NULL,
  `BoitePharmacie` tinyint(1) NOT NULL,
  `BoiteSendrie` tinyint(1) NOT NULL,
  `FeuAntiBrouillard` tinyint(1) NOT NULL,
  `EcranTactile` tinyint(1) NOT NULL,
  `JantesAlliages` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_vehicule`
--

INSERT INTO `ent_vehicule` (`id`, `Modele`, `Marque`, `Apercu`, `PrixParJour`, `Energie`, `ModelAnnee`, `NombrePlace`, `Matricule`, `Chassis`, `Couleur`, `Kilometrage`, `Etat`, `Transmission`, `DEB_ASSURANCE`, `FIN_ASSURANCE`, `AGENCE_ASSURANCE`, `DEB_CONTROL`, `FIN_CONTROL`, `AGENCE_CONTROL`, `DATE_VIDANGE`, `KM_VIDANGE`, `KM_RETOUR_VIDANGE`, `Vimage1`, `Vimage2`, `Vimage3`, `Vimage4`, `Vimage5`, `Climatiseur`, `TriangeSignalisation`, `ABS`, `SiegeAuto`, `DirectionAssiste`, `AirbagConducteur`, `AirbagPassager`, `VitresElectriques`, `LecteurCd`, `VerouillageCentralise`, `CapteurCollision`, `SiegesEnCuir`, `RoueSecours`, `CableRemorquage`, `AntiVol`, `Alarme`, `CricManivelle`, `CameraRecul`, `BoitePharmacie`, `BoiteSendrie`, `FeuAntiBrouillard`, `EcranTactile`, `JantesAlliages`) VALUES
(1, 7, 5, '', 8000, 'Essence', '2019', '5', '033462-119-16', '', '', 5000, 'indisponible', 'Manuel', '', '', '', '', '', '', '', 0, 0, 'marutisuzuki-vitara-brezza-right-front-three-quarter3.jpg', 'marutisuzuki-vitara-brezza-rear-view37.jpg', 'marutisuzuki-vitara-brezza-dashboard10.jpg', 'marutisuzuki-vitara-brezza-boot-space28.jpg', 'marutisuzuki-vitara-brezza-boot-space59.jpg', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
(2, 15, 6, '', 10000, 'Essence', '2019', '5', '109606.119.16', '8888888888888', 'noir', 157000, 'libre', 'Automatique', '', '', '', '', '', '', '', 0, 0, 'zw-toyota-fortuner-2020-2.jpg', '', '', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(3, 16, 7, '', 5000, 'Essence', '2020', '5', '333333-20-16', '', '', 5000, 'libre', 'Automatique', '', '', '', '', '', '', '', 0, 0, 'Nissan-GTR-Right-Front-Three-Quarter-84895.jpg', '', '', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(4, 11, 3, '', 5000, 'Essence', '2020', '5', '22222-121-16', '11111111111', 'rouge', 100000, 'libre', 'Manuel', '', '19/12/2022', '', '', '14/10/2022', '', '', 0, 0, '', '', '', '', '', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
(6, 14, 4, '', 0, 'Essence', '', '', '151510-119-16', '', '', 0, 'libre', 'Manuel', '', '', '', '', '', '', '', 0, 0, '', '', '', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(7, 17, 8, '', 0, 'Essence', '', '', '151510-119-16', '', '', 0, 'indisponible', 'Manuel', '', '', '', '', '', '', '', 0, 0, '', '', '', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Structure de la table `ent_vehicule2`
--

DROP TABLE IF EXISTS `ent_vehicule2`;
CREATE TABLE IF NOT EXISTS `ent_vehicule2` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `ent_vehicule_image`
--

DROP TABLE IF EXISTS `ent_vehicule_image`;
CREATE TABLE IF NOT EXISTS `ent_vehicule_image` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_vehicule` int(11) NOT NULL,
  `image` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `ent_vehicule_image`
--

INSERT INTO `ent_vehicule_image` (`id`, `id_vehicule`, `image`) VALUES
(1, 1, 'ibiza1.jpg'),
(2, 1, 'ibiza2.jpg'),
(3, 1, 'ibiza3.jpg'),
(4, 2, 'creta3.jpg'),
(5, 2, 'creta2.jpg'),
(6, 2, 'creta1.jpg'),
(7, 3, 'octavai 1.jpg'),
(8, 3, 'octavia 2.jpg');

-- --------------------------------------------------------

--
-- Structure de la table `products`
--

DROP TABLE IF EXISTS `products`;
CREATE TABLE IF NOT EXISTS `products` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Price` double NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `products`
--

INSERT INTO `products` (`Id`, `Name`, `Price`) VALUES
(1, 'mmmm', 120),
(2, 'POP2', 133),
(3, 'mmmm', 120);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
