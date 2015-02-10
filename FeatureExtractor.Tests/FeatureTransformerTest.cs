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
    }
}
