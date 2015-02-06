using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FeatureExtractor.Tests
{
    [TestClass]
    public class FeatureExtractorTest
    {
        [TestMethod]
        public void TestExtractWithContextAndOneSimpleScenario()
        {
            // Arrange
            Extractor extractor = new Extractor();
            Dictionary<string, string> requirements = new Dictionary<string, string>();
            requirements.Add("ESD_044", "  Contexte: Étant donné un interpréteur de script Scénario: Changement de table Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK");
            
            // Act
            Dictionary<string, Requirement> extractedRequirements = extractor.extract(requirements);

            // Assert
            Assert.AreEqual("Étant donné un interpréteur de script", extractedRequirements["ESD_044"].m_strContext);
            Assert.AreEqual(1, extractedRequirements["ESD_044"].m_Scenarios.Count);
            bool bFound = false;
            for (int i = 0; i < extractedRequirements["ESD_044"].m_Scenarios.Count; i++)
            {
                if (extractedRequirements["ESD_044"].m_Scenarios[i].m_strSteps == "Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK" &&
                    extractedRequirements["ESD_044"].m_Scenarios[i].m_strTitle == "Changement de table")
                {
                    bFound = true;
                }
            }
            Assert.AreEqual(true, bFound);

        }
    }
}
