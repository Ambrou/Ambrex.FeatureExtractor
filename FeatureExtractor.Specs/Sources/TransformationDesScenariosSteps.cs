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
            ScenarioContext.Current.Pending();
        }

        [Given(@"son contexte est ""(.*)""")]
        public void GivenSonContexteEst(string strContexte)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"je transforme le scénario")]
        public void WhenJeTransformeLeScenario()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"l'exigence extraite devient:")]
        public void ThenLExigenceExtraiteDevient(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"son contexte devient ""(.*)""")]
        public void ThenSonContexteDevient(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
