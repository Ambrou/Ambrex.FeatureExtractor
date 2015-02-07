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
            Assert.AreEqual("Soit  eaeueiaoeo'", requirement.m_Scenarios[0].m_strSteps);
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
            scenario = new Scenario("Vérification du RTC Port pour un RTC soft ou hard", "Etant donné le champ Active RTC defini a un type de RTC hard ou soft Et le champ RTC Port <etat> Lorsque je verifie la configuration RTC Alors j’ai la boite de dialogue d’erreur IDS_ERR_RTC_PORT_CONFIG Et TeTriS ne se lance pas Exemple: | etat | | inexistant | | vide | IDS_ERR_RTC_PORT_CONFIG Erreur de configuration de TeTriS : RTC port non défini dans le fichier TeTriS Configuration Error : there is no RTC port configuration in the file Cette vérification du matériel se fait via la lecture du fichier de configuration «HardwareConfigurationTable_Default.ini ». En effet, ce dernier liste toutes les combinaisons de hardware autorisées possibles, il est analysé au lancement de l’application afin de continuer ou de bloquer le démarrage. Si les champs ne sont pas renseignés ou sont commentés, la valeur par défaut est « NO » (pas de matériel de connecté). Si la configuration matérielle n'existe pas, le lancement de l'application est arrêté et une boite de dialogue s'ouvre avec un message rappelant à l'utilisateur sa configuration hardware, et que celle-ci n’est pas correcte.");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["toto"] = requirement;

            // Act
            transformer.transform(Requirements);

            // Assert
            Assert.AreEqual("", requirement.m_strContext);
            Assert.AreEqual("Soit le champ Active RTC defini a NO\nLorsque je verifie la configuration RTC\nAlors TeTriS ne verifie pas le champ RTC Port", requirement.m_Scenarios[0].m_strSteps);
            Assert.AreEqual("Vérification du RTC Port pour un RTC NO", requirement.m_Scenarios[0].m_strTitle);

            Assert.AreEqual("Soit le champ Active RTC defini a un type de RTC hard ou soft\nEt le champ RTC Port <etat>\nLorsque je verifie la configuration RTC\nAlors j'ai la boite de dialogue d'erreur IDS_ERR_RTC_PORT_CONFIG\nEt TeTriS ne se lance pas\nExemples:\n| etat |\n| inexistant |\n| vide | IDS_ERR_RTC_PORT_CONFIG Erreur de configuration de TeTriS : RTC port non defini dans le fichier TeTriS Configuration Error : there is no RTC port configuration in the file Cette verification du materiel se fait via la lecture du fichier de configuration «HardwareConfigurationTable_Default.ini ». En effet, ce dernier liste toutes les combinaisons de hardware autorisees possibles, il est analyse au lancement de l'application afin de continuer ou de bloquer le demarrage. Si les champs ne sont pas renseignes ou sont commentes, la valeur par defaut est « NO » (pas de materiel de connecte). Si la configuration materielle n'existe pas, le lancement de l'application est arrete et une boite de dialogue s'ouvre avec un message rappelant a l'utilisateur sa configuration hardware, et que celle-ci n'est pas correcte.", requirement.m_Scenarios[1].m_strSteps);
            Assert.AreEqual("Vérification du RTC Port pour un RTC soft ou hard", requirement.m_Scenarios[1].m_strTitle);
        }
    }
}
