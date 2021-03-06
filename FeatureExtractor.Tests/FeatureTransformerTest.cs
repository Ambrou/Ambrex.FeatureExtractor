﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FeatureExtractor.Tests
{
    [TestClass]
    public class FeatureTransformerTest
    {
        [TestMethod]
        public void TestFeatureTransformer()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "Étant donné un interpréteur de script éàèùëïäöêô’";
            Scenario scenario = new Scenario(" éàèùëïäöêô’", "Étant donné  éàèùëïäöêô’");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un interpreteur de script eaeueiaoeo'", requirement.m_strContext);
            Assert.AreEqual("Soit eaeueiaoeo'", requirement.m_Scenarios[0].m_strSteps);
            Assert.AreEqual(" éàèùëïäöêô’", requirement.m_Scenarios[0].m_strTitle);
        }

        [TestMethod]
        public void TestFeatureTransformerIssue1()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("Vérification du RTC Port pour un RTC NO", "Etant donné le champ Active RTC defini a NO Lorsque je verifie la configuration RTC Alors TeTriS ne verifie pas le champ RTC Port");
            requirement.m_Scenarios.Add(scenario);
            scenario = new Scenario("Vérification du RTC Port pour un RTC soft ou hard", "Etant donné le champ Active RTC defini a un type de RTC hard ou soft Et le champ RTC Port <etat> Lorsque je verifie la configuration RTC Alors j’ai la boite de dialogue d’erreur IDS_ERR_RTC_PORT_CONFIG Et TeTriS ne se lance pas Exemple: | etat | | inexistant | | vide |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("", requirement.m_strContext);
            Assert.AreEqual("Soit le champ Active RTC defini a NO\nLorsque je verifie la configuration RTC\nAlors TeTriS ne verifie pas le champ RTC Port", requirement.m_Scenarios[0].m_strSteps);
            Assert.AreEqual("Vérification du RTC Port pour un RTC NO", requirement.m_Scenarios[0].m_strTitle);

            Assert.AreEqual("Soit le champ Active RTC defini a un type de RTC hard ou soft\nEt le champ RTC Port <etat>\nLorsque je verifie la configuration RTC\nAlors j'ai la boite de dialogue d'erreur IDS_ERR_RTC_PORT_CONFIG\nEt TeTriS ne se lance pas\nExemples:\n| etat       |\n| inexistant |\n| vide       |", requirement.m_Scenarios[1].m_strSteps);
            Assert.AreEqual("Vérification du RTC Port pour un RTC soft ou hard", requirement.m_Scenarios[1].m_strTitle);
        }

        [TestMethod]
        public void TestFeatureTransformerIssue4()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("Vérification de la configuration de la carte réseau", "Etant donné les données Ethernet correctement définies dans la configuration TeTriS Exemples : | statut | droits | etat | resultat | | differente | administrateur | modifiee | OK (modified) | | differente | non administrateur | non modifiee | error | | identique | administrateur | non modifiee | OK (not modified) | | identique | non administrateur | non modifiee | OK (not modified) |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["ESD-TXL-TeTriS-008"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("", requirement.m_strContext);
            Assert.AreEqual("Soit les donnees Ethernet correctement definies dans la configuration TeTriS\nExemples:\n| statut     | droits             | etat         | resultat          |\n| differente | administrateur     | modifiee     | OK (modified)     |\n| differente | non administrateur | non modifiee | error             |\n| identique  | administrateur     | non modifiee | OK (not modified) |\n| identique  | non administrateur | non modifiee | OK (not modified) |", requirement.m_Scenarios[0].m_strSteps);
            Assert.AreEqual("Vérification de la configuration de la carte réseau", requirement.m_Scenarios[0].m_strTitle);          
        }

        [TestMethod]
        public void TestFeatureTransformerIssue5()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("Vérification de la configuration de la carte réseau", "Soit un detecteur de generation 3 Et la configuration detecteur la commande : | en-tete | valeur | titre | val_arg | format | | II | 0x24 | Info Temperature | 0x600 | Temperature 0xs2 Range 0xu1 | Lorsque j'appelle le mot clef pxSend 0x24 0x600 Alors j'ai la reponse TCL vide Et le script retourne TCL_OK Exemples: |etat |wait | |definissant |false | |ne definissant pas |true |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["ESD-TXL-TeTriS-008"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("", requirement.m_strContext);
            Assert.AreEqual("Soit un detecteur de generation 3\nEt la configuration detecteur la commande :\n| en-tete | valeur | titre            | val_arg | format                      |\n| II      | 0x24   | Info Temperature | 0x600   | Temperature 0xs2 Range 0xu1 |\nLorsque j'appelle le mot clef pxSend 0x24 0x600\nAlors j'ai la reponse TCL vide\nEt le script retourne TCL_OK\nExemples:\n| etat               | wait  |\n| definissant        | false |\n| ne definissant pas | true  |", requirement.m_Scenarios[0].m_strSteps);
            Assert.AreEqual("Vérification de la configuration de la carte réseau", requirement.m_Scenarios[0].m_strTitle);
        }

        [TestMethod]
        public void TestFeatureTransformerWithOutSpaceBetweenPipeInTable()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "Étant donné un interpréteur de script éàèùëïäöêô’";
            Scenario scenario = new Scenario(" éàèùëïäöêô’", "Soit un detecteur de type type Lorsque j'appelle le mot clef pxSetEnergyParameters autoswitch rechargetrigger lowleveltriggerwakeup lowleveltriggerstartimage securitytemperature dateofexchangeweek dateofexchangeyear launchcalibration Alors j'ai la trace d'erreur numero IDS_TCL_ERR_PX_SET_ENERGY_PARAMETERS_WRONG_ARG. Et le script retourne TCL_KO Exemple: | type | autoswitch| rechargetrigger| lowleveltriggerwakeup| lowleveltriggerstartimage| securitytemperature| dateofexchangeweek| dateofexchangeyear| launchcalibration| | 4600 | G | 2 | 3 | 4 | 5 | 6 | 7 | 8 | | 4700 | 1 | 2G | 3 | 4 | 5 | 6 | 7 | 8 | | 4800 | 1 | 2 | 3G | 4 | 5 | 6 | 7 | 8 | | generation 3| 1 | 2 | 3 | 4G | 5 | 6 | 7 | 8 | | generation 2| 1 | 2 | 3 | 4 | 5G | 6 | 7 | 8 | | 4800 | 1 | 2 | 3 | 4 | 5 | 6G | 7 | 8 | | generation 3| 1 | 2 | 3 | 4 | 5 | 6 | 7G | 8 | | generation 2| 1|2| 3 | 4 | 5 | 6 | 7 | G |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un interpreteur de script eaeueiaoeo'", requirement.m_strContext);
            Assert.AreEqual("Soit un detecteur de type type\nLorsque j'appelle le mot clef pxSetEnergyParameters autoswitch rechargetrigger lowleveltriggerwakeup lowleveltriggerstartimage securitytemperature dateofexchangeweek dateofexchangeyear launchcalibration\nAlors j'ai la trace d'erreur numero IDS_TCL_ERR_PX_SET_ENERGY_PARAMETERS_WRONG_ARG\nEt le script retourne TCL_KO\nExemples:\n| type         | autoswitch | rechargetrigger | lowleveltriggerwakeup | lowleveltriggerstartimage | securitytemperature | dateofexchangeweek | dateofexchangeyear | launchcalibration |\n| 4600         | G          | 2               | 3                     | 4                         | 5                   | 6                  | 7                  | 8                 |\n| 4700         | 1          | 2G              | 3                     | 4                         | 5                   | 6                  | 7                  | 8                 |\n| 4800         | 1          | 2               | 3G                    | 4                         | 5                   | 6                  | 7                  | 8                 |\n| generation 3 | 1          | 2               | 3                     | 4G                        | 5                   | 6                  | 7                  | 8                 |\n| generation 2 | 1          | 2               | 3                     | 4                         | 5G                  | 6                  | 7                  | 8                 |\n| 4800         | 1          | 2               | 3                     | 4                         | 5                   | 6G                 | 7                  | 8                 |\n| generation 3 | 1          | 2               | 3                     | 4                         | 5                   | 6                  | 7G                 | 8                 |\n| generation 2 | 1          | 2               | 3                     | 4                         | 5                   | 6                  | 7                  | G                 |", requirement.m_Scenarios[0].m_strSteps);
            Assert.AreEqual(" éàèùëïäöêô’", requirement.m_Scenarios[0].m_strTitle);
            
        }

        [TestMethod]
        public void TestFeatureTransformerIssue7()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "Étant donné un interpréteur de script éàèùëïäöêô’";
            Scenario scenario = new Scenario(" éàèùëïäöêô’", "Etant donné la première ligne du fichier Fit1.fit ne contenant pas <ligne> Et le reste du fichier contenant | [Single/Serial Exposure] | | FX128= 1 1 1 70 100 60 100 | Et un générateur <type> Lorsque je charge ce fichier depuis l’IHM Alors j’ai la boîte de dialogue en erreur avec le message: IDS_ERR_LOAD_FIT_FILE_WRONG_HEADER Exemples: | ligne | type | | ; TeTriS LWDR file | Philips avec le protocole LWDR | | ; XSTREAM FIT file | NO | | ; XSTREAM FIT file | philips avec le protocole SDL |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un interpreteur de script eaeueiaoeo'", requirement.m_strContext);
            Assert.AreEqual("Soit la premiere ligne du fichier Fit1.fit ne contenant pas <ligne>\nEt le reste du fichier contenant\n| [Single/Serial Exposure]   |\n| FX128= 1 1 1 70 100 60 100 |\nEt un generateur <type>\nLorsque je charge ce fichier depuis l'IHM\nAlors j'ai la boite de dialogue en erreur avec le message: IDS_ERR_LOAD_FIT_FILE_WRONG_HEADER\nExemples:\n| ligne              | type                           |\n| ; TeTriS LWDR file | Philips avec le protocole LWDR |\n| ; XSTREAM FIT file | NO                             |\n| ; XSTREAM FIT file | philips avec le protocole SDL  |", requirement.m_Scenarios[0].m_strSteps);
            Assert.AreEqual(" éàèùëïäöêô’", requirement.m_Scenarios[0].m_strTitle);
        }

        [TestMethod]
        public void TestFeatureTransformerIssue8()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "Soit un interpreteur TCL Soit un interpreteur TCL";
            Scenario scenario = new Scenario(" éàèùëïäöêô’", "Etant donné la première ligne du fichier Fit1.fit ne contenant pas <ligne> Et le reste du fichier contenant | [Single/Serial Exposure] | | FX128= 1 1 1 70 100 60 100 | Et un générateur <type> Lorsque je charge ce fichier depuis l’IHM Alors j’ai la boîte de dialogue en erreur avec le message: IDS_ERR_LOAD_FIT_FILE_WRONG_HEADER Exemples: | ligne | type | | ; TeTriS LWDR file | Philips avec le protocole LWDR | | ; XSTREAM FIT file | NO | | ; XSTREAM FIT file | philips avec le protocole SDL |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un interpreteur TCL\nSoit un interpreteur TCL", requirement.m_strContext);
        }

        [TestMethod]
        public void TestFeatureTransformerIssue8_bis()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "Soit un interpreteur TCL Soit une IHM";
            Scenario scenario = new Scenario(" éàèùëïäöêô’", "Etant donné la première ligne du fichier Fit1.fit ne contenant pas <ligne> Et le reste du fichier contenant | [Single/Serial Exposure] | | FX128= 1 1 1 70 100 60 100 | Et un générateur <type> Lorsque je charge ce fichier depuis l’IHM Alors j’ai la boîte de dialogue en erreur avec le message: IDS_ERR_LOAD_FIT_FILE_WRONG_HEADER Exemples: | ligne | type | | ; TeTriS LWDR file | Philips avec le protocole LWDR | | ; XSTREAM FIT file | NO | | ; XSTREAM FIT file | philips avec le protocole SDL |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un interpreteur TCL\nSoit une IHM", requirement.m_strContext);
        }

        [TestMethod]
        public void TestFeatureTransformerIssue9()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "Soit un interpreteur TCL Soit un interpreteur TCL";
            Scenario scenario = new Scenario(" éàèùëïäöêô’", "Etant donné la configuration detecteur définissant les modes : | mode | | 1    | | 7    | | 4    | | 3    |     Quand j’affiche le menu <menu>     Alors les modes et leurs informations sont affiches dans l’ordre : | mode | | 1    | | 3    | | 4    | | 7    | Exemple: | menu                             | | Detector->Control->Select Mode   | | mode de la barre de mode         | | mode de la barre de mode etendue |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit la configuration detecteur definissant les modes :\n| mode |\n| 1    |\n| 7    |\n| 4    |\n| 3    |\nQuand j'affiche le menu <menu>\nAlors les modes et leurs informations sont affiches dans l'ordre :\n| mode |\n| 1    |\n| 3    |\n| 4    |\n| 7    |\nExemples:\n| menu                             |\n| Detector->Control->Select Mode   |\n| mode de la barre de mode         |\n| mode de la barre de mode etendue |", requirement.m_Scenarios[0].m_strSteps);
        }

        [TestMethod]
        public void TestFeatureTransformerWithTableWithEmptyCase()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Etant donné la configuration detecteur définissant les tables <table> Quand j'affiche le menu <menu> Alors les tables affichees sont dans l'ordre <ordre> Exemple: | table | menu | ordre | | 1 7 4 3 | Detector->Control->Select Table | 1 3 4 7 | | | Detector->Control->Select Table | | | 1 7 4 3 | table de la barre de mode | 1 3 4 7 | | | table de la barre de mode | | | 1 7 4 3 | table de la barre de mode etendue | 1 3 4 7 | | | table de la barre de mode etendue | |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit la configuration detecteur definissant les tables <table>\nQuand j'affiche le menu <menu>\nAlors les tables affichees sont dans l'ordre <ordre>\nExemples:\n| table   | menu                              | ordre   |\n| 1 7 4 3 | Detector->Control->Select Table   | 1 3 4 7 |\n|         | Detector->Control->Select Table   |         |\n| 1 7 4 3 | table de la barre de mode         | 1 3 4 7 |\n|         | table de la barre de mode         |         |\n| 1 7 4 3 | table de la barre de mode etendue | 1 3 4 7 |\n|         | table de la barre de mode etendue |         |", requirement.m_Scenarios[0].m_strSteps);
        }

        [TestMethod]
        public void TestFeatureTransformerIssue10()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Etant donné un détecteur de type <type> Et l’etat de connexion du detecteur est <etat> Alors l’entrée Detector -> Setup -> DefectMap -> Erase est <etat_menu>. Exemple: | type | etat | etat_menu | | PX4600 | connecte | actif | | PX4700-6 | connecte | actif | | PX4700-2 | connecte | inactif | | PX4700 | connecte | inactif | | PX4800 | connecte | inactif | | gen3 | connecte | inactif | | PX3040 | connecte | inactif | | PX2020C | connecte | inactif | | PX2121C | connecte | inactif | | Portable2 | connecte | inactif | | PX2630 | connecte | actif | | PX5100 | connecte | actif | | PX5500 | connecte | actif | | PXFS36 | connecte | actif | | PX4143R | connecte | actif | | PX4343R | connecte | actif | | PX4343F-3 | connecte | actif | | materiel | deconnecte | inactif |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un detecteur de type <type>\nEt l'etat de connexion du detecteur est <etat>\nAlors l'entree Detector -> Setup -> DefectMap -> Erase est <etat_menu>\nExemples:\n| type      | etat       | etat_menu |\n| PX4600    | connecte   | actif     |\n| PX4700-6  | connecte   | actif     |\n| PX4700-2  | connecte   | inactif   |\n| PX4700    | connecte   | inactif   |\n| PX4800    | connecte   | inactif   |\n| gen3      | connecte   | inactif   |\n| PX3040    | connecte   | inactif   |\n| PX2020C   | connecte   | inactif   |\n| PX2121C   | connecte   | inactif   |\n| Portable2 | connecte   | inactif   |\n| PX2630    | connecte   | actif     |\n| PX5100    | connecte   | actif     |\n| PX5500    | connecte   | actif     |\n| PXFS36    | connecte   | actif     |\n| PX4143R   | connecte   | actif     |\n| PX4343R   | connecte   | actif     |\n| PX4343F-3 | connecte   | actif     |\n| materiel  | deconnecte | inactif   |", requirement.m_Scenarios[0].m_strSteps);
        }

        [TestMethod]
        public void TestFeatureTransformerIssue12()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Etant donné un détecteur de génération 3 Lorsque le détecteur envoie la trame <severite><code><contexte> Alors j’ai la trace standard d'information <trace> Exemple : | severite | code | contexte | trace | | 00 | 0001 | 4465746563746F7220726561647920746F20646F20616E20696D616765 | \"Event received : Detector ready to do an image (severity: no, code: 0x100 Detector ready to do an image again )\" | | 01 | 0900 | 4465746563746F7220726561647920746F20646F20616E20696D616765 | \"Event received : Detector ready to do an image (severity: critical, code: 0x009 POST failed. At least one POST failed ) \" | | 10 | 0003 | 4465746563746F7220726561647920746F20646F20616E20696D616765 | \"Event received : Detector ready to do an image (severity: warning, code: 0x300 Network reconfiguration request )\" |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un detecteur de generation 3\nLorsque le detecteur envoie la trame <severite><code><contexte>\nAlors j'ai la trace standard d'information <trace>\nExemples:\n| severite | code | contexte                                                   | trace                                                                                                                    |\n| 00       | 0001 | 4465746563746F7220726561647920746F20646F20616E20696D616765 | \"Event received : Detector ready to do an image (severity: no, code: 0x100 Detector ready to do an image again )\"        |\n| 01       | 0900 | 4465746563746F7220726561647920746F20646F20616E20696D616765 | \"Event received : Detector ready to do an image (severity: critical, code: 0x009 POST failed. At least one POST failed ) \" |\n| 10       | 0003 | 4465746563746F7220726561647920746F20646F20616E20696D616765 | \"Event received : Detector ready to do an image (severity: warning, code: 0x300 Network reconfiguration request )\"       |", requirement.m_Scenarios[0].m_strSteps);
        }

        [TestMethod]
        public void TestFeatureTransformerWithTableAfterSontOrSuivantes()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Etant donné le fichier Tetris_ImageHeader.ini contenant les informations suivantes | clef              | nb_word |   offset   |  masque   | type |    | MODE              |    1    |    0x00    |    0x000F | dec  | Alors les paramètres du mot clef getImagesParameters sont  | parametres        |    | MODE              |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit le fichier Tetris_ImageHeader.ini contenant les informations suivantes\n| clef | nb_word | offset | masque | type |\n| MODE | 1       | 0x00   | 0x000F | dec  |\nAlors les parametres du mot clef getImagesParameters sont\n| parametres |\n| MODE       |", requirement.m_Scenarios[0].m_strSteps);
        }



        [TestMethod]
        public void TestFeatureTransformerWithTableAfterSuivant()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Etant donné le fichier Tetris_ImageHeader.ini contenant les informations suivant | clef              | nb_word |   offset   |  masque   | type |    | MODE              |    1    |    0x00    |    0x000F | dec  | Alors les paramètres du mot clef getImagesParameters sont  | parametres        |    | MODE              |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit le fichier Tetris_ImageHeader.ini contenant les informations suivant\n| clef | nb_word | offset | masque | type |\n| MODE | 1       | 0x00   | 0x000F | dec  |\nAlors les parametres du mot clef getImagesParameters sont\n| parametres |\n| MODE       |", requirement.m_Scenarios[0].m_strSteps);
        }


        [TestMethod]
        public void TestFeatureTransformerWithExempleWithoutDoublePointButWithPipe()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Soit un detecteur sans information de data Alors j'ai une image d'offset de reference temporaire. Exemple | data | | mode | | table |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un detecteur sans information de data\nAlors j'ai une image d'offset de reference temporaire\nExemples:\n| data  |\n| mode  |\n| table |", requirement.m_Scenarios[0].m_strSteps);
        }

        [TestMethod]
        public void TestFeatureTransformerTheLastFinishByPointAndFollowedByIDS()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Soit un sequenceur de memoire Et le script retourne TCL_KO. IDS_TCL_ERR_GET_SEQUENCES_NUMBER_INV_ARG pas d'argument requis. Usage : getSequencesNumber no argument required. Usage : getSequencesNumber");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un sequenceur de memoire\nEt le script retourne TCL_KO", requirement.m_Scenarios[0].m_strSteps);
        }

        [TestMethod]
        public void TestFeatureTransformerFrenchComasToEnglishComas()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Soit «un sequenceur» de memoire Et le script « retourne » TCL_KO.");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit \"un sequenceur\" de memoire\nEt le script \"retourne\" TCL_KO", requirement.m_Scenarios[0].m_strSteps);
        }

        [TestMethod]
        public void TestFeatureTransformerSameTextInColumnExample()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Soit un detecteur de generation 3 Et le type de demande d'image a utiliser est defini a <type> Lorsque je demande une image Alors une demande <demande> de type Image Frame Request est faite Exemples: | type | demande | | RDO | RDOE | | RDO | RDOE |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un detecteur de generation 3\nEt le type de demande d'image a utiliser est defini a <type>\nLorsque je demande une image\nAlors une demande <demande> de type Image Frame Request est faite\nExemples:\n| type | demande |\n| RDO  | RDOE    |\n| RDO  | RDOE    |", requirement.m_Scenarios[0].m_strSteps);
        }

        [TestMethod]
        public void TestFeatureTransformerRemovePointAfEndOfLine()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Soit un detecteur de generation 3. Et le type de demande d'image a utiliser est defini a <type>. Lorsque je demande une image Alors une demande <demande> de type Image.Frame.Request est faite. Exemples: | type | demande | | RDO | RDOE | | RDO | RDOE |");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un detecteur de generation 3\nEt le type de demande d'image a utiliser est defini a <type>\nLorsque je demande une image\nAlors une demande <demande> de type Image.Frame.Request est faite\nExemples:\n| type | demande |\n| RDO  | RDOE    |\n| RDO  | RDOE    |", requirement.m_Scenarios[0].m_strSteps);
        }

        [TestMethod]
        public void TestFeatureTransformerRemovePointAfEndOfScenario()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Soit un detecteur de generation 3. Et le type de demande d'image a utiliser est defini a <type>. Lorsque je demande une image Alors une demande <demande> de type Image.Frame.Request est faite.");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un detecteur de generation 3\nEt le type de demande d'image a utiliser est defini a <type>\nLorsque je demande une image\nAlors une demande <demande> de type Image.Frame.Request est faite", requirement.m_Scenarios[0].m_strSteps);
        }

        [TestMethod]
        public void TestFeatureTransformerWithAPointInScenario()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Etant donné un RTC de type ACQPXGen3 Lorsque j'appelle le mot clef getModeParameters Alors la trace de résultat TCL est { {mode 1} {gain 2 N/A} {R.L. 6 N/A} {X.W. 3} }");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["ESD-TXL-TeTriS-305"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un RTC de type ACQPXGen3\nLorsque j'appelle le mot clef getModeParameters\nAlors la trace de resultat TCL est { {mode 1} {gain 2 N/A} {R.L. 6 N/A} {X.W. 3} }", requirement.m_Scenarios[0].m_strSteps);
        }

        [TestMethod]
        public void TestFeatureTransformerWithCommentInScenario()
        {
            // Arrange
            FeatureTransformer transformer = new FeatureTransformer();
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("", "Etant donné un RTC de type ACQPXGen3 #Je lance l'action via le mot clef Lorsque j'appelle le mot clef getModeParameters # Maintenant j'ai le resultat Alors la trace de résultat TCL est { {mode 1} {gain 2 N/A} {R.L. 6 N/A} {X.W. 3} }");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["ESD-TXL-TeTriS-305"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("Soit un RTC de type ACQPXGen3\n# Je lance l'action via le mot clef\nLorsque j'appelle le mot clef getModeParameters\n# Maintenant j'ai le resultat\nAlors la trace de resultat TCL est { {mode 1} {gain 2 N/A} {R.L. 6 N/A} {X.W. 3} }", requirement.m_Scenarios[0].m_strSteps);
        }
    }
}
