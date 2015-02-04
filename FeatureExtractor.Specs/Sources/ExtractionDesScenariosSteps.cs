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
            var requirements = new Dictionary<string, string>();

            foreach (var row in table.Rows)
            {
                requirements[row["ReqID"]] = row["TEXTE"];
            }
            extractor.setRequirements(requirements);
        }

        [When(@"j'extrais les scénarios")]
        public void WhenJExtraisLesScenarios()
        {
            extractor.extract();
        }

        [Then(@"le besoin (.*) existe")]
        public void ThenLeBesoin_Existe(string strRequirementID)
        {
            requirement = extractor.getRequirement(strRequirementID);
            Assert.IsNotNull(requirement);  
        }

        [Then(@"Et il contient le scénario:")]
        public void ThenEtIlContientLeScenario(Table table)
        {
            foreach (var row in table.Rows)
            {
                Assert.AreEqual(true, requirement.Item2.Contains(new Tuple<string, string>(row["titre"], row["scénario"])));
            }
        }

        [Then(@"Et il contient le contexte ""(.*)""")]
        public void ThenEtIlContientLeContexte(string strContexte)
        {
            Assert.AreEqual(strContexte, requirement.Item1); ;
        }

        Extractor extractor = new Extractor();
        Tuple<string, List<Tuple<string,string>>> requirement;
    }
}
