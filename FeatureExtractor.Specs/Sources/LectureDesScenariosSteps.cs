using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace FeatureExtractor.Specs
{
    [Binding]
    public class LectureDesScenariosSteps
    {
        [Given(@"Le fichier ESD\.agex contenant les lignes:")]
        public void GivenLeFichierESD_AgexContenantLesLignes(Table table)
        {
            strFile = "ESD.agex";
            System.IO.StreamWriter file = new System.IO.StreamWriter(strFile, false, Encoding.GetEncoding("windows-1252"));
            foreach (var row in table.Rows)
            {
                file.WriteLine(row["ligne"]);
            }
            file.Close();
        }

        [When(@"j'analyse ce fichier")]
        public void WhenJeAnalyseCeFichier()
        {
            FeatureReader reader = new FeatureReader();
            requirements = reader.readRequirements(strFile);
        }


        [Then(@"j'ai l'exigence (.*) avec comme texte ""(.*)"" et titre ""(.*)""")]
        public void ThenJExigencesESD_AvecCommeTexte(string strReqId, string strRequirement, string strTitle)
        {
            Assert.AreEqual(strRequirement, requirements[strReqId].Item2);
            Assert.AreEqual(strTitle, requirements[strReqId].Item1);
        }

        string strFile;
        Dictionary<string, Tuple<string, string>> requirements;
    }
}
