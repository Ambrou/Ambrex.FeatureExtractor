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

                writeContext(ref file, ref pair.Value.m_strContext);
                writeScenarios(ref file, ref pair.Value.m_Scenarios);

                file.Close();
            }
        }

        private void writeContext(ref System.IO.StreamWriter file, ref string strContext)
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
        }

        private void writeScenarios(ref System.IO.StreamWriter file, ref List<Scenario> Scenarios)
        {
            foreach (var scenario in Scenarios)
            {
                file.WriteLine("");
                file.WriteLine("  @clean");
                file.WriteLine("  Scénario: " + scenario.m_strTitle);
                string[] lines = scenario.m_strSteps.Split('\n');
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
            }
        }
    }
}
