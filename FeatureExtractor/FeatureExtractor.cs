using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeatureExtractor
{
    public class Extractor
    {
        public Dictionary<string, Requirement> extract(Dictionary<string, string> requirements)
        {
            Dictionary<string, Requirement> extractedRequirements = new Dictionary<string, Requirement>();
            foreach (var requirement in requirements)
            {
                Requirement requirementScenario = new Requirement();
                extractContextAndScenario(requirement.Value, ref requirementScenario.m_strContext, ref requirementScenario.m_Scenarios);

                extractedRequirements.Add(requirement.Key, requirementScenario);
            }
            return extractedRequirements;
        }

        private void extractContextAndScenario(string strRawRequirement, ref string strContext, ref List<Scenario> scenario)
        {
            extractContext(strRawRequirement, ref strContext);
            extractScenario(strRawRequirement, ref scenario);
        }

        private void extractContext(string strRawRequirement, ref string strContext)
        {
            strContext = "";
            string[] words = strRawRequirement.Split(' ');
            bool bIsContext = false;
            foreach (var word in words)
            {
                switch (word)
                {
                    case "Contexte:":
                        {
                            bIsContext = true;
                        }
                        break;
                    case "Scénario:":
                        {
                            bIsContext = false;
                            strContext = strContext.TrimEnd(' ');
                        }
                        break;
                    default:
                        {
                            if (bIsContext == true)
                            {
                                strContext += word;
                                strContext += " ";
                            }
                        }
                        break;
                }
            }
        }

        private void extractScenario(string strRawRequirement, ref List<Scenario> scenarios)
        {
            bool bIsScenarioTitle = false;
            bool bIsScenarioBody = false;
            string[] words = strRawRequirement.Split(' ');
            string strTitle = "";
            string strBody = "";
            foreach (var word in words)
            {
                switch (word)
                {
                    case "Scénario:":
                    {
                        if (bIsScenarioBody == true)
                        {
                            scenarios.Add(new Scenario(strTitle.TrimEnd(' '), strBody.TrimEnd(' ')));
                        }
                        strTitle = "";
                        bIsScenarioTitle = true;
                        bIsScenarioBody = false;
                    }
                    break;
                    case "Étant":
                    case "Etant":
                    {
                        if (bIsScenarioTitle == true)
                        {
                            bIsScenarioTitle = false;
                            bIsScenarioBody = true;
                            strBody = "";
                            strBody += word;
                            strBody += " ";
                        }
                    }
                    break;
                    case " ":
                    case "":
                    {

                    }
                    break;
                    case "Résultats":
                    {
                        bIsScenarioBody = false;
                    }
                    break;
                    default:
                    {
                        if (bIsScenarioTitle == true)
                        {
                            strTitle += word;
                            strTitle += " ";
                        }
                        if (bIsScenarioBody == true)
                        {
                            strBody += word;
                            strBody += " ";
                        }
                    }
                    break;
                }
            }
            scenarios.Add(new Scenario(strTitle.TrimEnd(' '), strBody.TrimEnd(' ')));
        }


        //public Dictionary<string, Requirement> getRequirements()
        //{
        //    return m_ExtractedRequirements;
        //}

        //private Dictionary<string, string> m_RawRequirements;
        //private Dictionary<string, Requirement> m_ExtractedRequirements;


    }
}
