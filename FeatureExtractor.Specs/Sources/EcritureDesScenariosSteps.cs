using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace FeatureExtractor.Specs.Sources
{
    [Binding]
    public class EcritureDesScenariosSteps
    {
        [Given(@"l'exigence transformée (.*) contenant les scénario:")]
        public void GivenLExigenceTransformeeESD_ContenantLesScenario(string strRequirementId, Table table)
        {
            strReqId = strRequirementId;
            foreach (var row in table.Rows)
            {
                Scenario scenario = new Scenario(row["titre"], row["scénario"]);
                requirement.m_Scenarios.Add(scenario);
            }
        }

        [Given(@"le contexte ""(.*)""")]
        public void GivenLeContexte(string strContext)
        {
            strContext = strContext.Replace("\\n", "\n");
            requirement.m_strContext = strContext;
        }

        [Given(@"sa fonctionnalité est ""(.*)""")]
        public void GivenSaFonctionnaliteEst(string strFeature)
        {
            requirement.m_strFeature = strFeature;
        }


        [When(@"je génére les fichiers scénarios temporaires")]
        public void WhenJeGenereLesFichiersScenariosTemporaires()
        {
            m_FormatedRequirements[strReqId] = requirement;
            FeatureWriter writer = new FeatureWriter();
            writer.write(m_FormatedRequirements);
        }

        [Then(@"j'ai le fichier contient (.*)\.feature contient les lignes:")]
        public void ThenJAiLeFichierContientESD__FeatureContientLesLignes(string strRequirementId, Table table)
        {
            string strFile = strRequirementId + ".feature";

            System.IO.StreamReader file = new System.IO.StreamReader(strFile, Encoding.GetEncoding("windows-1252"));
            foreach (var row in table.Rows)
            {
                string line = file.ReadLine();
                Assert.AreEqual(row["ligne"].Trim('\"'),line);
            }
            file.Close();
        }

        Requirement requirement = new Requirement();
        Dictionary<string, Requirement> m_FormatedRequirements = new Dictionary<string,Requirement>();
        string strReqId;
    }
}
