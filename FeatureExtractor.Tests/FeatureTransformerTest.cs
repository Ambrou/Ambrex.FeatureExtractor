using System;
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
            Assert.AreEqual("Soit un detecteur de type type\nLorsque j'appelle le mot clef pxSetEnergyParameters autoswitch rechargetrigger lowleveltriggerwakeup lowleveltriggerstartimage securitytemperature dateofexchangeweek dateofexchangeyear launchcalibration\nAlors j'ai la trace d'erreur numero IDS_TCL_ERR_PX_SET_ENERGY_PARAMETERS_WRONG_ARG.\nEt le script retourne TCL_KO\nExemples:\n| type         | autoswitch | rechargetrigger | lowleveltriggerwakeup | lowleveltriggerstartimage | securitytemperature | dateofexchangeweek | dateofexchangeyear | launchcalibration |\n| 4600         | G          | 2               | 3                     | 4                         | 5                   | 6                  | 7                  | 8                 |\n| 4700         | 1          | 2G              | 3                     | 4                         | 5                   | 6                  | 7                  | 8                 |\n| 4800         | 1          | 2               | 3G                    | 4                         | 5                   | 6                  | 7                  | 8                 |\n| generation 3 | 1          | 2               | 3                     | 4G                        | 5                   | 6                  | 7                  | 8                 |\n| generation 2 | 1          | 2               | 3                     | 4                         | 5G                  | 6                  | 7                  | 8                 |\n| 4800         | 1          | 2               | 3                     | 4                         | 5                   | 6G                 | 7                  | 8                 |\n| generation 3 | 1          | 2               | 3                     | 4                         | 5                   | 6                  | 7G                 | 8                 |\n| generation 2 | 1          | 2               | 3                     | 4                         | 5                   | 6                  | 7                  | G                 |", requirement.m_Scenarios[0].m_strSteps);
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
    }
}
