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
    }
}
