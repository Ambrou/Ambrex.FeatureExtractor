using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FeatureExtractor
{
    public class Extractor
    {
        public Dictionary<string, Requirement> extract(Dictionary<string, Tuple<string, string>> requirements)
        {
            Dictionary<string, Requirement> extractedRequirements = new Dictionary<string, Requirement>();
            foreach (var requirement in requirements)
            {
                Requirement requirementScenario = new Requirement();
                requirementScenario.m_strFeature = Regex.Replace(requirement.Value.Item1, " \\[p\\.[0-9]+\\]$", "");
                //requirementScenario.m_strFeature = requirementScenario.m_strFeature.Replace('’', ' ');
                extractContextAndScenario(requirement.Value.Item2, ref requirementScenario.m_strContext, ref requirementScenario.m_Scenarios);
                if (requirementScenario.m_Scenarios.Count != 0)
                {
                    extractedRequirements.Add(requirement.Key, requirementScenario);
                }
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
                            strContext = strContext.TrimEnd(' ').TrimStart(' ');
                        }
                        break;
                    case " ":
                    case "":
                        {

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
            bool bPartOfExample = false;
            string[] words = strRawRequirement.Split(' ');
            string strTitle = "";
            string strBody = "";
            string strPartOfExample = "";
            string strLastWord = "";
            foreach (var word in words)
            {
                switch (word)
                {
                    case "Scénario:":
                    {
                        bPartOfExample = false;
                        strPartOfExample = "";
                        if (bIsScenarioBody == true)
                        {
                            scenarios.Add(new Scenario(strTitle.TrimEnd(' ').TrimStart(' '), strBody.TrimEnd(' ').TrimStart(' ')));
                        }
                        strTitle = "";
                        bIsScenarioTitle = true;
                        bIsScenarioBody = false;
                    }
                    break;
                    case "Étant":
                    case "Etant":
                    case "Soit":
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
                    case "Lorsque":
                    {
                        if (bIsScenarioTitle == true || bIsScenarioBody == true)
                        {
                            if (bIsScenarioTitle == true)
                            {
                                strBody = "";
                            }
                            bIsScenarioTitle = false;
                            bIsScenarioBody = true;
                            
                            strBody += word;
                            strBody += " ";
                        }
                    }
                    break;
                    case "|":
                    {
                        if (bPartOfExample == true)
                        {
                            strBody += strPartOfExample;
                            strPartOfExample = "";
                        }
                        bPartOfExample = true;
                        strBody += word;
                        strBody += " ";
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
                        if (word == strLastWord)
                        {
                            bIsScenarioBody = false;
                        }
                        if (bIsScenarioTitle == true && bPartOfExample == false)
                        {
                            strTitle += word;
                            strTitle += " ";
                        }
                        if (bIsScenarioBody == true && bPartOfExample == false)
                        {
                            strBody += word;
                            strBody += " ";
                        }
                        if(bPartOfExample == true)
                        {
                            strPartOfExample += word;
                            strPartOfExample += " ";
                        }
                        strLastWord = word;
                    }
                    break;
                }
            }
            if (strTitle != "" && strBody != "")
            {
                scenarios.Add(new Scenario(strTitle.TrimEnd(' ').TrimStart(' '), strBody.TrimEnd(' ').TrimStart(' ')));
            }
        }
    }
}
