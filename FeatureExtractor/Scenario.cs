using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeatureExtractor
{
    public class Scenario
    {
        public Scenario(string strTitle, string strSteps)
        {
            m_strTitle = strTitle;
            m_strSteps = strSteps;
        }
        public string m_strTitle;
        public string m_strSteps;
    }
}
