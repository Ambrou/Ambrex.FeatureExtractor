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
                requirement.m_Scenario.Add(new Tuple<string, string>(row["titre"], row["scénario"]));
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
                Assert.AreEqual(true, requirement.m_Scenario.Contains(new Tuple<string,string>(row["titre"], row["scénario"])));
            }
            
        }

        [Then(@"son contexte devient ""(.*)""")]
        public void ThenSonContexteDevient(string strContext)
        {
            Assert.AreEqual(strContext, requirement.m_strContext);
        }

        Requirement requirement = new Requirement();
        FeatureTransformer transformer = new FeatureTransformer();
    }
}
