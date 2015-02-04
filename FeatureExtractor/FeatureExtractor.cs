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
            //m_ExtractedRequirement = new Dictionary<string, List<Tuple<string, string>>>();
            //foreach(var requirement in m_RawRequirements)
            //{
            //    List<Tuple<string, string>> requirementScenario = new List<Tuple<string,string>>();
            //    m_ExtractedRequirement.Add(requirement.Key, requirementScenario);
            //}
        }


        public void setRequirements(Dictionary<string, string> requirements)
        {
            m_RawRequirements = requirements;
        }

        public Tuple<string, List<Tuple<string, string>>> getRequirement(string strRequirementID)
        {
            return m_ExtractedRequirement[strRequirementID];
        }

        private Dictionary<string, string> m_RawRequirements;
       // private Dictionary<string, List<Tuple<string, string>>> m_ExtractedRequirement;
        private Dictionary<string, List<Tuple<string, Tuple<string, string>>>
            List<Tuple<string, string>>> m_ExtractedRequirement;

    }
}
