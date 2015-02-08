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
            strText = strText.Replace("Etant donné", "Soit");
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
            // Transform the blank character before the : character
            strText = strText.Replace(" ", " ");
        }

        private void formatSteps(ref string strText)
        {
            bool bExampleParameterStarted = false;
            bool bExampleEmpty = false;
            bool bDoublePointOccurs = false;
            bool bExampleOccurs = false;
            bool bWriteTable = false;
            int iColumnIndex = 0;
            int iColumnSize = 0;
            Dictionary<int, int> columnSize = new Dictionary<int, int>();
            string[] words = strText.Split(' ');
            strText = "";
            //string newText = "";
            foreach (var word in words)
            {
                switch (word)
                {
                    case "Soit":
                    case "Lorsque":
                    case "Alors":
                    case "Et":
                        {
                            strText = addNewLine(strText);
                            strText = addWordFollowedBySpaceCharacter(strText, word);
                            bDoublePointOccurs = false;
                        }
                        break;
                    case "Exemple:":
                        {
                            strText = addNewLine(strText);
                            strText += "Exemples:\n";
                            bDoublePointOccurs = false;
                            bExampleOccurs = true;
                        }
                        break;
                    case "Exemples:":
                        {
                            strText = addNewLine(strText);
                            strText += word;
                            strText += "\n";
                            bDoublePointOccurs = false;
                            bExampleOccurs = true;
                        }
                        break;
                    case "|":
                        {

                            if (bDoublePointOccurs == true || bExampleOccurs == true)
                            {
                                bWriteTable = true;
                            }
                            if (bDoublePointOccurs == true)
                            {
                                bDoublePointOccurs = false;
                                strText = addNewLine(strText);
                                iColumnIndex = 0;
                                if (columnSize.Count <= iColumnIndex)
                                {
                                    columnSize[iColumnIndex] = 0;
                                }
                            }
                            bExampleParameterStarted = true;
                            if (bExampleEmpty == true)
                            {
                                strText = addNewLine(strText);
                                iColumnIndex = 0;
                                if (columnSize.Count <= iColumnIndex)
                                {
                                    columnSize[iColumnIndex] = 0;
                                }
                            }
                            else
                            {
                                iColumnIndex++;
                                if(columnSize.Count <= iColumnIndex)
                                {
                                    columnSize[iColumnIndex] = 0;
                                }
                            }
                            strText = addWordFollowedBySpaceCharacter(strText, word);
                            bExampleEmpty = true;
                        }
                        break;
                    case ":":
                        {
                            bDoublePointOccurs = true;
                            strText = addWordFollowedBySpaceCharacter(strText, word);
                        }
                        break;
                    case " ":
                    case "":
                        {

                        }
                        break;
                    default:
                        {
                            if (bWriteTable == true)
                            {
                                iColumnSize += word.Length + 1;
                                columnSize[iColumnIndex] = Math.Max(columnSize[iColumnIndex], iColumnSize);
                            }
                            strText = addWordFollowedBySpaceCharacter(strText, word);
                            if (bExampleParameterStarted == true)
                            {
                                bExampleEmpty = false;
                            }
                            bDoublePointOccurs = false;
                        }
                        break;
                }
            }
            //strText = newText.TrimEnd(' ');
            strText = strText.TrimEnd(' ');
        }

        private static string addWordFollowedBySpaceCharacter(string strText, string word)
        {
            strText += word;
            strText += " ";
            return strText;
        }

        private static string addNewLine(string strText)
        {
            if (strText.Length != 0)
            {
                strText = strText.TrimEnd(' ');
                strText += "\n";
            }
            return strText;
        }
    }
}
