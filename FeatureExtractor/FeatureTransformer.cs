using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeatureExtractor
{
    public class FeatureTransformer
    {
        public Dictionary<string, Requirement> transform(Dictionary<string, Requirement> Requirements)
        {
            foreach (var pair in Requirements)
            {
                transform(ref pair.Value.m_strContext);
                foreach (var scenario in pair.Value.m_Scenarios)
                {
                    transform(ref scenario.m_strSteps);
                }
            }
            return Requirements;
        }

        private void transform(ref string strText)
        {
            removeSpicyCharacters(ref strText);
            formatSteps(ref strText);
        }

        private void removeSpicyCharacters(ref string strText)
        {
            strText = strText.Replace("Étant donné", "Soit");
            strText = strText.Replace("é", "e");
            strText = strText.Replace("è", "e");
            strText = strText.Replace("ê", "e");
            strText = strText.Replace("ù", "u");
            strText = strText.Replace("à", "a");
            strText = strText.Replace("à", "a");
            strText = strText.Replace("’", "'");
            strText = strText.Replace("ô", "o");
            strText = strText.Replace("ë", "e");
            strText = strText.Replace("ö", "o");
            strText = strText.Replace("ï", "i");
            strText = strText.Replace("ä", "a");
        }

        private void formatSteps(ref string strText)
        {
            string[] words = strText.Split(' ');
            string newText = "";
            foreach (var word in words)
            {
                switch (word)
                {
                    case "Soit":
                    case "Lorsque":
                    case "Alors":
                    case "Et":
                        {
                            if (newText.Length != 0)
                            {
                                newText = newText.TrimEnd(' ');
                                newText += "\n";
                            }
                            newText += word;
                            newText += " ";
                        }
                        break;
                    default:
                        {
                            newText += word;
                            newText += " ";
                        }
                        break;
                }
            }
            strText = newText.TrimEnd(' ');
        }
    }
}
