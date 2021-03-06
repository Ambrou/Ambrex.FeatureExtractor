﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FeatureExtractor.Tests
{
    [TestClass]
    public class FeatureWriterTest
    {
        [TestMethod]
        public void TestFeatureWriterIssue1()
        {
            // Arrange
            Requirement requirement = new Requirement();
            requirement.m_strContext = "";
            Scenario scenario = new Scenario("Vérification du RTC Port pour un RTC NO", "Soit le champ Active RTC defini a NO\nLorsque je verifie la configuration RTC\nAlors TeTriS ne verifie pas le champ RTC Port");
            requirement.m_Scenarios.Add(scenario);
            scenario = new Scenario("Vérification du RTC Port pour un RTC soft ou hard", "Soit le champ Active RTC defini a un type de RTC hard ou soft\nEt le champ RTC Port <etat>\nLorsque je verifie la configuration RTC\nAlors j'ai la boite de dialogue d'erreur IDS_ERR_RTC_PORT_CONFIG\nEt TeTriS ne se lance pas Exemple: | etat | | inexistant | | vide | IDS_ERR_RTC_PORT_CONFIG Erreur de configuration de TeTriS : RTC port non defini dans le fichier TeTriS Configuration Error : there is no RTC port configuration in the file Cette verification du materiel se fait via la lecture du fichier de configuration «HardwareConfigurationTable_Default.ini ». En effet, ce dernier liste toutes les combinaisons de hardware autorisees possibles, il est analyse au lancement de l'application afin de continuer ou de bloquer le demarrage. Si les champs ne sont pas renseignes ou sont commentes, la valeur par defaut est « NO » (pas de materiel de connecte). Si la configuration materielle n'existe pas, le lancement de l'application est arrete et une boite de dialogue s'ouvre avec un message rappelant a l'utilisateur sa configuration hardware, et que celle-ci n'est pas correcte.");
            requirement.m_Scenarios.Add(scenario);
            Dictionary<string, Requirement> Requirements = new Dictionary<string, Requirement>();
            Requirements["ESD-TXL-TeTriS-001"] = requirement;
            FeatureWriter writer = new FeatureWriter();

            // Act
            writer.write(Requirements);

            //Assert
        }
    }
}
