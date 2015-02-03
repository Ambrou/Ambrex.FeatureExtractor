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
            requirment = extractor.getRequirement(strRequirementID);
            Assert.Equals(strRequirementID, requirement.Id());  
        }

        [Then(@"Et il contient le scénario:")]
        public void ThenEtIlContientLeScenario(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Et il contient le contexte ""(.*)""")]
        public void ThenEtIlContientLeContexte(string strContexte)
        {
            ScenarioContext.Current.Pending();
        }



        Extractor extractor = new Extractor();
        Requirement requirment;
    }
}
