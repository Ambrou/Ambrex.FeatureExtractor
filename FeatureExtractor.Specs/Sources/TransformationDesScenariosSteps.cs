using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace FeatureExtractor.Specs.Sources
{
    [Binding]
    public class TransformationDesScenariosSteps
    {
        [Given(@"l'exigence extraite suivante:")]
        public void GivenLExigenceExtraiteSuivante(Table table)
        {
            foreach (var row in table.Rows)
            {
                requirement.m_Scenarios.Add(new Scenario(row["titre"], row["scénario"]));
            }
        }

        [Given(@"son contexte est ""(.*)""")]
        public void GivenSonContexteEst(string strContexte)
        {
            requirement.m_strContext = strContexte;
        }

        [When(@"je transforme le scénario")]
        public void WhenJeTransformeLeScenario()
        {
            transformer.transform(ref requirement);
        }

        [Then(@"l'exigence extraite devient:")]
        public void ThenLExigenceExtraiteDevient(Table table)
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

        [Then(@"son contexte devient ""(.*)""")]
        public void ThenSonContexteDevient(string strContext)
        {
            strContext = strContext.Replace("\\n", "\n");
            Assert.AreEqual(strContext, requirement.m_strContext);
        }

        Requirement requirement = new Requirement();
        FeatureTransformer transformer = new FeatureTransformer();
    }
}
