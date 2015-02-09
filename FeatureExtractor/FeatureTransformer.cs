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
            bool bExamplesOccurs = false;
            bool bWriteInTable = false;
            bool bPipeOccurs = false;
            int iIndexColumn = 0;
            int iSizeColumn = 0;
            Dictionary<int, int> sizeColums = new Dictionary<int, int>();
            string[] words = strText.Split(' ');
            string newText = "";
            string strTable = "";
            foreach (var word in words)
            {
                switch (word)
                {
                    case "Soit":
                    case "Lorsque":
                    case "Alors":
                    case "Et":
                        {
                            transformTable(ref bWriteInTable, ref iIndexColumn, sizeColums, ref newText, ref strTable);
                            if (newText.Length != 0)
                            {
                                newText = newText.TrimEnd(' ');
                                newText += "\n";
                            }
                            newText += word;
                            newText += " ";
                            bDoublePointOccurs = false;
                            bPipeOccurs = false;
                        }
                        break;
                    case "Exemple:":
                        {
                            strText = addNewLine(strText);
                            strText += "Exemples:\n";
                            bDoublePointOccurs = false;
                            bExamplesOccurs = true;
                            bPipeOccurs = false;
                        }
                        break;
                    case "Exemples:":
                        {
                            strText = addNewLine(strText);
                            strText += word;
                            strText += "\n";
                            bDoublePointOccurs = false;
                            bExamplesOccurs = true;
                            bPipeOccurs = false;
                        }
                        break;
                    case "|":
                        {
                            if (bPipeOccurs == false)
                            {
                                iIndexColumn = 0;
                            }
                            else
                            {
                                iIndexColumn++;
                            }
                            iSizeColumn = 1;
                            if (bDoublePointOccurs == true)
                            {
                                bDoublePointOccurs = false;
                                newText = addNewLine(newText);
                                iIndexColumn = 0;
                                bWriteInTable = true;
                            }
                            if(bExamplesOccurs == true)
                            {
                                bWriteInTable = true;
                            }

                            bExampleParameterStarted = true;
                            if (bExampleEmpty == true)
                            {
                                strTable = strTable.TrimEnd(' ');
                                strTable += "\n";
                                iIndexColumn = 0;
                                iSizeColumn = 1;
                            }
                            if (bWriteInTable == true)
                            {
                                strTable += word;
                                strTable += " ";
                            }
                            else
                            {
                                newText += word;
                                newText += " ";
                            }
                            
                            bExampleEmpty = true;
                            bPipeOccurs = true;
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
                            if (bWriteInTable == true)
                            {
                                iSizeColumn += word.Length + 1;
                                if (iIndexColumn < sizeColums.Count)
                                {
                                    sizeColums[iIndexColumn] = Math.Max(sizeColums[iIndexColumn], iSizeColumn);
                                }
                                else
                                {
                                    sizeColums[iIndexColumn] = iSizeColumn;
                                }
                                strTable += word;
                                strTable += " ";
                            }
                            else
                            {
                                newText = addWordFollowedBySpaceCharacter(newText, word);
                            }
                            if (bExampleParameterStarted == true)
                            {
                                bExampleEmpty = false;
                            }
                            bDoublePointOccurs = false;
                        }
                        break;
                }
            }
            transformTable(ref bWriteInTable, ref iIndexColumn, sizeColums, ref newText, ref strTable);
            /*if (strTable.Length != 0)
            {
                string[] lines = strTable.Split('\n');
                foreach (var line in lines)
                {
                    iIndexColumn = 0;
                    string[] exampleParts = line.Split('|');
                    foreach (var examplePart in exampleParts)
                    {
                        while (examplePart.Length < sizeColums[iIndexColumn])
                        {
                            examplePart.Insert(examplePart.Length, " ");
                        }
                        iIndexColumn++;
                    }
                }
                newText = strTable;
                strTable = "";
                bWriteInTable = false;
            }*/

            strText = newText.TrimEnd(' ');
        }

        private static string addWordFollowedBySpaceCharacter(string strText, string word)
        {
            strText += word;
            strText += " ";
            return strText;
        }

        private static string addNewLine(string strText)
        {
            strText = strText.TrimEnd(' ');
            strText += "\n";
            return strText;
        }

        private static void transformTable(ref bool bWriteInTable, ref int iIndexColumn, Dictionary<int, int> sizeColums, ref string newText, ref string strTable)
        {
            if (strTable.TrimEnd(' ').Length != 0)
            {
                string strTemp = "";
                string strTemp2 = "";
                string[] lines = strTable.TrimEnd(' ').Split('\n');
                int iLine = 0;
                foreach (var line in lines)
                {
                    iIndexColumn = 0;
                    string[] exampleParts = line.Split('|');
                    foreach (var examplePart in exampleParts)
                    {

                        if (examplePart.Length != 0)
                        {
                            strTemp += "|";
                            strTemp2 = examplePart;
                            while (strTemp2.Length < sizeColums[iIndexColumn])
                            {
                                strTemp2 = strTemp2.Insert(strTemp2.Length - 1, " ");
                            }
                            strTemp += strTemp2;
                            iIndexColumn++;
                        }
                    }
                    strTemp += "|";
                    iLine++;
                    if (iLine != lines.Length)
                    {
                        strTemp += "\n";
                    }
                }
                newText += strTemp;
                strTable = "";
                bWriteInTable = false;
            }
        }
    }
}
