using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FeatureExtractor
{
    public class FeatureWriter
    {
        public void write(Dictionary<string, Requirement> m_FormatedRequirements)
        {
            foreach (var pair in m_FormatedRequirements)
            {
                string strFile = Regex.Replace(pair.Key, "[a-zA-Z\\-_]", "") + ".feature";
                //string strFile = pair.Key + ".feature";
                System.IO.StreamWriter file = new System.IO.StreamWriter(strFile);

                writeHeader(ref file, pair.Key, pair.Value.m_strFeature);
                writeContext(ref file, ref pair.Value.m_strContext);
                writeScenarios(ref file, ref pair.Value.m_Scenarios);

                file.Close();
            }
        }

        private void writeHeader(ref System.IO.StreamWriter file, string strRequirementId, string strFeature)
        {
            file.WriteLine("# language: fr");
            file.WriteLine("# encoding: Windows-1252");
            file.WriteLine("@" + strRequirementId);
            file.WriteLine("Fonctionnalité: " + strFeature);
            file.WriteLine("");
        }

        private void writeContext(ref System.IO.StreamWriter file, ref string strContext)
        {
            if (strContext.Length != 0)
            {
                file.WriteLine("  Contexte:");
                string[] lines = strContext.Split('\n');
                foreach (var line in lines)
                {
                    if (line.StartsWith("Et") == true)
                    {
                        file.WriteLine("      " + line);
                    }
                    else
                    {
                        file.WriteLine("    " + line);
                    }
                }
                file.WriteLine("");
            }
        }

        private void writeScenarios(ref System.IO.StreamWriter file, ref List<Scenario> Scenarios)
        {
            foreach (var scenario in Scenarios)
            {
                file.WriteLine("  @clean");
                if (scenario.m_strSteps.Contains("Exemples:") == true)
                {
                    file.WriteLine("  Plan du scénario: " + scenario.m_strTitle);
                }
                else
                {
                    file.WriteLine("  Scénario: " + scenario.m_strTitle);
                }

                int iCounter = 0;
                string[] lines = scenario.m_strSteps.Replace("\r","").Split('\n');
                foreach (var line in lines)
                {
                    if (line.StartsWith("Et") == true)
                    {
                        file.WriteLine("      " + line);
                    }
                    else if (line.StartsWith("|") == true)
                    {
                        file.WriteLine("        " + line);
                    }
                    else if (line.StartsWith("Exemples:") == true)
                    {
                        file.WriteLine("  " + line);
                    }
                    else
                    {
                        file.WriteLine("    " + line);
                    }
                    iCounter++;
                    if (iCounter == lines.Length)
                    {
                        file.WriteLine("");
                    }
                }
            }
        }
    }
}
