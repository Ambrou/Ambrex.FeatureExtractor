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
            extractor.setRequirements(requirements);

            // Act
            extractor.extract();

            // Assert
            Assert.IsNotNull(extractor.getRequirement("ESD_044"));
            Assert.AreEqual("Étant donné un interpréteur de script", extractor.getRequirement("ESD_044").m_strContext);
            Assert.AreEqual(1, extractor.getRequirement("ESD_044").m_Scenario.Count);
            Assert.AreEqual(true, extractor.getRequirement("ESD_044").m_Scenario.Contains(new Tuple<string,string>("Changement de table", "Étant donné un matériel Et la configuration définissant la table 7 Lorsque j'appelle le mot clef changeTable 7 Alors le script retourne OK")));

        }
    }
}
