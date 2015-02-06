using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeatureExtractor
{
    public class Extractor
    {
        public void extract()
        {
            m_ExtractedRequirements = new Dictionary<string, Requirement>();
            foreach (var requirement in m_RawRequirements)
            {
                Requirement requirementScenario = new Requirement();
                extractContextAndScenario(requirement.Value, ref requirementScenario.m_strContext, ref requirementScenario.m_Scenarios);

                m_ExtractedRequirements.Add(requirement.Key, requirementScenario);
            }
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


        public void setRequirements(Dictionary<string, string> requirements)
        {
            m_RawRequirements = requirements;
        }

        public Requirement getRequirement(string strRequirementID)
        {
            return m_ExtractedRequirements[strRequirementID];
        }

        private Dictionary<string, string> m_RawRequirements;
        private Dictionary<string, Requirement> m_ExtractedRequirements;


    }
}
