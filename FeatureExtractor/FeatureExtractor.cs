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
            throw new NotImplementedException();
        }

        public void getRequirement(string requirementID)
        {
            throw new NotImplementedException();
        }

        public void setRequirements(Dictionary<string, string> requirements)
        {
            m_Requirements = requirements;
        }

        private Dictionary<string, string> m_Requirements;
    }
}
