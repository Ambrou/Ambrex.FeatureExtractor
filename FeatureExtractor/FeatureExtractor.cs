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
                extractFonctionnalityName(requirement, requirementScenario);
                extractContextAndScenario(requirement.Value.Item2, ref requirementScenario.m_strContext, ref requirementScenario.m_Scenarios);
                addScenario(extractedRequirements, requirement, requirementScenario);
            }
            return extractedRequirements;
        }

        private void addScenario(Dictionary<string, Requirement> extractedRequirements, KeyValuePair<string, Tuple<string, string>> requirement, Requirement requirementScenario)
        {
            if (requirementScenario.m_Scenarios.Count != 0)
            {
                extractedRequirements.Add(requirement.Key, requirementScenario);
            }
        }

        private void extractFonctionnalityName(KeyValuePair<string, Tuple<string, string>> requirement, Requirement requirementScenario)
        {
            requirementScenario.m_strFeature = Regex.Replace(requirement.Value.Item1, " \\[p\\.[0-9]+\\]$", "");
        }

        private void extractContextAndScenario(string strRawRequirement, ref string strContext, ref List<Scenario> scenario)
        {
            strRawRequirement = insertSpaceBeforeAndAfterPipe(strRawRequirement);
            extractContext(strRawRequirement, ref strContext);
            extractScenario(strRawRequirement, ref scenario);
        }

        private string insertSpaceBeforeAndAfterPipe(string strText)
        {
            for (int iLoop = 0; iLoop < strText.Length; ++iLoop)
            {
                if (iLoop < strText.Length - 1)
                {
                    if (strText[iLoop] == '|' && strText[iLoop + 1] != ' ')
                    {
                        strText = strText.Insert(iLoop + 1, " ");
                    }
                }
                if (0 < iLoop)
                {
                    if (strText[iLoop] == '|' && strText[iLoop - 1] != ' ')
                    {
                        strText = strText.Insert(iLoop, " ");
                    }
                }
            }
            return strText;
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
                            if (strContext.Length != 0)
                            {
                                strContext += " ";
                            }
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
                switch (word.Replace('\x00A0', ' '))
                {
                    case "Scénario:":
                    case "Scénario :":
                    {
                        bPartOfExample = false;
                        strPartOfExample = "";
                        if (strTitle != "" && strBody != "")
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
                            strBody = addWordFollowedBySpaceCharacter(strBody, word);
                        }
                        bPartOfExample = false;
                    }
                    break;
                    case "Lorsque":
                    case "Quand":
                    case "Et":
                    case "Alors":
                    {
                        if (bIsScenarioTitle == true || bIsScenarioBody == true)
                        {
                            if (bIsScenarioTitle == true)
                            {
                                strBody = "";
                            }
                            bIsScenarioTitle = false;
                            bIsScenarioBody = true;

                            strBody = addWordFollowedBySpaceCharacter(strBody, word);
                        }
                        bPartOfExample = false;
                    }
                    break;
                    case "|":
                    {
                        if (bIsScenarioBody == true)
                        {
                            if (bPartOfExample == true)
                            {
                                strBody += strPartOfExample;
                                strPartOfExample = "";
                            }
                            bPartOfExample = true;
                            strBody = addWordFollowedBySpaceCharacter(strBody, word);
                        }
                    }
                    break;
                    case " ":
                    case "":
                    {

                    }
                    break;
                    case "Résultats":
                    case "Messages":
                    case "Message":
                    case "Accès":
                    case "IDS_ERR_TCL_GET_XG_COUNTERS_INV_ARG":
                    case "IDS_ERR_GENE_ADAPT_TUBE_X_WRONG_ARG":
                    case "Si":
                    case "Syntaxe":
                    {
                        bIsScenarioBody = false;
                        bPartOfExample = false;
                    }
                    break;
                    default:
                    {
                        if (word == strLastWord)
                        {
                            if (Regex.Match(word, "^[A-Z]", RegexOptions.None).Success == true &&
                                Regex.Match(word, "^PX[0-9]+[A-Z]*", RegexOptions.None).Success == false &&
                                Regex.Match(word, "^Portable2$", RegexOptions.IgnoreCase).Success == false &&
                                Regex.Match(word, "^NO$", RegexOptions.None).Success == false &&
                                Regex.Match(word, "^PX_TEST$", RegexOptions.None).Success == false)
                            {
                                bIsScenarioBody = false;
                            }
                        }
                        if (bIsScenarioTitle == true && bPartOfExample == false)
                        {
                            strTitle = addWordFollowedBySpaceCharacter(strTitle, word);
                        }
                        if (bIsScenarioBody == true && bPartOfExample == false)
                        {
                            strBody = addWordFollowedBySpaceCharacter(strBody, word);
                        }
                        if (bIsScenarioBody == true && bPartOfExample == true)
                        {
                            strPartOfExample = addWordFollowedBySpaceCharacter(strPartOfExample, word);
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

        private static string addWordFollowedBySpaceCharacter(string strBody, string word)
        {
            strBody += word.TrimEnd('\x00A0');
            strBody += " ";
            return strBody;
        }
    }
}
