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

            // Transform the blank character before the : character
            strText = insertSpaceBeforeAndAfterPipe(strText);
            strText = strText.Replace(" ", " ");
            strText = strText.Replace("Exemples :", "Exemples:");
            strText = strText.Replace("Exemple |", "Exemples: |");
            strText = strText.Replace("Exemple :", "Exemples:");
            strText = strText.Replace("Exemple:", "Exemples:");
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
            strText = strText.Replace("î", "i");
            strText = strText.Replace("ä", "a");
            strText = strText.Replace("–", "-");
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

        private void formatSteps(ref string strText)
        {
            bool bExampleParameterStarted = false;
            bool bExampleEmpty = false;
            bool bDoublePointOccurs = false;
            bool bExamplesOccurs = false;
            bool bWriteInTable = false;
            bool bPipeOccurs = false;
            bool bEndOfLine = false;
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
                    case "Quand":
                        {
                            transformTable(ref bWriteInTable, ref iIndexColumn, ref sizeColums, ref newText, ref strTable);
                            if (newText.Length != 0)
                            {
                                newText = addNewLine(newText);
                            }
                            newText = addWordFollowedBySpaceCharacter(newText, word);
                            bDoublePointOccurs = false;
                            bPipeOccurs = false;
                            bEndOfLine = false;
                        }
                        break;
                    //case "Exemple:":
                    //    {
                    //        transformTable(ref bWriteInTable, ref iIndexColumn, ref sizeColums, ref newText, ref strTable);
                    //        newText = addNewLine(newText);
                    //        newText += "Exemples:\n";
                    //        bDoublePointOccurs = false;
                    //        bExamplesOccurs = true;
                    //        bPipeOccurs = false;
                    //        bEndOfLine = false;
                    //    }
                    //    break;
                    case "Exemples:":
                        {
                            transformTable(ref bWriteInTable, ref iIndexColumn, ref sizeColums, ref newText, ref strTable);
                            newText = addNewLine(newText);
                            newText += word;
                            newText += "\n";
                            bDoublePointOccurs = false;
                            bExamplesOccurs = true;
                            bPipeOccurs = false;
                            bEndOfLine = false;
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
                            if (bExampleEmpty == true && sizeColums.Count < iIndexColumn)
                            {
                                strTable = strTable.TrimEnd(' ');
                                strTable += "\n";
                                iIndexColumn = 0;
                                iSizeColumn = 1;
                            }
                            if (bWriteInTable == true)
                            {
                                strTable = addWordFollowedBySpaceCharacter(strTable, word);
                            }
                            else
                            {
                                newText = addWordFollowedBySpaceCharacter(newText, word);
                            }
                            
                            bExampleEmpty = true;
                            bPipeOccurs = true;
                        }
                        break;
                    case ":":
                    case "contenant":
                    case "suivantes":
                    case "suivant":
                    case "sont":
                        {
                            if (bEndOfLine == false)
                            {
                                if(bWriteInTable == true)
                                {
                                    strTable = addWordFollowedBySpaceCharacter(strTable, word);
                                }
                                else
                                {
                                    bDoublePointOccurs = true;
                                    newText = addWordFollowedBySpaceCharacter(newText, word);
                                }
                            }
                        }
                        break;
                    case " ":
                    case "":
                        {

                        }
                        break;
                    default:
                        {
                            if (bEndOfLine == false)
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
                                    strTable = addWordFollowedBySpaceCharacter(strTable, word);
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
                            if (word.EndsWith(".") == true && bWriteInTable == false)
                            {
                                bEndOfLine = true;
                            }
                        }
                        break;
                }
            }
            transformTable(ref bWriteInTable, ref iIndexColumn, ref sizeColums, ref newText, ref strTable);
            
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

        private static void transformTable(ref bool bWriteInTable, ref int iIndexColumn, ref Dictionary<int, int> sizeColums, ref string newText, ref string strTable)
        {
            if (strTable.TrimEnd(' ').Length != 0)
            {
                string strTemp = "";
                string strTemp2 = "";
                string[] lines = strTable.TrimEnd(' ').Split('\n');
                int iLine = 0;
                foreach (var line in lines)
                {
                    if (line.Length != 0)
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
                }
                newText += strTemp;
                newText = newText.TrimEnd('\n');
                strTable = "";
                bWriteInTable = false;

                iIndexColumn = 0;
                sizeColums = new Dictionary<int, int>();
            }
        }
    }
}
