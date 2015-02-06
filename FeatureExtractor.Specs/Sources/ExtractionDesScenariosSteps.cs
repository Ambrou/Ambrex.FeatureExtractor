using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace FeatureExtractor.Specs.Sources
{
    [Binding]
    public class ExtractionDesScenariosSteps
    {
        [Given(@"les exigences suivantes:")]
        public void GivenLesExigencesSuivantes(Table table)
        {

            foreach (var row in table.Rows)
            {
                requirements[row["ReqID"]] = row["TEXTE"];
            }
        }

        [When(@"j'extrais les scénarios")]
        public void WhenJExtraisLesScenarios()
        {
            extractedRequirements = extractor.extract(requirements);
        }

        [Then(@"le besoin (.*) existe")]
        public void ThenLeBesoin_Existe(string strRequirementID)
        {
            Assert.IsNotNull(extractedRequirements[strRequirementID]);
            requirement = extractedRequirements[strRequirementID];
        }

        [Then(@"Et il contient le scénario:")]
        public void ThenEtIlContientLeScenario(Table table)
        {
            foreach (var row in table.Rows)
            {
                bool bFound = false;
                for (int i = 0; i < requirement.m_Scenarios.Count; i++)
                {
                    if (requirement.m_Scenarios[i].m_strSteps == row["scénario"] &&
                        requirement.m_Scenarios[i].m_strTitle == row["titre"])
                    {
                        bFound = true;
                    }
                }
                Assert.AreEqual(true, bFound);
            }
        }

        [Then(@"Et il contient le contexte ""(.*)""")]
        public void ThenEtIlContientLeContexte(string strContexte)
        {
            Assert.AreEqual(strContexte, requirement.m_strContext); ;
        }

        [Then(@"Et il contient les scénarios:")]
        public void ThenEtIlContientLesScenario(Table table)
        {
            foreach (var row in table.Rows)
            {
                bool bFound = false;
                for (int i = 0; i < requirement.m_Scenarios.Count; i++)
                {
                    if (requirement.m_Scenarios[i].m_strSteps == row["scénarios"] &&
                        requirement.m_Scenarios[i].m_strTitle == row["titre"])
                    {
                        bFound = true;
                    }
                }
                Assert.AreEqual(true, bFound);
            }
        }

        Dictionary<string, string> requirements = new Dictionary<string, string>();
        Dictionary<string, Requirement> extractedRequirements;
        Extractor extractor = new Extractor();
        Requirement requirement;
    }
}
